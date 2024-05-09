using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Xml.Linq;
using Python.Runtime;

namespace Engineering_Inventory
{
    public class PythonInterop
    {
        private dynamic pythonModule;

        public void InitializePythonEngine()
        {
            // Correctly set the path to the Python DLL
            //Runtime.PythonDLL = @"C:\Users\dboyer\AppData\Local\Programs\Python\Python312\python312.dll";
            Runtime.PythonDLL = @"C:\Users\Derek\AppData\Local\Programs\Python\Python312\python312.dll";

            // Initialize Python engine
            PythonEngine.Initialize();

            // Acquire the Python Global Interpreter Lock
            using (Py.GIL())
            {
                // Import the Python module
                pythonModule = Py.Import("Data.EngInvDB");
            }
        }

        public void ShutdownPythonEngine()
        {
            // Shutdown Python engine
            PythonEngine.Shutdown();
        }

        public (bool, string, dynamic, string) DatabaseLogin(string username, string password, string site)
        {
            try
            {
                dynamic result = pythonModule.database_login(username, password, site);

                bool success = result[0];
                string message = result[1];
                dynamic permissions = result[2];
                Program.user_site = site;

                return (success, message, permissions, username);
            }
            catch (PythonException ex)
            {

                string errorString = $"Python error occurred: {ex.Message}\n Stack Trace: {ex.Traceback}";

                return (false, errorString, null, null);
            }
        }

        public bool EditInventory(string part, string qty, string location, string module, string location2 = null)
        {
            dynamic pythonFunc = null;
            switch (module)
            {
                case "Insert":
                    pythonFunc = pythonModule.insert_part;
                    break;
                case "Picking":
                    pythonFunc = pythonModule.pick_part;
                    break;
                case "Bin_Move":
                    pythonFunc = pythonModule.move_inventory;
                    break;
            }
            try
            {
                dynamic result = pythonFunc(part, qty, location, location2);

                if (result.ToString() == "True")
                {
                    // Case 1: Python function returns a boolean directly
                    
                    return true;
                }
                else if (result is PyObject tuple && tuple.HasAttr("Item1") && tuple.HasAttr("Item2"))
                {
                    // Case 2: Python function returns a tuple containing (bool, string)
                    bool successBool = tuple.GetAttr("Item1").As<bool>();
                    string message = tuple.GetAttr("Item2").As<string>();
                    MessageBox.Show(message); // Show the message in the message box
                    return successBool;
                }
                else
                {
                    // Unexpected return type
                    MessageBox.Show("Unexpected return type from Python function");
                    MessageBox.Show(result.ToString()); // Show the result in the message box
                    return false;
                }
            }
            catch (PythonException ex)
            {
                string errorString = $"Python error occurred: {ex.Message}\n Stack Trace: {ex.Traceback}";
                MessageBox.Show(errorString);
                return false;
            }
        }

        public List<(string, int, string)> CycleCountPull(string location)
        {
            try
            {
                dynamic result = pythonModule.display_cycle_count(location);
                List<(string, int, string)> dataPacket = new List<(string, int, string)>();

                foreach (dynamic partData in result)
                {
                    string partNumber = partData["Part Number"];
                    int qty = partData["Quantity"];
                    string desc = partData["Description"];
                    dataPacket.Add((partNumber, qty, desc));
                }
                return dataPacket;
            }
            catch (PythonException ex)
            {
                MessageBox.Show($"Python error occurred: {ex.Message}\n Stack Trace: {ex.Traceback}");
                return new List<(string, int, string)>();
            }
        }

        public void CycleCountSubmit(string location, string part, string qty)
        {
            pythonModule.submit_cycle_count(location, part, qty);
        }

        public (bool success, string message) AddPartNumber(string part_number, string part_description, int? minn = null, int? maxx = null, int? lead_time = null, string supplier = null, float? price = null, string comment = null, string purchase_link = null)
        {
            try
            {
                dynamic result = pythonModule.add_new_part(part_number, part_description, minn, maxx, lead_time, supplier, price, comment, purchase_link);
                // Assume result is a PyObject that should be a tuple
                if (result is PyObject tuple)
                {
                    // Explicitly cast the result of Length to int
                    int tupleLength = (int)tuple.Length();
                    if (tupleLength >= 2)
                    {
                        bool success = tuple[0].As<bool>();  // Access elements directly if possible
                        string message = tuple[1].As<string>();
                        return (success, message);
                    }
                    else
                    {
                        return (false, "Tuple does not contain enough elements.");
                    }
                }
                else
                {
                    return (false, "Object is not a tuple");
                }
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
            {
                return (false, "Error accessing properties from the Python response: " + ex.Message);
            }
            catch (Exception ex)
            {
                return (false, $"Failed to add new part: {ex.Message}");
            }
        }

        public string GetPartDetails(string partNumber)
        {
            string message = pythonModule.delete_part_query(partNumber);
            return message;
        }

        public dynamic GetPartInfo(string partNumber)
        {
            return pythonModule.get_part_info(partNumber);
        }

        public (bool success, string message) SetPartInfo(string part_number, string part_description, int? minn = null, int? maxx = null, int? lead_time = null, string supplier = null, float? price = null, string comment = null, string purchase_link = null)
        {
            try
            {
                dynamic result = pythonModule.set_part_info(part_number, part_description, minn, maxx, lead_time, supplier, price, comment, purchase_link);
                // Assume result is a PyObject that should be a tuple
                if (result is PyObject tuple)
                {
                    // Explicitly cast the result of Length to int
                    int tupleLength = (int)tuple.Length();
                    if (tupleLength >= 2)
                    {
                        bool success = tuple[0].As<bool>();  // Access elements directly if possible
                        string message = tuple[1].As<string>();
                        return (success, message);
                    }
                    else
                    {
                        return (false, "Tuple does not contain enough elements.");
                    }
                }
                else
                {
                    return (false, "Object is not a tuple");
                }
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
            {
                return (false, "Error accessing properties from the Python response: " + ex.Message);
            }
            catch (Exception ex)
            {
                return (false, $"Failed to add new part: {ex.Message}");
            }
        }

        public bool DeletePart(string partNumber)
        {
            try
            {
                // Attempt to delete the part and return the result.
                bool result = pythonModule.delete_part(partNumber);
                return result;
            }
            catch
            {
                // If an error occurs, show a message box and return false.
                MessageBox.Show("There was an error deleting the part");
                return false;
            }
        }

        public string EditLocation(string location, string module)
        {
           if (location != null)
           {
                try
                {
                    string result = pythonModule.edit_loc(location, module);
                    return result;
                }
                catch
                {
                    return "There was an error";
                }
           }
            else
            {
                return "Location cannot be null";
            }
        }

        public string AddUser(string username, string password, Dictionary<string, object> permissions)
        {
            using (Py.GIL())
            {
                try
                {
                    PyDict pyDict = new();
                    foreach (var item in permissions)
                    {
                        pyDict[item.Key.ToPython()] = item.Value.ToPython();
                    }
                    string result = pythonModule.add_user(username, password, pyDict).ToString();
                    return result;
                }
                catch (Exception ex)
                {
                    // Return error message directly if something goes wrong
                    return $"Failed to add user: {ex.Message}";
                }
            }
        }

        public string DeleteUser(string username)
        {
            try
            {
                // Attempt to delete the part and return the result.
                string result = pythonModule.delete_user(username);
                return result;
            }
            catch
            {
                // If an error occurs, show a message box and return false.
                string message = "There was an error deleting the user";
                return message;
            }
        }

    }
}


