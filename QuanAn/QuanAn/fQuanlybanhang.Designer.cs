using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace QuanAn
{
    partial class fQuanlyBanHang
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
            this.ToolPanel = new System.Windows.Forms.Panel();
            this.MaNVLb = new System.Windows.Forms.Label();
            this.AccountLb = new System.Windows.Forms.Label();
            this.LoadUcDoanhThuButton = new System.Windows.Forms.Button();
            this.LoadUcThucDonButton = new System.Windows.Forms.Button();
            this.LogOutButton = new System.Windows.Forms.Button();
            this.LoadUcQuanLyButton = new System.Windows.Forms.Button();
            this.LoadDonHangButton = new System.Windows.Forms.Button();
            this.LoadUcLoginButton = new System.Windows.Forms.Button();
            this.UserPanel = new System.Windows.Forms.Panel();
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.StaffPanel = new System.Windows.Forms.Panel();
            this.ToolPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolPanel
            // 
            this.ToolPanel.BackColor = System.Drawing.Color.Silver;
            this.ToolPanel.Controls.Add(this.MaNVLb);
            this.ToolPanel.Controls.Add(this.AccountLb);
            this.ToolPanel.Controls.Add(this.LoadUcDoanhThuButton);
            this.ToolPanel.Controls.Add(this.LoadUcThucDonButton);
            this.ToolPanel.Controls.Add(this.LogOutButton);
            this.ToolPanel.Controls.Add(this.LoadUcQuanLyButton);
            this.ToolPanel.Controls.Add(this.LoadDonHangButton);
            this.ToolPanel.Controls.Add(this.LoadUcLoginButton);
            this.ToolPanel.Location = new System.Drawing.Point(6, 10);
            this.ToolPanel.Margin = new System.Windows.Forms.Padding(6);
            this.ToolPanel.Name = "ToolPanel";
            this.ToolPanel.Size = new System.Drawing.Size(338, 1250);
            this.ToolPanel.TabIndex = 0;
            // 
            // MaNVLb
            // 
            this.MaNVLb.AutoSize = true;
            this.MaNVLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaNVLb.Location = new System.Drawing.Point(6, 56);
            this.MaNVLb.Name = "MaNVLb";
            this.MaNVLb.Size = new System.Drawing.Size(0, 32);
            this.MaNVLb.TabIndex = 9;
            // 
            // AccountLb
            // 
            this.AccountLb.AutoSize = true;
            this.AccountLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountLb.Location = new System.Drawing.Point(6, 8);
            this.AccountLb.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.AccountLb.Name = "AccountLb";
            this.AccountLb.Size = new System.Drawing.Size(0, 36);
            this.AccountLb.TabIndex = 8;
            // 
            // LoadUcDoanhThuButton
            // 
            this.LoadUcDoanhThuButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LoadUcDoanhThuButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LoadUcDoanhThuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadUcDoanhThuButton.Location = new System.Drawing.Point(6, 659);
            this.LoadUcDoanhThuButton.Margin = new System.Windows.Forms.Padding(6);
            this.LoadUcDoanhThuButton.Name = "LoadUcDoanhThuButton";
            this.LoadUcDoanhThuButton.Size = new System.Drawing.Size(326, 122);
            this.LoadUcDoanhThuButton.TabIndex = 7;
            this.LoadUcDoanhThuButton.Text = "Doanh thu";
            this.LoadUcDoanhThuButton.UseVisualStyleBackColor = false;
            this.LoadUcDoanhThuButton.Click += new System.EventHandler(this.LoadUcDoanhThuButton_Click);
            // 
            // LoadUcThucDonButton
            // 
            this.LoadUcThucDonButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LoadUcThucDonButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LoadUcThucDonButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadUcThucDonButton.Location = new System.Drawing.Point(6, 513);
            this.LoadUcThucDonButton.Margin = new System.Windows.Forms.Padding(6);
            this.LoadUcThucDonButton.Name = "LoadUcThucDonButton";
            this.LoadUcThucDonButton.Size = new System.Drawing.Size(326, 122);
            this.LoadUcThucDonButton.TabIndex = 6;
            this.LoadUcThucDonButton.Text = "Thực đơn";
            this.LoadUcThucDonButton.UseVisualStyleBackColor = false;
            this.LoadUcThucDonButton.Click += new System.EventHandler(this.LoadUcThucDonButton_Click);
            // 
            // LogOutButton
            // 
            this.LogOutButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LogOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LogOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOutButton.Location = new System.Drawing.Point(6, 1162);
            this.LogOutButton.Margin = new System.Windows.Forms.Padding(6);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(326, 76);
            this.LogOutButton.TabIndex = 4;
            this.LogOutButton.Text = "Đăng xuất";
            this.LogOutButton.UseVisualStyleBackColor = false;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // LoadUcQuanLyButton
            // 
            this.LoadUcQuanLyButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LoadUcQuanLyButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LoadUcQuanLyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadUcQuanLyButton.Location = new System.Drawing.Point(6, 368);
            this.LoadUcQuanLyButton.Margin = new System.Windows.Forms.Padding(6);
            this.LoadUcQuanLyButton.Name = "LoadUcQuanLyButton";
            this.LoadUcQuanLyButton.Size = new System.Drawing.Size(326, 122);
            this.LoadUcQuanLyButton.TabIndex = 2;
            this.LoadUcQuanLyButton.Text = "Quản lý nhân viên";
            this.LoadUcQuanLyButton.UseVisualStyleBackColor = false;
            this.LoadUcQuanLyButton.Click += new System.EventHandler(this.LoadUcQuanLyButton_Click);
            // 
            // LoadDonHangButton
            // 
            this.LoadDonHangButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LoadDonHangButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LoadDonHangButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadDonHangButton.Location = new System.Drawing.Point(6, 223);
            this.LoadDonHangButton.Margin = new System.Windows.Forms.Padding(6);
            this.LoadDonHangButton.Name = "LoadDonHangButton";
            this.LoadDonHangButton.Size = new System.Drawing.Size(326, 122);
            this.LoadDonHangButton.TabIndex = 1;
            this.LoadDonHangButton.Text = "Đơn hàng";
            this.LoadDonHangButton.UseVisualStyleBackColor = false;
            this.LoadDonHangButton.Click += new System.EventHandler(this.LoadDonHangButton_Click);
            // 
            // LoadUcLoginButton
            // 
            this.LoadUcLoginButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LoadUcLoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LoadUcLoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadUcLoginButton.Location = new System.Drawing.Point(6, 1066);
            this.LoadUcLoginButton.Margin = new System.Windows.Forms.Padding(6);
            this.LoadUcLoginButton.Name = "LoadUcLoginButton";
            this.LoadUcLoginButton.Size = new System.Drawing.Size(326, 76);
            this.LoadUcLoginButton.TabIndex = 0;
            this.LoadUcLoginButton.Text = "Đăng nhập";
            this.LoadUcLoginButton.UseVisualStyleBackColor = false;
            this.LoadUcLoginButton.Click += new System.EventHandler(this.LoadUcLoginButton_Click);
            // 
            // UserPanel
            // 
            this.UserPanel.Location = new System.Drawing.Point(356, 10);
            this.UserPanel.Margin = new System.Windows.Forms.Padding(6);
            this.UserPanel.Name = "UserPanel";
            this.UserPanel.Size = new System.Drawing.Size(1804, 1250);
            this.UserPanel.TabIndex = 1;
            // 
            // LoginPanel
            // 
            this.LoginPanel.Location = new System.Drawing.Point(356, 10);
            this.LoginPanel.Margin = new System.Windows.Forms.Padding(6);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(1804, 1250);
            this.LoginPanel.TabIndex = 2;
            // 
            // StaffPanel
            // 
            this.StaffPanel.Location = new System.Drawing.Point(356, 10);
            this.StaffPanel.Margin = new System.Windows.Forms.Padding(6);
            this.StaffPanel.Name = "StaffPanel";
            this.StaffPanel.Size = new System.Drawing.Size(1804, 1250);
            this.StaffPanel.TabIndex = 3;
            // 
            // fQuanlyBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2168, 1500);
            this.Controls.Add(this.StaffPanel);
            this.Controls.Add(this.LoginPanel);
            this.Controls.Add(this.UserPanel);
            this.Controls.Add(this.ToolPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "fQuanlyBanHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý quán ăn";
            this.ToolPanel.ResumeLayout(false);
            this.ToolPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ToolPanel;
        private System.Windows.Forms.Button LoadUcLoginButton;
        private System.Windows.Forms.Panel UserPanel;
        private System.Windows.Forms.Button LoadDonHangButton;
        private System.Windows.Forms.Button LoadUcQuanLyButton;
        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.Button LoadUcThucDonButton;
        private System.Windows.Forms.Button LoadUcDoanhThuButton;
        private Panel LoginPanel;
        private Panel StaffPanel;
        private Label AccountLb;
        private Label MaNVLb;
    }
}