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

        private void loginWindow_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the Enter key is pressed
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void usernameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(char)Keys.Enter)
            {
                e.Handled = true;
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void logInButton_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(char)Keys.Enter)
            {
                e.Handled = true;
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void passwordBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(char)Keys.Enter)
            {
                e.Handled = true;
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void b(object sender, EventArgs e)
        {

        }
    }
}




