
namespace BTL_QLBanTrangSuc
{
    partial class frmQLNhanVien
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
            this.lbMaNhanVien = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lbFullName = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lbAddress = new System.Windows.Forms.Label();
            this.lbSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.panelRole = new System.Windows.Forms.Panel();
            this.RBAdmin = new System.Windows.Forms.RadioButton();
            this.RBNhanVien = new System.Windows.Forms.RadioButton();
            this.lbRole = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.clMaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTenNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNgayVaoLam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clVaiTro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTinhTrang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.RBStopWork = new System.Windows.Forms.RadioButton();
            this.RBWork = new System.Windows.Forms.RadioButton();
            this.lbStatus = new System.Windows.Forms.Label();
            this.panelRole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.panelStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbMaNhanVien
            // 
            this.lbMaNhanVien.AutoSize = true;
            this.lbMaNhanVien.Location = new System.Drawing.Point(85, 46);
            this.lbMaNhanVien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbMaNhanVien.Name = "lbMaNhanVien";
            this.lbMaNhanVien.Size = new System.Drawing.Size(72, 13);
            this.lbMaNhanVien.TabIndex = 0;
            this.lbMaNhanVien.Text = "Mã nhân viên";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(176, 46);
            this.txtMaNV.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(129, 20);
            this.txtMaNV.TabIndex = 1;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(176, 82);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(2);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(129, 20);
            this.txtFullName.TabIndex = 3;
            // 
            // lbFullName
            // 
            this.lbFullName.AutoSize = true;
            this.lbFullName.Location = new System.Drawing.Point(85, 82);
            this.lbFullName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbFullName.Name = "lbFullName";
            this.lbFullName.Size = new System.Drawing.Size(39, 13);
            this.lbFullName.TabIndex = 2;
            this.lbFullName.Text = "Họ tên";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(536, 45);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(2);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(129, 20);
            this.txtAddress.TabIndex = 5;
            // 
            // lbAddress
            // 
            this.lbAddress.AutoSize = true;
            this.lbAddress.Location = new System.Drawing.Point(445, 45);
            this.lbAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(40, 13);
            this.lbAddress.TabIndex = 4;
            this.lbAddress.Text = "Địa chỉ";
            // 
            // lbSDT
            // 
            this.lbSDT.AutoSize = true;
            this.lbSDT.Location = new System.Drawing.Point(444, 82);
            this.lbSDT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSDT.Name = "lbSDT";
            this.lbSDT.Size = new System.Drawing.Size(70, 13);
            this.lbSDT.TabIndex = 6;
            this.lbSDT.Text = "Số điện thoại";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(536, 82);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(2);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(129, 20);
            this.txtSDT.TabIndex = 7;
            // 
            // panelRole
            // 
            this.panelRole.Controls.Add(this.RBAdmin);
            this.panelRole.Controls.Add(this.RBNhanVien);
            this.panelRole.Controls.Add(this.lbRole);
            this.panelRole.Location = new System.Drawing.Point(87, 123);
            this.panelRole.Margin = new System.Windows.Forms.Padding(2);
            this.panelRole.Name = "panelRole";
            this.panelRole.Size = new System.Drawing.Size(238, 51);
            this.panelRole.TabIndex = 8;
            // 
            // RBAdmin
            // 
            this.RBAdmin.AutoSize = true;
            this.RBAdmin.Location = new System.Drawing.Point(150, 15);
            this.RBAdmin.Margin = new System.Windows.Forms.Padding(2);
            this.RBAdmin.Name = "RBAdmin";
            this.RBAdmin.Size = new System.Drawing.Size(61, 17);
            this.RBAdmin.TabIndex = 2;
            this.RBAdmin.TabStop = true;
            this.RBAdmin.Text = "Quản lý";
            this.RBAdmin.UseVisualStyleBackColor = true;
            // 
            // RBNhanVien
            // 
            this.RBNhanVien.AutoSize = true;
            this.RBNhanVien.Location = new System.Drawing.Point(63, 15);
            this.RBNhanVien.Margin = new System.Windows.Forms.Padding(2);
            this.RBNhanVien.Name = "RBNhanVien";
            this.RBNhanVien.Size = new System.Drawing.Size(74, 17);
            this.RBNhanVien.TabIndex = 1;
            this.RBNhanVien.TabStop = true;
            this.RBNhanVien.Text = "Nhân viên";
            this.RBNhanVien.UseVisualStyleBackColor = true;
            // 
            // lbRole
            // 
            this.lbRole.AutoSize = true;
            this.lbRole.Location = new System.Drawing.Point(11, 15);
            this.lbRole.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbRole.Name = "lbRole";
            this.lbRole.Size = new System.Drawing.Size(37, 13);
            this.lbRole.TabIndex = 0;
            this.lbRole.Text = "Vai trò";
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAdd.Location = new System.Drawing.Point(102, 207);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(56, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AutoSize = true;
            this.btnUpdate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnUpdate.Location = new System.Drawing.Point(203, 207);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(56, 23);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDelete.Location = new System.Drawing.Point(306, 207);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(56, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Xoá";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRefresh.Location = new System.Drawing.Point(410, 207);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(56, 23);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvNhanVien
            // 
            this.dgvNhanVien.AllowUserToAddRows = false;
            this.dgvNhanVien.AllowUserToDeleteRows = false;
            this.dgvNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhanVien.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clMaNV,
            this.clTenNV,
            this.clDiaChi,
            this.clSDT,
            this.clNgayVaoLam,
            this.clVaiTro,
            this.clTinhTrang});
            this.dgvNhanVien.Location = new System.Drawing.Point(37, 256);
            this.dgvNhanVien.Margin = new System.Windows.Forms.Padding(2);
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.RowHeadersWidth = 51;
            this.dgvNhanVien.RowTemplate.Height = 24;
            this.dgvNhanVien.Size = new System.Drawing.Size(768, 228);
            this.dgvNhanVien.TabIndex = 15;
            this.dgvNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhanVien_CellClick);
            this.dgvNhanVien.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhanVien_CellContentClick);
            // 
            // clMaNV
            // 
            this.clMaNV.DataPropertyName = "sMaNV";
            this.clMaNV.HeaderText = "Mã nhân viên";
            this.clMaNV.Name = "clMaNV";
            // 
            // clTenNV
            // 
            this.clTenNV.DataPropertyName = "sTenNV";
            this.clTenNV.HeaderText = "Tên nhân viên";
            this.clTenNV.Name = "clTenNV";
            // 
            // clDiaChi
            // 
            this.clDiaChi.DataPropertyName = "sDiaChi";
            this.clDiaChi.HeaderText = "Địa chỉ";
            this.clDiaChi.Name = "clDiaChi";
            // 
            // clSDT
            // 
            this.clSDT.DataPropertyName = "sSDT";
            this.clSDT.HeaderText = "SoDT";
            this.clSDT.Name = "clSDT";
            // 
            // clNgayVaoLam
            // 
            this.clNgayVaoLam.DataPropertyName = "dNgayVaoLam";
            this.clNgayVaoLam.HeaderText = "Ngày vào làm";
            this.clNgayVaoLam.Name = "clNgayVaoLam";
            // 
            // clVaiTro
            // 
            this.clVaiTro.DataPropertyName = "sVaiTro";
            this.clVaiTro.HeaderText = "Vai trò";
            this.clVaiTro.Name = "clVaiTro";
            // 
            // clTinhTrang
            // 
            this.clTinhTrang.DataPropertyName = "sTinhTrang";
            this.clTinhTrang.HeaderText = "Tình trạng";
            this.clTinhTrang.Name = "clTinhTrang";
            // 
            // panelStatus
            // 
            this.panelStatus.Controls.Add(this.RBStopWork);
            this.panelStatus.Controls.Add(this.RBWork);
            this.panelStatus.Controls.Add(this.lbStatus);
            this.panelStatus.Location = new System.Drawing.Point(442, 123);
            this.panelStatus.Margin = new System.Windows.Forms.Padding(2);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(299, 51);
            this.panelStatus.TabIndex = 9;
            // 
            // RBStopWork
            // 
            this.RBStopWork.AutoSize = true;
            this.RBStopWork.Location = new System.Drawing.Point(188, 15);
            this.RBStopWork.Margin = new System.Windows.Forms.Padding(2);
            this.RBStopWork.Name = "RBStopWork";
            this.RBStopWork.Size = new System.Drawing.Size(109, 17);
            this.RBStopWork.TabIndex = 2;
            this.RBStopWork.TabStop = true;
            this.RBStopWork.Text = "Ngưng hoạt động";
            this.RBStopWork.UseVisualStyleBackColor = true;
            // 
            // RBWork
            // 
            this.RBWork.AutoSize = true;
            this.RBWork.Location = new System.Drawing.Point(94, 15);
            this.RBWork.Margin = new System.Windows.Forms.Padding(2);
            this.RBWork.Name = "RBWork";
            this.RBWork.Size = new System.Drawing.Size(76, 17);
            this.RBWork.TabIndex = 1;
            this.RBWork.TabStop = true;
            this.RBWork.Text = "Hoạt động";
            this.RBWork.UseVisualStyleBackColor = true;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(12, 15);
            this.lbStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(55, 13);
            this.lbStatus.TabIndex = 0;
            this.lbStatus.Text = "Tình trạng";
            // 
            // frmQLNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 492);
            this.Controls.Add(this.panelStatus);
            this.Controls.Add(this.dgvNhanVien);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panelRole);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.lbSDT);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lbAddress);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lbFullName);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.lbMaNhanVien);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmQLNhanVien";
            this.Text = "FormManagementEmployee";
            this.Load += new System.EventHandler(this.FormManagementEmployee_Load);
            this.panelRole.ResumeLayout(false);
            this.panelRole.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMaNhanVien;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lbFullName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lbAddress;
        private System.Windows.Forms.Label lbSDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Panel panelRole;
        private System.Windows.Forms.RadioButton RBAdmin;
        private System.Windows.Forms.RadioButton RBNhanVien;
        private System.Windows.Forms.Label lbRole;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.RadioButton RBStopWork;
        private System.Windows.Forms.RadioButton RBWork;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTenNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNgayVaoLam;
        private System.Windows.Forms.DataGridViewTextBoxColumn clVaiTro;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTinhTrang;
    }
}