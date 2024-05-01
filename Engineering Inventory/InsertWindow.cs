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
    public partial class InsertInventory : Form
    {
        bool app_permisson;
        public InsertInventory(bool permission)
        {
            permission = app_permisson;
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            PythonInterop pythonInterop = new PythonInterop();
            string part = partBox.Text;
            string qty = qtyBox.Text;
            string loc = locBox.Text;
            bool perm = app_permisson;

            pythonInterop.InsertInventory(part, qty, loc, perm);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
