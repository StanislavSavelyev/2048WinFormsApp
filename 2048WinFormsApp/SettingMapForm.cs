namespace _2048WinFormsApp
{
    public partial class SettingMapForm : Form
    {
        public int MapHeight { get; private set; }
        public int MapWidth { get; private set; }

        public SettingMapForm(int currentWidth, int currentHeight)
        {
            InitializeComponent();

            MapHeightTextBox.Text = currentHeight.ToString();
            MapWidthTextBox.Text = currentWidth.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(MapWidthTextBox.Text, out int width) && int.TryParse(MapHeightTextBox.Text, out int height))
            {
                if(height > 3 && width > 3)
                {
                    MapHeight = height;
                    MapWidth = width;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Поле не должно быть меньше чем 3 на 3");
                }
            }
            else
            {
                MessageBox.Show("Введенные данные должны быть цифрами, попробуйте еще раз!");
            }
        }
    }
}
