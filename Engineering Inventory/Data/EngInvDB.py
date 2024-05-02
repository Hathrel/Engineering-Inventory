import pyodbc as db
from datetime import datetime

#TODO: All inventory actions. When picking is established, make sure you delete relationship references with the location is zeroed out for that part.

user_name = None
user_site = None #TODO: Add a dropdown in the login screen to select site, this will allow this app to scale

class QuantityException(Exception):
    def __init__(self):
        self.message = "Not enough in location to complete this tranasaction"
        
class PartException(Exception):
    def __init__(self):
        self.message = "That part number does not exist in this location."
    
def database_login(username, password):
    global user_name
    connection = open_database_connection()
    if not connection:
        return False, "Failed to connect to the database."

    try:
        cursor = connection.cursor()
        sql_command = """
        SELECT [Password], [Pick_Permit], [Insert_Permit], [Edit_Permit], [Purchase_Permit] 
        FROM [Login_Data] WHERE [Username]=?
        """
        cursor.execute(sql_command, [username])
        result = cursor.fetchone()
        print(result)

        if result:
            stored_password, *user_permissions = result
            print(user_permissions)
            user_name = username
            if stored_password == password:
                global_permissions = {
                    "Picking": user_permissions[0],
                    "Insert": user_permissions[1],
                    "Edit": user_permissions[2],
                    "Purchase": user_permissions[3]
                }
                return True, "Login Successful!", global_permissions
            else:
                return False, "Incorrect Password", None
        else:
            return False, "Username not found", None

    except db.Error as e:
        print(f"Database error: {e}")
        return False, "Sorry, there was an error with the database. Please try again.", None

    finally:
        close_database_connection(connection, cursor)

def open_database_connection():
    #db_path = r"C:\\Users\\Derek\\source\\repos\\Engineering-Inventory\\Engineering_Inventory.accdb"
    db_path = r"C:\Users\dboyer\source\repos\Engineering Inventory\Engineering_Inventory.accdb"
    connection_string = fr"DRIVER={{Microsoft Access Driver (*.mdb, *.accdb)}};DBQ={db_path};"
    try:
        connection = db.connect(connection_string)
        return connection
    except db.Error as e:
        print(f"Error connecting to database: {e}")
        return None

def close_database_connection(connection, cursor):
    if cursor:
        cursor.close()
    if connection:
        connection.close()

def query_table(cursor,table_name):
    try:
        cursor.execute(f"SELECT 1 from {table_name}")
        cursor.fetchall()
        return True
    except db.Error:
        return False

import pyodbc as db
from datetime import datetime

#TODO: All inventory actions. When picking is established, make sure you delete relationship references with the location is zeroed out for that part.

user_name = ""
user_site = None #TODO: Add a dropdown in the login screen to select site, this will allow this app to scale

class QuantityException(Exception):
    def __init__(self):
        self.message = "Not enough in location to complete this tranasaction"
        
class PartException(Exception):
    def __init__(self):
        self.message = "That part number does not exist in this location."
    
def database_login(username, password):
    global user_name
    connection = open_database_connection()
    if not connection:
        return False, "Failed to connect to the database."

    try:
        cursor = connection.cursor()
        sql_command = """
        SELECT [Password], [Pick_Permit], [Insert_Permit], [Edit_Permit], [Purchase_Permit] 
        FROM [Login_Data] WHERE [Username]=?
        """
        cursor.execute(sql_command, [username])
        result = cursor.fetchone()
        print(result)

        if result:
            stored_password, *user_permissions = result
            print(user_permissions)
            user_name = username
            if stored_password == password:
                global_permissions = {
                    "Picking": user_permissions[0],
                    "Insert": user_permissions[1],
                    "Edit": user_permissions[2],
                    "Purchase": user_permissions[3]
                }
                return True, "Login Successful!", global_permissions
            else:
                return False, "Incorrect Password", None
        else:
            return False, "Username not found", None

    except db.Error as e:
        print(f"Database error: {e}")
        return False, "Sorry, there was an error with the database. Please try again.", None

    finally:
        close_database_connection(connection, cursor)

def open_database_connection():
    #db_path = r"C:\\Users\\Derek\\source\\repos\\Engineering-Inventory\\Engineering_Inventory.accdb"
    db_path = r"C:\Users\dboyer\source\repos\Engineering Inventory\Engineering_Inventory.accdb"
    connection_string = fr"DRIVER={{Microsoft Access Driver (*.mdb, *.accdb)}};DBQ={db_path};"
    try:
        connection = db.connect(connection_string)
        return connection
    except db.Error as e:
        print(f"Error connecting to database: {e}")
        return None

def close_database_connection(connection, cursor):
    if cursor:
        cursor.close()
    if connection:
        connection.close()

def query_table(cursor,table_name):
    try:
        cursor.execute(f"SELECT 1 from {table_name}")
        cursor.fetchall()
        return True
    except db.Error:
        return False

