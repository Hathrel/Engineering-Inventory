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
        private string editModule;
        public EditLocationWindow(string module)
        {
            InitializeComponent();
            this.Text = $"{module} Location";
            this.editModule = module;
            LocBanner.Text = $"{module} Location";
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(LocBox.Text)) { }
            {
                string result = Program.pI.EditLocation(LocBox.Text, editModule);
                MessageBox.Show(result);
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
