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
using System.IO;

namespace QuanAn
{
    public partial class UcThucDon : UserControl
    {
        public static UcThucDon instance;

        public DataGridView foodDataGridView;
        public UcThucDon()
        {
            instance = this;
            InitializeComponent();
            FoodNameTb.Enabled = false;
            PriceNud.Enabled = false;
            foodDataGridView = FoodDataGridView;
        }

        private List<Food> FoodList = FoodDAO.Instance.LoadFoodWithFixedExtras();
        private List<Food> uniqueFoodList = new List<Food>();
        public void LoadFood()
        {

            FoodList = FoodDAO.Instance.LoadFoodWithFixedExtras();
            // Tạo danh sách mới để chứa các dòng không trùng lặp
            uniqueFoodList.Clear();
            ReadIntegersFromFile();
            foreach (Food food in FoodList)
            {
                bool isDuplicate = false;
                int maMN = food.MaMN;

                // Kiểm tra xem MaMN có tồn tại trong danh sách numbers không
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
            FoodDataGridView.DataSource = null;
            FoodDataGridView.DataSource = uniqueFoodList;
            FoodDataGridView.Columns["MaMN"].Visible = false;
            FoodDataGridView.Columns["So_luong"].Visible = false;
            FoodDataGridView.Columns["Ghi_chu"].Visible = false;
            FoodDataGridView.Columns["Thanh_tien"].Visible = false;
            FoodDataGridView.Columns["MaCTDH"].Visible = false;

            DataGridViewColumn colTenMon = FoodDataGridView.Columns["Ten_mon"];
            colTenMon.DisplayIndex = 0;
            colTenMon.Width = 200;

            DataGridViewColumn colDonGia = FoodDataGridView.Columns["Don_gia"];
            colDonGia.DisplayIndex = 1;
        }
        
        private void ResetTb()
        {
            FoodIdTb.Text = "0";
            FoodNameTb.Text = "";
            PriceNud.Value = 0;
        }

        private enum EditStage
        {
            Initial, 
            Editable 
        }

        private EditStage editStage = EditStage.Initial;

        private int MaMN = -1;

        private void FoodDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;

            if (dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                int selectedIndex = selectedRow.Index;
                
                if (selectedIndex >= 0 && selectedIndex < FoodList.Count)
                {
                    Food selectedFood = uniqueFoodList[selectedIndex];

                    // Sử dụng dữ liệu từ foodList
                    int maMN = selectedFood.MaMN;
                    double Don_gia = selectedFood.Don_gia;
                    string Ten_mon = selectedFood.Ten_mon;
                    MaMN = maMN;
                    FoodNameTb.Enabled = false;
                    PriceNud.Enabled = false;
                    FoodIdTb.Text = maMN.ToString();
                    FoodNameTb.Text = Ten_mon;
                    PriceNud.Value = (decimal)Don_gia;
                }
            }
        }

        private bool isFirstClick = true;
        List<string> FoodListName = new List<string>();

        private void AddFoodToFoodList()
        {
            foreach (Food food in uniqueFoodList)
            {
                string Ten_mon = food.Ten_mon;
                FoodListName.Add(Ten_mon);
            }
        }

