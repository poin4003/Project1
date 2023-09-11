using QuanAn.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using QuanAn.DTO;

namespace QuanAn
{
    public partial class UcLogin : UserControl
    {
        public static UcLogin instance;

        public bool LoginStatus = false;

        public System.Windows.Forms.TextBox passWordTb;

        public System.Windows.Forms.ComboBox userNameCb;

        public Label statusLb;

        public int maCv;
        public UcLogin()
        {
            InitializeComponent();
            instance = this;
            statusLb = StatusLb;
            userNameCb = UserNameCb;
            passWordTb = PasswordTb;
            maCv = MaCv;
            LoadUserNameToCombobox();
            panel1.BringToFront();
        }

        bool Login(string username, string password)
        {
            return LoginDAO.Instance.Login(username, password);
        }

        public int MaNV = 0;
        public int MaCv = 2;
        private List<Staff> staffs;
        void LoadUserNameToCombobox()
        {
            // Load danh sách nhân viên từ cơ sở dữ liệu hoặc nguồn dữ liệu khác
            staffs = StaffDAO.Instance.LoadStaffList();

            // Gán danh sách nhân viên làm nguồn dữ liệu cho ComboBox
            UserNameCb.DataSource = staffs;

            // Thiết lập trường muốn hiển thị trong ComboBox (Tên đăng nhập)
            UserNameCb.DisplayMember = "Ten_dang_nhap";

            // Thiết lập trường chứa giá trị thực sự của ComboBox (ID hoặc một trường khác nếu cần)
            UserNameCb.ValueMember = "MaNV";

            // Thiết lập trườn chứa giá trị mã chức vụ
            UserNameCb.ValueMember = "MaCv";

        }
  
        private void UserNameCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UserNameCb.SelectedIndex != -1)
            {
                // Lấy MaNV từ đối tượng đã chọn và gán vào biến MaNV
                MaNV = staffs[UserNameCb.SelectedIndex].MaNV;
                MaCv = staffs[UserNameCb.SelectedIndex].MaCv;
            }
        }
        int Decentralization_Login(string username, string password)
        {
            return LoginDAO.Instance.Decentralization_Login(username, password);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPasswordCb.Checked)
            {
                PasswordTb.PasswordChar = '\0';
            }
            else
            {
                PasswordTb.PasswordChar = '*';
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            //fQuanlyBanHang.instance.p1.Enabled = true;
            string username = UserNameCb.Text;
            string password = PasswordTb.Text;
            if (username == "" || password == "")
            {
                MessageBox.Show("Bạn đã nhập thiếu tài khoản hoặc mật khẩu. Vui lòng kiểm tra lại", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Decentralization_Login(username, password) == 1)
                {
                    LoginStatus = true;
                    StatusLb.Text = "Đã đăng nhập thành công, tài khoản " + username;
                    //StatusLb.ForeColor = Color.FromArgb(0, 0, 255);
                    StatusLb.ForeColor = Color.FromArgb(255, 153, 51);
                    fQuanlyBanHang.instance.accountLb.Text = "Tài khoản: " + username;
                    fQuanlyBanHang.instance.accountLb.ForeColor = Color.FromArgb(0, 0, 0);
                    fQuanlyBanHang.instance.StaffPanel1.Enabled = true;
                    fQuanlyBanHang.instance.UserPanel1.Enabled = true;
                    fQuanlyBanHang.instance.maNVLb.Text = "Mã nhân viên: " + MaNV;
                    UserNameCb.Enabled = false;
                    PasswordTb.Enabled = false;
                    UcThucDon.instance.LoadFood();
                    UcQuanLy.instance.LoadData();
                    UcDonHang.instance.LoadFood();
                }
                else if (Decentralization_Login(username, password) == 2)
                {
                    LoginStatus = true;
                    StatusLb.Text = "Đã đăng nhập thành công, tài khoản " + username;
                    //StatusLb.ForeColor = Color.FromArgb(0, 0, 255);
                    StatusLb.ForeColor = Color.FromArgb(255, 153, 51);
                    fQuanlyBanHang.instance.accountLb.Text = "Tài khoản: " + username;
                    fQuanlyBanHang.instance.accountLb.ForeColor = Color.FromArgb(0, 0, 0);
                    fQuanlyBanHang.instance.StaffPanel1.Enabled = true;
                    fQuanlyBanHang.instance.maNVLb.Text = "Mã nhân viên: " + MaNV;
                    UserNameCb.Enabled = false;
                    PasswordTb.Enabled = false;
                    UcThucDon.instance.LoadFood();
                }
                else
                {
                    MessageBox.Show("Sai mật khẩu. Vui lòng kiểm tra lại", "Sai thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
