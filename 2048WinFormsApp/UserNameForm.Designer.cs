namespace _2048WinFormsApp
{
    partial class UserNameForm
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
            UserNameLabel = new Label();
            UserNameTextBox = new TextBox();
            SaveNameButton = new Button();
            SuspendLayout();
            // 
            // UserNameLabel
            // 
            UserNameLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            UserNameLabel.Location = new Point(122, 61);
            UserNameLabel.Name = "UserNameLabel";
            UserNameLabel.Size = new Size(232, 25);
            UserNameLabel.TabIndex = 0;
            UserNameLabel.Text = "Введите ваше имя";
            // 
            // UserNameTextBox
            // 
            UserNameTextBox.Location = new Point(122, 127);
            UserNameTextBox.Name = "UserNameTextBox";
            UserNameTextBox.Size = new Size(211, 27);
            UserNameTextBox.TabIndex = 1;
            // 
            // SaveNameButton
            // 
            SaveNameButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            SaveNameButton.Location = new Point(151, 186);
            SaveNameButton.Name = "SaveNameButton";
            SaveNameButton.Size = new Size(140, 56);
            SaveNameButton.TabIndex = 2;
            SaveNameButton.Text = "Сохранить";
            SaveNameButton.UseVisualStyleBackColor = true;
            SaveNameButton.Click += SaveNameButton_Click;
            // 
            // UserName
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(462, 280);
            Controls.Add(SaveNameButton);
            Controls.Add(UserNameTextBox);
            Controls.Add(UserNameLabel);
            Name = "UserName";
            Text = "UserName";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label UserNameLabel;
        private TextBox UserNameTextBox;
        private Button SaveNameButton;
    }
}