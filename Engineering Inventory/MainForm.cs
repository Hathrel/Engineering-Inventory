namespace Engineering_Inventory
{
    // MainForm.cs
    public partial class MainForm : Form
    {
        private readonly PythonInterop pI;

        public MainForm(PythonInterop pythonInterop, dynamic permissions, string user_name)
        {
            pI = pythonInterop;
            InitializeComponent();
            string username = user_name;

            // Parse permissions
            Program.pickingPermission = permissions["Picking"];
            Program.insertPermission = permissions["Insert"];
            Program.editPermission = permissions["Edit"];
            Program.purchasePermission = permissions["Purchase"];

            welcomeLabel.Text = $"Welcome {username}, you are working in SITEHERE";
        }
        private void insertButton_Click(object sender, EventArgs e)
        {
            if (!Program.insertPermission)
            {
                MessageBox.Show("You don't have permission to do that!");
                return;
            }

            InsertInventory insertInventory = new(Program.insertPermission, pI);
            insertInventory.ShowDialog();
        }

        private void PickingButton_Click(object sender, EventArgs e)
        {
            if (!Program.pickingPermission)
            {
                MessageBox.Show("You don't have permission to do that!");
                return;
            }

            PickingInventory pickingInventory = new(Program.pickingPermission, pI);
            pickingInventory.ShowDialog();
        }
    }
}


