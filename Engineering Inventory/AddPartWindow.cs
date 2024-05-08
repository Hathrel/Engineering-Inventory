using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Engineering_Inventory
{
    public partial class AddPartWindow : Form
    {
        public AddPartWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string part_number = PartNumberBox.Text.ToUpper();
            string part_description = PartDescBox.Text;
            string minn = MinnBox.Text;
            string maxx = MaxxBox.Text;
            string lead_time = LeadTimeBox.Text;
            string supplier = SupplierBox.Text.ToUpper();
            string price = PriceBox.Text;
            string comment = CommentsBox.Text;
            string purchase_link = PurchaseLinkBox.Text;

            try
            {
                // Convert string to int and float
                int minnInt = string.IsNullOrEmpty(minn) ? 0 : int.Parse(minn);
                int maxxInt = string.IsNullOrEmpty(maxx) ? 0 : int.Parse(maxx);
                int leadTimeInt = string.IsNullOrEmpty(lead_time) ? 0 : int.Parse(lead_time);
                float priceFloat = string.IsNullOrEmpty(price) ? 0f : float.Parse(price, CultureInfo.InvariantCulture);

                // Call the method with the converted types and get the result
                var (success, message) = Program.pI.AddPartNumber(part_number, part_description, minnInt, maxxInt, leadTimeInt, supplier, priceFloat, comment, purchase_link);

                // Display the result message to the user
                if (success)
                {
                    MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            string helpText;
            Control activeControl = this.ActiveControl;
            if (activeControl != null)
            {
                switch (activeControl.Name)
                {
                    case "PartNumberBox":
                        helpText = "Assign the part number. Current convention follows 'ENG000111'.";
                        break;
                    case "PartDescBox":
                        helpText = "Describe what the part is, or enter the manufacturer's description.";
                        break;
                    case "MinnBox":
                        helpText = "Minimum quantity before order is needed.";
                        break;
                    case "MaxxBox":
                        helpText = "Maximum quantity to keep on hand. This is what we will try to order to during a PO.";
                        break;
                    case "LeadTimeBox":
                        helpText = "How long on average does it take to arrive.";
                        break;
                    case "SupplierBox":
                        helpText = "Who we are buying this from.";
                        break;
                    case "PriceBox":
                        helpText = "Cost per unit. In multi-pack parts, divide the total cost by the number of units.";
                        break;
                    case "CommentsBox":
                        helpText = "If there is anything additional to know about this part, it goes here.";
                        break;
                    case "PurchaseLinkBox":
                        helpText = "Must be a valid URL. This should be a link to the purchase page or purchasing information.";
                        break;
                    default:
                        helpText = "No help available for this item.";
                        break;
                }

                MessageBox.Show(helpText, "Help Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void PartNumberBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void PartDescBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void MinnBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void MaxxBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void LeadTimeBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void SupplierBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void PriceBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void CommentsBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void PurchaseLinkBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                PartNumberBox.Select();
            }
        }

        private void AddPartWindow_Load(object sender, EventArgs e)
        {
            PartNumberBox.Select();
        }
    }
}
