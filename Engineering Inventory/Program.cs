using System;
using System.DirectoryServices;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace Engineering_Inventory
{
    internal static class Program
    {
        private static bool terminated = false;
        private static PythonInterop pI;
        public static bool pickingPermission;
        public static bool insertPermission;
        public static bool editPermission;
        public static bool purchasePermission;
        public static string user_name;

        [STAThread]
        static void Main()
        {
            // Initialize Python engine
            InitializePythonEngine();

            // Initialize application configuration
            ApplicationConfiguration.Initialize();

            // Subscribe to the ApplicationExit event
            Application.ApplicationExit += Application_ApplicationExit;

            // Run the login window
            loginWindow loginWindow = new loginWindow(pI);
            loginWindow.LoginSuccessful += LoginWindow_LoginSuccessful;
            Application.Run(loginWindow);

            // Check if login was successful
            if (loginWindow.loginSuccess)
            {
        // Store user permissions
        dynamic userPermissions = loginWindow.user_permissions;

                // Create MainForm instance only if login was successful
                MainForm mainForm = new MainForm(pI, userPermissions, user_name);
                Application.Run(mainForm);


                // Close the current instance of loginWindow
                loginWindow.Close();
            }
        }

        private static void LoginWindow_LoginSuccessful(object sender, string username)
        {
            user_name = username;
        }

        private static void InitializePythonEngine()
        {
            // Create an instance of PythonInterop and initialize Python engine
            pI = new PythonInterop();
            pI.InitializePythonEngine();
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            if(terminated == true){
                pI.ShutdownPythonEngine();
            }
            // Shutdown Python engine when the program exits
        }
    }
}


