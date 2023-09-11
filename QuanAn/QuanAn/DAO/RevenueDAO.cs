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
    public class RevenueDAO
    {
        private static RevenueDAO instance;

        public static RevenueDAO Instance
        {
            get { if (instance == null) ; instance = new RevenueDAO(); return instance; }
            private set => instance = value;
        }

        public RevenueDAO() { }

        public List<Order> GetOrderListByDay(string day)
        {
            List<Order> orders = new List<Order>();

            DataTable data = DataProvider.Instance.ExecuteQuery($"EXEC USP_GetDonHangByNgay @Ngay = '{day}'");
            
            foreach (DataRow row in data.Rows)
            {
                Order order = new Order(row);
                orders.Add(order);
            }

            return orders;
        }

        public List<Order> GetOrderListByDayFiled(string day)
        {
            List<Order> orders = new List<Order>();

            DataTable data = DataProvider.Instance.ExecuteQuery($"EXEC USP_GetDonHangByNgayFiled @Ngay = '{day}'");

            foreach (DataRow row in data.Rows)
            {
                Order order = new Order(row);
                orders.Add(order);
            }

            return orders;
        }

        public List<Order> GetOrderListByMonth(string month)
        {
            List<Order> orders = new List<Order>();

            DataTable data = DataProvider.Instance.ExecuteQuery($"EXEC USP_GetDonHangByThang @Ngay = '{month}'");

            foreach (DataRow row in data.Rows)
            {
                Order order = new Order(row);
                orders.Add(order);
            }

            return orders;
        }

        public List<Order> GetOrderListByMonthFiled(string month)
        {
            List<Order> orders = new List<Order>();

            DataTable data = DataProvider.Instance.ExecuteQuery($"EXEC USP_GetDonHangByThangFiled @Ngay = '{month}'");

            foreach (DataRow row in data.Rows)
            {
                Order order = new Order(row);
                orders.Add(order);
            }

            return orders;
        }

        public float GetTotalRevenueOnDay(string day)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery($"EXEC USP_GetToTalRevenueOnDay @Ngay = '{day}'");

            if (data.Rows.Count > 0)
            {
                object value = data.Rows[0][0];
                if (value != DBNull.Value)
                {
                    if (float.TryParse(value.ToString(), out float result))
                    {
                        return result;
                    }
                }
            }
            return -1;
        }

        public float GetTotalRevenueOnMonth(string month)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery($"EXEC USP_GetTotalRevenueOnMonth @Ngay = '{month}'");

            if (data.Rows.Count > 0)
            {
                object value = data.Rows[0][0];
                if (value != DBNull.Value)
                {
                    if (float.TryParse(value.ToString(), out float result))
                    {
                        return result;
                    }
                }
            }
            return -1;
        }

        public int GetCountOfOrderOnDay(string day)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery($"EXEC USP_GetCountOfOrderOnDay @Ngay = '{day}'");

            if ( data.Rows.Count > 0 )
            {
                return Convert.ToInt32(data.Rows[0][0]);
            }
            return -1;
        }

        public int GetCountOfOrderOnMonth(string month)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery($"EXEC USP_GetCountOfOrderOnMonth @Ngay = '{month}'");

            if ( data.Rows.Count > 0 )
            {
                return Convert.ToInt32(data.Rows[0][0]);
            }
            return -1;
        }
    }
}
