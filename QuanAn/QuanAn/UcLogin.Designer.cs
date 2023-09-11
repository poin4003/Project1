namespace QuanAn
{
    partial class UcLogin
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.StatusLb = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ShowPasswordCb = new System.Windows.Forms.CheckBox();
            this.PasswordTb = new System.Windows.Forms.TextBox();
            this.PasswordLb = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.UserNameCb = new System.Windows.Forms.ComboBox();
            this.UserNameLb = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.StatusLb);
            this.panel1.Controls.Add(this.LoginButton);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(30, 349);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1726, 500);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // StatusLb
            // 
            this.StatusLb.AutoSize = true;
            this.StatusLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLb.Location = new System.Drawing.Point(50, 391);
            this.StatusLb.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.StatusLb.Name = "StatusLb";
            this.StatusLb.Size = new System.Drawing.Size(283, 39);
            this.StatusLb.TabIndex = 4;
            this.StatusLb.Text = "Chưa đăng nhập";
            // 
            // LoginButton
            // 
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginButton.Location = new System.Drawing.Point(1184, 364);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(6);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(286, 93);
            this.LoginButton.TabIndex = 3;
            this.LoginButton.Text = "Đăng nhập";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ShowPasswordCb);
            this.panel3.Controls.Add(this.PasswordTb);
            this.panel3.Controls.Add(this.PasswordLb);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(24, 221);
            this.panel3.Margin = new System.Windows.Forms.Padding(6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1678, 99);
            this.panel3.TabIndex = 2;
            // 
            // ShowPasswordCb
            // 
            this.ShowPasswordCb.AutoSize = true;
            this.ShowPasswordCb.Location = new System.Drawing.Point(1458, 35);
            this.ShowPasswordCb.Margin = new System.Windows.Forms.Padding(6);
            this.ShowPasswordCb.Name = "ShowPasswordCb";
            this.ShowPasswordCb.Size = new System.Drawing.Size(201, 50);
            this.ShowPasswordCb.TabIndex = 4;
            this.ShowPasswordCb.Text = "Hiển thị";
            this.ShowPasswordCb.UseVisualStyleBackColor = true;
            this.ShowPasswordCb.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // PasswordTb
            // 
            this.PasswordTb.Location = new System.Drawing.Point(440, 27);
            this.PasswordTb.Margin = new System.Windows.Forms.Padding(6);
            this.PasswordTb.Name = "PasswordTb";
            this.PasswordTb.PasswordChar = '*';
            this.PasswordTb.Size = new System.Drawing.Size(1002, 53);
            this.PasswordTb.TabIndex = 2;
            this.PasswordTb.Text = "12345";
            // 
            // PasswordLb
            // 
            this.PasswordLb.AutoSize = true;
            this.PasswordLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLb.Location = new System.Drawing.Point(24, 33);
            this.PasswordLb.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.PasswordLb.Name = "PasswordLb";
            this.PasswordLb.Size = new System.Drawing.Size(215, 46);
            this.PasswordLb.TabIndex = 0;
            this.PasswordLb.Text = "Mật khẩu: ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.UserNameCb);
            this.panel2.Controls.Add(this.UserNameLb);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(24, 85);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1678, 103);
            this.panel2.TabIndex = 1;
            // 
            // UserNameCb
            // 
            this.UserNameCb.FormattingEnabled = true;
            this.UserNameCb.Location = new System.Drawing.Point(440, 27);
            this.UserNameCb.Name = "UserNameCb";
            this.UserNameCb.Size = new System.Drawing.Size(1006, 54);
            this.UserNameCb.TabIndex = 1;
            this.UserNameCb.SelectedIndexChanged += new System.EventHandler(this.UserNameCb_SelectedIndexChanged);
            // 
            // UserNameLb
            // 
            this.UserNameLb.AutoSize = true;
            this.UserNameLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameLb.Location = new System.Drawing.Point(24, 27);
            this.UserNameLb.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.UserNameLb.Name = "UserNameLb";
            this.UserNameLb.Size = new System.Drawing.Size(323, 46);
            this.UserNameLb.TabIndex = 0;
            this.UserNameLb.Text = "Tên đăng nhập: ";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1366, 647);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(16, 16);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::QuanAn.Properties.Resources.Project__2_;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1784, 1190);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // UcLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "UcLogin";
            this.Size = new System.Drawing.Size(1784, 1190);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox PasswordTb;
        private System.Windows.Forms.Label PasswordLb;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label UserNameLb;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox ShowPasswordCb;
        private System.Windows.Forms.Label StatusLb;
        private System.Windows.Forms.ComboBox UserNameCb;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
