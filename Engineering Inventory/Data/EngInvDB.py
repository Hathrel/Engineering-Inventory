import pyodbc as db
from datetime import datetime

global user_name
global user_site

class QuantityException(Exception):
    def __init__(self):
        self.message = "Not enough in location to complete this tranasaction"
        
class PartException(Exception):
    def __init__(self):
        self.message = "That part number does not exist in this location."
    
def database_login(username, password, site):
    with open_database_connection() as conn, conn.cursor() as cursor:
        if not conn:
            return (False, "Failed to connect to the database.", {})
        global user_name
        user_name = username
        global user_site
        user_site = site
        try:
            sql_command = """
            SELECT [Password], [Pick_Permit], [Insert_Permit], [Edit_Permit], [Purchase_Permit] 
            FROM [Login_Data] WHERE [Username]=?
            """
            cursor.execute(sql_command, [username])
            result = cursor.fetchone()
            print(result)

            if result:
                stored_password, pick_permit, insert_permit, edit_permit, purchase_permit = result
                if stored_password == password:
                    global_permissions = {
                        "Picking": pick_permit,
                        "Insert": insert_permit,
                        "Edit": edit_permit,
                        "Purchase": purchase_permit
                    }
                    return (True, "Login Successful!", global_permissions)
                else:
                    return (False, "Incorrect Password", {})
            else:
                return (False, "Username not found", {})

        except db.Error as e:
            print(f"Database error: {e}")
            return (False, "Sorry, there was an error with the database. Please try again.", {})

def open_database_connection():
    db_path = r"C:/Users/Derek/source/repos/Engineering-Inventory/Engineering_Inventory.accdb"
    connection_string = fr"DRIVER={{Microsoft Access Driver (*.mdb, *.accdb)}};DBQ={db_path};"
    try:
        connection = db.connect(connection_string)
        return connection
    except db.Error as e:
        print(f"Error connecting to database: {e}")
        return None

def query_table(cursor,table_name):
    with open_database_connection() as conn, conn.cursor() as cursor:
        try:
            cursor.execute(f"SELECT 1 from {table_name}")
            cursor.fetchall()
            return True
        except db.Error:
            return False

def insert_part(*args):
    part_number = args[0]
    qty = args[1]
    location = args[2]
    site = user_site
    
    with open_database_connection() as conn, conn.cursor() as cursor:
        if not query_table(cursor, f"{site}_Part_Location_Rel"):
            cursor.execute(f"CREATE TABLE {site}_Part_Location_Rel (Part_ID INT, Location_ID INT, Location_Qty INT)")
            conn.commit()

        cursor.execute("SELECT Part_ID FROM Part_List WHERE Part_Number = ?", (part_number.upper(),))
        part_id = cursor.fetchone()

        cursor.execute(f"SELECT Location_ID FROM Locations_{site} WHERE Location = ?", (location.upper(),))
        location_id = cursor.fetchone()

        if part_id and location_id:
            part_id = part_id[0]
            location_id = location_id[0]
            
            cursor.execute(f"SELECT Location_Qty FROM {site}_Part_Location_Rel WHERE Part_ID = ? AND Location_ID = ?", (part_id, location_id))
            rel = cursor.fetchone()
            if rel:
                new_location_qty = rel[0] + int(qty)
                cursor.execute(f"UPDATE {site}_Part_Location_Rel SET Location_Qty = ? WHERE Part_ID = ? AND Location_ID = ?", (new_location_qty, part_id, location_id))
            else:
                new_location_qty = int(qty)
                cursor.execute(f"INSERT INTO {site}_Part_Location_Rel (Part_ID, Location_ID, Location_Qty) VALUES (?, ?, ?)", (part_id, location_id, int(qty)))

            cursor.execute(f"SELECT {site}_On_Hand_Balance FROM Part_List WHERE Part_ID = ?", (part_id,))
            q_balance = cursor.fetchone()[0]
            if q_balance is None:
                current_balance = 0
            else:
                current_balance = q_balance

            new_balance = current_balance + int(qty)
            cursor.execute(f"UPDATE Part_List SET {site}_On_Hand_Balance = ? WHERE Part_ID = ?", (new_balance, part_id))
            conn.commit()
            log_transaction(part_id,location_id, location_id, int(qty), new_location_qty, new_balance, "Insert")
            return True
        else:
            return False, "Part or location does not exist"

