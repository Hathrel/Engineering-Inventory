using System;
using System.Windows.Forms;

namespace Engineering_Inventory
{
    public partial class loginWindow : Form
    {
        private PythonInterop pI; // Declare a field to hold an instance of PythonInterop

        public loginWindow()
        {
            InitializeComponent();

            // Create an instance of PythonInterop
            pI = new PythonInterop();
            pI.InitializePythonEngine();
        }
        private void logInButton_Click(object sender, EventArgs e)
        {
            string username = usernameBox.Text;
            string password = passwordBox.Text;

            try
            {
                // Call DatabaseLogin method from PythonInterop
                (bool success, string message, dynamic permissions) = pI.DatabaseLogin(username, password);

                // Handle the result
                if (success)
                {
                    // Show a success message (optional)
                    MessageBox.Show(message, "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Close the current login form
                    this.Close();

                    // Open the main form
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                }
                else
                {
                    // Show error message if login failed
                    MessageBox.Show(message, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("Error during login: " + ex.Message);
            }
        }
    }
}



