namespace QuanAn
{
    partial class UcThucDon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PriceNud = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.MenuDisplayPanel = new System.Windows.Forms.Panel();
            this.FoodNameTb = new System.Windows.Forms.TextBox();
            this.FoodIdTb = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.MenuFunctionPanel = new System.Windows.Forms.Panel();
            this.EditFoodButton = new System.Windows.Forms.Button();
            this.DeleteFoodButton = new System.Windows.Forms.Button();
            this.AddFoodButton = new System.Windows.Forms.Button();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.FoodDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.PriceNud)).BeginInit();
            this.MenuDisplayPanel.SuspendLayout();
            this.MenuFunctionPanel.SuspendLayout();
            this.MenuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FoodDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // PriceNud
            // 
            this.PriceNud.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PriceNud.Location = new System.Drawing.Point(246, 145);
            this.PriceNud.Margin = new System.Windows.Forms.Padding(6);
            this.PriceNud.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.PriceNud.Name = "PriceNud";
            this.PriceNud.Size = new System.Drawing.Size(580, 41);
            this.PriceNud.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 4);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(207, 46);
            this.label9.TabIndex = 8;
            this.label9.Text = "Thực đơn:";
            // 
            // MenuDisplayPanel
            // 
            this.MenuDisplayPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MenuDisplayPanel.Controls.Add(this.PriceNud);
            this.MenuDisplayPanel.Controls.Add(this.FoodNameTb);
            this.MenuDisplayPanel.Controls.Add(this.FoodIdTb);
            this.MenuDisplayPanel.Controls.Add(this.label12);
            this.MenuDisplayPanel.Controls.Add(this.label11);
            this.MenuDisplayPanel.Controls.Add(this.label10);
            this.MenuDisplayPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuDisplayPanel.Location = new System.Drawing.Point(928, 64);
            this.MenuDisplayPanel.Margin = new System.Windows.Forms.Padding(6);
            this.MenuDisplayPanel.Name = "MenuDisplayPanel";
            this.MenuDisplayPanel.Size = new System.Drawing.Size(852, 988);
            this.MenuDisplayPanel.TabIndex = 7;
            // 
            // FoodNameTb
            // 
            this.FoodNameTb.Location = new System.Drawing.Point(246, 78);
            this.FoodNameTb.Margin = new System.Windows.Forms.Padding(6);
            this.FoodNameTb.Name = "FoodNameTb";
            this.FoodNameTb.Size = new System.Drawing.Size(576, 41);
            this.FoodNameTb.TabIndex = 4;
            // 
            // FoodIdTb
            // 
            this.FoodIdTb.Location = new System.Drawing.Point(246, 10);
            this.FoodIdTb.Margin = new System.Windows.Forms.Padding(6);
            this.FoodIdTb.Name = "FoodIdTb";
            this.FoodIdTb.ReadOnly = true;
            this.FoodIdTb.Size = new System.Drawing.Size(576, 41);
            this.FoodIdTb.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 145);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(134, 36);
            this.label12.TabIndex = 2;
            this.label12.Text = "Đơn giá:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 78);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(147, 36);
            this.label11.TabIndex = 1;
            this.label11.Text = "Tên món:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 10);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(180, 36);
            this.label10.TabIndex = 0;
            this.label10.Text = "Mã món ăn:";
            // 
            // MenuFunctionPanel
            // 
            this.MenuFunctionPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MenuFunctionPanel.Controls.Add(this.EditFoodButton);
            this.MenuFunctionPanel.Controls.Add(this.DeleteFoodButton);
            this.MenuFunctionPanel.Controls.Add(this.AddFoodButton);
            this.MenuFunctionPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuFunctionPanel.Location = new System.Drawing.Point(928, 1064);
            this.MenuFunctionPanel.Margin = new System.Windows.Forms.Padding(6);
            this.MenuFunctionPanel.Name = "MenuFunctionPanel";
            this.MenuFunctionPanel.Size = new System.Drawing.Size(852, 176);
            this.MenuFunctionPanel.TabIndex = 6;
            // 
            // EditFoodButton
            // 
            this.EditFoodButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EditFoodButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditFoodButton.Location = new System.Drawing.Point(450, 35);
            this.EditFoodButton.Margin = new System.Windows.Forms.Padding(6);
            this.EditFoodButton.Name = "EditFoodButton";
            this.EditFoodButton.Size = new System.Drawing.Size(200, 114);
            this.EditFoodButton.TabIndex = 2;
            this.EditFoodButton.Text = "Sửa";
            this.EditFoodButton.UseVisualStyleBackColor = true;
            this.EditFoodButton.Click += new System.EventHandler(this.EditFoodButton_Click);
            // 
            // DeleteFoodButton
            // 
            this.DeleteFoodButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DeleteFoodButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteFoodButton.Location = new System.Drawing.Point(230, 35);
            this.DeleteFoodButton.Margin = new System.Windows.Forms.Padding(6);
            this.DeleteFoodButton.Name = "DeleteFoodButton";
            this.DeleteFoodButton.Size = new System.Drawing.Size(200, 114);
            this.DeleteFoodButton.TabIndex = 1;
            this.DeleteFoodButton.Text = "Xóa";
            this.DeleteFoodButton.UseVisualStyleBackColor = true;
            this.DeleteFoodButton.Click += new System.EventHandler(this.DeleteFoodButton_Click);
            // 
            // AddFoodButton
            // 
            this.AddFoodButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddFoodButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddFoodButton.Location = new System.Drawing.Point(10, 35);
            this.AddFoodButton.Margin = new System.Windows.Forms.Padding(6);
            this.AddFoodButton.Name = "AddFoodButton";
            this.AddFoodButton.Size = new System.Drawing.Size(200, 114);
            this.AddFoodButton.TabIndex = 0;
            this.AddFoodButton.Text = "Thêm";
            this.AddFoodButton.UseVisualStyleBackColor = true;
            this.AddFoodButton.Click += new System.EventHandler(this.AddFoodButton_Click);
            // 
            // MenuPanel
            // 
            this.MenuPanel.Controls.Add(this.FoodDataGridView);
            this.MenuPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuPanel.Location = new System.Drawing.Point(16, 58);
            this.MenuPanel.Margin = new System.Windows.Forms.Padding(6);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(896, 1182);
            this.MenuPanel.TabIndex = 5;
            // 
            // FoodDataGridView
            // 
            this.FoodDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.FoodDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.FoodDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FoodDataGridView.Location = new System.Drawing.Point(0, 0);
            this.FoodDataGridView.Margin = new System.Windows.Forms.Padding(6);
            this.FoodDataGridView.Name = "FoodDataGridView";
            this.FoodDataGridView.RowHeadersWidth = 51;
            this.FoodDataGridView.RowTemplate.Height = 24;
            this.FoodDataGridView.Size = new System.Drawing.Size(896, 1182);
            this.FoodDataGridView.StandardTab = true;
            this.FoodDataGridView.TabIndex = 0;
            this.FoodDataGridView.SelectionChanged += new System.EventHandler(this.FoodDataGridView_SelectionChanged);
            // 
            // UcThucDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label9);
            this.Controls.Add(this.MenuDisplayPanel);
            this.Controls.Add(this.MenuFunctionPanel);
            this.Controls.Add(this.MenuPanel);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "UcThucDon";
            this.Size = new System.Drawing.Size(1800, 1246);
            ((System.ComponentModel.ISupportInitialize)(this.PriceNud)).EndInit();
            this.MenuDisplayPanel.ResumeLayout(false);
            this.MenuDisplayPanel.PerformLayout();
            this.MenuFunctionPanel.ResumeLayout(false);
            this.MenuPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FoodDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown PriceNud;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel MenuDisplayPanel;
        private System.Windows.Forms.TextBox FoodNameTb;
        private System.Windows.Forms.TextBox FoodIdTb;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel MenuFunctionPanel;
        private System.Windows.Forms.Button EditFoodButton;
        private System.Windows.Forms.Button DeleteFoodButton;
        private System.Windows.Forms.Button AddFoodButton;
        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.DataGridView FoodDataGridView;
    }
}
