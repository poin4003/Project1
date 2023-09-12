using QuanAn.DAO;
using QuanAn.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanAn
{
    public partial class UcQuanLy : UserControl
    {
        public static UcQuanLy instance;

        private List<Staff> staffList = StaffDAO.Instance.LoadStaffList();

        public DataGridView calendarDataGridView, staffDataGridView, salaryDataGridView;

        public UcQuanLy()
        {
            InitializeComponent();
            instance = this;
            TurnReadOnlyControl(false);
            TurnToEnable(false);
            calendarDataGridView = CalendarDataGridView;
            staffDataGridView = StaffDataGridView;
            salaryDataGridView = SalaryDataGridView;
        }

        #region MethodForStaff
        // Biến dùng để lưu dữ liệu nhân viên cho từng DataGridView
        private List<Staff> staffListForStaffDataGridView;
        private List<Staff> staffListForCalendarDataGridView;
        private List<Staff> staffListForSalaryDataGridView;

        public void LoadData()
        {
            // Khởi tạo dữ liệu cho tất cả DataGridView
            LoadDataForDataGridView(StaffDataGridView);
            LoadDataForDataGridView(CalendarDataGridView);
            LoadDataForDataGridView(SalaryDataGridView);
        }

        private List<Staff> GetDataSourceForDataGridView(DataGridView dataGridView)
        {
            // Dựa vào DataGridView cụ thể để trả về dữ liệu tương ứng
            if (dataGridView == StaffDataGridView)
            {
                return staffListForStaffDataGridView;
            }
            else if (dataGridView == CalendarDataGridView)
            {
                return staffListForCalendarDataGridView;
            }
            else if (dataGridView == SalaryDataGridView)
            {
                return staffListForSalaryDataGridView;
            }

            // Trường hợp không xác định, trả về null hoặc một danh sách rỗng
            return new List<Staff>();
        }

        private void StaffFilterCb_CheckedChanged(object sender, EventArgs e)
        {
            // Lấy dữ liệu cho DataGridView cụ thể
            List<Staff> dataSource = GetDataSourceForDataGridView(StaffDataGridView);

            // Cập nhật dữ liệu dựa trên trạng thái của checkbox
            dataSource = StaffFilterCb.Checked
                ? StaffDAO.Instance.LoadStaffListFilteredByStatus()
                : StaffDAO.Instance.LoadStaffList();

            // Lưu lại dữ liệu cho DataGridView
            staffListForStaffDataGridView = dataSource;

            // Cập nhật DataGridView
            StaffDataGridView.DataSource = dataSource;
        }

        private void CalendarStaffFilterCb_CheckedChanged(object sender, EventArgs e)
        {
            // Lấy dữ liệu cho DataGridView cụ thể
            List<Staff> dataSource = GetDataSourceForDataGridView(CalendarDataGridView);

            // Cập nhật dữ liệu dựa trên trạng thái của checkbox
            dataSource = CalendarStaffFilterCb.Checked
                ? StaffDAO.Instance.LoadStaffListFilteredByStatus()
                : StaffDAO.Instance.LoadStaffList();

            // Lưu lại dữ liệu cho DataGridView
            staffListForCalendarDataGridView = dataSource;

            // Cập nhật DataGridView
            CalendarDataGridView.DataSource = dataSource;
        }

        private void SalaryStaffFilterCb_CheckedChanged(object sender, EventArgs e)
        {
            // Lấy dữ liệu cho DataGridView cụ thể
            List<Staff> dataSource = GetDataSourceForDataGridView(SalaryDataGridView);

            // Cập nhật dữ liệu dựa trên trạng thái của checkbox
            dataSource = SalaryStaffFilterCb.Checked
                ? StaffDAO.Instance.LoadStaffListFilteredByStatus()
                : StaffDAO.Instance.LoadStaffList();

            // Lưu lại dữ liệu cho DataGridView
            staffListForSalaryDataGridView = dataSource;

            // Cập nhật DataGridView
            SalaryDataGridView.DataSource = dataSource;
        }

        private void LoadDataForDataGridView(DataGridView dataGridView)
        {
            staffList = StaffDAO.Instance.LoadStaffList();
            dataGridView.DataSource = staffList;

            // Ẩn/hiện các cột cụ thể trong DataGridView
            dataGridView.Columns["MaNV"].Visible = false;
            dataGridView.Columns["Ten_dang_nhap"].Visible = false;
            dataGridView.Columns["Mat_khau"].Visible = false;
            dataGridView.Columns["MaCv"].Visible = false;
            dataGridView.Columns["Ngay_dau_di_lam"].Visible = false;
            dataGridView.Columns["Sdt"].Visible = false;

            DataGridViewColumn colHoTen = dataGridView.Columns["HoTen"];
            colHoTen.DisplayIndex = 0;
            colHoTen.Width = 190;

            DataGridViewColumn colTrangThai = dataGridView.Columns["TrangThai"];
            colTrangThai.DisplayIndex = 1;
        }

        void TurnReadOnlyControl(bool status)
        {
            StaffNameTb.Enabled = status;
            PositionPanel.Enabled = status;
            StatusPanel.Enabled = status;
            PhoneNumberTb.Enabled = status;
            FirstDateAtWorkDtp.Enabled = status;
            UserNameTb.Enabled = status;
            PasswordTb.Enabled = status;
        }

        void ResetDefaultControl()
        {
            StaffIdTb.Enabled = false;
            StaffIdTb.Text = "";
            StaffNameTb.Text = "";
            ManagerRadioButton.Checked = false;
            StaffRadioButton.Checked = true;
            StillWorkingRadioButton.Checked = true;
            StoppedWorkingRadioButton.Checked = false;
            PhoneNumberTb.Text = "";
            FirstDateAtWorkDtp.Text = DateTime.Now.ToString("yyyy-MM-dd");
            UserNameTb.Text = "";
            PasswordTb.Text = ""; 
        }
        #endregion

        #region MethodForCalendar
        private void UpdateNumberOfWorkingDaysListView(List<DTO.Calendar> calendars)
        {
            NumberOfWorkingDaysLv.Items.Clear();

            foreach (DTO.Calendar calendar in calendars)
            {
                ListViewItem item = new ListViewItem(calendar.Ngay_lam.ToString("yyyy-MM-dd"));
                item.SubItems.Add(calendar.So_gio_lam.ToString());
                NumberOfWorkingDaysLv.Items.Add(item);
            }
        }

        #endregion

        #region MethodForSalary
        
        void TurnToEnable(bool status)
        {
            BonusSalaryTb.Enabled = status;
            PenaltySalaryTb.Enabled = status;
        }

        #endregion

        #region eventForStaff
        private enum EditStage
        {
            Initial,
            Editable
        }

        private int MaNV = -1;        
        private bool isFirstClick = true;
        private void StaffDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            if(dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                TurnReadOnlyControl(false);
                isFirstClick = true;
                int selectedIndex = selectedRow.Index;
                if (selectedIndex >= 0 && selectedIndex < staffList.Count)
                {
                    Staff selectedStaff = staffList[selectedIndex];
                    int MaNV = selectedStaff.MaNV;
                    string Ten_dang_nhap = selectedStaff.Ten_dang_nhap;
                    string Mat_khau = selectedStaff.Mat_khau;
                    int MaCV = selectedStaff.MaCv;
                    string HoTen = selectedStaff.HoTen;
                    string Ngay_dau_di_lam = Convert.ToDateTime(selectedStaff.Ngay_dau_di_lam).ToString("yyyy-MM-dd");
                    string Sdt = selectedStaff.Sdt;
                    string Trang_thai = selectedStaff.TrangThai;

                    StaffIdTb.Text = MaNV.ToString();
                    StaffNameTb.Text = HoTen;
                    if (MaCV == 1)
                    {
                        ManagerRadioButton.Checked = true;
                    }
                    else
                    {
                        StaffRadioButton.Checked = true;
                    }

                    if (Trang_thai == "Đang đi làm")
                    {
                        StillWorkingRadioButton.Checked = true;
                    }
                    else
                    {
                        StoppedWorkingRadioButton.Checked = true;
                    }

                    FirstDateAtWorkDtp.Value = Convert.ToDateTime(Ngay_dau_di_lam);
                    PhoneNumberTb.Text = Sdt;
                    UserNameTb.Text = Ten_dang_nhap;
                    PasswordTb.Text = Mat_khau;
                }
            }
        }

        private void AddStaffButton_Click(object sender, EventArgs e)
        {
            if (isFirstClick)
            {
                TurnReadOnlyControl(true);
                ResetDefaultControl();
                isFirstClick = false;
            }
            else
            {
                int macv = 2;
                string trang_thai = "Đang đi làm";
                if (ManagerRadioButton.Checked)
                {
                    macv = 1;
                }
                else if (StaffRadioButton.Checked)
                {
                    macv = 2;
                }

                if (StillWorkingRadioButton.Checked)
                {
                    trang_thai = "Đang đi làm";
                }
                else if (StoppedWorkingRadioButton.Checked)
                {
                    trang_thai = "Đã nghỉ làm";
                }

                string ten_dang_nhap = UserNameTb.Text;
                string mat_khau = PasswordTb.Text;
                string hoTen = StaffNameTb.Text;
                string ngay_dau_di_lam = FirstDateAtWorkDtp.Value.ToString("yyyy-MM-dd");
                string sdt = PhoneNumberTb.Text;

                // Kiểm tra độ dài của các trường dữ liệu
                if (ten_dang_nhap.Length > 50 || mat_khau.Length > 1000 || hoTen.Length > 50 || sdt.Length > 10)
                {
                    MessageBox.Show("Tên đăng nhập, mật khẩu, họ tên hoặc số điện thoại quá dài. Vui lòng kiểm tra lại.", "Trường dữ liệu quá dài", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (string.IsNullOrEmpty(ten_dang_nhap) || string.IsNullOrEmpty(mat_khau) || string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(ngay_dau_di_lam) || string.IsNullOrEmpty(sdt))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm nhân viên.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Nếu không có trường dữ liệu nào trống và không quá dài, thực hiện thêm nhân viên
                    StaffDAO.Instance.AddStaff(ten_dang_nhap, mat_khau, macv, hoTen, ngay_dau_di_lam, sdt, trang_thai);
                    TurnReadOnlyControl(false);
                    ResetDefaultControl();
                    LoadData();
                    isFirstClick = true;
                }
            }
        }

        private void EditStaffButton_Click(object sender, EventArgs e)
        {
            if (isFirstClick)
            {
                // Chuyển các control sang trạng thái cho phép chỉnh sửa
                TurnReadOnlyControl(true);
                isFirstClick = false;
            }
            else
            {
                int macv = 2;
                string trang_thai = "Đang đi làm";
                if (ManagerRadioButton.Checked)
                {
                    macv = 1;
                }
                else if (StaffRadioButton.Checked)
                {
                    macv = 2;
                }

                if (StillWorkingRadioButton.Checked)
                {
                    trang_thai = "Đang đi làm";
                }
                else if (StoppedWorkingRadioButton.Checked)
                {
                    trang_thai = "Đã nghỉ làm";
                }

                // Lấy mã nhân viên từ control StaffIdTb
                int manv;
                if (!int.TryParse(StaffIdTb.Text, out manv))
                {
                    MessageBox.Show("Mã nhân viên không hợp lệ. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Không thực hiện chỉnh sửa nếu mã nhân viên không hợp lệ
                }

                string ten_dang_nhap = UserNameTb.Text;
                string mat_khau = PasswordTb.Text;
                string hoTen = StaffNameTb.Text;
                string ngay_dau_di_lam = FirstDateAtWorkDtp.Value.ToString("yyyy-MM-dd");
                string sdt = PhoneNumberTb.Text;

                // Kiểm tra độ dài của các trường dữ liệu
                if (ten_dang_nhap.Length > 50 || mat_khau.Length > 1000 || hoTen.Length > 50 || sdt.Length > 10)
                {
                    MessageBox.Show("Tên đăng nhập, mật khẩu, họ tên hoặc số điện thoại quá dài. Vui lòng kiểm tra lại.", "Trường dữ liệu quá dài", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (string.IsNullOrEmpty(ten_dang_nhap) || string.IsNullOrEmpty(mat_khau) || string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(ngay_dau_di_lam) || string.IsNullOrEmpty(sdt))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi chỉnh sửa thông tin nhân viên.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Nếu không có trường dữ liệu nào trống và không quá dài, thực hiện chỉnh sửa thông tin nhân viên
                    StaffDAO.Instance.EditStaff(manv, ten_dang_nhap, mat_khau, macv, hoTen, ngay_dau_di_lam, sdt, trang_thai);

                    // Sau khi chỉnh sửa, đặt lại các control về trạng thái ban đầu và isFirstClick thành true
                    TurnReadOnlyControl(false);
                    ResetDefaultControl();
                    isFirstClick = true;
                    LoadData();
                }
            }
        }

        #endregion

        #region EventForCalendar

        private int selectedMaNV;
        private void CalendarDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                int selectedIndex = selectedRow.Index;
                if (selectedIndex >= 0 && selectedIndex < staffList.Count)
                {
                    Staff selectedStaff = staffList[selectedIndex];
                    int manv = selectedStaff.MaNV;
                    string hoten = selectedStaff.HoTen;
                    selectedMaNV = manv;
                    WorkingHoursLb.Text = "Số giờ làm của nhân viên " + hoten;
                    List<DTO.Calendar> calendars = CalendarDAO.Instance.GetCalendarByMaNV(manv);

                    UpdateNumberOfWorkingDaysListView(calendars);
                }
            }
        }
        
        List<DateTime> dateTimes = new List<DateTime>();
        private void GetCalendarList(int maNV)
        {
            dateTimes.Clear();
            List<DTO.Calendar> calendars = CalendarDAO.Instance.GetCalendarByMaNV(maNV);
            foreach (DTO.Calendar calendar in calendars)
            {
                DateTime Ngay = calendar.Ngay_lam;
                dateTimes.Add(Ngay);
            }
        }

        private void AddCalendarButton_Click(object sender, EventArgs e)
        {
            GetCalendarList(selectedMaNV);
            string ngay_lam = CalendarDateChoosedDtp.Value.ToString("yyyy-MM-dd");
            if (dateTimes.Contains(DateTime.Parse(ngay_lam)))
            {
                MessageBox.Show("Ngày đã có. Vui lòng thử lại ngày khác", "Ngày trùng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int so_gio_lam = (int)WorkingHoursNud.Value;
                if (so_gio_lam == 0)
                {
                    MessageBox.Show("Vui lòng nhập số giờ làm.", "Thiếu số giờ làm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    CalendarDAO.Instance.AddNewCalendar(ngay_lam, selectedMaNV, so_gio_lam);
                    List<DTO.Calendar> calendars = CalendarDAO.Instance.GetCalendarByMaNV(selectedMaNV);
                    UpdateNumberOfWorkingDaysListView(calendars);
                }
            }
        }


        private void CalendarDateChoosedDtp_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = CalendarDateChoosedDtp.Value.Date; // Lấy ngày bằng cách loại bỏ giờ, phút và giây
            DateTime currentDate = DateTime.Now.Date; // Lấy ngày hiện tại

            if (selectedDate <= currentDate)
            {
                // Ngày được chọn nhỏ hơn hoặc bằng ngày hiện tại
                UpdateControlsData();
            }
            else
            {
                // Ngày được chọn không hợp lệ
                MessageBox.Show("Không thể chọn ngày sau ngày hiện tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Đặt lại DateTimePicker về ngày hiện tại
                CalendarDateChoosedDtp.Value = currentDate;
            }
        }

        #endregion

        #region EventForSalary

        private bool isFirstClick1 = true;
        private void EditSalaryButton_Click(object sender, EventArgs e)
        {
            if (isFirstClick)
            {
                TurnToEnable(true);
                isFirstClick = false;
            }
            else
            {
                float LuongThuong = float.Parse(BonusSalaryTb.Text);
                float LuongPhat = float.Parse(PenaltySalaryTb.Text);
                DateTime selectedDate = MonthInputDtp.Value;
                string month = selectedDate.ToString("yyyy-MM-dd");

                AdditionSalary addition = SalaryDAO.Instance.GetLuongPhuByThangNhap(month);
                if (addition.MaLuongPhu == 0)
                {
                    SalaryDAO.Instance.InsertAdditionSalary(LuongThuong, LuongPhat, month);
                    isFirstClick = true;
                    TurnToEnable(false);
                    UpdateControlsData();
                }
                else
                {
                    SalaryDAO.Instance.UpdateAdditionSalary(LuongThuong, LuongPhat, month);
                    isFirstClick = true;
                    TurnToEnable(false);
                    UpdateControlsData();
                }
            }
        }

        private void UpdateControlsData()
        {
            DataGridViewRow selectedRow = SalaryDataGridView.SelectedRows.Count > 0 ? SalaryDataGridView.SelectedRows[0] : null;
            DateTime selectedDate = MonthInputDtp.Value;

            if (selectedRow != null)
            { 
                int selectedIndex = selectedRow.Index;
                if (selectedIndex >= 0 && selectedIndex < staffList.Count)
                {
                    Staff selectedStaff = staffList[selectedIndex];
                    int MaNV = selectedStaff.MaNV;
                    int MaCV = selectedStaff.MaCv;

                    string month = selectedDate.ToString("yyyy-MM-dd");
                    float totalWorkHours = CalendarDAO.Instance.GetTotalWorkHours(month, MaNV);
                    BasicSalary basicSalary = SalaryDAO.Instance.GetLuongTheoGioByMaCV(MaCV);
                    AdditionSalary additionSalary = SalaryDAO.Instance.GetLuongPhuByThangNhap(month);

                    if (MaCV == 1)
                    {
                        ManagerSalaryRadioButton.Checked = true;
                    }
                    else
                    {
                        StaffSalaryRadioButton.Checked = true;
                    }

                    StaffsSalaryTb.Text = MaNV.ToString();
                    HourlyTb.Text = basicSalary.LuongTheoGio.ToString();
                    BonusSalaryTb.Text = additionSalary.LuongThuong.ToString();
                    PenaltySalaryTb.Text = additionSalary.LuongPhat.ToString();
                    TotalWorkHoursTb.Text = totalWorkHours.ToString();
                    TotalSalaryTb.Text = (totalWorkHours * (basicSalary.LuongTheoGio + additionSalary.LuongThuong + additionSalary.LuongPhat)).ToString();
                }
            }
        }

        private void SalaryDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            UpdateControlsData();
        }

        private void MonthInputDtp_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = MonthInputDtp.Value;
            DateTime currentDate = DateTime.Now;

            if (selectedDate <= currentDate)
            {
                // Tháng được chọn nhỏ hơn hoặc bằng tháng hiện tại
                UpdateControlsData();
            }
            else
            {
                // Tháng được chọn không hợp lệ
                MessageBox.Show("Không thể chọn tháng lớn hơn tháng hiện tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Đặt lại DateTimePicker về tháng hiện tại
                MonthInputDtp.Value = currentDate;
            }
        }

        #endregion

    }
}

