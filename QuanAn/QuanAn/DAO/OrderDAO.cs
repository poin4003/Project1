using QuanAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanAn.DAO
{
    public class OrderDAO
    {
        private static OrderDAO instance;

        public static OrderDAO Instance
        {
            get { if (instance == null) ; instance = new OrderDAO(); return instance; }
            private set => instance = value;
        }
        
        public OrderDAO() { }
        
        public Order GetOrderWithIDMax()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_GetOrderWithIDMax");

            if (data.Rows.Count > 0)
            {
                Order order = new Order(data.Rows[0]);
                return order;
            }
            return null;
        }

        public Order GetOrderByMaDH(int MaDH)
        {   
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_GetOrderByMaDH @maDH", new object[] { MaDH });
            
            if(data.Rows.Count > 0)
            {
                Order order = new Order(data.Rows[0]);
                return order;
            }
            return null;
        }
    }
}
