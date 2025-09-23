namespace CertificateGenerator
{
    public partial class MainForm : Form
    {
        private static readonly Dictionary<string, string> employeers = EmployeeStorage.GetEmployees();
        public static string _selectedFolderOlimpiads = string.Empty;
        public static string _selectedFolderCertificate= string.Empty;
        public static string studentsSex = string.Empty;
        public static string employeeFIO = string.Empty;
        public static string employeePosition = string.Empty;
        public static ProgressBar _staticProgressBar;

        public MainForm()
        {
            InitializeComponent();
            EmployeeComboBox.SelectedIndexChanged += new EventHandler(EmployeeComboBox_SelectedIndexChanged);
            _staticProgressBar = this.FilesProgressBar;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MaleRadioButton.Checked = true;
            foreach (var employee in employeers)
            {
                EmployeeComboBox.Items.Add(employee.Key);
            }
            EmployeeComboBox.SelectedIndex = 0;
        }

        private void CerticateGeneratorButton_ClickAsync(object sender, EventArgs e)
        {
            Student student = new Student(firstNameTextBox.Text, secondNameTextBox.Text, lastNameTextBox.Text, loginSGTextBox.Text, StudyClassTextBox.Text, StudentIDTextBox.Text);
            if (MaleRadioButton.Checked) studentsSex = "он";
            else if (FemaleRadioButton.Checked) studentsSex = "она";
            CreateWordDocument.CreateDocx(student);
            MessageBox.Show("Справка сформирована");
            Application.Exit();
        }

        private void EmployeeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmployeeTextBox.Text = employeers[EmployeeComboBox.Text];
            employeePosition = EmployeeTextBox.Text;
            employeeFIO = EmployeeComboBox.Text;
        }

        private void buttonOlimpiadsSelectFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Выберите папку с итогами олимпиад";
                folderDialog.ShowNewFolderButton = false;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderDialog.SelectedPath;
                    _selectedFolderOlimpiads = selectedPath;
                    OlimpiadsSelectedFolderLabel.Text = selectedPath;
                }
            }
        }

        private void buttonCertificateSelectedFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Выберите папку для справки";
                folderDialog.ShowNewFolderButton = false;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderDialog.SelectedPath;
                    _selectedFolderCertificate = selectedPath;
                    CertificateSelectedFolderLabel.Text = selectedPath;
                }
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