def pick_part(*args):
    part_number = args[0]
    qty = args[1]
    location = args[2]
    site = user_site
    
    with open_database_connection() as conn, conn.cursor() as cursor:

        cursor.execute("SELECT Part_ID FROM Part_List WHERE Part_Number = ?", (part_number.upper(),))
        part_id = cursor.fetchone()

        cursor.execute(f"SELECT Location_ID FROM Locations_{site} WHERE Location = ?", (location.upper(),))
        location_id = cursor.fetchone()

        if part_id and location_id:
            part_id = part_id[0]
            location_id = location_id[0]
    
            cursor.execute(f"SELECT Location_Qty FROM {site}_Part_Location_Rel WHERE Part_ID = ? AND Location_ID = ?", (part_id, location_id))
            rel = cursor.fetchone()
            if rel:
                new_location_qty = rel[0] - int(qty)
                if new_location_qty < 0:
                    raise QuantityException("Not enough of this part in location.")
                elif new_location_qty > 0:
                    cursor.execute(f"UPDATE {site}_Part_Location_Rel SET Location_Qty = ? WHERE Part_ID = ? AND Location_ID = ?", (new_location_qty, part_id, location_id))
                else:
                    cursor.execute(f"DELETE FROM {site}_Part_Location_Rel WHERE Part_ID = ? AND Location_ID = ?", (part_id, location_id))
            else:
                raise PartException("That part doesn't exist in this location.")


            cursor.execute(f"SELECT {site}_On_Hand_Balance FROM Part_List WHERE Part_ID = ?", (part_id,))
            q_balance = cursor.fetchone()[0]
            if q_balance is None:
                current_balance = 0
            else:
                current_balance = q_balance

            new_balance = current_balance - int(qty)
            cursor.execute(f"UPDATE Part_List SET {site}_On_Hand_Balance = ? WHERE Part_ID = ?", (new_balance, part_id))
            conn.commit()
            log_transaction(part_id,location_id, location_id, int(qty), new_location_qty, new_balance, "Picking")
            return True
        else:
            return False, "Part or location does not exist"

def log_transaction(part_number, old_location, new_location, transaction_qty, new_qty, total_qty, module):
    with open_database_connection() as conn, conn.cursor() as cursor:
        date = datetime.now()
        username = user_name
        site = user_site
        primary_key = str(f"{date}{part_number}{old_location}")

        if not query_table(cursor, "Transaction_Logs"):
            cursor.execute("""
            CREATE TABLE Transaction_Logs (
                Part_ID INT, 
                Old_Location_ID INT, 
                New_Location_ID INT, 
                Transaction_Quantity INT, 
                New_Quantity INT, 
                Total_Quantity INT, 
                User_Name VARCHAR(255), 
                Site VARCHAR(255), 
                Module VARCHAR(255), 
                Transaction_Date DATE, 
                Tran_ID VARCHAR(255) PRIMARY KEY
                                                )
                                            """)

        if module == "Picking":
            transaction_qty *= -1

        total_qty_row = cursor.execute("SELECT CVG2_On_Hand_Balance FROM Part_List WHERE Part_ID = ?", (part_number,)).fetchone()
        if total_qty_row:
            total_qty = total_qty_row[0]
        else:
            total_qty = None

        cursor.execute("INSERT INTO Transaction_Logs (Part_ID, Old_Location_ID, New_Location_ID, Transaction_Quantity, New_Quantity, Total_Quantity, User_Name, Site, Module, Transaction_Date, Tran_ID) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", (part_number, old_location, new_location, transaction_qty, new_qty, total_qty, username, site, module, date, primary_key))
        conn.commit()