using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engineering_Inventory
{
    public partial class EditPartWindow : Form
    {
        bool editFlag = false;
        public EditPartWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton_MouseClick(object sender, EventArgs e)
        {
            if (editFlag)
            {
                DialogResult dialog = MessageBox.Show("You are about to submit your changes. These changes cannot be reversed.", "Continue?", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    string part_number = PartNumberBox.Text.ToUpper();
                    string part_description = DescriptionBox.Text;
                    string minn = MinnBox.Text;
                    string maxx = MaxxBox.Text;
                    string lead_time = LeadTimeBox.Text;
                    string supplier = SupplierBox.Text.ToUpper();
                    string price = PriceBox.Text;
                    string comment = CommentBox.Text;
                    string purchase_link = PurchaseLinkBox.Text;

                    try
                    {
                        // Convert string to int and float
                        int minnInt = string.IsNullOrEmpty(minn) ? 0 : int.Parse(minn);
                        int maxxInt = string.IsNullOrEmpty(maxx) ? 0 : int.Parse(maxx);
                        int leadTimeInt = string.IsNullOrEmpty(lead_time) ? 0 : int.Parse(lead_time);
                        float priceFloat = string.IsNullOrEmpty(price) ? 0f : float.Parse(price, CultureInfo.InvariantCulture);

                        // Call the method with the converted types and get the result
                        dynamic result = Program.pI.SetPartInfo(part_number, part_description, minnInt, maxxInt, leadTimeInt, supplier, priceFloat, comment, purchase_link);

                        // Display the result message to the user
                        if (result.Item1)
                        {
                            MessageBox.Show(result.Item2, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(result.Item2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Please enter valid numbers for Min, Max, Lead Time, and Price.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                ResetButton_Click(sender, e);
            }
            else
            {
                dynamic partInfo = Program.pI.GetPartInfo(PartNumberBox.Text.ToUpper());

                if (partInfo != null)
                {
                    foreach (Control control in this.Controls) 
                    { 
                        if (control is TextBox textBox)
                        {
                            if (control.Name == "PartNumberBox" || control.Name == "DescriptionBox")
                            textBox.Enabled = false;
                            else
                            {
                                textBox.Enabled = true;
                            }
                        }
                    }
                    DescriptionBox.Text = partInfo["Part_Description"];
                    MinnBox.Text = partInfo["MIN"];
                    MaxxBox.Text = partInfo["MAX"];
                    SupplierBox.Text = partInfo["Supplier"];
                    PriceBox.Text = partInfo["Price"];
                    PurchaseLinkBox.Text = partInfo["Purchase_Link"];
                    LeadTimeBox.Text = partInfo["Lead_Time"];
                    CommentBox.Text = partInfo["Comment"];
                }

                editFlag = true;
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Text = "";

                    textBox.Enabled = textBox.Name == "PartNumberBox";
                }
            }
            editFlag = false;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            editFlag = false;
            this.Close();
        }

        private void PartNumberBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==(char)Keys.Enter)
            {
                if(!string.IsNullOrEmpty(PartNumberBox.Text))
                SubmitButton_MouseClick(sender, e);
            }
        }
    }
}
