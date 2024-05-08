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
    public partial class EditLocationWindow : Form
    {
        public EditLocationWindow()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {

        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(LocBox.Text)) { }
            {
               
            }
        }

        private void LocBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                SubmitButton_Click(sender, e);
            }
        }
    }
}
