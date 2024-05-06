using System;
using System.Runtime.CompilerServices;
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

            // Set the Python path
            //Environment.SetEnvironmentVariable("PYTHONPATH", @"C:\Users\Derek\AppData\Local\Programs\Python\Python312\Lib\site-packages");

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
                // Call Python function
                dynamic result = pythonModule.database_login(username, password, site);

                // Extract result components
                bool success = result[0];
                string message = result[1];
                dynamic permissions = result[2];
                Program.user_site = site;

                return (success, message, permissions, username);
            }
            catch (PythonException ex)
            {
                // Handle Python exception
                // Log or display the exception details
                Console.WriteLine($"Python Exception: {ex.Message}");
                Console.WriteLine($"Python Traceback: {ex.Traceback}");
                string errorString = $"Python error occurred: {ex.Message}\n Stack Trace: {ex.Traceback}";

                // Return detailed error message
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
    }
}


