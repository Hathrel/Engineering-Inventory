import pyodbc as db
from datetime import datetime
import json
import openpyxl as xl

global user_name
global user_site
global config_path
                           
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
        user_site = site.upper()

        try:
            sql_command = f"""
            SELECT [Password], [Add_Part_Permit], [Add_Loc_Permit], [Edit_Permit], [Admin], [{site}]
            FROM [Login_Data] WHERE [Username]=?
            """
            cursor.execute(sql_command, [username])
            result = cursor.fetchone()
            print(result)

            if result:
                stored_password, add_part_permit, add_loc_permit, edit_permit, admin, site = result
                if stored_password == password:
                    global_permissions = {
                        "Addpart": add_part_permit,
                        "Addloc": add_loc_permit,
                        "Edit": edit_permit,
                        "Admin": admin,
                        "Site": site
                    }
                    if global_permissions["Site"] == True:
                        return (True, "Login Successful!", global_permissions)     
                    elif global_permissions["Site"] == False:
                        return (False, "You do not have permission to access this site.", {})
                    else:
                        return (False, "There was an issue with your site selection.", {})
                else:
                    return (False, "Incorrect Password", {})
            else:
                return (False, "Username not found", {})

        except db.Error as e:
            print(f"Database error: {e}")
            return (False, "Sorry, there was an error with the database. Please try again.", {})

def open_database_connection():
    try:
        with open(config_path, 'r') as file:
            config = json.load(file)
        
        db_path = config['database_path']
        
        connection_string = f"DRIVER={{Microsoft Access Driver (*.mdb, *.accdb)}};DBQ={db_path};"
        
        connection = db.connect(connection_string)
        return connection
    except Exception as e:
        print(f"Error connecting to database or reading the config file: {e}")
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
            cursor.execute(f"""
            CREATE TABLE {site}_Part_Location_Rel (
                Part_ID LONG, 
                Location_ID LONG, 
                Location_Qty INT, 
                FOREIGN KEY (Part_ID) REFERENCES Part_List(Part_ID),
                FOREIGN KEY (Location_ID) REFERENCES Locations_{site}(Location_ID)
                )
                """)

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

def move_inventory(*args):
    part_number = args[0]
    qty = args[1]
    old_loc = args[2]
    new_loc = args[3]
    site = user_site
    with open_database_connection() as conn, conn.cursor() as cursor:
    
        cursor.execute("SELECT Part_ID FROM Part_List WHERE Part_Number = ?", (part_number.upper(),))
        orig_part_id = cursor.fetchone()

        cursor.execute(f"SELECT Location_ID FROM Locations_{site} WHERE Location = ?", (old_loc.upper(),))
        old_loc_id = cursor.fetchone()
        
        if orig_part_id and old_loc_id:
            part_id = orig_part_id[0]
            old_loc_id = old_loc_id[0]
            
            cursor.execute(f"SELECT Location_Qty FROM {site}_Part_Location_Rel WHERE Part_ID = ? AND Location_ID = ?", (part_id, old_loc_id))
            rel = cursor.fetchone()
            if rel:
                old_location_qty = rel[0] - int(qty)
                if old_location_qty < 0:
                    raise QuantityException("Not enough of this part in location.")
                elif old_location_qty > 0:
                    cursor.execute(f"UPDATE {site}_Part_Location_Rel SET Location_Qty = ? WHERE Part_ID = ? AND Location_ID = ?", (old_location_qty, part_id, old_loc_id))
                else:
                    cursor.execute(f"DELETE FROM {site}_Part_Location_Rel WHERE Part_ID = ? AND Location_ID = ?", (part_id, old_loc_id))
            else:
                raise PartException("That part doesn't exist in this location.")
            
            cursor.execute(f"SELECT Location_ID FROM Locations_{site} WHERE Location = ?", (new_loc.upper(),))
            new_loc_id = cursor.fetchone()
            
            if orig_part_id and new_loc_id:
                new_loc_id = new_loc_id[0]
                cursor.execute(f"SELECT Location_Qty FROM {site}_Part_Location_Rel WHERE Part_ID = ? AND Location_ID = ?", (part_id, new_loc_id))
                rel = cursor.fetchone()
                if rel:
                    new_location_qty = rel[0] + int(qty)
                    cursor.execute(f"UPDATE {site}_Part_Location_Rel SET Location_Qty = ? WHERE Part_ID = ? AND Location_ID = ?", (new_location_qty, part_id, new_loc_id))
                else:
                    new_location_qty = int(qty)
                    cursor.execute(f"INSERT INTO {site}_Part_Location_Rel (Part_ID, Location_ID, Location_Qty) VALUES (?, ?, ?)", (part_id, new_loc_id, int(qty)))
                    
                cursor.execute(f"SELECT {site}_On_Hand_Balance FROM Part_List WHERE Part_ID = ?", (part_id,))
                q_balance = cursor.fetchone()[0]
                if q_balance is None:
                    current_balance = 0
                else:
                    current_balance = q_balance
                conn.commit()
                log_transaction(part_id,old_loc_id, new_loc_id, int(qty), new_location_qty, current_balance, "Move Inventory")
                return True
            else:
                return False, "Part or Location doesn't exist."

