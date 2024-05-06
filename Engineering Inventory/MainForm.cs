using System.Runtime.InteropServices;

namespace Engineering_Inventory
{
    // MainForm.cs
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            welcomeLabel.Text = $"Welcome {Program.user_name}, you are working in {Program.user_site}";
        }
        private void insertButton_Click(object sender, EventArgs e)
        {
            if (!Program.insertPermission)
            {
                MessageBox.Show("You don't have permission to do that!");
                return;
            }

            InsertInventory insertInventory = new();
            insertInventory.ShowDialog();
        }

        private void PickingButton_Click(object sender, EventArgs e)
        {
            if (!Program.pickingPermission)
            {
                MessageBox.Show("You don't have permission to do that!");
                return;
            }

            PickingInventory pickingInventory = new();
            pickingInventory.ShowDialog();
        }
    }
}


