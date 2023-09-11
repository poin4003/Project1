using QuanAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace QuanAn.DAO
{
    public class FoodDAO
    {

        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return instance; }
            private set => instance = value;
        }
        
        public FoodDAO() { }
            
        public void CreateNewOrder(int MaNV)
        {
            DateTime Today = DateTime.Now;

            Order order = OrderDAO.Instance.GetOrderWithIDMax();
            if (order.Khach_dua != 0)
                DataProvider.Instance.ExecuteNonQuery("EXEC USP_CreateDonHang @maNV , @ngay", new object[] { MaNV, Today.ToString("yyyy-MM-dd") });
        }
        
        public void AddFoodToOrder(int maDH, int maMN, int so_luong, string ghi_chu, float thanh_tien)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_AddFoodToChitietdonhang @maDH , @maMN , @so_luong , @ghi_chu , @thanh_tien", new object[] { maDH, maMN, so_luong, ghi_chu, thanh_tien });
        }

        public void UpdateToCompleteOrder(int maDH, float khach_dua, float tong_tien, float tien_thua)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_UpdateDonHang @MaDH , @khach_dua , @tong_tien , @tien_thua", new object[] { maDH, khach_dua, tong_tien, tien_thua});
        }

        public void DeleteFoodFromOrderByMaCTDH(int maCTDH)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_DeleteFoodFromChitietdonhang @maCTDH = " + maCTDH);
        }
        
        public void InsertFoodToThucDon(string ten_mon, float don_gia)
        {
            DataProvider.Instance.ExecuteNonQuery($"EXEC USP_InsertMonToThucDon @ten_mon = N'{ten_mon}', @don_gia = {don_gia}");
        }

        public void DeleteFoodFromThucDon(int maMN)
        {
            DataProvider.Instance.ExecuteNonQuery($"EXEC USP_DeleteMonFromThucDon @maMN = {maMN}");
        }

        public void UpdateFood(int maMN, string ten_mon, float don_gia)
        {
            DataProvider.Instance.ExecuteNonQuery($"EXEC USP_UpdateMon @maMN = {maMN}, @ten_mon = N'{ten_mon}', @don_gia = {don_gia}");
        }
        
        public DataTable GetFoodListByMaDH(int maDH)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery($"EXEC USP_GetFoodListByOrderId @maDH = {maDH}");
            return data;
        }

        public List<Food> LoadFoodListByMaDH(int id)
        {
            List<Food> foodList = new List<Food>();

            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_GetFoodByMaDH @maDH", new object[] {id});
            
            foreach (DataRow row in data.Rows)
            {
                Food food = new Food(row);
                foodList.Add(food);
            }

            return foodList;
        }

        public List<Food> LoadFoodWithFixedExtras()
        {
            List<Food> foodList = new List<Food>();

            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_GetFoodWithFixedExtras");

            foreach (DataRow row in data.Rows)
            {
                Food food = new Food(row);
                foodList.Add(food);
            }

            return foodList;
        }
    }
}
