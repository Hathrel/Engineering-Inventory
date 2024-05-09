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
    public partial class DeleteUserWindow : Form
    {
        public DeleteUserWindow()
        {
            InitializeComponent();
        }

        private void UsernameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(UsernameBox.Text)) 
                {
                    SubmitButton_Click(sender, e);
                }
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty (UsernameBox.Text))
            {
                DialogResult warningResult = MessageBox.Show($"WARNING: You are about to delete user {UsernameBox.Text}. This cannot be undone.", "Do you want to proceed?", MessageBoxButtons.YesNo);
                if (warningResult == DialogResult.Yes)
                {
                    string result = Program.pI.DeleteUser(UsernameBox.Text);
                    MessageBox.Show(result);
                    UsernameBox.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Please enter a username.", "", MessageBoxButtons.OK);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
