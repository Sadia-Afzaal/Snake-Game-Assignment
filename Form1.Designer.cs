namespace WinFormsApp1
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            gamePanel = new Panel();
            startPanel = new Panel();
            lblInstructions = new Label();
            lblTitle = new Label();
            lblScore = new Label();
            lblHighScore = new Label();
            btnStart = new Button();
            btnPause = new Button();
            lblMsg = new Label();
            comboSpeed = new ComboBox();
            gameOverPanel = new Panel();
            btnRestart = new Button();
            lblMessage = new Label();
            gameTimer = new System.Windows.Forms.Timer(components);
            gamePanel.SuspendLayout();
            startPanel.SuspendLayout();
            gameOverPanel.SuspendLayout();
            SuspendLayout();
            // 
            // gamePanel
            // 
            gamePanel.BorderStyle = BorderStyle.FixedSingle;
            gamePanel.Controls.Add(startPanel);
            gamePanel.Location = new Point(10, 10);
            gamePanel.Name = "gamePanel";
            gamePanel.Size = new Size(400, 400);
            gamePanel.TabIndex = 0;
            gamePanel.Paint += gamePanel_Paint;
            // 
            // startPanel
            // 
            startPanel.BackColor = Color.LightGray;
            startPanel.Controls.Add(lblInstructions);
            startPanel.Controls.Add(lblTitle);
            startPanel.Location = new Point(-1, -1);
            startPanel.Name = "startPanel";
            startPanel.Size = new Size(400, 400);
            startPanel.TabIndex = 0;
            // 
            // lblInstructions
            // 
            lblInstructions.AutoSize = true;
            lblInstructions.Font = new Font("Segoe UI Light", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInstructions.Location = new Point(20, 120);
            lblInstructions.Name = "lblInstructions";
            lblInstructions.Size = new Size(285, 140);
            lblInstructions.TabIndex = 1;
            lblInstructions.Text = "Use arrow keys to move.\r\nEat food to grow (+10 points).\r\nDon't hit walls or your own body.\r\nPause with the Pause button.\r\nChoose difficulty and press Start.\r\n";
            lblInstructions.Click += label1_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(120, 40);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(184, 65);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "SNAKE";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblScore.Location = new Point(430, 20);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(105, 32);
            lblScore.TabIndex = 1;
            lblScore.Text = "Score: 0";
            // 
            // lblHighScore
            // 
            lblHighScore.AutoSize = true;
            lblHighScore.Font = new Font("Segoe UI Light", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHighScore.Location = new Point(430, 66);
            lblHighScore.Name = "lblHighScore";
            lblHighScore.Size = new Size(123, 28);
            lblHighScore.TabIndex = 2;
            lblHighScore.Text = "High Score: 0";
            lblHighScore.Click += label1_Click;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(430, 118);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(180, 40);
            btnStart.TabIndex = 3;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnPause
            // 
            btnPause.Enabled = false;
            btnPause.Location = new Point(430, 183);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(180, 40);
            btnPause.TabIndex = 4;
            btnPause.Text = "Pause";
            btnPause.UseVisualStyleBackColor = true;
            btnPause.Click += btnPause_Click;
            // 
            // lblMsg
            // 
            lblMsg.AutoSize = true;
            lblMsg.Location = new Point(542, 309);
            lblMsg.Name = "lblMsg";
            lblMsg.Size = new Size(0, 25);
            lblMsg.TabIndex = 5;
            // 
            // comboSpeed
            // 
            comboSpeed.DropDownStyle = ComboBoxStyle.DropDownList;
            comboSpeed.DropDownWidth = 180;
            comboSpeed.FormattingEnabled = true;
            comboSpeed.Items.AddRange(new object[] { "Easy", "Normal", "Hard" });
            comboSpeed.Location = new Point(428, 246);
            comboSpeed.Name = "comboSpeed";
            comboSpeed.Size = new Size(182, 33);
            comboSpeed.TabIndex = 6;
            // 
            // gameOverPanel
            // 
            gameOverPanel.BackColor = Color.Black;
            gameOverPanel.Controls.Add(btnRestart);
            gameOverPanel.Controls.Add(lblMessage);
            gameOverPanel.Location = new Point(10, 10);
            gameOverPanel.Name = "gameOverPanel";
            gameOverPanel.Size = new Size(400, 400);
            gameOverPanel.TabIndex = 2;
            gameOverPanel.Visible = false;
            // 
            // btnRestart
            // 
            btnRestart.Location = new Point(40, 295);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(100, 36);
            btnRestart.TabIndex = 1;
            btnRestart.Text = "Restart";
            btnRestart.UseVisualStyleBackColor = true;
            btnRestart.Click += btnRestart_Click;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMessage.ForeColor = Color.White;
            lblMessage.Location = new Point(40, 80);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(207, 48);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "Game Over";
            // 
            // gameTimer
            // 
            gameTimer.Tick += gameTimer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(778, 544);
            Controls.Add(gameOverPanel);
            Controls.Add(comboSpeed);
            Controls.Add(lblMsg);
            Controls.Add(btnPause);
            Controls.Add(btnStart);
            Controls.Add(lblHighScore);
            Controls.Add(lblScore);
            Controls.Add(gamePanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Snake Game";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            gamePanel.ResumeLayout(false);
            startPanel.ResumeLayout(false);
            startPanel.PerformLayout();
            gameOverPanel.ResumeLayout(false);
            gameOverPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel gamePanel;
        private Label lblScore;
        private Label lblHighScore;
        private Button btnStart;
        private Button btnPause;
        private Label lblMsg;
        private ComboBox comboSpeed;
        private Panel startPanel;
        private Label lblInstructions;
        private Label lblTitle;
        private Panel gameOverPanel;
        private Label lblMessage;
        private Button btnRestart;
        private System.Windows.Forms.Timer gameTimer;
    }
}
