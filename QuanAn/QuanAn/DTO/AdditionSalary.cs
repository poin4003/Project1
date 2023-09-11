using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanAn.DTO
{
    public class AdditionSalary
    {
        private int maLuongPhu;
        private float luongThuong;
        private float luongPhat;

        public AdditionSalary(int maLuongPhu, float luongThuong, float luongPhat) 
        {
            this.MaLuongPhu = maLuongPhu;
            this.LuongThuong = luongThuong;
            this.LuongPhat = luongPhat;
        }

        public AdditionSalary(DataRow row)
        {
            //this.MaLuongPhu = (int)row["MaLuongPhu"];
            if (row["MaLuongPhu"] != DBNull.Value && int.TryParse(row["MaLuongPhu"].ToString(), out int maLuongPhu))
            {
                this.MaLuongPhu = maLuongPhu;
            }
            else
            {
                this.MaLuongPhu = 0;
            }
            // Kiểm tra xem giá trị trong cột "Luong_thuong" có phải là một số hợp lệ không
            if (float.TryParse(row["Luong_thuong"].ToString(), out float luongThuong))
            {
                this.LuongThuong = luongThuong;
            }
            else
            {
                this.LuongThuong = 0;
            }
            //this.LuongPhat = float.Parse(row["Luong_phat"].ToString());
            if (float.TryParse(row["Luong_phat"].ToString(), out float luongPhat))
            {
                this.LuongPhat = luongPhat;
            }
            else
            {
                this.LuongPhat = 0;
            }
        }

        public float LuongThuong { get => luongThuong; set => luongThuong = value; }
        public float LuongPhat { get => luongPhat; set => luongPhat = value; }
        public int MaLuongPhu { get => maLuongPhu; set => maLuongPhu = value; }
    }
}
