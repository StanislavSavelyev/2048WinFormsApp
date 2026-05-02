namespace _2048WinFormsApp
{
    public partial class MainForm : Form
    {
        private int mapWidth = 4;
        private int mapHeight = 4;
        private Label[,] labelsMap;
        private static Random random = new Random();
        private int score = 0;
        private string currentPlayerName = "Игрок";
        private SaveData saveData;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CreateUser();

            saveData = SaveRepository.Load();

            InitGame();

            GenerateNumber();

            ShowScore();
            ShowBestScore();
        }

        private void ShowBestScore()
        {
            bestScoreLabel.Text = saveData.BestScore.ToString();
        }

        private void ShowScore()
        {
            scoreLabel.Text = score.ToString();

            if (score > saveData.BestScore)
            {
                saveData.BestScore = score;
                ShowBestScore();
                SaveGame();
            }
        }

        private void SaveGame()
        {
            SaveRepository.Save(saveData);
        }

        private void InitGame()
        {
            labelsMap = new Label[mapHeight, mapWidth];

            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    var newLabel = CreateLabel(i, j);
                    gamePanel.Controls.Add(newLabel);
                    labelsMap[i, j] = newLabel;
                }
            }

            UpdateLabelsPositions();
        }

        private void GenerateNumber()
        {
            List<(int, int)> emptyCells = new List<(int, int)>();
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    if (labelsMap[i, j].Text == string.Empty)
                    {
                        emptyCells.Add((i, j));
                    }
                }
            }

            if (emptyCells.Count == 0)
            {
                return;
            }

            var randomCell = emptyCells[random.Next(emptyCells.Count)];
            var randomValue = random.Next(100);
            var value = randomValue < 75 ? "2" : "4";

            var numberValue = int.Parse(value);

            Label currentLabel = labelsMap[randomCell.Item1, randomCell.Item2];

            currentLabel.Text = value;
            currentLabel.BackColor = GetTileColor(numberValue);
        }

        private Label CreateLabel(int indexRow, int indexColumn)
        {
            var label = new Label();
            label.BackColor = SystemColors.ButtonShadow;
            label.BorderStyle = BorderStyle.FixedSingle;
            label.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label.TextAlign = ContentAlignment.MiddleCenter;

            return label;
        }

        private void UpdateLabelsPositions()
        {
            if (labelsMap == null) return;

            var padding = 20;

            var cellSize = Math.Min
            (
                (this.ClientSize.Width - padding * 2),
                (this.ClientSize.Height - padding * 2 - 50)
            ) / Math.Max(mapWidth, mapHeight);

            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    labelsMap[i, j].Size = new Size(cellSize, cellSize);
                    labelsMap[i, j].Location = new Point(padding + j * cellSize, padding + i * cellSize);
                }
            }
        }

        private void MoveTilesAndMerge(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                MoveRight();
            }
            if (e.KeyCode == Keys.Left)
            {
                MoveLeft();
            }
            if (e.KeyCode == Keys.Up)
            {
                MoveUp();
            }
            if (e.KeyCode == Keys.Down)
            {
                MoveDown();
            }
        }
        private void MoveRight()
        {
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = mapWidth - 1; j >= 0; j--)
                {
                    if (labelsMap[i, j].Text != string.Empty)
                    {
                        for (int k = j - 1; k >= 0; k--)
                        {
                            if (labelsMap[i, k].Text != string.Empty)
                            {
                                if (labelsMap[i, j].Text == labelsMap[i, k].Text)
                                {
                                    var number = int.Parse(labelsMap[i, k].Text);
                                    score += number * 2;
                                    var newNumber = number * 2;

                                    labelsMap[i, j].Text = (number * 2).ToString();
                                    labelsMap[i, k].Text = string.Empty;

                                    labelsMap[i, j].BackColor = GetTileColor(newNumber);
                                    labelsMap[i, k].BackColor = SystemColors.ButtonShadow;
                                }
                                break;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = mapWidth - 1; j >= 0; j--)
                {
                    if (labelsMap[i, j].Text == string.Empty)
                    {
                        for (int k = j - 1; k >= 0; k--)
                        {
                            if (labelsMap[i, k].Text != string.Empty)
                            {
                                labelsMap[i, j].Text = labelsMap[i, k].Text;
                                labelsMap[i, j].BackColor = labelsMap[i, k].BackColor;
                                labelsMap[i, k].Text = string.Empty;
                                labelsMap[i, k].BackColor = SystemColors.ButtonShadow;
                                break;
                            }
                        }
                    }
                }
            }

            GenerateNumber();
            ShowScore();

            if (IsGameOver())
            {
                EndGame();
            }
        }

        private void MoveLeft()
        {
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    if (labelsMap[i, j].Text != string.Empty)
                    {
                        for (int k = j + 1; k < mapWidth; k++)
                        {
                            if (labelsMap[i, k].Text != string.Empty)
                            {
                                if (labelsMap[i, j].Text == labelsMap[i, k].Text)
                                {
                                    var number = int.Parse(labelsMap[i, k].Text);
                                    score += number * 2;
                                    var newNumber = number * 2;

                                    labelsMap[i, j].Text = (number * 2).ToString();
                                    labelsMap[i, k].Text = string.Empty;

                                    labelsMap[i, j].BackColor = GetTileColor(newNumber);
                                    labelsMap[i, k].BackColor = SystemColors.ButtonShadow;
                                }
                                break;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    if (labelsMap[i, j].Text == string.Empty)
                    {
                        for (int k = j + 1; k < mapWidth; k++)
                        {
                            if (labelsMap[i, k].Text != string.Empty)
                            {
                                labelsMap[i, j].Text = labelsMap[i, k].Text;
                                labelsMap[i, j].BackColor = labelsMap[i, k].BackColor;
                                labelsMap[i, k].Text = string.Empty;
                                labelsMap[i, k].BackColor = SystemColors.ButtonShadow;
                                break;
                            }
                        }
                    }
                }
            }

            GenerateNumber();
            ShowScore();

            if (IsGameOver())
            {
                EndGame();
            }
        }

        private void MoveUp()
        {
            for (int j = 0; j < mapWidth; j++)
            {
                for (int i = 0; i < mapHeight; i++)
                {
                    if (labelsMap[i, j].Text != string.Empty)
                    {
                        for (int k = i + 1; k < mapHeight; k++)
                        {
                            if (labelsMap[k, j].Text != string.Empty)
                            {
                                if (labelsMap[i, j].Text == labelsMap[k, j].Text)
                                {
                                    var number = int.Parse(labelsMap[k, j].Text);
                                    score += number * 2;
                                    var newNumber = number * 2;

                                    labelsMap[i, j].Text = (number * 2).ToString();
                                    labelsMap[k, j].Text = string.Empty;

                                    labelsMap[i, j].BackColor = GetTileColor(newNumber);
                                    labelsMap[k, j].BackColor = SystemColors.ButtonShadow;
                                }
                                break;
                            }
                        }
                    }
                }
            }

            for (int j = 0; j < mapWidth; j++)
            {
                for (int i = 0; i < mapHeight; i++)
                {
                    if (labelsMap[i, j].Text == string.Empty)
                    {
                        for (int k = i + 1; k < mapHeight; k++)
                        {
                            if (labelsMap[k, j].Text != string.Empty)
                            {
                                labelsMap[i, j].Text = labelsMap[k, j].Text;
                                labelsMap[i, j].BackColor = labelsMap[k, j].BackColor;
                                labelsMap[k, j].Text = string.Empty;
                                labelsMap[k, j].BackColor = SystemColors.ButtonShadow;
                                break;
                            }
                        }
                    }
                }
            }

            GenerateNumber();
            ShowScore();

            if (IsGameOver())
            {
                EndGame();
            }
        }

        private void MoveDown()
        {
            for (int j = 0; j < mapWidth; j++)
            {
                for (int i = mapHeight - 1; i >= 0; i--)
                {
                    if (labelsMap[i, j].Text != string.Empty)
                    {
                        for (int k = i - 1; k >= 0; k--)
                        {
                            if (labelsMap[k, j].Text != string.Empty)
                            {
                                if (labelsMap[i, j].Text == labelsMap[k, j].Text)
                                {
                                    var number = int.Parse(labelsMap[k, j].Text);
                                    score += number * 2;
                                    var newNumber = number * 2;

                                    labelsMap[i, j].Text = (number * 2).ToString();
                                    labelsMap[k, j].Text = string.Empty;

                                    labelsMap[i, j].BackColor = GetTileColor(newNumber);
                                    labelsMap[k, j].BackColor = SystemColors.ButtonShadow;
                                }
                                break;
                            }
                        }
                    }
                }
            }

            for (int j = 0; j < mapWidth; j++)
            {
                for (int i = mapHeight - 1; i >= 0; i--)
                {
                    if (labelsMap[i, j].Text == string.Empty)
                    {
                        for (int k = i - 1; k >= 0; k--)
                        {
                            if (labelsMap[k, j].Text != string.Empty)
                            {
                                labelsMap[i, j].Text = labelsMap[k, j].Text;
                                labelsMap[i, j].BackColor = labelsMap[k, j].BackColor;
                                labelsMap[k, j].Text = string.Empty;
                                labelsMap[k, j].BackColor = SystemColors.ButtonShadow;
                                break;
                            }
                        }
                    }
                }
            }

            GenerateNumber();
            ShowScore();

            if (IsGameOver())
            {
                EndGame();
            }
        }

        private void EndGame()
        {
            saveData.History.Add(new GameResult(currentPlayerName) { Score = score });
            SaveGame();
            MessageBox.Show($"Игра окончена! Ваш счёт: {score}", "2048");
        }

        private void RulesGameClick(object sender, EventArgs e)
        {
            MessageBox.Show("Игра 2048 — логическая головоломка, " +
                "цель которой — получить плитку с номиналом «2048», " +
                "объединяя одинаковые числа (2, 4, 8... 1024, 2048). " +
                "Плитки сдвигаются стрелками, при столкновении суммируются, " +
                "а после каждого хода появляется новая «2» или «4». Игра заканчивается, " +
                "когда поле заполнено и ходы невозможны.");
        }

        private void RestartClick(object sender, EventArgs e)
        {
            score = 0;
            ShowScore();

            if (labelsMap != null)
            {
                for (int i = 0; i < labelsMap.GetLength(0); i++)
                {
                    for (int j = 0; j < labelsMap.GetLength(1); j++)
                    {
                        gamePanel.Controls.Remove(labelsMap[i, j]);
                    }
                }
                labelsMap = null;
            }

            InitGame();
            GenerateNumber();
            UpdateLabelsPositions();
        }

        private void ExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool IsMovePossible()
        {
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    if (labelsMap[i, j].Text == string.Empty)
                        return true;
                }
            }

            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    if (j + 1 < mapWidth && labelsMap[i, j].Text == labelsMap[i, j + 1].Text)
                        return true;

                    if (i + 1 < mapHeight && labelsMap[i, j].Text == labelsMap[i + 1, j].Text)
                        return true;
                }
            }

            return false;
        }

        private bool IsGameOver()
        {
            return !IsMovePossible();
        }

        private void CreateUser()
        {
            Hide();

            UserNameForm userResult = new UserNameForm();
            userResult.ShowDialog();
            currentPlayerName = userResult.Name;

            Show();
        }

        private void HistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();

            var historyForm = new HistoryForm(saveData.History);
            historyForm.ShowDialog();

            Show();
        }

        private void SettingMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settingMapForm = new SettingMapForm(mapWidth, mapHeight);

            if (settingMapForm.ShowDialog() == DialogResult.OK)
            {
                mapWidth = settingMapForm.MapWidth;
                mapHeight = settingMapForm.MapHeight;

                RestartClick(sender, e);
            }
        }

        private Color GetTileColor(int value)
        {
            switch (value)
            {
                case 2: return Color.FromArgb(238, 228, 218);
                case 4: return Color.FromArgb(237, 224, 200);
                case 8: return Color.FromArgb(242, 177, 121);
                case 16: return Color.FromArgb(245, 149, 99);
                case 32: return Color.FromArgb(246, 124, 95);
                case 64: return Color.FromArgb(246, 94, 59);
                case 128: return Color.FromArgb(237, 207, 114);
                case 256: return Color.FromArgb(237, 204, 97);
                case 512: return Color.FromArgb(237, 200, 80);
                case 1024: return Color.FromArgb(237, 197, 63);
                case 2048: return Color.FromArgb(237, 194, 46);

                default:
                    int shade = 238 - (int)Math.Log(value, 2) * 5;
                    shade = Math.Max(0, shade);
                    return Color.FromArgb(shade, shade, shade);
            }
        }
    }
}
