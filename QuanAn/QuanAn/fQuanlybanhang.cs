using QuanAn.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanAn
{
    public partial class fQuanlyBanHang : Form
    {   
        public static fQuanlyBanHang instance;
        public Panel UserPanel1, LoginPanel1, StaffPanel1;
        public Label accountLb, maNVLb;
        
        UcQuanLy ucQuanLy1 = new UcQuanLy();
        UcThucDon ucThucDon1 = new UcThucDon();
        UcDoanhThu ucDoanhThu1 = new UcDoanhThu();
        UcDonHang ucDonHang1 = new UcDonHang();
        UcLogin ucLogin1 = new UcLogin();
        public fQuanlyBanHang()
        {
            InitializeComponent();
            instance = this;
            UserPanel1 = UserPanel;
            LoginPanel1 = LoginPanel;
            StaffPanel1 = StaffPanel;
            accountLb = AccountLb;
            maNVLb = MaNVLb;

            this.Icon = new Icon(Application.StartupPath + "\\Resources\\R.ico");
            this.Controls.Add(LoginPanel);
            this.Controls.Add(StaffPanel);

            ucQuanLy1.Dock = DockStyle.Fill;
            ucDoanhThu1.Dock = DockStyle.Fill;
            ucDonHang1.Dock = DockStyle.Fill;
            ucThucDon1.Dock = DockStyle.Fill;
            ucLogin1.Dock = DockStyle.Fill;
            
            LoginPanel.Controls.Add(ucLogin1);
            StaffPanel.Controls.Add(ucDonHang1);  
            UserPanel.Controls.Add(ucDoanhThu1);          
            UserPanel.Controls.Add(ucThucDon1);           
            UserPanel.Controls.Add(ucQuanLy1);

            StaffPanel.Enabled = false;
            UserPanel.Enabled = false;

            LoginPanel.BringToFront();
        }
        

        private void LoadUcQuanLyButton_Click(object sender, EventArgs e)
        {
            this.UserPanel.BringToFront();
            ucQuanLy1.BringToFront();
        }

        private void LoadUcThucDonButton_Click(object sender, EventArgs e)
        {   
            this.UserPanel.BringToFront();
            ucThucDon1.BringToFront();
        }

        private void LoadUcDoanhThuButton_Click(object sender, EventArgs e)
        {   
            this.UserPanel.BringToFront();
            ucDoanhThu1.BringToFront();
        }

        private void LoadDonHangButton_Click(object sender, EventArgs e)
        {   
            this.StaffPanel.BringToFront();
            ucDonHang1.BringToFront();
        }

        private void LoadUcLoginButton_Click(object sender, EventArgs e)
        { 
           this.LoginPanel.BringToFront();
           ucLogin1.BringToFront();
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            if(UcLogin.instance.LoginStatus)
            {
                DialogResult result = MessageBox.Show("Bạn muốn đăng xuất?", "Thông báo", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {     
                    UcLogin.instance.statusLb.Text = "Chưa đăng nhập";
                    UcLogin.instance.LoginStatus = false;
                    UcLogin.instance.userNameCb.Text = "";
                    UcLogin.instance.passWordTb.Text = "";
                    UcLogin.instance.statusLb.ForeColor = Color.FromArgb(0, 0, 0);
                    AccountLb.Text = "";
                    MaNVLb.Text = "";
                    UcLogin.instance.userNameCb.Enabled = true;
                    UcLogin.instance.passWordTb.Enabled = true;
                    AccountLb.ForeColor = Color.FromArgb(0, 0, 0);
                    StaffPanel.Enabled = false;
                    UserPanel.Enabled = false;
                    UcThucDon.instance.foodDataGridView.DataSource = null;
                    UcQuanLy.instance.calendarDataGridView.DataSource = null;
                    UcQuanLy.instance.staffDataGridView.DataSource = null;
                    UcQuanLy.instance.salaryDataGridView.DataSource = null;
                    UcDoanhThu.instance.orderDataGridView.DataSource = null;
                    UcDonHang.instance.menuLv.Items.Clear();
                }
            }
        }
    }
}
