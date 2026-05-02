namespace _2048WinFormsApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            scoreLabel = new Label();
            menuStrip1 = new MenuStrip();
            менюToolStripMenuItem = new ToolStripMenuItem();
            RulesGame = new ToolStripMenuItem();
            Restart = new ToolStripMenuItem();
            SettingMapToolStripMenuItem = new ToolStripMenuItem();
            Exit = new ToolStripMenuItem();
            HistoryToolStripMenuItem = new ToolStripMenuItem();
            label2 = new Label();
            bestScoreLabel = new Label();
            gamePanel = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 34);
            label1.Name = "label1";
            label1.Size = new Size(47, 20);
            label1.TabIndex = 0;
            label1.Text = "Счет :";
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.Location = new Point(58, 34);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(17, 20);
            scoreLabel.TabIndex = 1;
            scoreLabel.Text = "0";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { менюToolStripMenuItem, HistoryToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(544, 28);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            менюToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { RulesGame, Restart, SettingMapToolStripMenuItem, Exit });
            менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            менюToolStripMenuItem.Size = new Size(65, 24);
            менюToolStripMenuItem.Text = "Меню";
            // 
            // RulesGame
            // 
            RulesGame.Name = "RulesGame";
            RulesGame.Size = new Size(255, 26);
            RulesGame.Text = "Правила игры";
            RulesGame.Click += RulesGameClick;
            // 
            // Restart
            // 
            Restart.Name = "Restart";
            Restart.Size = new Size(255, 26);
            Restart.Text = "Начать заново";
            Restart.Click += RestartClick;
            // 
            // SettingMapToolStripMenuItem
            // 
            SettingMapToolStripMenuItem.Name = "SettingMapToolStripMenuItem";
            SettingMapToolStripMenuItem.Size = new Size(255, 26);
            SettingMapToolStripMenuItem.Text = "Изменить размер поля";
            SettingMapToolStripMenuItem.Click += SettingMapToolStripMenuItem_Click;
            // 
            // Exit
            // 
            Exit.Name = "Exit";
            Exit.Size = new Size(255, 26);
            Exit.Text = "Выйти";
            Exit.Click += ExitClick;
            // 
            // HistoryToolStripMenuItem
            // 
            HistoryToolStripMenuItem.Name = "HistoryToolStripMenuItem";
            HistoryToolStripMenuItem.Size = new Size(110, 24);
            HistoryToolStripMenuItem.Text = "История игр";
            HistoryToolStripMenuItem.Click += HistoryToolStripMenuItem_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(146, 34);
            label2.Name = "label2";
            label2.Size = new Size(104, 20);
            label2.TabIndex = 3;
            label2.Text = "Лучший счет :";
            // 
            // bestScoreLabel
            // 
            bestScoreLabel.AutoSize = true;
            bestScoreLabel.Location = new Point(256, 34);
            bestScoreLabel.Name = "bestScoreLabel";
            bestScoreLabel.Size = new Size(17, 20);
            bestScoreLabel.TabIndex = 4;
            bestScoreLabel.Text = "0";
            // 
            // gamePanel
            // 
            gamePanel.Location = new Point(1, 67);
            gamePanel.Name = "gamePanel";
            gamePanel.Size = new Size(543, 526);
            gamePanel.TabIndex = 5;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(544, 592);
            Controls.Add(gamePanel);
            Controls.Add(bestScoreLabel);
            Controls.Add(label2);
            Controls.Add(scoreLabel);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "MainForm";
            Text = "2048";
            Load += MainForm_Load;
            KeyDown += MoveTilesAndMerge;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label scoreLabel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem менюToolStripMenuItem;
        private ToolStripMenuItem RulesGame;
        private ToolStripMenuItem Restart;
        private ToolStripMenuItem Exit;
        private Label label2;
        private Label bestScoreLabel;
        private ToolStripMenuItem HistoryToolStripMenuItem;
        private ToolStripMenuItem SettingMapToolStripMenuItem;
        private Panel gamePanel;
    }
}