def display_cycle_count(location):
    data_packet = []
    with open_database_connection() as conn, conn.cursor() as cursor:
        cursor.execute(f"""
                        SELECT Part_List.Part_Number, {user_site}_Part_Location_Rel.Location_Qty, Part_List.Part_Description
                        FROM (Part_List 
                        INNER JOIN {user_site}_Part_Location_Rel ON Part_List.Part_ID = {user_site}_Part_Location_Rel.Part_ID) 
                        INNER JOIN Locations_{user_site} ON {user_site}_Part_Location_Rel.Location_ID = Locations_{user_site}.Location_ID
                        WHERE Locations_{user_site}.Location = ?;
                       """, (location.upper(),))    
        for row in cursor.fetchall():
            part_number, quantity, description = row
            data_packet.append({
                'Part Number': part_number,
                'Quantity': quantity,
                'Description': description
            })
    return data_packet

def submit_cycle_count(location, part, qty):
    date = datetime.now()
    user = user_name
    site = user_site

    with open_database_connection() as conn, conn.cursor() as cursor:
        try:
            cursor.execute("SELECT Part_ID FROM Part_List WHERE Part_Number = ?", (part.upper(),))
            part_id = cursor.fetchone()
            if not part_id:
                raise IndexError("Part number not found")
            part_id = part_id[0]

            cursor.execute(f"SELECT Location_ID FROM Locations_{site} WHERE Location = ?", (location.upper(),))
            location_id = cursor.fetchone()
            if not location_id:
                raise IndexError("Location not found")
            location_id = location_id[0]
            
            cursor.execute(f"SELECT Location_Qty FROM {site}_Part_Location_Rel WHERE Part_ID = ? AND Location_ID = ?", (part_id, location_id))
            location_balance = cursor.fetchone()
            if not location_balance:
                loc_balance = 0
            else:
                loc_balance = location_balance[0]

            cursor.execute("INSERT INTO Cycle_Counts (Part_ID, Location_ID, Qty, Count_Date, Username, Site, Location_Balance) VALUES (?, ?, ?, ?, ?, ?, ?)",
                            (part_id, location_id, int(qty), date, user, site, loc_balance))
            conn.commit()
            return True, "Cycle Count successfully submitted."
        except IndexError as e:
            return False, str(e)
        except Exception as e:
            return False, f"An error occurred: {str(e)}"
        
def add_new_part(part_number, part_description, minn=None, maxx=None, lead_time=None, supplier=None, price=None, comment=None, purchase_link=None):
    try:
        with open_database_connection() as conn, conn.cursor() as cursor:
                eng_sql = "SELECT MAX(Part_Number) FROM Part_List WHERE Part_Number LIKE 'ENG%'"
                cursor.execute(eng_sql)
                last_number = cursor.fetchone()[0]
                last_digit = int(last_number[3:]) + 1
                new_location_suggestion = "ENG"+str(last_digit).zfill(6)

                check_sql = "SELECT COUNT(*) FROM Part_List WHERE Part_Number = ?"
                cursor.execute(check_sql, (part_number,))
                if cursor.fetchone()[0] > 0:
                    return False, f"Error: Part number already exists. Try {new_location_suggestion}"

                insert_sql = """
                    INSERT INTO Part_List
                        (Part_Number, Part_Description, MIN, MAX, Lead_Time, Supplier, Price, Comment, Purchase_Link)
                    VALUES
                        (?, ?, ?, ?, ?, ?, ?, ?, ?)
                """
                params = (
                    part_number,
                    part_description,
                    None if minn is None else int(minn),
                    None if maxx is None else int(maxx),
                    None if lead_time is None else int(lead_time),
                    supplier,
                    None if price is None else float(price),
                    comment,
                    purchase_link
                )
                cursor.execute(insert_sql, params)
                conn.commit()
                return (True, "Part Added Successfully. ")
    except Exception as e:
        return (False, str(e))

