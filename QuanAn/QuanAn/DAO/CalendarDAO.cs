using QuanAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanAn.DAO
{
    public class CalendarDAO
    {
        private static CalendarDAO instance;

        public static CalendarDAO Instance
        {
            get { if (instance == null) instance = new CalendarDAO(); return instance; }
            private set => instance = value;
        }

        public CalendarDAO() { }
        
        public List<Calendar> GetCalendarByMaNV(int manv)
        {
            List<Calendar> calendars = new List<Calendar>();

            DataTable data = DataProvider.Instance.ExecuteQuery($"EXEC USP_GetCalendarbyMaNV @manv = {manv}");

            foreach (DataRow row in data.Rows)
            {
                Calendar calendar = new Calendar(row);
                calendars.Add(calendar);
            }

            return calendars;
        }

        public void AddNewCalendar(string ngay_lam, int manv, int so_gio_lam)
        {
            DataProvider.Instance.ExecuteNonQuery($"EXEC USP_AddCalendar @ngay_lam = '{ngay_lam}', @manv = {manv}, @so_gio_lam = {so_gio_lam}");
        }

        public void EditCalendar(int maLichLam, int so_gio_lam)
        {
            DataProvider.Instance.ExecuteNonQuery($"USP_EditCalendar @maLichLam = {maLichLam}, @so_gio_lam = {so_gio_lam}");
        }

        // Lấy tổng giờ làm trong tháng bằng tháng nhập và mã nhân viên
        public float GetTotalWorkHours(string ThangNhap, int MaNV)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery($"EXEC USP_GetGioLam @manv = {MaNV}, @thang_nhap = '{ThangNhap}'");

            if (data.Rows.Count > 0)
            {
                if (float.TryParse(data.Rows[0][0].ToString(), out float totalWorkHours))
                {
                    return totalWorkHours;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }
    }
}
