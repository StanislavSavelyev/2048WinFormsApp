namespace _2048WinFormsApp
{
    public partial class UserNameForm : Form
    {
        public string Name { get; private set; }

        public UserNameForm()
        {
            InitializeComponent();
        }

        private void SaveNameButton_Click(object sender, EventArgs e)
        {
            if (GetName())
            {
                Name = UserNameTextBox.Text;
                Close();
                return;
            }

            MessageBox.Show("Веденные данные являются цифрой, попробуйте еще раз!");
        }

        private bool GetName()
        {
            return !int.TryParse(UserNameTextBox.Text, out int _);
        }
    }
}
