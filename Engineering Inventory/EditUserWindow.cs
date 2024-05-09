using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engineering_Inventory
{
    public partial class EditUserWindow : Form
    {
        bool editFlag = false;
        public EditUserWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {

            if (editFlag)
            {
                Dictionary<string, object> userinfo = new Dictionary<string, object>();

                userinfo["Password"] = PasswordBox.Text;

                foreach (Control control in this.Controls)
                {
                    if (control is CheckBox checkBox)
                    {
                        userinfo[checkBox.Text] = checkBox.Checked;
                    }
                }
                string result = Program.pI.SetUserInfo(UserNameBox.Text, userinfo);
                MessageBox.Show(result);
                ResetButton_Click(sender, e);
            }

            else
            {
                dynamic result = Program.pI.GetUserInfo(UserNameBox.Text);
                editFlag = true;
                UserNameBox.Enabled = false;
                EditPartsBox.Checked = result["Add_Part_Permit"];
                EditLocationsBox.Checked = result["Add_Loc_Permit"];
                EditInventoryBox.Checked = result["Edit_Permit"];
                AdminBox.Checked = result["Admin"];
                CVG2Box.Checked = result["CVG2"];
                SwedesBox.Checked = result["SWEDESBORO_117"];
                LEX1Box.Checked = result["LEX1"];
                WestChesterBox.Checked = result["WESTCHESTER_1305"];
                YYZBox.Checked = result["YYZ"];
                foreach (Control control in this.Controls)
                {
                    if (control.Name == "UserNameBox" && control is not Button)
                    {
                        control.Enabled = false;
                    }
                    else
                    {
                        control.Enabled = true;
                    }
                }
                PasswordBox.Select();
            }
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
                if (!string.IsNullOrEmpty(UserNameBox.Text))
                {
                    SubmitButton_Click(sender, e);
                }
            }
        }

        private void PasswordBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                    SubmitButton_Click(sender, e);
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                }
                else if (control is TextBox textBox)
                {
                    textBox.Text = "";
                }
                if (control.Name != "UserNameBox" && control is not Label)
                {
                    control.Enabled = false;
                }
                else
                {
                    control.Enabled = true;
                }
            }
            UserNameBox.Enabled = true;
            editFlag = false;
        }

        private void EditUserWindow_Load(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                UserNameBox.Select();
            }
;
        }
    }
}
