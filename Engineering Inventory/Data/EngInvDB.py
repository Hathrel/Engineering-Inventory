import pyodbc as db

user_name = None
permissions = {"Picking": False, "Insert": False, "Edit": False, "Purchase": False}

import pyodbc as db

def database_login(username, password):
    username = username
    password = password
    print(username, password)
    connection = open_database_connection()
    if not connection:
        return False, "Failed to connect to the database.", None

    try:
        cursor = connection.cursor()
        sql_command = """
        SELECT [Password], [Pick_Permit], [Insert_Permit], [Edit_Permit], [Purchase_Permit] 
        FROM [Login_Data] WHERE [Username]=?
        """
        cursor.execute(sql_command, [username])
        result = cursor.fetchone()

        if result:
            stored_password, *user_permissions = result
            if stored_password == password:
                permissions = {
                    "Picking": user_permissions[0] == "Yes",
                    "Insert": user_permissions[1] == "Yes",
                    "Edit": user_permissions[2] == "Yes",
                    "Purchase": user_permissions[3] == "Yes"
                }
                return True, "Login Successful!", permissions
            else:
                return False, "Incorrect Password", None
        else:
            return False, "Username not found", None

    except db.Error as e:
        print(f"Database error: {e}")
        return False, f"Sorry, there was an error with the database. Please try again.", None

    finally:
        close_database_connection(connection, cursor)

def open_database_connection():
    db_path = r"C:\\Users\\Derek\\source\\repos\\Engineering-Inventory\\Engineering_Inventory.accdb"
    #db_path = r"C:\Users\dboyer\Documents\Engineering Inventory\Engineering_Inventory.accdb"
    connection_string = fr"DRIVER={{Microsoft Access Driver (*.mdb, *.accdb)}};DBQ={db_path};"
    try:
        connection = db.connect(connection_string)
        return connection
    except db.Error as e:
        print(f"Error connecting to database: {e}")
        return None

def close_database_connection(connection, cursor=None):
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

def insert_part(part_number, location, qty, validated):
    if validated != True:
        return False
    if permissions['Insert'] == False:
        return "You don't have permission to do that!"
    connection = open_database_connection()
    cursor = connection.cursor()
    if query_table(cursor, "Part_Loc_Rel") == False:
        cursor.execute(f"CREATE TABLE Part_Loc_Rel (Part_Number, {location})")