def delete_part_query(part_number):
    try:
        with open_database_connection() as conn:
            cursor = conn.cursor()
            part_desc = cursor.execute("SELECT Part_Description FROM Part_List WHERE Part_Number = ?", (part_number,)).fetchone()
            if part_desc:
                return f"{part_desc[0]}"
            else:
                return "Part number not found."
    except Exception as e:
        return f"There was an error retrieving Part_Description: {e}"

def delete_part(part_number):
    try:
        with open_database_connection() as conn:
            cursor = conn.cursor()
            cursor.execute("DELETE FROM Part_List WHERE Part_Number = ?", (part_number,))
            conn.commit()
            return True
    except Exception as e:
        print(f"Error deleting part: {e}")
        return False

def get_part_info(part_number):
    try:
        with open_database_connection() as conn, conn.cursor() as cursor:
            query = """
                SELECT Part_Description, MIN, MAX, Lead_Time, Supplier, Price, Comment, Purchase_Link
                FROM Part_List 
                WHERE Part_Number = ?
            """
            cursor.execute(query, (part_number,))
            row = cursor.fetchone()
            if row:
                column_names = [desc[0] for desc in cursor.description]
                part_info_dict = {column_names[i]: str(row[i]) for i in range(len(column_names))}
                return part_info_dict
            else:
                return None
    except Exception as e:
        print(f"Error retrieving part information: {e}")
        return None
    
def set_part_info(part_number, part_description, minn=None, maxx=None, lead_time=None, supplier=None, price=None, comment=None, purchase_link=None):
    try:
        with open_database_connection() as conn, conn.cursor() as cursor:
                check_sql = "SELECT COUNT(*) FROM Part_List WHERE Part_Number = ?"
                cursor.execute(check_sql, (part_number,))
                if cursor.fetchone()[0] == 0:
                    return False, "Error: Part number does not exist."
                update_sql = """
                    UPDATE Part_List SET
                        Part_Description = ?,
                        MIN = ?,
                        MAX = ?,
                        Lead_Time = ?,
                        Supplier = ?,
                        Price = ?,
                        Comment = ?,
                        Purchase_Link = ?
                    WHERE Part_Number = ?
                """
                params = (
                    part_description,
                    None if minn is None else int(minn),
                    None if maxx is None else int(maxx),
                    None if lead_time is None else int(lead_time),
                    supplier,
                    None if price is None else float(price),
                    comment,
                    purchase_link,
                    part_number
                )
                cursor.execute(update_sql, params)
                conn.commit()
                return (True, "Part updated successfully.")
    except Exception as e:
        return (False, str(e))

def edit_loc(location, module):
    try:
        with open_database_connection() as conn, conn.cursor() as cursor:
            table_name = f"Locations_{user_site}"

            if not query_table(cursor, table_name):
                cursor.execute(f"""
                CREATE TABLE {table_name} (
                    Location VARCHAR(255) 
                    )
                    """)
            conn.commit()

            if module == "Add":
                # Check if the location already exists
                cursor.execute(f"SELECT Location_ID FROM {table_name} WHERE Location = ?", (location,))
                if cursor.fetchone() is None:  # If no results, the location does not exist
                    cursor.execute(f"INSERT INTO {table_name} (Location) VALUES(?)", (location,))
                    conn.commit()
                    return "Location added successfully."
                else:
                    return "Location already exists."

            elif module == "Delete":
                # Check if the location exists before attempting to delete
                cursor.execute(f"SELECT Location_ID FROM {table_name} WHERE Location = ?", (location,))
                if cursor.fetchone() is not None:  # If results, the location exists
                    cursor.execute(f"DELETE FROM {table_name} WHERE Location = ?", (location,))
                    conn.commit()
                    return "Location deleted successfully."
                else:
                    return "Location does not exist."

    except Exception as e:
        return f"An error occurred: {e}"

    except Exception as e:
        return f"An error occurred: {e}"
    
def add_user(username, password, permissions):
    try:
        add_part = permissions["Edit Parts"];
        add_loc = permissions["Edit Locations"];
        edit = permissions["Edit Inventory"];
        admin = permissions["Admin"];
        cvg2permit = permissions["CVG2"];
        lex1permit = permissions["LEX1"];
        swedespermit = permissions["SWEDESBORO_117"];
        westchesterpermit = permissions["WESTCHESTER_1305"];
        yyzpermit = permissions["YYZ"];

        with open_database_connection() as conn, conn.cursor() as cursor:
                check_sql = "SELECT COUNT(*) FROM Login_Data WHERE Username = ?"
                cursor.execute(check_sql, (username,))
                if cursor.fetchone()[0] > 0:
                    return "User already exists in database"

                insert_user = """
                INSERT INTO Login_Data (Username, Password, Add_Part_Permit, Add_Loc_Permit, Edit_Permit, Admin, CVG2, SWEDESBORO_117, LEX1, WESTCHESTER_1305, YYZ)
                VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
                """
                params = (
                    username,
                    password,
                    add_part,
                    add_loc,
                    edit,
                    admin,
                    cvg2permit,
                    swedespermit,
                    lex1permit,
                    westchesterpermit,
                    yyzpermit
                )
                cursor.execute(insert_user, params)
                conn.commit()
                return "User added successfully."
    except Exception as e:
        return f"An error occurred: {str(e)}"
    
