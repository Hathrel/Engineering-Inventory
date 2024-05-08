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
    public partial class AddFoundWindow : Form
    {
        private string partLocation;
        public AddFoundWindow(string location)
        {
            this.partLocation = location.ToUpper();
            InitializeComponent();
            AddFoundStatus.Text = $"Found inventory in {partLocation}";
        }

        private void PartBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(QtyBox.Text) && !string.IsNullOrEmpty(PartBox.Text))
                {
                    SubmitButton_Click(sender, e);
                }
                else
                {
                    e.Handled = true;
                    SelectNextControl((Control)sender, true, true, true, true);
                }
            }
        }

        private void QtyBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(QtyBox.Text) && !string.IsNullOrEmpty(PartBox.Text))
                {
                    SubmitButton_Click(sender, e);
                }
                else
                {
                    e.Handled = true;
                    SelectNextControl((Control)sender, true, true, true, true);
                }
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(QtyBox.Text) && !string.IsNullOrEmpty(PartBox.Text))
            {
                string part = PartBox.Text;
                string qty = QtyBox.Text;
                Program.pI.CycleCountSubmit(partLocation, part, qty);
                if (AddMoreBox.Checked == true)
                {
                    PartBox.Text = "";
                    QtyBox.Text = "";
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
