using System;
using Python.Runtime;

namespace Engineering_Inventory
{
    public class PythonInterop
    {
        private dynamic pythonModule;

        public void InitializePythonEngine()
        {
            // Correctly set the path to the Python DLL
            Runtime.PythonDLL = @"C:\Users\dboyer\AppData\Local\Programs\Python\Python312\python312.dll";
            //Runtime.PythonDLL = @"C:\Users\Derek\AppData\Local\Programs\Python\Python312\python312.dll";

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

        public (bool, string, dynamic, string) DatabaseLogin(string username, string password)
        {
            try
            {
                // Call Python function
                dynamic result = pythonModule.database_login(username, password);

                // Extract result components
                bool success = result[0];
                string message = result[1];
                dynamic permissions = result[2];

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
        public bool InsertInventory(string part, string qty, string location, dynamic permission)
        {
            try
            {
                bool result = pythonModule.insert_part(part, qty, location, permission);
                return result;
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


