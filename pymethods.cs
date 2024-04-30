using System;
using Python.Runtime;

namespace Engineering_Inventory
{
    public class PythonInterop
    {
        public void InitializePythonEngine()
        {
            // Initialize Python engine
            PythonEngine.Initialize();
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
                string scriptPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Data", "EngInvDB");
                dynamic pythonModule = Py.Import(scriptPath);
                dynamic result = pythonModule.database_login(username, password);

                bool success = result[0];
                string message = result[1];
                dynamic permissions = result[2];

                return (success, message, permissions);
            }
            catch (PythonException ex)
            {
                // Handle Python exception
                // Log or display the full traceback of the Python exception
                string traceback = ex.ToString();
                Console.WriteLine(traceback);
                return (false, traceback, null);
            }
        }
    }
}
