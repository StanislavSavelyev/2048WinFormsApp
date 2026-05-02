namespace _2048WinFormsApp
{
    partial class HistoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            historyTextBox = new TextBox();
            SuspendLayout();
            // 
            // historyTextBox
            // 
            historyTextBox.Location = new Point(2, 1);
            historyTextBox.Multiline = true;
            historyTextBox.Name = "historyTextBox";
            historyTextBox.ReadOnly = true;
            historyTextBox.ScrollBars = ScrollBars.Vertical;
            historyTextBox.Size = new Size(797, 448);
            historyTextBox.TabIndex = 0;
            // 
            // HistoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(historyTextBox);
            Name = "HistoryForm";
            Text = "HistoryForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox historyTextBox;
    }
}