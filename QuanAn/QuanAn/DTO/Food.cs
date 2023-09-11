using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanAn.DTO
{
    public class Food
    {
        private int maCTDH;
        private int maMN;
        private string ten_mon;
        private float don_gia;
        private int so_luong;
        private string ghi_chu;
        private float thanh_tien;

        public Food(int maCTDH, int maMN, string ten_mon, float don_gia, int so_luong, string ghi_chu, float thanh_tien)
        {
            this.maCTDH = maCTDH;
            this.MaMN = maMN;
            this.Ten_mon = ten_mon;
            this.Don_gia = don_gia;
            this.So_luong = so_luong;
            this.Ghi_chu = ghi_chu;
            Thanh_tien = thanh_tien;
        }

        public Food(DataRow row)
        {
            this.MaCTDH = (int)row["MaCTDH"];
            this.MaMN = (int)row["MaMN"];
            this.Ten_mon = row["Ten_mon"].ToString();
            this.Don_gia = float.Parse(row["Don_gia"].ToString()); 
            this.So_luong = (int)row["So_luong"];
            this.Ghi_chu = row["Ghi_chu"].ToString();

            float thanh_tien;
            if (float.TryParse(row["Thanh_tien"].ToString(), out thanh_tien))
            {
                Thanh_tien = thanh_tien;
            }
            else
            {
                Thanh_tien = 0; 
            }
        }

        /*        
        public Food(DataRow row)
        {
            this.MaMN = (int)row["MaMN"];
            this.Ten_mon = row["Ten_mon"].ToString();
            this.Don_gia = float.Parse(row["Don_gia"]));
            this.So_luong = (int)row["So_luong"];
            this.Ghi_chu = row["Ghi_chu"].ToString();
            Thanh_tien = (float)Convert.ToDouble(row["Thanh_tien"].ToString());
        }
        */

        public int MaMN { get => maMN; set => maMN = value; }
        public float Don_gia { get => don_gia; set => don_gia = value; }
        public string Ten_mon { get => ten_mon; set => ten_mon = value; }
        public int So_luong { get => so_luong; set => so_luong = value; }
        public string Ghi_chu { get => ghi_chu; set => ghi_chu = value; }
        public float Thanh_tien { get => thanh_tien; set => thanh_tien = value; }
        public int MaCTDH { get => maCTDH; set => maCTDH = value; }
    }
}
