using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanAn.DTO
{
    public class BasicSalary
    {
        private int maLuongCung;
        private float luongTheoGio;
        private int maCv;

        public BasicSalary(int maLuongCung, float luongTheoGio, int maCV, int maCv)
        {
            this.MaLuongCung = maLuongCung;
            this.LuongTheoGio = luongTheoGio;
            this.MaCV = maCv;
        }

        public BasicSalary(DataRow row)
        {
            this.MaLuongCung = (int)row["MaLuongCung"];
            this.LuongTheoGio = float.Parse(row["LuongTheoGio"].ToString());
        }

        public int MaLuongCung { get => maLuongCung; set => maLuongCung = value; }
        public float LuongTheoGio { get => luongTheoGio; set => luongTheoGio = value; }
        public int MaCV { get => maCv; set => maCv = value; }
    }
}
