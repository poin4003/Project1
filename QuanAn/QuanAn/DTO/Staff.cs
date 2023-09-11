using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanAn.DTO
{
    public class Staff
    {
        private int maNV;
        private string ten_dang_nhap;
        private string mat_khau;
        private int maCv;
        private string hoTen;
        private DateTime ngay_dau_di_lam;
        private string sdt;
        private string trangThai;

        public Staff(int maNV, string ten_dang_nhap, string mat_khau, int maCv, string hoTen,
            DateTime ngay_dau_di_lam, string std, string trang_thai)
        {
            this.MaNV = maNV;
            this.Ten_dang_nhap = ten_dang_nhap;
            this.Mat_khau = mat_khau;
            this.MaCv = maCv;
            this.HoTen = hoTen;
            this.Ngay_dau_di_lam = ngay_dau_di_lam;
            this.Sdt = sdt;
            this.TrangThai = trang_thai;
        }

        public Staff(DataRow row)
        {
            this.MaNV = (int)row["MaNV"];
            this.Ten_dang_nhap = row["Ten_dang_nhap"].ToString();
            this.Mat_khau = row["Mat_khau"].ToString();
            this.MaCv = (int)row["MaCv"];
            this.HoTen = row["HoTen"].ToString();
            this.Ngay_dau_di_lam = (DateTime)row["Ngay_dau_di_lam"];
            this.Sdt = row["Sdt"].ToString();
            this.TrangThai = row["Trang_thai"].ToString();
        }

        public int MaNV { get => maNV; set => maNV = value; }
        public string Ten_dang_nhap { get => ten_dang_nhap; set => ten_dang_nhap = value; }
        public string Mat_khau { get => mat_khau; set => mat_khau = value; }
        public int MaCv { get => maCv; set => maCv = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public DateTime Ngay_dau_di_lam { get => ngay_dau_di_lam; set => ngay_dau_di_lam = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
    }
}
