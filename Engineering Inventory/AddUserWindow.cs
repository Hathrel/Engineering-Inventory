namespace Engineering_Inventory
{
    public partial class AddUserWindow : Form
    {
        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> permissions = new Dictionary<string, object>();

            foreach (Control control in this.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    permissions[checkBox.Text] = checkBox.Checked;
                }
            }
            string result = Program.pI.AddUser(UserNameBox.Text, PasswordBox.Text, permissions);
            MessageBox.Show(result);
            AddUserWindow_Load(sender, e);
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserNameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (!string.IsNullOrEmpty(UserNameBox.Text) && !string.IsNullOrEmpty(PasswordBox.Text))
                {
                    SubmitButton_Click(sender, e);
                }
                else
                {
                    SelectNextControl((Control)sender, true, true, true, true);
                }
            }
        }

        private void PasswordBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (!string.IsNullOrEmpty(UserNameBox.Text) && !string.IsNullOrEmpty(PasswordBox.Text))
                {
                    SubmitButton_Click(sender, e);
                }
                else
                {
                    SelectNextControl((Control)sender, true, true, true, true);
                }
            }
        }

        private void AddUserWindow_Load(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    if (control.Text == Program.user_site || control.Text == "Edit Inventory")
                    {
                        checkBox.Checked = true;
                    }
                    else
                    {
                        checkBox.Checked = false;
                    }
                }
                else if (control is TextBox textBox)
                {
                    textBox.Text = "";
                }
            }
        }
    }
}
