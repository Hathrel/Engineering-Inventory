using System;
using System.Windows.Forms;

namespace Engineering_Inventory
{
    internal static class Program
    {
        public static PythonInterop pI;
        public static bool addPartPermission;
        public static bool addLocPermission;
        public static bool editPermission;
        public static bool admin;
        public static string user_site;
        public static string user_name;

        [STAThread]
        static void Main()
        {
            InitializePythonEngine();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (loginWindow loginWindow = new loginWindow(pI))
            {
                Application.Run(loginWindow);

                if (loginWindow.loginSuccess)
                {
                    dynamic userPermissions = loginWindow.user_permissions;
                    addPartPermission = userPermissions["Addpart"];
                    addLocPermission = userPermissions["Addloc"];
                    editPermission = userPermissions["Edit"];
                    admin = userPermissions["Admin"];

                    using (MainForm mainForm = new MainForm())
                    {
                        Application.Run(mainForm);
                    }
                }
            }
            ShutdownApplication();
        }

        private static void InitializePythonEngine()
        {
            pI = new PythonInterop();
            pI.InitializePythonEngine();
        }

        private static void ShutdownApplication()
        {
            if (Application.OpenForms.Count == 0)
            {
                pI.ShutdownPythonEngine();
                Application.Exit();
            }
        }
    }
}



