using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanAn.DTO
{
    public class Order
    {
        private int maDH;
        private int maNV;
        private float tong_tien;
        private float khach_dua;
        private float tien_thua;
        private DateTime ngay;

        public Order(int maDH, int maNV, float tong_tien, float khach_dua, float tien_thua, DateTime ngay)
        {
            this.MaDH = maDH;
            this.MaNV = maNV;
            this.Tong_tien = tong_tien;
            this.Khach_dua = khach_dua;
            this.Tien_thua = tien_thua;
            this.Ngay = ngay;  
        }

        /*        
        public Order(DataRow row)
        {
            this.MaDH = (int)row["MaDH"];
            this.MaNV = (int)row["MaNV"];
            this.Tong_tien = (float)Convert.ToDouble(row["Tong_tien"].ToString());
            this.Khach_dua = (float)Convert.ToDouble(row["Khach_dua"].ToString());
            this.Tien_thua = (float)Convert.ToDouble(row["Tien_thua"].ToString());
            this.Ngay = (DateTime)row["Ngay"];
        }
        */

        public Order(DataRow row)
        {
            this.MaDH = (int)row["MaDH"];
            this.MaNV = (int)row["MaNV"];

            if (float.TryParse(row["Tong_tien"].ToString(), out float tongTien))
            {
                this.Tong_tien = tongTien;
            }
            else
            {
                this.Tong_tien = 0; 
            }

            if (float.TryParse(row["Khach_dua"].ToString(), out float khachDua))
            {
                this.Khach_dua = khachDua;
            }
            else
            {
                this.Khach_dua = 0;
            }

            if (float.TryParse(row["Tien_thua"].ToString(), out float tienThua))
            {
                this.Tien_thua = tienThua;
            }
            else
            {
                this.Tien_thua = 0;
            }

            this.Ngay = (DateTime)row["Ngay"];
        }

        public int MaDH { get => maDH; set => maDH = value; }
        public float Tong_tien { get => tong_tien; set => tong_tien = value; }
        public float Khach_dua { get => khach_dua; set => khach_dua = value; }
        public float Tien_thua { get => tien_thua; set => tien_thua = value; }
        public DateTime Ngay { get => ngay; set => ngay = value; }
        public int MaNV { get => maNV; set => maNV = value; }
    }
}
