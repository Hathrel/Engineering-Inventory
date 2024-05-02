namespace Engineering_Inventory
{
    // MainForm.cs
    public partial class MainForm : Form
    {
        private readonly PythonInterop pI;
        private bool pickingPermission;
        private bool insertPermission;
        private bool editPermission;
        private bool purchasePermission;

        public MainForm(PythonInterop pythonInterop, dynamic permissions, string user_name)
        {
            pI = pythonInterop;
            InitializeComponent();
            string username = user_name;
            welcomeLabel.Text = $"Welcome {username}";

            // Parse permissions
            pickingPermission = permissions["Picking"];
            insertPermission = permissions["Insert"];
            editPermission = permissions["Edit"];
            purchasePermission = permissions["Purchase"];
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            if (!insertPermission)
            {
                MessageBox.Show("You don't have permission to do that!");
                return;
            }

            InsertInventory insertInventory = new(insertPermission, pI);
                insertInventory.ShowDialog();
        }
    }
}


