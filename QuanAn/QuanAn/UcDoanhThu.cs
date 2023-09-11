using QuanAn.DAO;
using QuanAn.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanAn
{
    public partial class UcDoanhThu : UserControl
    {
        public static UcDoanhThu instance;

        public DataGridView orderDataGridView;

        public UcDoanhThu()
        {
            InitializeComponent();
            instance = this;
            orderDataGridView = OrderDataGridView;
        }

        private List<Order> orders;
        public void LoadOrderByDay(string day)
        {
            orders = RevenueDAO.Instance.GetOrderListByDayFiled(day);
            OrderDataGridView.DataSource = orders;
            OrderDataGridView.Columns["Tong_tien"].Visible = false;
            OrderDataGridView.Columns["Khach_dua"].Visible = false;
            OrderDataGridView.Columns["Tien_thua"].Visible = false;

            DataGridViewColumn colMaDH = OrderDataGridView.Columns["MaDH"];
            colMaDH.DisplayIndex = 0;

            DataGridViewColumn colMaNV = OrderDataGridView.Columns["MaNV"];
            colMaNV.DisplayIndex = 1;

            DataGridViewColumn colNgay = OrderDataGridView.Columns["Ngay"];
            colNgay.DisplayIndex = 2;

        }

        private void OrderDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (OrderDataGridView.Columns[e.ColumnIndex].Name == "Ngay" && e.Value != null)
            {
                DateTime dateValue;
                if (DateTime.TryParse(e.Value.ToString(), out dateValue))
                {
                    // Định dạng lại giá trị ngày theo định dạng "yyyy-MM-dd"
                    e.Value = dateValue.ToString("yyyy-MM-dd");
                    e.FormattingApplied = true;
                }
            }
        }


        public void LoadOrderByMonth(string month)
        {
            orders = RevenueDAO.Instance.GetOrderListByMonthFiled(month);
            OrderDataGridView.DataSource = orders;
            OrderDataGridView.Columns["Tong_tien"].Visible = false;
            OrderDataGridView.Columns["Khach_dua"].Visible = false;
            OrderDataGridView.Columns["Tien_thua"].Visible = false;

            DataGridViewColumn colMaDH = OrderDataGridView.Columns["MaDH"];
            colMaDH.DisplayIndex = 0;

            DataGridViewColumn colMaNV = OrderDataGridView.Columns["MaNV"];
            colMaNV.DisplayIndex = 1;

            DataGridViewColumn colNgay = OrderDataGridView.Columns["Ngay"];
            //colNgay.DateTime.Parse()
            colNgay.DisplayIndex = 2;
        }

        private void CalculateRevenueByDayButton_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = RevenueDtp.Value;
            string formattedDate = selectedDate.ToString("yyyy-MM-dd");
            //MessageBox.Show(formattedDate);
            LoadOrderByDay(formattedDate);
            float revenue = RevenueDAO.Instance.GetTotalRevenueOnDay(formattedDate);
            int countOfOrder = RevenueDAO.Instance.GetCountOfOrderOnDay(formattedDate);
            NumberOfOrdersTb.Text = countOfOrder.ToString();
            
            if(revenue == -1)
                MessageBox.Show("Ngày không có doanh thu", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            else
                RevenueTb.Text = revenue.ToString();
        }

        private void CalculateRevenueByMonthButton_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = RevenueDtp.Value;
            string formattedDate = selectedDate.ToString("yyyy-MM-dd");           
            LoadOrderByMonth(formattedDate);
            float revenue = RevenueDAO.Instance.GetTotalRevenueOnMonth(formattedDate);
            int countOfOrder = RevenueDAO.Instance.GetCountOfOrderOnMonth(formattedDate);
            NumberOfOrdersTb.Text = countOfOrder.ToString();           
            if (revenue == -1)
                MessageBox.Show("Tháng không có doanh thu", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            else
                RevenueTb.Text = revenue.ToString();
        }

        private void OrderDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;

            if (dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                int selectedIndex = selectedRow.Index;
                if (selectedIndex >= 0 && selectedIndex < orders.Count)
                {
                    Order selectedOrder = orders[selectedIndex];
                    int maDH = selectedOrder.MaDH;
                    float tong_tien = selectedOrder.Tong_tien;
                    float khach_dua = selectedOrder.Khach_dua;
                    float tien_thua = selectedOrder.Tien_thua;

                    OrderTb.Text = maDH.ToString();
                    TotalMoneyTb.Text = tong_tien.ToString();
                    MoneyGivingByCustomerTb.Text = khach_dua.ToString();
                    ChangeTb.Text = tien_thua.ToString();
                    DataTable foods = FoodDAO.Instance.GetFoodListByMaDH(Convert.ToInt32(maDH));
                    FoodListLv.Items.Clear();
                    foreach (DataRow row in foods.Rows)
                    {
                        //MessageBox.Show(row["ten_mon"].ToString());
                        ListViewItem ten_mon = new ListViewItem(row["ten_mon"].ToString());
                        ten_mon.SubItems.Add(row["MaMN"].ToString());
                        FoodListLv.Items.Add(ten_mon);
                    }
                }
             }
        }
    }
}
