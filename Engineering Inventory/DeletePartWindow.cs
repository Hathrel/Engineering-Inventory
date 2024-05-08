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
    public partial class DeletePartWindow : Form
    {
        public DeletePartWindow()
        {
            InitializeComponent();
        }

        private void PartNumberBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SubmitButton_MouseClick(sender, e);
            }
        }

        private void SubmitButton_MouseClick(object sender, EventArgs e)
        {
            string result = "Error";
            if (!string.IsNullOrEmpty(PartNumberBox.Text))
            {
                try
                {
                    result = Program.pI.GetPartDetails(PartNumberBox.Text);
                    if (!string.IsNullOrEmpty(result))
                    {
                        DeleteButton.Visible = true;
                        DescriptionBox.Visible = true;
                        DescriptionLabel.Visible = true;
                        DescriptionBox.Text = result;
                    }
                }
                catch
                {
                    MessageBox.Show($"There was an error with the C# interop method.{result}");
                }
            }
            else
            {
                MessageBox.Show("Please enter a part number.");
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteButton_MouseClick(object sender, MouseEventArgs e)
        {
            DialogResult warningResult = MessageBox.Show("WARNING: You are about to permanently delete this part. This cannot be undone.",
                                                         "Confirm Deletion",
                                                         MessageBoxButtons.OKCancel,
                                                         MessageBoxIcon.Warning);
            if (warningResult == DialogResult.OK)
            {
                bool deleteSuccessful = Program.pI.DeletePart(PartNumberBox.Text);
                if (deleteSuccessful)
                {
                    MessageBox.Show("Part deleted successfully.");
                }
                else
                {
                    MessageBox.Show("There was an error deleting the part.");
                }
            }
        }
    }
}
