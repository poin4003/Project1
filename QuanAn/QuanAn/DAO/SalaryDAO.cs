using QuanAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanAn.DAO
{
    public class SalaryDAO
    {
        private static SalaryDAO instance;

        public static SalaryDAO Instance
        {
            get { if (instance == null) instance = new SalaryDAO(); return instance; }
            private set => instance = value;
        }

        public SalaryDAO() { }

        // Lấy lương theo giờ bằng mã chức vụ
        public BasicSalary GetLuongTheoGioByMaCV(int MaCV)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery($"EXEC USP_GetLuongTheoGioByMaCV @macv = {MaCV}");
            
            if(data.Rows.Count > 0)
            {
                BasicSalary basicSalary = new BasicSalary(data.Rows[0]);
                return basicSalary;
            }
            return null;
        }

        // Lấy lương phụ theo giờ bằng tháng nhập
        public AdditionSalary GetLuongPhuByThangNhap(string ThangNhap)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery($"EXEC USP_GetLuongPhuByThangNam @ThangNam = '{ThangNhap}'");

            if(data.Rows.Count > 0)
            {
                AdditionSalary additionSalary = new AdditionSalary(data.Rows[0]);
                return additionSalary;
            }
            return null;
        }

        // Thêm lương phụ mới
        public void InsertAdditionSalary(float LuongThuong, float LuongPhat, string ThangNhap)
        {
            DataProvider.Instance.ExecuteNonQuery($"EXEC USP_InsertAdditionalSalary @LuongThuong = {LuongThuong}, @LuongPhat = {LuongPhat}, @Thang_nhap = '{ThangNhap}'");
        }

        // Cập nhật bảng lương phụ
        public void UpdateAdditionSalary(float LuongThuong, float LuongPhat, string ThangNhap)
        {
            DataProvider.Instance.ExecuteNonQuery($"EXEC USP_UpdateAdditionalSalary @Thang_nhap = '{ThangNhap}', @LuongThuong = {LuongThuong}, @LuongPhat = {LuongPhat}");
        }

        // Cập nhật bảng lương cứng
        public void UpdateBasicSalary(int MaLuongCung, float LuongTheoGio)
        {
            DataProvider.Instance.ExecuteNonQuery($"EXEC USP_UpdateBasicSalary @MaLuongCung = {MaLuongCung}, @LuongTheoGio = {LuongTheoGio}");
        }
     }
}
