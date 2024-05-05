using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace BTL_QLBanTrangSuc
{
    public partial class frmQLSanPham : Form
    {
        string constr = "Data Source=ANPHATPC\\SQLEXPRESS;Initial Catalog=QuanLyBanTrangSuc;Integrated Security=True";
        private bool allowEmptyTenSP = false;

        public frmQLSanPham()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgr_load();
            dgrSanPham.ClearSelection();

            txtMaSP.Enabled = false;
            txtTenSP.Enabled = false;
            txtSoLuong.Enabled = false;
            txtMauSac.Enabled = false;
            txtNguyenLieuChinh.Enabled = false;
            txtChatLieu.Enabled = false;
            txtDoDai.Enabled = false;

            cboLoaiSP.Enabled = false;
            cboNCC.Enabled = false;

            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            loadNCC();
            loadLoaiSanPham();
        }

        private void dgr_load()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT sMaSP, sTenSP, sTenLoai, iSoLuong, sMauSac, sChatLieu, sNguyenLieuChinh, sDoDai, sTenNCC " +
                                                        "FROM tblNCC, tblSanPham, tblLoaiSanPham " +
                                                        "WHERE tblSanPham.bttXoa = 0 AND tblNCC.sMaNCC = tblSanPham.sMaNCC AND tblSanPham.sMaLoaiSP = tblLoaiSanPham.sMaLoaiSP", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dgrSanPham.DataSource = tb;
                    }
                }
            }

            dgrSanPham.Columns["sMaSP"].HeaderText = "Mã sản phẩm";
            dgrSanPham.Columns["sTenSP"].HeaderText = "Tên sản phẩm";
            dgrSanPham.Columns["sTenLoai"].HeaderText = "Tên loại sản phẩm";
            dgrSanPham.Columns["iSoLuong"].HeaderText = "Số lượng";
            dgrSanPham.Columns["sMauSac"].HeaderText = "Màu sắc";
            dgrSanPham.Columns["sChatLieu"].HeaderText = "Chất liệu";
            dgrSanPham.Columns["sNguyenLieuChinh"].HeaderText = "Nguyên liệu chính";
            dgrSanPham.Columns["sDoDai"].HeaderText = "Độ dài";
            dgrSanPham.Columns["sTenNCC"].HeaderText = "Tên nhà cung cấp";
        }

        private void loadLoaiSanPham()
        {
            DataTable tb = new DataTable();

            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblLoaiSanPham", cnn))
                {
                    cnn.Open();
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    ad.Fill(tb);
                }
            }

            cboLoaiSP.DataSource = tb;
            cboLoaiSP.DisplayMember = "sTenLoai";
            cboLoaiSP.ValueMember = "sMaLoaiSP";

            DataRow allItem = tb.NewRow();
            allItem["sMaLoaiSP"] = "";
            allItem["sTenLoai"] = "Tất cả";
            tb.Rows.InsertAt(allItem, 0);

            cboLoaiSP.SelectedIndex = 0;

            lblLoaiSP.Text = cboLoaiSP.SelectedValue.ToString();
        }

        private void loadNCC()
        {
            DataTable tb = new DataTable();

            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblNCC", cnn))
                {
                    cnn.Open();
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    ad.Fill(tb);
                }
            }

            cboNCC.DataSource = tb;
            cboNCC.DisplayMember = "sTenNCC";
            cboNCC.ValueMember = "sMaNCC";

            DataRow allItem = tb.NewRow();
            allItem["sMaNCC"] = "";
            allItem["sTenNCC"] = "Tất cả";
            tb.Rows.InsertAt(allItem, 0);

            cboNCC.SelectedIndex = 0;

            lblNCC.Text = cboNCC.SelectedValue.ToString();
        }

        private void dgrSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgrSanPham.Rows[e.RowIndex];

                txtMaSP.Text = row.Cells["sMaSP"].Value.ToString();
                txtTenSP.Text = row.Cells["sTenSP"].Value.ToString();
                cboLoaiSP.Text = row.Cells["sTenLoai"].Value.ToString();
                txtSoLuong.Text = row.Cells["iSoLuong"].Value.ToString();
                txtMauSac.Text = row.Cells["sMauSac"].Value.ToString();
                txtNguyenLieuChinh.Text = row.Cells["sNguyenLieuChinh"].Value.ToString();
                txtChatLieu.Text = row.Cells["sChatLieu"].Value.ToString();
                txtDoDai.Text = row.Cells["fDoDai"].Value.ToString();
                cboNCC.Text = row.Cells["sTenNCC"].Value.ToString();
            }

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
    //        btnTim.Enabled = true;

            txtMaSP.Enabled = false;
            txtTenSP.Enabled = false;
            txtSoLuong.Enabled = false;
            txtMauSac.Enabled = false;
            txtNguyenLieuChinh.Enabled = false;
            txtChatLieu.Enabled = false;
            txtDoDai.Enabled = false;

            cboLoaiSP.Enabled = false;
            cboNCC.Enabled = false;

            /*errorProvider1.SetError(txtMaSP, "");
            errorProvider1.SetError(txtTenSP, "");
            errorProvider1.SetError(txtSoLuong, "");
            errorProvider1.SetError(txtMauSac, "");
            errorProvider1.SetError(txtNguyenLieuChinh, "");
            errorProvider1.SetError(txtChatLieu, "");
            errorProvider1.SetError(txtDoDai, "");*/
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            /*errorProvider1.SetError(txtMaSP, "");
            errorProvider1.SetError(txtTenSP, "");
            errorProvider1.SetError(txtSoLuong, "");
            errorProvider1.SetError(txtMauSac, "");
            errorProvider1.SetError(txtNguyenLieuChinh, "");
            errorProvider1.SetError(txtChatLieu, "");
            errorProvider1.SetError(txtDoDai, "");*/

            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtSoLuong.Text = "";
            txtMauSac.Text = "";
            txtNguyenLieuChinh.Text = "";
            txtChatLieu.Text = "";
            txtDoDai.Text = "";

            txtMaSP.Enabled = false;
            txtTenSP.Enabled = false;
            txtSoLuong.Enabled = false;
            txtMauSac.Enabled = false;
            txtNguyenLieuChinh.Enabled = false;
            txtChatLieu.Enabled = false;
            txtDoDai.Enabled = false;

            cboLoaiSP.Enabled = false;
            cboNCC.Enabled = false;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
     //       btnTim.Enabled = true;

            cboLoaiSP.SelectedIndex = 0;
            cboNCC.SelectedIndex = 0;

            dgr_load();
            dgrSanPham.ClearSelection();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Kiểm tra ấn lần 1
            if (txtMaSP.Enabled == false)
            {
                txtMaSP.Text = "";
                txtTenSP.Text = "";
                txtSoLuong.Text = "";
                txtMauSac.Text = "";
                txtNguyenLieuChinh.Text = "";
                txtChatLieu.Text = "";
                txtDoDai.Text = "";

                txtMaSP.Enabled = true;
                txtTenSP.Enabled = true;
                txtSoLuong.Enabled = true;
                txtMauSac.Enabled = true;
                txtNguyenLieuChinh.Enabled = true;
                txtChatLieu.Enabled = true;
                txtDoDai.Enabled = true;

                cboLoaiSP.Enabled = true;
                cboNCC.Enabled = true;
                cboLoaiSP.SelectedIndex = 0;
                cboNCC.SelectedIndex = 0;

                btnSua.Enabled = false;
                btnXoa.Enabled = false;
     //           btnTim.Enabled = false;

                txtMaSP.Focus();

                dgrSanPham.ClearSelection();

                return;
            }

            //Xử lý
            string maSP = txtMaSP.Text;
            string maLoaiSP = cboLoaiSP.SelectedValue.ToString();
            string tenSP = txtTenSP.Text;
            //int soLuong = int.Parse(txtSoLuong.Text);
            string soLuong = txtSoLuong.Text;
            string mauSac = txtMauSac.Text;
            string chatLieu = txtChatLieu.Text;
            string nguyenLieuChinh = txtNguyenLieuChinh.Text;
            string doDai = txtDoDai.Text;
            string maNCC = cboNCC.SelectedValue.ToString();

            if(txtMaSP.Text == "" || txtTenSP.Text == "" || txtNguyenLieuChinh.Text == "" || txtMauSac.Text == "" ||
               txtDoDai.Text == "" || txtChatLieu.Text == "" || cboLoaiSP.Text == "" || cboNCC.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo");
            }

            if (txtMaSP.Enabled && string.IsNullOrEmpty(maSP))
            {
                return;
            }
            else
            {
               // errorProvider1.SetError(txtMaSP, "");
            }

            if (maLoaiSP == "")
            {
              //  MessageBox.Show("Vui lòng chọn loại sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtTenSP.Enabled && string.IsNullOrEmpty(tenSP))
            {
                return;
            }
            else
            {
               // errorProvider1.SetError(txtTenSP, "");
            }

            /*if (!int.TryParse(txtSoLuong.Text))
            {
              //  errorProvider1.SetError(txtSoLuong, "Vui lòng nhập số lượng là một giá trị số nguyên.");
                return;
            }*/
            /*else
            {
               // errorProvider1.SetError(txtSoLuong, "");
            }*/

            if (txtMauSac.Enabled && string.IsNullOrEmpty(mauSac))
            {
                return;
            }
            else
            {
               // errorProvider1.SetError(txtMauSac, "");
            }

            if (txtChatLieu.Enabled && string.IsNullOrEmpty(chatLieu))
            {
                return;
            }
            else
            {
               // errorProvider1.SetError(txtChatLieu, "");
            }

            if (txtNguyenLieuChinh.Enabled && string.IsNullOrEmpty(nguyenLieuChinh))
            {
                return;
            }
            else
            {
               // errorProvider1.SetError(txtNguyenLieuChinh, "");
            }

            if (txtDoDai.Enabled && string.IsNullOrEmpty(doDai))
            {
                return;
            }
            else
            {
                errorProvider1.SetError(txtDoDai, "");
            }

            if (maNCC == "")
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (KiemTraTonTaiMaSP(maSP))
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại, vui lòng nhập mã mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (KiemTraTonTaiTenSP(tenSP))
            {
                MessageBox.Show("Tên sản phẩm đã tồn tại, vui lòng nhập tên mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(errorProvider1.GetError(txtMaSP)) && string.IsNullOrEmpty(errorProvider1.GetError(txtTenSP)) && string.IsNullOrEmpty(errorProvider1.GetError(txtSoLuong)) && string.IsNullOrEmpty(errorProvider1.GetError(txtMauSac)) && string.IsNullOrEmpty(errorProvider1.GetError(txtNguyenLieuChinh)) && string.IsNullOrEmpty(errorProvider1.GetError(txtChatLieu)) && string.IsNullOrEmpty(errorProvider1.GetError(txtDoDai)) && cboLoaiSP.Text != "Tất cả" && cboNCC.Text != "Tất cả")
            {
                ThemDuLieuVaoDB(maSP, tenSP, maLoaiSP, int.Parse(soLuong), mauSac, chatLieu, nguyenLieuChinh, doDai, maNCC);

                dgr_load();
                dgrSanPham.ClearSelection();

                txtMaSP.Text = "";
                txtTenSP.Text = "";
                txtSoLuong.Text = "";
                txtMauSac.Text = "";
                txtNguyenLieuChinh.Text = "";
                txtChatLieu.Text = "";
                txtDoDai.Text = "";

               // MessageBox.Show("Bạn vừa thêm thành công 1 sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            txtMaSP.Enabled = false;
            txtTenSP.Enabled = false;
            txtSoLuong.Enabled = false;
            txtMauSac.Enabled = false;
            txtNguyenLieuChinh.Enabled = false;
            txtChatLieu.Enabled = false;
            txtDoDai.Enabled = false;

            cboLoaiSP.Enabled = false;
            cboNCC.Enabled = false;

            /*errorProvider1.SetError(txtMaSP, "");
            errorProvider1.SetError(txtTenSP, "");
            errorProvider1.SetError(txtSoLuong, "");
            errorProvider1.SetError(txtMauSac, "");
            errorProvider1.SetError(txtNguyenLieuChinh, "");
            errorProvider1.SetError(txtChatLieu, "");
            errorProvider1.SetError(txtDoDai, "");*/

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
    //        btnTim.Enabled = true;

            cboLoaiSP.SelectedIndex = 0;
            cboNCC.SelectedIndex = 0;
        }

        
        private void txtMaSP_Validating(object sender, CancelEventArgs e)
        {
            if (txtMaSP.Text == "")
            {
               // errorProvider1.SetError(txtMaSP, "Vui lòng nhập mã sản phẩm");
                return;
            }
            else
            {
                errorProvider1.SetError(txtMaSP, "");
            }
        }

        private void txtTenSP_Validating(object sender, CancelEventArgs e)
        {
            if (!allowEmptyTenSP && txtTenSP.Text == "")
            {
               // errorProvider1.SetError(txtTenSP, "Vui lòng nhập tên sản phẩm");
                return;
            }
            else
            {
                errorProvider1.SetError(txtTenSP, "");
            }
        }

        private void txtSoLuong_Validating(object sender, CancelEventArgs e)
        {
            int soLuong;
            if (!int.TryParse(txtSoLuong.Text, out soLuong))
            {
              //  errorProvider1.SetError(txtSoLuong, "Vui lòng nhập số lượng là một giá trị số nguyên.");
            }
            else
            {
                errorProvider1.SetError(txtSoLuong, "");
            }
        }

        private void txtMauSac_Validating(object sender, CancelEventArgs e)
        {
            if (txtMauSac.Text == "")
            {
               // errorProvider1.SetError(txtMauSac, "Vui lòng nhập màu sắc");
                return;
            }
            else
            {
                errorProvider1.SetError(txtMauSac, "");
            }
        }

        private void txtNguyenLieuChinh_Validating(object sender, CancelEventArgs e)
        {
            if (txtNguyenLieuChinh.Text == "")
            {
               // errorProvider1.SetError(txtNguyenLieuChinh, "Vui lòng nhập nguyên liệu chính");
                return;
            }
            else
            {
                errorProvider1.SetError(txtNguyenLieuChinh, "");
            }
        }

        private void txtChatLieu_Validating(object sender, CancelEventArgs e)
        {
            if (txtChatLieu.Text == "")
            {
              //  errorProvider1.SetError(txtChatLieu, "Vui lòng nhập chất liệu");
                return;
            }
            else
            {
                errorProvider1.SetError(txtChatLieu, "");
            }
        }

        private void txtDoDai_Validating(object sender, CancelEventArgs e)
        {
            if (txtDoDai.Text == "")
            {
               // errorProvider1.SetError(txtDoDai, "Vui lòng nhập độ dài");
                return;
            }
            else
            {
                errorProvider1.SetError(txtDoDai, "");
            }
        }

        private bool KiemTraTonTaiMaSP(string maSP)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblSanPham WHERE sMaSP = @MaSP", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@MaSP", maSP);
                    cnn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private bool KiemTraTonTaiTenSP(string tenSP)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblSanPham WHERE sTenSP = @TenSP", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@TenSP", tenSP);
                    cnn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void ThemDuLieuVaoDB(string maSP, string tenSP, string maLoaiSP, int soLuong, string mauSac, string chatLieu, string nguyenLieuChinh, string doDai, string maNCC)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO tblSanPham (sMaSP, sMaLoaiSP, sTenSP, iSoLuong, sMauSac, sChatLieu, sNguyenLieuChinh, fDoDai, sMaNCC) " +
                    "VALUES (@MaSP, @MaLoaiSP, @TenSP, @SoLuong, @MauSac, @ChatLieu, @NguyenLieuChinh, @DoDai, @MaNCC)", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@MaSP", maSP);
                    cmd.Parameters.AddWithValue("@MaLoaiSP", maLoaiSP);
                    cmd.Parameters.AddWithValue("@TenSP", tenSP);
                    cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                    cmd.Parameters.AddWithValue("@MauSac", mauSac);
                    cmd.Parameters.AddWithValue("@ChatLieu", chatLieu);
                    cmd.Parameters.AddWithValue("@NguyenLieuChinh", nguyenLieuChinh);
                    cmd.Parameters.AddWithValue("@DoDai", doDai);
                    cmd.Parameters.AddWithValue("@MaNCC", maNCC);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //Kiểm tra ấn lần 1
            if (txtTenSP.Enabled == false)
            {
                txtTenSP.Enabled = true;
                txtSoLuong.Enabled = true;
                txtMauSac.Enabled = true;
                txtNguyenLieuChinh.Enabled = true;
                txtChatLieu.Enabled = true;
                txtDoDai.Enabled = true;

                cboLoaiSP.Enabled = true;
                cboNCC.Enabled = true;

                btnThem.Enabled = false;
                btnXoa.Enabled = false;
    //            btnTim.Enabled = false;

                dgrSanPham.ClearSelection();

                return;
            }

            string maSP = txtMaSP.Text;
            string maLoaiSP = cboLoaiSP.SelectedValue.ToString();
            string tenSP = txtTenSP.Text;
            int soLuong = int.Parse(txtSoLuong.Text);
            string mauSac = txtMauSac.Text;
            string chatLieu = txtChatLieu.Text;
            string nguyenLieuChinh = txtNguyenLieuChinh.Text;
            string doDai = txtDoDai.Text;
            string maNCC = cboNCC.SelectedValue.ToString();

            if (maLoaiSP == "")
            {
                MessageBox.Show("Vui lòng chọn loại sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtTenSP.Enabled && string.IsNullOrEmpty(tenSP))
            {
                return;
            }
            else
            {
                errorProvider1.SetError(txtTenSP, "");
            }

            if (!int.TryParse(txtSoLuong.Text, out soLuong))
            {
                errorProvider1.SetError(txtSoLuong, "Vui lòng nhập số lượng là một giá trị số nguyên.");
                return;
            }
            else
            {
                errorProvider1.SetError(txtSoLuong, "");
            }

            if (txtMauSac.Enabled && string.IsNullOrEmpty(mauSac))
            {
                return;
            }
            else
            {
                errorProvider1.SetError(txtMauSac, "");
            }

            if (txtChatLieu.Enabled && string.IsNullOrEmpty(chatLieu))
            {
                return;
            }
            else
            {
                errorProvider1.SetError(txtChatLieu, "");
            }

            if (txtNguyenLieuChinh.Enabled && string.IsNullOrEmpty(nguyenLieuChinh))
            {
                return;
            }
            else
            {
                errorProvider1.SetError(txtNguyenLieuChinh, "");
            }

            if (txtDoDai.Enabled && string.IsNullOrEmpty(doDai))
            {
                return;
            }
            else
            {
                errorProvider1.SetError(txtDoDai, "");
            }

            if (maNCC == "")
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (KiemTraTonTaiTenSP2(maSP, tenSP))
            {
                MessageBox.Show("Tên sản phẩm đã tồn tại, vui lòng nhập tên mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            suaDuLieuTrongDB(maSP, tenSP, maLoaiSP, soLuong, mauSac, chatLieu, nguyenLieuChinh, doDai, maNCC);

            dgr_load();
            dgrSanPham.ClearSelection();

            errorProvider1.SetError(txtMaSP, "");
            errorProvider1.SetError(txtTenSP, "");
            errorProvider1.SetError(txtSoLuong, "");
            errorProvider1.SetError(txtMauSac, "");
            errorProvider1.SetError(txtNguyenLieuChinh, "");
            errorProvider1.SetError(txtChatLieu, "");
            errorProvider1.SetError(txtDoDai, "");

            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtSoLuong.Text = "";
            txtMauSac.Text = "";
            txtNguyenLieuChinh.Text = "";
            txtChatLieu.Text = "";
            txtDoDai.Text = "";

            txtMaSP.Enabled = false;
            txtTenSP.Enabled = false;
            txtSoLuong.Enabled = false;
            txtMauSac.Enabled = false;
            txtNguyenLieuChinh.Enabled = false;
            txtChatLieu.Enabled = false;
            txtDoDai.Enabled = false;

            cboLoaiSP.Enabled = false;
            cboNCC.Enabled = false;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
      //      btnTim.Enabled = true;

            cboLoaiSP.SelectedIndex = 0;
            cboNCC.SelectedIndex = 0;
        }

        private bool KiemTraTonTaiTenSP2(string maSP, string tenSP)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblSanPham WHERE sMaSP != @MaSP AND sTenSP = @TenSP", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@MaSP", maSP);
                    cmd.Parameters.AddWithValue("@TenSP", tenSP);
                    cnn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void suaDuLieuTrongDB(string maSP, string tenSP, string maLoaiSP, int soLuong, string mauSac, string chatLieu, string nguyenLieuChinh, string doDai, string maNCC)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE tblSanPham SET sTenSP = @TenSP, sMaLoaiSP = @MaLoaiSP, iSoLuong = @SoLuong, sMauSac = @MauSac, sChatLieu = @ChatLieu, sNguyenLieuChinh = @NguyenLieuChinh, fDoDai = @DoDai, sMaNCC = @MaNCC WHERE sMaSP = @MaSP", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@MaSP", maSP);
                    cmd.Parameters.AddWithValue("@TenSP", tenSP);
                    cmd.Parameters.AddWithValue("@MaLoaiSP", maLoaiSP);
                    cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                    cmd.Parameters.AddWithValue("@MauSac", mauSac);
                    cmd.Parameters.AddWithValue("@ChatLieu", chatLieu);
                    cmd.Parameters.AddWithValue("@NguyenLieuChinh", nguyenLieuChinh);
                    cmd.Parameters.AddWithValue("@DoDai", doDai);
                    cmd.Parameters.AddWithValue("@MaNCC", maNCC);

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();

                    MessageBox.Show("Sửa thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maSP = txtMaSP.Text;

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection cnn = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE tblSanPham SET bttXoa = 1 WHERE sMaSP = @MaSP", cnn))
                    {
                        cmd.Parameters.AddWithValue("@MaSP", maSP);
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Xóa sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            errorProvider1.SetError(txtMaSP, "");
            errorProvider1.SetError(txtTenSP, "");
            errorProvider1.SetError(txtSoLuong, "");
            errorProvider1.SetError(txtMauSac, "");
            errorProvider1.SetError(txtNguyenLieuChinh, "");
            errorProvider1.SetError(txtChatLieu, "");
            errorProvider1.SetError(txtDoDai, "");

            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtSoLuong.Text = "";
            txtMauSac.Text = "";
            txtNguyenLieuChinh.Text = "";
            txtChatLieu.Text = "";
            txtDoDai.Text = "";

            txtMaSP.Enabled = false;
            txtTenSP.Enabled = false;
            txtSoLuong.Enabled = false;
            txtMauSac.Enabled = false;
            txtNguyenLieuChinh.Enabled = false;
            txtChatLieu.Enabled = false;
            txtDoDai.Enabled = false;

            cboLoaiSP.Enabled = false;
            cboNCC.Enabled = false;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
    //        btnTim.Enabled = true;

            cboLoaiSP.SelectedIndex = 0;
            cboNCC.SelectedIndex = 0;

            dgr_load();
            dgrSanPham.ClearSelection();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            //Check ấn lần 1
            if (txtTenSP.Enabled == false)
            {
                allowEmptyTenSP = true;

                txtTenSP.Enabled = true;
                cboLoaiSP.Enabled = true;
                cboNCC.Enabled = true;

                cboLoaiSP.SelectedIndex = 0;
                cboNCC.SelectedIndex = 0;

                dgr_load();
                dgrSanPham.ClearSelection();

                txtMaSP.Text = "";
                txtTenSP.Text = "";
                txtSoLuong.Text = "";
                txtMauSac.Text = "";
                txtNguyenLieuChinh.Text = "";
                txtChatLieu.Text = "";
                txtDoDai.Text = "";

                txtMaSP.Enabled = false;
                txtSoLuong.Enabled = false;
                txtMauSac.Enabled = false;
                txtNguyenLieuChinh.Enabled = false;
                txtChatLieu.Enabled = false;
                txtDoDai.Enabled = false;

                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                return;
            }

            //Xử lý
            string tenSP = txtTenSP.Text.Trim();
            string maLoai = cboLoaiSP.SelectedValue.ToString();
            string maNCC = cboNCC.SelectedValue.ToString();

            using (SqlConnection cnn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("SELECT sMaSP, sTenSP, sTenLoai, iSoLuong, sMauSac, sChatLieu, sNguyenLieuChinh, fDoDai, sTenNCC " +
                        "FROM tblSanPham INNER JOIN tblLoaiSanPham ON tblSanPham.sMaLoaiSP = tblLoaiSanPham.sMaLoaiSP INNER JOIN tblNCC ON tblSanPham.sMaNCC = tblNCC.sMaNCC " +
                        "WHERE tblSanPham.bttXoa = 0 " +
                        "AND tblSanPham.sMaLoaiSP LIKE @MaLoaiSP AND tblSanPham.sMaNCC LIKE @MaNCC AND tblSanPham.sTenSP LIKE @TenSP", cnn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@MaNCC", "%" + maNCC + "%");
                cmd.Parameters.AddWithValue("@MaLoaiSP", "%" + maLoai + "%");
                cmd.Parameters.AddWithValue("@TenSP", "%" + tenSP + "%");

                DataTable dataTable = new DataTable();

                try
                {
                    cnn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);

                    int resultCount = dataTable.Rows.Count;

                    if (resultCount > 0)
                    {
                        dgrSanPham.DataSource = dataTable;

                        // Hiển thị thông báo với số lượng kết quả tìm kiếm
                        MessageBox.Show("Tìm thấy " + resultCount + " sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dataTable.Rows.Count > 0)
                {
                    dgrSanPham.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                errorProvider1.SetError(txtMaSP, "");
                errorProvider1.SetError(txtTenSP, "");
                errorProvider1.SetError(txtSoLuong, "");
                errorProvider1.SetError(txtMauSac, "");
                errorProvider1.SetError(txtNguyenLieuChinh, "");
                errorProvider1.SetError(txtChatLieu, "");
                errorProvider1.SetError(txtDoDai, "");

                txtMaSP.Text = "";
                txtSoLuong.Text = "";
                txtMauSac.Text = "";
                txtNguyenLieuChinh.Text = "";
                txtChatLieu.Text = "";
                txtDoDai.Text = "";

                txtMaSP.Enabled = false;
                txtSoLuong.Enabled = false;
                txtMauSac.Enabled = false;
                txtNguyenLieuChinh.Enabled = false;
                txtChatLieu.Enabled = false;
                txtDoDai.Enabled = false;

                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
      //          btnTim.Enabled = true;
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            /*try
            {
                int.Parse(txtSoLuong.Text);
            }
            catch
            {
                errorProvider1.SetError(txtSoLuong,"Vui lòng nhập số");
            }*/
        }
    }
}
