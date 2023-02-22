namespace HangameTetrisLauncher
{
    partial class FormMain
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
            this.bStart = new System.Windows.Forms.Button();
            this.bExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.gbRemember = new System.Windows.Forms.GroupBox();
            this.rAutoLogin = new System.Windows.Forms.RadioButton();
            this.rRemIDPass = new System.Windows.Forms.RadioButton();
            this.rRemID = new System.Windows.Forms.RadioButton();
            this.rRemNothing = new System.Windows.Forms.RadioButton();
            this.bOptions = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbChannel = new System.Windows.Forms.ComboBox();
            this.cbSkip = new System.Windows.Forms.CheckBox();
            this.gbRemember.SuspendLayout();
            this.SuspendLayout();
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(15, 114);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(75, 23);
            this.bStart.TabIndex = 4;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // bExit
            // 
            this.bExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bExit.Location = new System.Drawing.Point(96, 114);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(75, 23);
            this.bExit.TabIndex = 5;
            this.bExit.Text = "Exit";
            this.bExit.UseVisualStyleBackColor = true;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(110, 17);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(100, 20);
            this.tbID.TabIndex = 1;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(110, 43);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(100, 20);
            this.tbPassword.TabIndex = 3;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // gbRemember
            // 
            this.gbRemember.Controls.Add(this.rAutoLogin);
            this.gbRemember.Controls.Add(this.rRemIDPass);
            this.gbRemember.Controls.Add(this.rRemID);
            this.gbRemember.Controls.Add(this.rRemNothing);
            this.gbRemember.Location = new System.Drawing.Point(56, 157);
            this.gbRemember.Name = "gbRemember";
            this.gbRemember.Size = new System.Drawing.Size(157, 108);
            this.gbRemember.TabIndex = 7;
            this.gbRemember.TabStop = false;
            this.gbRemember.Text = "Remember";
            // 
            // rAutoLogin
            // 
            this.rAutoLogin.AutoSize = true;
            this.rAutoLogin.Location = new System.Drawing.Point(21, 79);
            this.rAutoLogin.Name = "rAutoLogin";
            this.rAutoLogin.Size = new System.Drawing.Size(76, 17);
            this.rAutoLogin.TabIndex = 3;
            this.rAutoLogin.TabStop = true;
            this.rAutoLogin.Text = "Auto Login";
            this.rAutoLogin.UseVisualStyleBackColor = true;
            this.rAutoLogin.Click += new System.EventHandler(this.rAutoLogin_Click);
            // 
            // rRemIDPass
            // 
            this.rRemIDPass.AutoSize = true;
            this.rRemIDPass.Checked = true;
            this.rRemIDPass.Location = new System.Drawing.Point(21, 19);
            this.rRemIDPass.Name = "rRemIDPass";
            this.rRemIDPass.Size = new System.Drawing.Size(94, 17);
            this.rRemIDPass.TabIndex = 0;
            this.rRemIDPass.TabStop = true;
            this.rRemIDPass.Text = "ID && Password";
            this.rRemIDPass.UseVisualStyleBackColor = true;
            // 
            // rRemID
            // 
            this.rRemID.AutoSize = true;
            this.rRemID.Location = new System.Drawing.Point(21, 39);
            this.rRemID.Name = "rRemID";
            this.rRemID.Size = new System.Drawing.Size(60, 17);
            this.rRemID.TabIndex = 1;
            this.rRemID.Text = "Only ID";
            this.rRemID.UseVisualStyleBackColor = true;
            // 
            // rRemNothing
            // 
            this.rRemNothing.AutoSize = true;
            this.rRemNothing.Location = new System.Drawing.Point(21, 59);
            this.rRemNothing.Name = "rRemNothing";
            this.rRemNothing.Size = new System.Drawing.Size(62, 17);
            this.rRemNothing.TabIndex = 2;
            this.rRemNothing.Text = "Nothing";
            this.rRemNothing.UseVisualStyleBackColor = true;
            // 
            // bOptions
            // 
            this.bOptions.Location = new System.Drawing.Point(178, 114);
            this.bOptions.Name = "bOptions";
            this.bOptions.Size = new System.Drawing.Size(75, 23);
            this.bOptions.TabIndex = 6;
            this.bOptions.Text = "Options";
            this.bOptions.UseVisualStyleBackColor = true;
            this.bOptions.Click += new System.EventHandler(this.bOptions_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Channel";
            // 
            // cbChannel
            // 
            this.cbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChannel.FormattingEnabled = true;
            this.cbChannel.Location = new System.Drawing.Point(110, 71);
            this.cbChannel.Name = "cbChannel";
            this.cbChannel.Size = new System.Drawing.Size(100, 21);
            this.cbChannel.TabIndex = 9;
            // 
            // cbSkip
            // 
            this.cbSkip.AutoSize = true;
            this.cbSkip.Location = new System.Drawing.Point(77, 271);
            this.cbSkip.Name = "cbSkip";
            this.cbSkip.Size = new System.Drawing.Size(88, 17);
            this.cbSkip.TabIndex = 10;
            this.cbSkip.Text = "Skip Updater";
            this.cbSkip.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AcceptButton = this.bStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bExit;
            this.ClientSize = new System.Drawing.Size(263, 295);
            this.Controls.Add(this.cbSkip);
            this.Controls.Add(this.cbChannel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bOptions);
            this.Controls.Add(this.gbRemember);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.bStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hangame Tetris Launcher";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.gbRemember.ResumeLayout(false);
            this.gbRemember.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.GroupBox gbRemember;
        private System.Windows.Forms.RadioButton rRemIDPass;
        private System.Windows.Forms.RadioButton rRemID;
        private System.Windows.Forms.RadioButton rRemNothing;
        private System.Windows.Forms.Button bOptions;
        private System.Windows.Forms.RadioButton rAutoLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbChannel;
        private System.Windows.Forms.CheckBox cbSkip;
    }
}

