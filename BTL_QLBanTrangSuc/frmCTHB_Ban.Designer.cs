namespace BTL_QLBanTrangSuc
{
    partial class frmCTHB_Ban
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvSanPham_Mua = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbSoHD = new System.Windows.Forms.Label();
            this.lbTenNV = new System.Windows.Forms.Label();
            this.lbTenKH = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbTongGia = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.sTenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnX = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham_Mua)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSanPham_Mua
            // 
            this.dgvSanPham_Mua.AllowUserToAddRows = false;
            this.dgvSanPham_Mua.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSanPham_Mua.BackgroundColor = System.Drawing.Color.White;
            this.dgvSanPham_Mua.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSanPham_Mua.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sTenSP,
            this.iSoLuong,
            this.fDonGia,
            this.fThanhTien});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSanPham_Mua.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSanPham_Mua.Location = new System.Drawing.Point(7, 162);
            this.dgvSanPham_Mua.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvSanPham_Mua.Name = "dgvSanPham_Mua";
            this.dgvSanPham_Mua.ReadOnly = true;
            this.dgvSanPham_Mua.Size = new System.Drawing.Size(418, 150);
            this.dgvSanPham_Mua.TabIndex = 0;
            this.dgvSanPham_Mua.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPham_Mua_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Số hoá đơn:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 119);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nhân viên:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 95);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Khách Hàng:";
            // 
            // lbSoHD
            // 
            this.lbSoHD.AutoSize = true;
            this.lbSoHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoHD.Location = new System.Drawing.Point(134, 71);
            this.lbSoHD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSoHD.Name = "lbSoHD";
            this.lbSoHD.Size = new System.Drawing.Size(44, 16);
            this.lbSoHD.TabIndex = 4;
            this.lbSoHD.Text = "label4";
            // 
            // lbTenNV
            // 
            this.lbTenNV.AutoSize = true;
            this.lbTenNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenNV.Location = new System.Drawing.Point(134, 119);
            this.lbTenNV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTenNV.Name = "lbTenNV";
            this.lbTenNV.Size = new System.Drawing.Size(44, 16);
            this.lbTenNV.TabIndex = 5;
            this.lbTenNV.Text = "label5";
            // 
            // lbTenKH
            // 
            this.lbTenKH.AutoSize = true;
            this.lbTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenKH.Location = new System.Drawing.Point(134, 95);
            this.lbTenKH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTenKH.Name = "lbTenKH";
            this.lbTenKH.Size = new System.Drawing.Size(44, 16);
            this.lbTenKH.TabIndex = 6;
            this.lbTenKH.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(275, 336);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Tổng giá:";
            // 
            // lbTongGia
            // 
            this.lbTongGia.AutoSize = true;
            this.lbTongGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongGia.Location = new System.Drawing.Point(343, 336);
            this.lbTongGia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTongGia.Name = "lbTongGia";
            this.lbTongGia.Size = new System.Drawing.Size(44, 16);
            this.lbTongGia.TabIndex = 8;
            this.lbTongGia.Text = "label8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(132, 29);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(163, 25);
            this.label9.TabIndex = 9;
            this.label9.Text = "Chi tiết hoá đơn";
            // 
            // sTenSP
            // 
            this.sTenSP.DataPropertyName = "sTenSP";
            this.sTenSP.FillWeight = 121.8274F;
            this.sTenSP.HeaderText = "Tên Sản Phẩm";
            this.sTenSP.Name = "sTenSP";
            this.sTenSP.ReadOnly = true;
            // 
            // iSoLuong
            // 
            this.iSoLuong.DataPropertyName = "iSoLuong";
            this.iSoLuong.FillWeight = 92.72421F;
            this.iSoLuong.HeaderText = "Số Lượng";
            this.iSoLuong.Name = "iSoLuong";
            this.iSoLuong.ReadOnly = true;
            // 
            // fDonGia
            // 
            this.fDonGia.DataPropertyName = "fDonGia";
            this.fDonGia.FillWeight = 92.72421F;
            this.fDonGia.HeaderText = "Giá bán";
            this.fDonGia.Name = "fDonGia";
            this.fDonGia.ReadOnly = true;
            // 
            // fThanhTien
            // 
            this.fThanhTien.DataPropertyName = "fThanhTien";
            this.fThanhTien.FillWeight = 92.72421F;
            this.fThanhTien.HeaderText = "Thành Tiền";
            this.fThanhTien.Name = "fThanhTien";
            this.fThanhTien.ReadOnly = true;
            // 
            // btnX
            // 
            this.btnX.BackColor = System.Drawing.Color.IndianRed;
            this.btnX.FlatAppearance.BorderSize = 0;
            this.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnX.Location = new System.Drawing.Point(393, 12);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(27, 23);
            this.btnX.TabIndex = 10;
            this.btnX.Text = "X";
            this.btnX.UseVisualStyleBackColor = false;
            this.btnX.Click += new System.EventHandler(this.btnX_Click);
            // 
            // frmCTHB_Ban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(432, 397);
            this.Controls.Add(this.btnX);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbTongGia);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbTenKH);
            this.Controls.Add(this.lbTenNV);
            this.Controls.Add(this.lbSoHD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvSanPham_Mua);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmCTHB_Ban";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCTHB_Ban";
            this.Load += new System.EventHandler(this.frmCTHB_Ban_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham_Mua)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSanPham_Mua;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbSoHD;
        private System.Windows.Forms.Label lbTenNV;
        private System.Windows.Forms.Label lbTenKH;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbTongGia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn iSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn fDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn fThanhTien;
        private System.Windows.Forms.Button btnX;
    }
}