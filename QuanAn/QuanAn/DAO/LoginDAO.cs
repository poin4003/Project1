using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanAn.DAO
{
    internal class LoginDAO
    {
        private static LoginDAO instance;

        public static LoginDAO Instance
        {
            get { if (instance == null) ; instance = new LoginDAO(); return instance; }
            private set => instance = value;
        }

        private LoginDAO() { }

        public bool Login(string username, string password)
        {
            string query = $"USP_Login @userName , @passWord";
            
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { username, password});

            return result.Rows.Count > 0;   
        }

        public int Decentralization_Login(string  username, string password) 
        {
            string query = $"USP_Login @userName , @passWord";
            
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { username, password});

            if (result.Rows.Count > 0) // Kiểm tra có dòng kết quả hay không
            {
                int maCv = Convert.ToInt32(result.Rows[0]["MaCv"]);
                return maCv;
            }

            return -1;
        }
    }
}
