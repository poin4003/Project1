using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanAn.DTO
{
    public class Calendar
    {
        private int maLichLam;
        private DateTime ngay_lam;
        private int maNV;
        private int so_gio_lam;
        
        public Calendar(int maLichLam, DateTime ngay_lam, int maNV, int so_gio_lam)
        {
            this.MaLichLam = maLichLam;
            this.Ngay_lam = ngay_lam;
            this.MaNV = maNV;
            this.So_gio_lam = so_gio_lam;
        }

        public Calendar(DataRow row)
        {
            this.MaLichLam = (int)row["MaLichLam"];
            this.Ngay_lam = (DateTime)row["Ngay_lam"];
            this.MaNV = (int)row["MaNV"];
            this.So_gio_lam = (int)row["So_gio_lam"];
        }

        public int MaLichLam { get => maLichLam; set => maLichLam = value; }
        public DateTime Ngay_lam { get => ngay_lam; set => ngay_lam = value; }
        public int MaNV { get => maNV; set => maNV = value; }
        public int So_gio_lam { get => so_gio_lam; set => so_gio_lam = value; }
    }
}
