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
                // Call the Python method and store the result in a dynamic variable
                dynamic result = pythonModule.add_new_part(part_number, part_description, minn, maxx, lead_time, supplier, price, comment, purchase_link);
                bool success = false;
                // Directly access dynamic properties
                if (result.success == "True")
                {
                    success = true;
                }
                string message = result.message;
                // Return the values in a tuple
                return (success, message);
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
            {
                // Handle cases where the dynamic object does not contain the expected properties
                return (false, "Error accessing properties from the Python response: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Return false and the exception message if an error occurs
                return (false, $"Failed to add new part: {ex.Message}");
            }
        }
    }
}


