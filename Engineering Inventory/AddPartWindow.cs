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
                dynamic result = Program.pI.AddPartNumber(part_number, part_description, minnInt, maxxInt, leadTimeInt, supplier, priceFloat, comment, purchase_link);

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

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
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
