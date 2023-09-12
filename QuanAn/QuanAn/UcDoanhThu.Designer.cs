namespace QuanAn
{
    partial class UcDoanhThu
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.OrderDataGridView = new System.Windows.Forms.DataGridView();
            this.OrderFunctionPanel = new System.Windows.Forms.Panel();
            this.NumberOfOrdersTb = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CalculateRevenueByDayButton = new System.Windows.Forms.Button();
            this.CalculateRevenueByMonthButton = new System.Windows.Forms.Button();
            this.RevenueTb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.RevenueDtp = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.OrderDisplayPanel = new System.Windows.Forms.Panel();
            this.ChangeTb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.MoneyGivingByCustomerTb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TotalMoneyTb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FoodListLv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.OrderTb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OrderRevenuePanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDataGridView)).BeginInit();
            this.OrderFunctionPanel.SuspendLayout();
            this.OrderDisplayPanel.SuspendLayout();
            this.OrderRevenuePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // OrderDataGridView
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.OrderDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.OrderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.OrderDataGridView.DefaultCellStyle = dataGridViewCellStyle8;
            this.OrderDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrderDataGridView.Location = new System.Drawing.Point(0, 0);
            this.OrderDataGridView.Margin = new System.Windows.Forms.Padding(6);
            this.OrderDataGridView.Name = "OrderDataGridView";
            this.OrderDataGridView.RowHeadersWidth = 51;
            this.OrderDataGridView.RowTemplate.Height = 24;
            this.OrderDataGridView.Size = new System.Drawing.Size(896, 796);
            this.OrderDataGridView.TabIndex = 0;
            this.OrderDataGridView.SelectionChanged += new System.EventHandler(this.OrderDataGridView_SelectionChanged);
            // 
            // OrderFunctionPanel
            // 
            this.OrderFunctionPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.OrderFunctionPanel.Controls.Add(this.NumberOfOrdersTb);
            this.OrderFunctionPanel.Controls.Add(this.label9);
            this.OrderFunctionPanel.Controls.Add(this.CalculateRevenueByDayButton);
            this.OrderFunctionPanel.Controls.Add(this.CalculateRevenueByMonthButton);
            this.OrderFunctionPanel.Controls.Add(this.RevenueTb);
            this.OrderFunctionPanel.Controls.Add(this.label7);
            this.OrderFunctionPanel.Controls.Add(this.RevenueDtp);
            this.OrderFunctionPanel.Controls.Add(this.label8);
            this.OrderFunctionPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderFunctionPanel.Location = new System.Drawing.Point(16, 866);
            this.OrderFunctionPanel.Margin = new System.Windows.Forms.Padding(6);
            this.OrderFunctionPanel.Name = "OrderFunctionPanel";
            this.OrderFunctionPanel.Size = new System.Drawing.Size(896, 374);
            this.OrderFunctionPanel.TabIndex = 9;
            // 
            // NumberOfOrdersTb
            // 
            this.NumberOfOrdersTb.Location = new System.Drawing.Point(320, 149);
            this.NumberOfOrdersTb.Margin = new System.Windows.Forms.Padding(6);
            this.NumberOfOrdersTb.Name = "NumberOfOrdersTb";
            this.NumberOfOrdersTb.ReadOnly = true;
            this.NumberOfOrdersTb.Size = new System.Drawing.Size(490, 41);
            this.NumberOfOrdersTb.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 145);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(215, 36);
            this.label9.TabIndex = 13;
            this.label9.Text = "Số lượng đơn:";
            // 
            // CalculateRevenueByDayButton
            // 
            this.CalculateRevenueByDayButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CalculateRevenueByDayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CalculateRevenueByDayButton.Location = new System.Drawing.Point(12, 227);
            this.CalculateRevenueByDayButton.Margin = new System.Windows.Forms.Padding(6);
            this.CalculateRevenueByDayButton.Name = "CalculateRevenueByDayButton";
            this.CalculateRevenueByDayButton.Size = new System.Drawing.Size(382, 138);
            this.CalculateRevenueByDayButton.TabIndex = 12;
            this.CalculateRevenueByDayButton.Text = "Tổng hợp doanh thu theo ngày";
            this.CalculateRevenueByDayButton.UseVisualStyleBackColor = true;
            this.CalculateRevenueByDayButton.Click += new System.EventHandler(this.CalculateRevenueByDayButton_Click);
            // 
            // CalculateRevenueByMonthButton
            // 
            this.CalculateRevenueByMonthButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CalculateRevenueByMonthButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CalculateRevenueByMonthButton.Location = new System.Drawing.Point(422, 227);
            this.CalculateRevenueByMonthButton.Margin = new System.Windows.Forms.Padding(6);
            this.CalculateRevenueByMonthButton.Name = "CalculateRevenueByMonthButton";
            this.CalculateRevenueByMonthButton.Size = new System.Drawing.Size(382, 138);
            this.CalculateRevenueByMonthButton.TabIndex = 11;
            this.CalculateRevenueByMonthButton.Text = "Tổng hợp doanh thu theo tháng";
            this.CalculateRevenueByMonthButton.UseVisualStyleBackColor = true;
            this.CalculateRevenueByMonthButton.Click += new System.EventHandler(this.CalculateRevenueByMonthButton_Click);
            // 
            // RevenueTb
            // 
            this.RevenueTb.Location = new System.Drawing.Point(320, 78);
            this.RevenueTb.Margin = new System.Windows.Forms.Padding(6);
            this.RevenueTb.Name = "RevenueTb";
            this.RevenueTb.ReadOnly = true;
            this.RevenueTb.Size = new System.Drawing.Size(490, 41);
            this.RevenueTb.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 78);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(171, 36);
            this.label7.TabIndex = 9;
            this.label7.Text = "Doanh thu:";
            // 
            // RevenueDtp
            // 
            this.RevenueDtp.CustomFormat = "yyyy-MM-dd";
            this.RevenueDtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.RevenueDtp.Location = new System.Drawing.Point(320, 10);
            this.RevenueDtp.Margin = new System.Windows.Forms.Padding(6);
            this.RevenueDtp.Name = "RevenueDtp";
            this.RevenueDtp.Size = new System.Drawing.Size(490, 41);
            this.RevenueDtp.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 10);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(288, 68);
            this.label8.TabIndex = 7;
            this.label8.Text = "Chọn ngày tháng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 46);
            this.label1.TabIndex = 8;
            this.label1.Text = "Các đơn hàng";
            // 
            // OrderDisplayPanel
            // 
            this.OrderDisplayPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.OrderDisplayPanel.Controls.Add(this.ChangeTb);
            this.OrderDisplayPanel.Controls.Add(this.label6);
            this.OrderDisplayPanel.Controls.Add(this.MoneyGivingByCustomerTb);
            this.OrderDisplayPanel.Controls.Add(this.label5);
            this.OrderDisplayPanel.Controls.Add(this.TotalMoneyTb);
            this.OrderDisplayPanel.Controls.Add(this.label4);
            this.OrderDisplayPanel.Controls.Add(this.FoodListLv);
            this.OrderDisplayPanel.Controls.Add(this.label3);
            this.OrderDisplayPanel.Controls.Add(this.OrderTb);
            this.OrderDisplayPanel.Controls.Add(this.label2);
            this.OrderDisplayPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderDisplayPanel.Location = new System.Drawing.Point(928, 58);
            this.OrderDisplayPanel.Margin = new System.Windows.Forms.Padding(6);
            this.OrderDisplayPanel.Name = "OrderDisplayPanel";
            this.OrderDisplayPanel.Size = new System.Drawing.Size(848, 1182);
            this.OrderDisplayPanel.TabIndex = 7;
            // 
            // ChangeTb
            // 
            this.ChangeTb.Location = new System.Drawing.Point(292, 882);
            this.ChangeTb.Margin = new System.Windows.Forms.Padding(6);
            this.ChangeTb.Name = "ChangeTb";
            this.ChangeTb.ReadOnly = true;
            this.ChangeTb.Size = new System.Drawing.Size(534, 41);
            this.ChangeTb.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 882);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 36);
            this.label6.TabIndex = 8;
            this.label6.Text = "Tiền thừa:";
            // 
            // MoneyGivingByCustomerTb
            // 
            this.MoneyGivingByCustomerTb.Location = new System.Drawing.Point(292, 814);
            this.MoneyGivingByCustomerTb.Margin = new System.Windows.Forms.Padding(6);
            this.MoneyGivingByCustomerTb.Name = "MoneyGivingByCustomerTb";
            this.MoneyGivingByCustomerTb.ReadOnly = true;
            this.MoneyGivingByCustomerTb.Size = new System.Drawing.Size(534, 41);
            this.MoneyGivingByCustomerTb.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 814);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 36);
            this.label5.TabIndex = 6;
            this.label5.Text = "Khách đưa:";
            // 
            // TotalMoneyTb
            // 
            this.TotalMoneyTb.Location = new System.Drawing.Point(292, 746);
            this.TotalMoneyTb.Margin = new System.Windows.Forms.Padding(6);
            this.TotalMoneyTb.Name = "TotalMoneyTb";
            this.TotalMoneyTb.ReadOnly = true;
            this.TotalMoneyTb.Size = new System.Drawing.Size(534, 41);
            this.TotalMoneyTb.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 746);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 36);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tổng tiền:";
            // 
            // FoodListLv
            // 
            this.FoodListLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.FoodListLv.FullRowSelect = true;
            this.FoodListLv.GridLines = true;
            this.FoodListLv.HideSelection = false;
            this.FoodListLv.Location = new System.Drawing.Point(292, 78);
            this.FoodListLv.Margin = new System.Windows.Forms.Padding(6);
            this.FoodListLv.Name = "FoodListLv";
            this.FoodListLv.Size = new System.Drawing.Size(534, 641);
            this.FoodListLv.TabIndex = 3;
            this.FoodListLv.UseCompatibleStateImageBehavior = false;
            this.FoodListLv.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên món";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "MaMN";
            this.columnHeader2.Width = 50;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(256, 101);
            this.label3.TabIndex = 2;
            this.label3.Text = "Danh sách món ăn:";
            // 
            // OrderTb
            // 
            this.OrderTb.Location = new System.Drawing.Point(292, 10);
            this.OrderTb.Margin = new System.Windows.Forms.Padding(6);
            this.OrderTb.Name = "OrderTb";
            this.OrderTb.ReadOnly = true;
            this.OrderTb.Size = new System.Drawing.Size(534, 41);
            this.OrderTb.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 36);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã đơn hàng:";
            // 
            // OrderRevenuePanel
            // 
            this.OrderRevenuePanel.Controls.Add(this.OrderDataGridView);
            this.OrderRevenuePanel.Location = new System.Drawing.Point(16, 58);
            this.OrderRevenuePanel.Margin = new System.Windows.Forms.Padding(6);
            this.OrderRevenuePanel.Name = "OrderRevenuePanel";
            this.OrderRevenuePanel.Size = new System.Drawing.Size(896, 796);
            this.OrderRevenuePanel.TabIndex = 6;
            // 
            // UcDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.OrderFunctionPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OrderDisplayPanel);
            this.Controls.Add(this.OrderRevenuePanel);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "UcDoanhThu";
            this.Size = new System.Drawing.Size(1800, 1246);
            ((System.ComponentModel.ISupportInitialize)(this.OrderDataGridView)).EndInit();
            this.OrderFunctionPanel.ResumeLayout(false);
            this.OrderFunctionPanel.PerformLayout();
            this.OrderDisplayPanel.ResumeLayout(false);
            this.OrderDisplayPanel.PerformLayout();
            this.OrderRevenuePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView OrderDataGridView;
        private System.Windows.Forms.Panel OrderFunctionPanel;
        private System.Windows.Forms.Button CalculateRevenueByDayButton;
        private System.Windows.Forms.Button CalculateRevenueByMonthButton;
        private System.Windows.Forms.TextBox RevenueTb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker RevenueDtp;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel OrderDisplayPanel;
        private System.Windows.Forms.TextBox ChangeTb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox MoneyGivingByCustomerTb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TotalMoneyTb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView FoodListLv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox OrderTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel OrderRevenuePanel;
        private System.Windows.Forms.TextBox NumberOfOrdersTb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}
