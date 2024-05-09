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
            InsertInventory insertInventory = new();
            insertInventory.ShowDialog();
        }

        private void PickingButton_Click(object sender, EventArgs e)
        {
            PickingInventory pickingInventory = new();
            pickingInventory.ShowDialog();
        }

        private void BinMove_Click(object sender, EventArgs e)
        {
            BinMoveInventory moveInventory = new();
            moveInventory.ShowDialog();
        }

        private void CycleCount_MouseClick(object sender, MouseEventArgs e)
        {
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

        private void DeletePartButton_Click(object sender, EventArgs e)
        {
            DeletePartWindow deletePartWindow = new();
            deletePartWindow.ShowDialog();
        }

        private void EditPartButton_Click(object sender, EventArgs e)
        {
            EditPartWindow editPartWindow = new();
            editPartWindow.ShowDialog();
        }

        private void DeleteLocationButton_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void AddLocationButton_Click(object sender, EventArgs e)
        {
            EditLocationWindow editLocationWindow = new("Add");
            editLocationWindow.ShowDialog();
        }

        private void DeleteLocationButton_Click(object sender, EventArgs e)
        {
            EditLocationWindow editLocationWindow = new("Delete");
            editLocationWindow.ShowDialog();
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            AddUserWindow addUserWindow = new();
            addUserWindow.ShowDialog();
        }

        private void DeleteUserButton_Click(object sender, EventArgs e)
        {

        }

        private void EditUserButton_Click(object sender, EventArgs e)
        {

        }
    }
}


