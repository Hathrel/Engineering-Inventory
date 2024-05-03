using System;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace Engineering_Inventory
{
    // loginWindow.cs
    public partial class loginWindow : Form
    {
        public event EventHandler<string> LoginSuccessful;
        private PythonInterop pI; // Declare a field to hold an instance of PythonInterop
        public bool loginSuccess = false;
        public dynamic user_permissions; // Corrected variable name

        public loginWindow(PythonInterop pythonInterop)
        {
            InitializeComponent();
            // Initialize PythonInterop instance
            pI = pythonInterop;
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            string username = usernameBox.Text;
            string password = passwordBox.Text;
            string site = SiteSelection.Text;

            try
            {
                // Call DatabaseLogin method from PythonInterop
                if (!string.IsNullOrEmpty(usernameBox.Text) && !string.IsNullOrEmpty(passwordBox.Text) && !string.IsNullOrEmpty(SiteSelection.Text))
                {
                    (bool success, string message, dynamic permissions, string loggedInUsername) = pI.DatabaseLogin(username, password, site);

                    // Handle the result
                    if (success)
                    {
                        // Close the current login form
                        loginSuccess = true;
                        user_permissions = permissions;
                        string loggedInUsernameValue = loggedInUsername; // Store the value in a separate variable

                        LoginSuccessful?.Invoke(this, loggedInUsername);

                        // Close the current instance of loginWindow
                        Close();
                    }
                    else
                    {
                        // Show error message if login failed
                        MessageBox.Show(message, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in all fields.");
                    SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("Error during login: " + ex.Message);
            }
        }

        private void logInButton_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(usernameBox.Text) && !string.IsNullOrEmpty(passwordBox.Text) && !string.IsNullOrEmpty(SiteSelection.Text))
                {
                    e.Handled = true;
                    logInButton_Click(sender, e);
                }
                else
                {
                    SelectNextControl((Control)sender, true, true, true, true);
                }
            }

        }

        private void loginWindow_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the Enter key is pressed
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(usernameBox.Text) && !string.IsNullOrEmpty(passwordBox.Text) && !string.IsNullOrEmpty(SiteSelection.Text))
                {
                    e.Handled = true;
                    logInButton_Click(sender, e);
                }
                else
                {
                    SelectNextControl((Control)sender, true, true, true, true);
                }
            }

        }

        private void usernameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(usernameBox.Text) && !string.IsNullOrEmpty(passwordBox.Text) && !string.IsNullOrEmpty(SiteSelection.Text))
                {
                    e.Handled = true;
                    logInButton_Click(sender, e);
                }
                else
                {
                    e.Handled = true;
                    SelectNextControl((Control)sender, true, true, true, true);
                }
            }
        }

        private void passwordBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(usernameBox.Text) && !string.IsNullOrEmpty(passwordBox.Text) && !string.IsNullOrEmpty(SiteSelection.Text))
                {
                    e.Handled = true;
                    logInButton_Click(sender, e);
                }
                else
                {
                    e.Handled = true;
                    SelectNextControl((Control)sender, true, true, true, true);
                }
            }
        }

        private void SiteSelection_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(usernameBox.Text) && !string.IsNullOrEmpty(passwordBox.Text) && !string.IsNullOrEmpty(SiteSelection.Text))
                {
                    e.Handled = true;
                    logInButton_Click(sender, e);
                }
                else
                {
                    e.Handled = true;
                    SelectNextControl((Control)sender, true, true, true, true);
                }
            }

        }
    }
}




