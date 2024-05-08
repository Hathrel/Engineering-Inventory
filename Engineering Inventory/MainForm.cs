using System.Runtime.InteropServices;

namespace Engineering_Inventory
{
    // MainForm.cs
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            MainStatusLabel.Text = $"Welcome {Program.user_name}, you are working in {Program.user_site}";
        }
        private void insertButton_Click(object sender, EventArgs e)
        {
            if (!Program.editPermission)
            {
                MessageBox.Show("You don't have permission to do that!");
                return;
            }

            InsertInventory insertInventory = new();
            insertInventory.ShowDialog();
        }

        private void PickingButton_Click(object sender, EventArgs e)
        {
            if (!Program.editPermission)
            {
                MessageBox.Show("You don't have permission to do that!");
                return;
            }

            PickingInventory pickingInventory = new();
            pickingInventory.ShowDialog();
        }

        private void BinMove_Click(object sender, EventArgs e)
        {
            if (!Program.editPermission)
            {
                MessageBox.Show("You don't have permission to do that!");
                return;
            }

            BinMoveInventory moveInventory = new();
            moveInventory.ShowDialog();
        }

        private void CycleCount_MouseClick(object sender, MouseEventArgs e)
        {
            if (!Program.editPermission)
            {
                MessageBox.Show("You don't have permission to do that!");
                return;
            }

            CycleCounts cycleCount = new();
            cycleCount.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Program.editPermission)
            {
                actionsBox.Visible = true;
            }
            if (Program.addLocPermission)
            {
                LocationEditBox.Visible = true;
            }
            if (Program.addPartPermission)
            {
                PartEditBox.Visible = true;
            }
            if (Program.admin)
            {
                AdminActionsBox.Visible = true;
            }
        }

        private void AddPartButton_Click(object sender, EventArgs e)
        {
            AddPartWindow addPartWindow = new();
            addPartWindow.ShowDialog();
        }
    }
}


