using System;
using System.IO;
using Python.Runtime;

namespace Engineering_Inventory
{
    public class PythonInterop
    {
        private dynamic pythonModule;

        public void InitializePythonEngine()
        {
            // Set the path to the Python DLL
            Runtime.PythonDLL = @"C:\Users\dboyer\AppData\Local\Programs\Python\Python312\python312.dll";

            // Initialize Python engine
            PythonEngine.Initialize();

            // Append directory containing Python module to sys.path
            string moduleDirectory = @"C:\users\dboyer\source\repos\Engineering Inventory\Engineering Inventory\Data";
            PythonEngine.Exec($"import sys; sys.path.append('{moduleDirectory}')");

            // Import the Python module
            pythonModule = Py.Import("EngInvDB");
        }

        public void ShutdownPythonEngine()
        {
            // Shutdown Python engine
            PythonEngine.Shutdown();
        }

        public (bool, string, dynamic) DatabaseLogin(string username, string password)
        {
            try
            {
                // Call Python function
                dynamic result = pythonModule.database_login(username, password);

                // Extract result components
                bool success = result[0];
                string message = result[1];
                dynamic permissions = result[2];

                return (success, message, permissions);
            }
            catch (PythonException ex)
            {
                // Handle Python exception
                // Log or display the exception details
                Console.WriteLine($"Python Exception: {ex.Message}");
                Console.WriteLine($"Python Traceback: {ex.Traceback}");
                string errorString = $"Python error occurred: {ex.Message}\n Stack Trace: {ex.Traceback}";

                // Return detailed error message
                return (false, errorString, null);
            }
        }
    }
}