def delete_user(username):
        try:
            with open_database_connection() as conn:
                cursor = conn.cursor()
                cursor.execute("DELETE FROM Login_Data WHERE Username = ?", (username,))
                conn.commit()
                return "User deleted successfully."
        except Exception as e:
            return f"Error deleting user: {e}"

def get_user_info(username):
    try:
        with open_database_connection() as conn, conn.cursor() as cursor:
            query = """
                SELECT 
                    Add_Part_Permit, 
                    Add_Loc_Permit, 
                    Edit_Permit, 
                    Admin, 
                    CVG2, 
                    SWEDESBORO_117,
                    LEX1, 
                    WESTCHESTER_1305,
                    YYZ
                FROM Login_Data 
                WHERE Username = ?
            """
            cursor.execute(query, (username,))
            row = cursor.fetchone()
            if row:
                column_names = [desc[0] for desc in cursor.description]
                return {column_names[i]: row[i] for i in range(len(column_names))}
            else:
                return {}
    except Exception as e:
        print(f"Error retrieving user information: {e}")
        return {}

def set_user_info(username, userinfo):
    try:
        password = userinfo["Password"]
        add_part = userinfo["Edit Parts"];
        add_loc = userinfo["Edit Locations"];
        edit = userinfo["Edit Inventory"];
        admin = userinfo["Admin"];
        cvg2permit = userinfo["CVG2"];
        lex1permit = userinfo["LEX1"];
        swedespermit = userinfo["SWEDESBORO_117"];
        westchesterpermit = userinfo["WESTCHESTER_1305"];
        yyzpermit = userinfo["YYZ"];
        with open_database_connection() as conn, conn.cursor() as cursor:
                check_sql = "SELECT COUNT(*) FROM Login_Data WHERE Username = ?"
                cursor.execute(check_sql, (username,))
                if cursor.fetchone()[0] == 0:
                    return False, "Error: User does not exist."
                update_sql = """
                    UPDATE Login_Data SET
                        Password = ?,
                        Add_Part_Permit = ?,
                        Edit_Permit = ?,
                        Add_Loc_Permit = ?,
                        Admin = ?,
                        CVG2 = ?,
                        SWEDESBORO_117 = ?,
                        LEX1 = ?,
                        WESTCHESTER_1305 = ?,
                        YYZ = ?
                    WHERE Username = ?
                """
                params = (
                    password,
                    False if add_part is None else add_part,
                    False if add_loc is None else add_loc,
                    False if edit is None else edit,
                    False if admin is None else admin,
                    False if cvg2permit is None else cvg2permit,
                    False if lex1permit is None else lex1permit,
                    False if swedespermit is None else swedespermit,
                    False if westchesterpermit is None else westchesterpermit,
                    False if yyzpermit is None else yyzpermit,
                    username
                )
                cursor.execute(update_sql, params)
                conn.commit()
                return ("User info updated successfully.")
    except Exception as e:
        return (str(e))
       
def log_transaction(part_number, old_location, new_location, transaction_qty, new_qty, total_qty, module):
    with open_database_connection() as conn, conn.cursor() as cursor:
        date = datetime.now()
        username = user_name
        site = user_site.upper()
        primary_key = str(f"{date}{part_number}{old_location}")

        if not query_table(cursor, "Transaction_Logs"):
            cursor.execute(f"""CREATE TABLE Transaction_Logs ( Part_ID INT,  
            Old_Location_ID LONG, 
            New_Location_ID LONG,
            Transaction_Quantity INT, 
            New_Quantity INT,Total_Quantity INT, 
            User_Name VARCHAR(255), 
            Site VARCHAR(255), 
            Module VARCHAR(255), 
            Transaction_Date DATE, 
            Tran_ID VARCHAR(255) PRIMARY KEY,
            FOREIGN KEY (Part_ID) REFERENCES Part_List(Part_ID),
            FOREIGN KEY (Old_Location_ID) REFERENCES Locations_{site}(Location_ID),
            FOREIGN KEY (New_Location_ID) REFERENCES Locations_{site}(Location_ID)
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

print(get_user_info("dboyer"))