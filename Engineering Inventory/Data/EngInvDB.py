import pyodbc as db

user_name = None

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

        if result:
            stored_password, *user_permissions = result
            user_name = username
            if stored_password == password:
                global_permissions = {
                    "Picking": user_permissions[0],
                    "Insert": user_permissions[1],
                    "Edit": user_permissions[2],
                    "Purchase": user_permissions[3]
                }
                for permission in global_permissions.keys():
                    if permission == "Yes":
                        global_permissions[permission] = True
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
    db_path = r"C:\Users\dboyer\Documents\Engineering Inventory\Engineering_Inventory.accdb"
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

def insert_part(part_number, location, qty, permissions):
    int_qty = int(qty)
    # Check if the user has permission to insert
    if not permissions:
        return "You don't have permission to do that!"

    # Open a database connection
    connection = open_database_connection()
    cursor = connection.cursor()

    try:
        # Check if the table exists
        if not query_table(cursor, "Part_Loc_Rel"):
            # If it doesn't exist, create the table
            cursor.execute(f"CREATE TABLE Part_Loc_Rel (Part_Number VARCHAR(255), {location} INT)")

        # Insert the part number and quantity into the table
        cursor.execute(f"INSERT INTO Part_Loc_Rel (Part_Number, {location}) VALUES (?, ?)", (part_number, int_qty))
        connection.commit()
        return True
    except Exception as e:
        # Handle exceptions
        connection.rollback()
        return False, f"Error inserting part: {e}"
    finally:
        # Close the cursor and connection
        close_database_connection()