def insert_part(*args):
    part_number = args[0]
    qty = int(args[1])
    location = args[2]
    new_qty = None
    
    # Open a database connection
    connection = open_database_connection()
    cursor = connection.cursor()
    
    try:
        # Check if the table exists
        if not query_table(cursor, "Part_Location_Rel"):
            # If it doesn't exist, create the table
            cursor.execute("CREATE TABLE Part_Location_Rel (Part_ID INT, Location_ID INT, Location_Qty INT)")

        # Check if the part and location exist
        part_exists = cursor.execute("SELECT Part_ID FROM Part_List WHERE Part_Number = ?", (part_number,)).fetchone()
        location_exists = cursor.execute("SELECT Location_ID FROM Locations_CVG2 WHERE Location = ?", (location,)).fetchone()
        if part_exists and location_exists:
            part_id = part_exists[0]
            location_id = location_exists[0]
            
            # Fetch current On_Hand_Balance from Part_List
            current_balance = cursor.execute("SELECT On_Hand_Balance FROM Part_List WHERE Part_ID = ?", (part_id,)).fetchone()[0]
            if current_balance is None:
                current_balance = 0
            
            # Calculate new On_Hand_Balance
            new_balance = current_balance + qty
            
            # Update the On_Hand_Balance in Part_List
            cursor.execute("UPDATE Part_List SET On_Hand_Balance = ? WHERE Part_ID = ?", (new_balance, part_id))
            
            # Update the Part_Location_Rel
            if existing_relationship := cursor.execute("SELECT * FROM Part_Location_Rel WHERE Part_ID = ? AND Location_ID = ?", (part_id, location_id)).fetchone():
                # If the relationship already exists, update the quantity
                present_qty = existing_relationship[2]  # Third column is Location_Qty
                new_qty = present_qty + qty
                cursor.execute("UPDATE Part_Location_Rel SET Location_Qty = ? WHERE Part_ID = ? AND Location_ID = ?", (new_qty, part_id, location_id))
            else:
                # Otherwise, insert the new relationship
                cursor.execute("INSERT INTO Part_Location_Rel (Part_ID, Location_ID, Location_Qty) VALUES (?, ?, ?)", (part_id, location_id, qty))
                new_qty = qty
            
            # Log the transaction
            log_transaction(connection, part_id, location_id, location_id, qty, new_qty, "Insert")

            connection.commit()
            
            return True
        else:
            return False, "Part or location does not exist"
    except Exception as e:
        # Roll back the transaction on error
        connection.rollback()
        return False, f"Error inserting/updating part-location relationship: {e}"
    finally:
        # Close the cursor and connection
        close_database_connection(connection, cursor)


def pick_part(*args):
    part_number = args[0]
    qty = args[1]
    location = args[2]
            
    # Open a database connection
    connection = open_database_connection()
    cursor = connection.cursor()
    
    try:
        # Check if the part and location exist
        part_exists = cursor.execute("SELECT Part_ID FROM Part_List WHERE Part_Number = ?", (part_number,)).fetchone()
        location_exists = cursor.execute("SELECT Location_ID FROM Locations_CVG2 WHERE Location = ?", (location,)).fetchone()
        if not (part_exists and location_exists):
            raise PartException("Part or location does not exist.")

        part_id = part_exists[0]
        location_id = location_exists[0]

        # Check if the relationship already exists
        existing_relationship = cursor.execute("SELECT * FROM Part_Location_Rel WHERE Part_ID = ? AND Location_ID = ?", (part_id, location_id)).fetchone()
        if existing_relationship:
            # If the relationship already exists, update the quantity
            present_qty = existing_relationship[2]  # Third column is Location_Qty
            new_qty = present_qty - qty
            if new_qty < 0:
                raise QuantityException("Not enough quantity in location to complete this transaction.")
            else:
                cursor.execute("UPDATE Part_Location_Rel SET Location_Qty = ? WHERE Part_ID = ? AND Location_ID = ?", (new_qty, part_id, location_id))

                # Update the On_Hand_Balance in Part_List
                current_balance = cursor.execute("SELECT On_Hand_Balance FROM Part_List WHERE Part_ID = ?", (part_id,)).fetchone()
                current_balance = current_balance[0] if current_balance is not None else 0
                new_balance = current_balance - qty
                cursor.execute("UPDATE Part_List SET On_Hand_Balance = ? WHERE Part_ID = ?", (new_balance, part_id))

                log_transaction(connection, part_id, location_id, location_id, qty, new_qty, "Picking")
            
                connection.commit()
        else:
            raise PartException("Part-location relationship does not exist.")

        return True
    
    except PartException as e:
        return False, str(e)
    
    except QuantityException as e:
        return False, str(e)
    
    except Exception as e:
        # Handle other exceptions
        connection.rollback()
        return False, f"Error inserting/updating part-location relationship: {e}"
    
    finally:
        # Close the cursor and connection
        close_database_connection(connection, cursor)

def log_transaction(connection, part_number, old_location, new_location, transaction_qty, new_qty, module):
    cursor = connection.cursor()
    date = datetime.now()
    username = user_name
    site = user_site

    if not query_table(cursor, "Transaction_Logs"):
        cursor.execute("CREATE TABLE Transaction_Logs (Part_ID INT, Old_Location_ID INT, New_Location_ID INT, Transaction_Quantity INT, New_Quantity INT, Total_Quantity INT, User_Name VARCHAR(255), Site VARCHAR(255), Module VARCHAR(255), Transaction_Date DATE, PRIMARY KEY (Part_ID, Transaction_Date))")

    if module == "Picking":
        transaction_qty *= -1

    total_qty_row = cursor.execute("SELECT On_Hand_Balance FROM Part_List WHERE Part_ID = ?", (part_number,)).fetchone()
    if total_qty_row:
        total_qty = total_qty_row[0]
    else:
        total_qty = None

    cursor.execute("INSERT INTO Transaction_Logs (Part_ID, Old_Location_ID, New_Location_ID, Transaction_Quantity, New_Quantity, Total_Quantity, User_Name, Site, Module, Transaction_Date) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", (part_number, old_location, new_location, transaction_qty, new_qty, total_qty, username, site, module, date))
    connection.commit()