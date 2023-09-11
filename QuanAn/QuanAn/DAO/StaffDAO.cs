using QuanAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanAn.DAO
{
    public class StaffDAO
    {
        private static StaffDAO instance;

        public static StaffDAO Instance
        {
            get { if (instance == null) instance = new StaffDAO(); return instance; }
            private set => instance = value;
        }

        private StaffDAO() { }

        public List<Staff> LoadStaffList()
        {
            List<Staff> staffList = new List<Staff>();

            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_GetStaff");

            foreach (DataRow row in data.Rows)
            {
                Staff staff = new Staff(row);
                staffList.Add(staff);
            }

            return staffList;
        }

        public List<Staff> LoadStaffListFilteredByStatus() 
        { 
            List<Staff> staffList = new List<Staff>();

            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_GetFilteredNhanVienByTrangthai");

            foreach (DataRow row in data.Rows)
            {
                Staff staff = new Staff(row);
                staffList.Add(staff);
            }

            return staffList;
        }

        public void AddStaff(string ten_dang_nhap, string mat_khau, int macv, string hoten, string ngay_dau_di_lam, string sdt, string trang_thai )
        {
            DataProvider.Instance.ExecuteNonQuery($"EXEC USP_AddStaff @ten_dang_nhap = N'{ten_dang_nhap}', @mat_khau = N'{mat_khau}', @macv = {macv}, @Hoten = N'{hoten}', @ngay_dau_di_lam = '{ngay_dau_di_lam}',@sdt = N'{sdt}', @trang_thai = N'{trang_thai}'");
        }

        public void EditStaff(int manv, string ten_dang_nhap, string mat_khau, int macv, string hoten, string ngay_dau_di_lam, string sdt, string trang_thai)
        {
            DataProvider.Instance.ExecuteNonQuery($"EXEC USP_EditStaff @manv = {manv}, @ten_dang_nhap = N'{ten_dang_nhap}', @mat_khau = N'{mat_khau}', @macv = {macv}, @Hoten = N'{hoten}', @ngay_dau_di_lam = '{ngay_dau_di_lam}',@sdt = N'{sdt}', @trang_thai = N'{trang_thai}'");
        }
    
    }
}
