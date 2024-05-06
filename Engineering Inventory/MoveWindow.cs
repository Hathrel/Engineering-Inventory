namespace Engineering_Inventory
{
    public partial class BinMoveInventory : Form
    {
        public BinMoveInventory()
        {
            InitializeComponent();
            BinMoveStatus.Text = $"Hello {Program.user_name}, you are working in {Program.user_site}";
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(partBox.Text) && !string.IsNullOrEmpty(qtyBox.Text) && !string.IsNullOrEmpty(OldLocBox.Text) && !string.IsNullOrEmpty(NewLocBox.Text))
            {
                string part_number = partBox.Text;
                string qty = qtyBox.Text;
                string newLocation = NewLocBox.Text;
                string oldLocation = OldLocBox.Text;

                bool result = Program.pI.EditInventory(part_number, qty, oldLocation, "Bin_Move", newLocation );
                if (result)
                {
                    MessageBox.Show("Part updated successfully.");
                    this.Close();
                }
            }
            else if (string.IsNullOrEmpty(partBox.Text) || string.IsNullOrEmpty(qtyBox.Text) || string.IsNullOrEmpty(OldLocBox.Text) || string.IsNullOrEmpty(NewLocBox.Text))
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

                if (string.IsNullOrEmpty(NewLocBox.Text))
                {
                    NewLocBox.Focus();
                    MessageBox.Show("Please enter an origin location");
                    return;
                }

                if (string.IsNullOrEmpty(OldLocBox.Text))
                {
                    OldLocBox.Focus();
                    MessageBox.Show("Please enter a destination location");
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
                if (!string.IsNullOrEmpty(partBox.Text) && !string.IsNullOrEmpty(qtyBox.Text) && !string.IsNullOrEmpty(OldLocBox.Text) && !string.IsNullOrEmpty(NewLocBox.Text))
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
                if (!string.IsNullOrEmpty(partBox.Text) && !string.IsNullOrEmpty(qtyBox.Text) && !string.IsNullOrEmpty(OldLocBox.Text) && !string.IsNullOrEmpty(NewLocBox.Text))
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

        private void OldLocBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(partBox.Text) && !string.IsNullOrEmpty(qtyBox.Text) && !string.IsNullOrEmpty(OldLocBox.Text) && !string.IsNullOrEmpty(NewLocBox.Text))
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

        private void NewLocBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(partBox.Text) && !string.IsNullOrEmpty(qtyBox.Text) && !string.IsNullOrEmpty(OldLocBox.Text) && !string.IsNullOrEmpty(NewLocBox.Text))
                {
                    e.Handled = true;
                    SubmitButton_Click(sender, e);
                }
                else if (string.IsNullOrEmpty(partBox.Text) || string.IsNullOrEmpty(qtyBox.Text) || string.IsNullOrEmpty(OldLocBox.Text) || string.IsNullOrEmpty(NewLocBox.Text))
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

                    if (string.IsNullOrEmpty(NewLocBox.Text))
                    {
                        NewLocBox.Focus();
                        MessageBox.Show("Please enter a destination location");
                        return;
                    }
                    if (string.IsNullOrEmpty(OldLocBox.Text))
                    {
                        OldLocBox.Focus();
                        MessageBox.Show("Please enter an origin location");
                        return;
                    }
                }
            }
        }
    }
}