        private void AddFoodButton_Click(object sender, EventArgs e)
        {
            if (isFirstClick)
            {
                FoodNameTb.Enabled = true;
                PriceNud.Enabled = true;

                ResetTb();

                isFirstClick = false;
            }
            else
            {
                AddFoodToFoodList();
                FoodNameTb.Enabled = false;
                PriceNud.Enabled = false;

                if (FoodListName.Contains(FoodNameTb.Text))
                {
                    MessageBox.Show("Tên món bị trùng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoadFood();
                    FoodNameTb.Enabled = false;
                    PriceNud.Enabled = false;
                    isFirstClick = true;
                    ResetTb();
                }
                else
                {
                    if (string.IsNullOrEmpty(FoodNameTb.Text) || PriceNud.Value == 0)
                    {
                        MessageBox.Show("Vui lòng nhập tên món và giá trước khi thêm.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        FoodNameTb.Enabled = true;
                        PriceNud.Enabled = true;
                        isFirstClick = false;
                    }
                    else
                    {
                        FoodDAO.Instance.InsertFoodToThucDon(FoodNameTb.Text, (float)PriceNud.Value);
                        FoodListName.Add(FoodNameTb.Text);

                        ResetTb();

                        FoodNameTb.Enabled = false;
                        PriceNud.Enabled = false;
                        isFirstClick = true;

                        if (UcDonHang.instance != null)
                        {
                            UcDonHang.instance.LoadFood();
                        }
                    }
                    // Gọi lại hàm LoadFood để cập nhật dữ liệu hiển thị trên DataGridView
                    LoadFood();
                }
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

        private async void DeleteFoodButton_Click(object sender, EventArgs e)
        {
            string filePath = (Application.StartupPath + "\\File\\DeletedFoodList.txt");
        
            try
            {
                await Task.Run(() =>
                {
                    using (StreamWriter sw = new StreamWriter(filePath, true)) // Chế độ ghi thêm (append)
                    {
                        sw.WriteLine(MaMN.ToString() + "\n");
                    }
                });

                Console.WriteLine("Ghi tệp thành công!");
            }
            catch (IOException ex)
            {
                MessageBox.Show("Lỗi ghi tệp: " + ex.Message);
            }

            if (MaMN != -1)
            {
                // Xóa dữ liệu từ CSDL dựa trên MaMN
                //FoodDAO.Instance.DeleteFoodFromThucDon(MaMN);

                // Tải lại danh sách thực đơn
                LoadFood();

                // Đặt MaMN về giá trị mặc định
                MaMN = -1;
                ResetTb();
                LoadFood();
                FoodNameTb.Enabled = false;
                PriceNud.Enabled = false;
                isFirstClick = true;
                if (UcDonHang.instance != null)
                {
                    UcDonHang.instance.LoadFood();
                }
            }
        }

        private string initialFoodName = ""; // Biến lưu trữ giá trị ban đầu của textbox tên món

        private void EditFoodButton_Click(object sender, EventArgs e)
        {
            if (editStage == EditStage.Initial)
            {
                //FoodNameTb.Enabled = true;
                PriceNud.Enabled = true;

                // Lưu giá trị ban đầu của textbox
                initialFoodName = FoodNameTb.Text;

                editStage = EditStage.Editable;
            }
            else if (editStage == EditStage.Editable)
            {
                // Lấy tên món bạn đang sửa
                string editedFoodName = FoodNameTb.Text;

                // Kiểm tra xem tên món đã thay đổi so với giá trị ban đầu
                bool hasChanged = initialFoodName != editedFoodName;

                if (hasChanged)
                {
                    // Kiểm tra xem tên món đã tồn tại trong danh sách món khác chưa
                    bool isNameDuplicate = FoodList.Any(food => food.Ten_mon == editedFoodName);

                    if (isNameDuplicate)
                    {
                        MessageBox.Show("Tên món bị trùng với món khác. Vui lòng chọn tên khác.", "Trùng tên món", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Không thực hiện cập nhật nếu trùng tên
                        //FoodNameTb.Enabled = true;
                        PriceNud.Enabled = true;
                    }
                }

                if (string.IsNullOrEmpty(editedFoodName) || PriceNud.Value == 0)
                {
                    MessageBox.Show("Vui lòng giá trước khi cập nhật.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Thực hiện cập nhật thông tin món
                    FoodDAO.Instance.UpdateFood(MaMN, editedFoodName, (float)PriceNud.Value);
                    LoadFood();
                    MaMN = -1;
                    editStage = EditStage.Initial;
                    //FoodNameTb.Enabled = false;
                    PriceNud.Enabled = false;
                    if (UcDonHang.instance != null)
                    {
                        UcDonHang.instance.LoadFood();
                    }
                }
            }
        }
    }
}
