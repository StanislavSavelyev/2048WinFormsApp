using System.Data;

namespace _2048WinFormsApp
{
    public partial class HistoryForm : Form
    {
        public HistoryForm(List<GameResult> history)
        {
            InitializeComponent();

            string historyText;

            if (history == null || history.Count == 0)
            {
                historyText = "История пуста. Сыграйте в игру!";
            }
            else
            {
                historyText = string.Join(Environment.NewLine, history.Select(r => $"{r.Name}: {r.Score}"));
            }

            historyTextBox.Text = historyText;
        }
    }
}
