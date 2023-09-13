using QuanAn.DAO;
using QuanAn.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanAn
{
    public partial class UcDonHang : UserControl
    {
        public static UcDonHang instance;
        public ListView menuLv;
        public UcDonHang()
        {
            InitializeComponent();
            instance = this;
            LoadOrderFood();
            menuLv = MenuLv;
        }

        #region Method
        void LoadOrderFood()
        {

            //List<Food> FoodList = FoodDAO.Instance.LoadFoodWithFixedExtras();

            //foreach (Food food in FoodList)
            //{
            //    ListViewItem item = new ListViewItem(food.Ten_mon.ToString());
            //    item.SubItems.Add(food.Don_gia.ToString());
            //    item.SubItems.Add(food.So_luong.ToString());
            //    item.SubItems.Add(food.Ghi_chu.ToString());
            //    item.SubItems.Add(food.Thanh_tien.ToString());
            //    item.SubItems.Add(food.MaCTDH.ToString());
            //    tong_tien += food.Thanh_tien;
            //    OrderLv.Items.Add(item);
            //}
        }
        
        List<Food> uniqueFoodList = new List<Food>();
        public void LoadFood()
        {
            MenuLv.Items.Clear();
            uniqueFoodList.Clear();
            List<Food> FoodList = FoodDAO.Instance.LoadFoodWithFixedExtras();
            ReadIntegersFromFile();
            foreach (Food food in FoodList)
            {
                bool isDuplicate = false;
                int maMN = food.MaMN;
                // Kiểm tra xem MaMN của dòng hiện tại có tồn tại trong danh sách
                if (FoodListDeleted.Contains(maMN))
                {
                    isDuplicate = true;
                }

                // Nếu không trùng lặp, thêm dòng vào danh sách mới
                if (!isDuplicate)
                {
                    uniqueFoodList.Add(food);
                }
            }

            foreach (Food food in uniqueFoodList)
            {
                ListViewItem listViewitem = new ListViewItem(food.Ten_mon.ToString());
                listViewitem.SubItems.Add(food.Don_gia.ToString());
                
                MenuLv.Items.Add(listViewitem);
            }
        }

        List<int> FoodListDeleted = new List<int>();

        private void ReadIntegersFromFile()
        {
            string filePath = (Application.StartupPath + "\\File\\DeletedFoodList.txt");
            FoodListDeleted.Clear();
            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    if (int.TryParse(line, out int number))
                    {
                        FoodListDeleted.Add(number);
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Lỗi đọc tệp: " + ex.Message);
            }
        }


        int GetMaMN(ListViewItem item)
        {
            List<Food> FoodList = FoodDAO.Instance.LoadFoodWithFixedExtras();

            foreach (Food food in uniqueFoodList)
            {
                if (item.SubItems[1].Text == food.Ten_mon.ToString())
                {
                    return food.MaMN;
                }
            }
            return 0;
        }

        float GetDonGia()
        {
            List<Food> FoodList = FoodDAO.Instance.LoadFoodWithFixedExtras();

            foreach (Food food in uniqueFoodList)
            {
                if (FoodNameTb.Text == food.Ten_mon.ToString())
                {
                    return food.Don_gia;
                }
            }
            return 0;
        }

        #endregion

        #region events


        private void CheckoutButton_Click(object sender, EventArgs e)
        {
            float khach_dua = float.Parse(MoneyGivingByCustomerTb.Text);

            if (khach_dua < tong_tien)
            {
                MessageBox.Show("Số tiền khách đưa không đủ để chốt đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc muốn chốt đơn?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    Order order = OrderDAO.Instance.GetOrderWithIDMax();
                    foreach (ListViewItem item in OrderLv.Items)
                    {
                        if (ListName.ContainsKey(item.SubItems[1].Text))
                        {
                            FoodDAO.Instance.AddFoodToOrder(order.MaDH, GetMaMN(item), int.Parse(item.SubItems[2].Text), ListName[item.SubItems[1].Text], float.Parse(item.SubItems[4].Text));
                        }
                    }
                    FoodDAO.Instance.UpdateToCompleteOrder(order.MaDH, khach_dua, tong_tien, (khach_dua - tong_tien));
                    count = 0;
                    MoneyGivingByCustomerTb.Text = "0";
                    TotalMoneyTb.Text = "0";
                    tong_tien = 0;
                    ChangeTb.Text = "0";
                    NoteTb.Text = "";
                    AmountOfFoodNud.Value = 1;
                    OrderLv.Items.Clear();
                    string maNV = fQuanlyBanHang.instance.maNVLb.Text;
                    string[] parts = maNV.Split(':');
                    if (parts.Length == 2)
                    {
                        string maNVCaption = parts[0].Trim(); 
                        string maNVValue = parts[1].Trim();  

                        FoodDAO.Instance.CreateNewOrder(int.Parse(maNVValue));
                    }

                    ListName.Clear();
                }
            }
        }

        private float tong_tien = 0;
        private int count = 0;                                  //Biến để set STT các món
        Dictionary<string, string> ListName = new Dictionary<string, string>();
        private void AddFoodButton_Click(object sender, EventArgs e)
        {
            int index_addnote = 0;
            float thanh_tien = GetDonGia() * (int)AmountOfFoodNud.Value;                                //Lưu 1 biến để tính thành tiền
            if (FoodNameTb.Text != "")
            {
                if (ListName.ContainsKey(FoodNameTb.Text))                          //Kiểm tra xem món ăn đó đã được thêm vào danh sách hay chưa
                {
                    foreach (ListViewItem item in OrderLv.Items)                //Duyệt các item trong listitem
                    {
                        if (item.SubItems[1].Text == FoodNameTb.Text)           //Nếu subitem chứa tên món trùng với tên món đã thêm => Cập nhật số lượng
                        {
                            int old_quantity = Convert.ToInt32(item.SubItems[2].Text);              //Lưu số lượng cũ từ subitem chứa số lượng
                            int new_quantity = Convert.ToInt32(AmountOfFoodNud.Text);               //Lưu số lượng mới từ AmountOfFoodNud
                            item.SubItems[2].Text = (old_quantity + new_quantity).ToString();       //Cộng 2 số lượng lại và cập nhật lại ở subitem chứa số lượng

                            float old_amount = Convert.ToInt32(item.SubItems[4].Text);              //Lưu thành tiền từ số lượng cũ của món
                            float new_amount = new_quantity * GetDonGia();                          //Tính thành tiền từ số lượng mới của món
                            item.SubItems[4].Text = (new_amount + old_amount).ToString();           //Cập nhật lại thành tiền mới của món
                            tong_tien += new_amount;                                                //Cộng thành tiền của số lượng mới vào tồng tiền

                            index_addnote = item.Index + 1;                                         //Lưu index để thêm note                         
                            if (NoteTb.Text != "")
                            {
                                while (index_addnote < OrderLv.Items.Count && OrderLv.Items[index_addnote].Text == "")
                                {
                                    index_addnote++;                                                    //Di chuyển đến vị trí cuối của note cũ
                                }
                                string sentence = NoteTb.Text;
                                ListName[FoodNameTb.Text] = ListName[FoodNameTb.Text] + ", " + NoteTb.Text;
                                string[] words = sentence.Split(',');
                                for (int i = words.Count() - 1; i >= 0; i--)
                                {
                                    ListViewItem item2 = new ListViewItem(Text = "");
                                    OrderLv.Items.Insert(index_addnote, item2);           //Chèn ghi chú vào index đã lưu trước đó
                                    item2.SubItems.Add("    " + words[i]);
                                }
                            }
                            break;
                        }
                    }
                }
                else
                {
                    count++;                                                //Mỗi lần click thêm món, STT sẽ được cộng 1 lên
                    string count_stt = Convert.ToString(count);             //Convert STT dạng số sang dạng chuỗi
                    ListName.Add(FoodNameTb.Text, NoteTb.Text);
                    ListViewItem item1 = new ListViewItem() { Text = count_stt };                               //Ô item sẽ chứa Item
                    OrderLv.Items.Add(item1);                                                                   //Thêm Item
                    item1.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = FoodNameTb.Text });          //Tên món nằm ở SubItem[0]
                    item1.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = AmountOfFoodNud.Text });     //Số lượng món nằm ở SubItem[1]
                    item1.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = GetDonGia().ToString() });   //Đơn giá nằm ở SubItem[2]
                    item1.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = thanh_tien.ToString() });    //Thành tiền nằm ở SubItem[3]
                    if (NoteTb.Text != "")                                                                      //Nếu có ghi chú
                    {
                        string sentence = NoteTb.Text;                                                          //Tạo một chuỗi lưu ghi chú
                        string[] words = sentence.Split(',');                                                   //Tách các ghi chú bởi dấu phẩy và lưu lại trong mảng
                        foreach (var word in words)                                                             //Duyệt từng thành phần trong mảng
                        {
                            ListViewItem item2 = new ListViewItem() { Text = "" };                              //item đầu chứa STT => dòng nào có Ghi chú, item của dòng đó sẽ trống
                            OrderLv.Items.Add(item2);                                                           //Thêm item
                            item2.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = "    " + word });    //Thêm ghi chú vào SubItem[0] và tiếp tục vòng lặp cho đến hết mảng
                        }
                    }
                    tong_tien += thanh_tien;
                }
                TotalMoneyTb.Text = tong_tien.ToString();
                NoteTb.Text = "";
                AmountOfFoodNud.Value = 1;
            }
            else
            {
                MessageBox.Show("Hãy chọn món trước khi thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (OrderLv.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in OrderLv.Items)
                {
                    if (ListName.ContainsKey(item.SubItems[1].Text))
                    {
                        ListName.Remove(item.SubItems[1].Text);
                    }
                }

                tong_tien -= float.Parse(OrderLv.SelectedItems[0].SubItems[4].Text);
                TotalMoneyTb.Text = tong_tien.ToString();

                if (OrderLv.Items.Count > 0)
                {
                    int count_stt = Convert.ToInt32(OrderLv.SelectedItems[0].Text);                 //Get STT của item được chọn ở dạng số 
                    int index_stt = OrderLv.SelectedItems[0].Index;                                 //Get index để cập nhật STT

                    int index = OrderLv.SelectedItems[0].Index;                                     //Get index của item bị xóa
                    OrderLv.Items.Remove(OrderLv.SelectedItems[0]);                                 //Xóa item được chọn
                    while (index < OrderLv.Items.Count && OrderLv.Items[index].Text == "")          //Lấy mốc index phía trên để xóa các dòng ghi chú của món
                    {
                        OrderLv.Items.RemoveAt(index);                                              // Xóa dòng có chứa ghi chú của món
                    }

                    if (count_stt == 1)                                                             //Cập nhật lại STT nếu xóa đầu danh sách
                    {
                        foreach (ListViewItem item in OrderLv.Items)                                //Duyệt từ đầu danh sách
                        {
                            if (item.Text != "")                                                    //Nếu item đó không rỗng == item đó có STT
                            {
                                item.Text = count_stt.ToString();                                   //Cập nhật lại STT
                                count_stt++;                                                        //Cộng STT lên và tiếp tục vòng lặp
                            }
                        }
                    }
                    else if (count_stt > 1 && count_stt < count)                                    //Cập nhật lại STT nếu xóa giữa danh sách
                    {
                        while (index_stt < OrderLv.Items.Count)                                     //Duyệt danh sách từ vị trí index của item đã xóa mà đã được lưu ở dòng trên
                        {                                                                           //index_stt đóng vai trò là 1 biến chạy trong vòng lặp này
                            if (OrderLv.Items[index_stt].Text != "")                                //Nếu item đó không rỗng == item đó có STT 
                            {
                                OrderLv.Items[index_stt].Text = count_stt.ToString();               //Cập nhật lại STT
                                count_stt++;                                                        //Cộng STT lên
                            }
                            index_stt++;                                                            //Cộng index lên và di chuyển đến item kế, tiếp tục vòng lặp
                        }
                    }
                }
                count--;                //Mỗi lần click xóa món, STT sẽ được giảm xuống
            }
            else
            {
                MessageBox.Show("Hãy chọn món trước khi xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MenuLv_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lsv = sender as ListView;

            if (lsv.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = MenuLv.SelectedItems[0];

                string Ten_mon_Column = selectedItem.SubItems[0].Text;
                string Don_gia_Column = selectedItem.SubItems[1].Text;

                //MessageBox.Show($"{Ten_mon_Column} : {Don_gia_Column}");
                FoodNameTb.Text = Ten_mon_Column;
                NoteTb.Text = "";
            }
        }
        private void MoneyGivingByCustomerTb_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (string.IsNullOrWhiteSpace(TotalMoneyTb.Text) || string.IsNullOrWhiteSpace(tb.Text))
            {
                ChangeTb.Text = string.Empty;
                return;
            }


            float moneyGiving;

            if (float.TryParse(TotalMoneyTb.Text, out tong_tien) && float.TryParse(tb.Text, out moneyGiving))
            {
                float change = moneyGiving - tong_tien;

                ChangeTb.Text = change.ToString();
                float khachDua = float.Parse(tb.Text);
                float tienThua = khachDua - tong_tien;
            }
            else
            {
                if (MessageBox.Show("Kí tự không hợp lệ!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.OK)
                {
                    MoneyGivingByCustomerTb.Text = "0";
                }
            }
        }

        //private int selectedMaCTDH;
        //private void OrderLv_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ListView lsv = sender as ListView;

        //    if (lsv.SelectedItems.Count > 0)
        //    {
        //        ListViewItem selectedItem = OrderLv.SelectedItems[0];

        //        string maCTDHValue = selectedItem.SubItems[5].Text;

        //        selectedMaCTDH = Convert.ToInt32(maCTDHValue); 
        //    }
        //}
        #endregion
    }
}

