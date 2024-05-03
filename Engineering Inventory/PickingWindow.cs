namespace Engineering_Inventory
{
    public partial class PickingInventory : Form
    {
        private readonly PythonInterop pI;
        bool app_permisson;
        public PickingInventory(bool permission, PythonInterop pythonInterop)
        {
            pI = pythonInterop;
            permission = app_permisson;
            InitializeComponent();
            PickingStatus.Text = $"Hello {Program.user_name}, you are working in {Program.sitePermission}";
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(partBox.Text) && !string.IsNullOrEmpty(qtyBox.Text) && !string.IsNullOrEmpty(locBox.Text))
            {
                string part_number = partBox.Text;
                string qty = qtyBox.Text;
                string location = locBox.Text;

                bool result = pI.EditInventory(part_number, qty, location, "Picking");
                if (result)
                {
                    MessageBox.Show("Part updated successfully.");
                    this.Close();
                }
            }
            else if (string.IsNullOrEmpty(partBox.Text) || string.IsNullOrEmpty(qtyBox.Text) || string.IsNullOrEmpty(locBox.Text))
            {
                // Focus on partBox if it's empty
                if (string.IsNullOrEmpty(partBox.Text))
                {
                    partBox.Focus();
                    MessageBox.Show("Please enter a part number.");
                    return;
                }

                // Focus on qtyBox if it's empty
                if (string.IsNullOrEmpty(qtyBox.Text))
                {
                    qtyBox.Focus();
                    MessageBox.Show("Please enter a quantity");
                    return;
                }

                if (string.IsNullOrEmpty(locBox.Text))
                {
                    locBox.Focus();
                    MessageBox.Show("Please enter a location");
                    return;
                }
            }


        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void partBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(partBox.Text) && !string.IsNullOrEmpty(qtyBox.Text) && !string.IsNullOrEmpty(locBox.Text))
                {
                    e.Handled = true;
                    SubmitButton_Click(sender, e);
                }
                else
                {
                    e.Handled = true;
                    SelectNextControl((Control)sender, true, true, true, true);
                }
            }
        }

        private void qtyBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(partBox.Text) && !string.IsNullOrEmpty(qtyBox.Text) && !string.IsNullOrEmpty(locBox.Text))
                {
                    e.Handled = true;
                    SubmitButton_Click(sender, e);
                }
                else
                {
                    e.Handled = true;
                    SelectNextControl((Control)sender, true, true, true, true);
                }
            }
        }

        private void locBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(partBox.Text) && !string.IsNullOrEmpty(qtyBox.Text) && !string.IsNullOrEmpty(locBox.Text))
                {
                    e.Handled = true;
                    SubmitButton_Click(sender, e);
                }
                else if (string.IsNullOrEmpty(partBox.Text) || string.IsNullOrEmpty(qtyBox.Text) || string.IsNullOrEmpty(locBox.Text))
                {
                    // Focus on partBox if it's empty
                    if (string.IsNullOrEmpty(partBox.Text))
                    {
                        partBox.Focus();
                        MessageBox.Show("Please enter a part number.");
                        return;
                    }

                    // Focus on qtyBox if it's empty
                    if (string.IsNullOrEmpty(qtyBox.Text))
                    {
                        qtyBox.Focus();
                        MessageBox.Show("Please enter a quantity");
                        return;
                    }

                    if (string.IsNullOrEmpty(locBox.Text))
                    {
                        locBox.Focus();
                        MessageBox.Show("Please enter a location");
                        return;
                    }
                }
            }
        }
    }
}