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
    public partial class frmQLLoaiSanPham : Form
    {
        string constr = "Data Source=ANPHATPC\\SQLEXPRESS;Initial Catalog=QuanLyBanTrangSuc;Integrated Security=True";

        public frmQLLoaiSanPham()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgr_load();
            dgrLoaiSP.ClearSelection();

            txtMaLoai.Enabled = false;
            txtTenLoai.Enabled = false;

            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void dgr_load()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT sMaLoaiSP, sTenLoai FROM tblLoaiSanPham WHERE bttXoa = 0", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dgrLoaiSP.DataSource = tb;
                    }
                }
            }

            dgrLoaiSP.Columns["sMaLoaiSP"].HeaderText = "Mã loại SP";
            dgrLoaiSP.Columns["sTenLoai"].HeaderText = "Tên loại SP";
        }

        

        private void dgrLoaiSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgrLoaiSP.Rows[e.RowIndex];

                txtMaLoai.Text = row.Cells["sMaLoaiSP"].Value.ToString();
                txtTenLoai.Text = row.Cells["sTenLoai"].Value.ToString();
            }

            errorProvider1.SetError(txtMaLoai, "");
            errorProvider1.SetError(txtTenLoai, "");

            txtTenLoai.Enabled = true;
            txtMaLoai.Enabled = false;

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            //btnTim.Enabled = true;
            btnThem.Enabled = true;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaLoai.Text = "";
            txtTenLoai.Text = "";

            errorProvider1.SetError(txtMaLoai, "");
            errorProvider1.SetError(txtTenLoai, "");

            dgr_load();
            dgrLoaiSP.ClearSelection();

            txtMaLoai.Enabled = false;
            txtTenLoai.Enabled = false;

            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnThem.Enabled = true;
     //       btnTim.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Check ấn lần 1
            if (txtMaLoai.Enabled == false && txtTenLoai.Enabled == false)
            {
                txtMaLoai.Text = "";
                txtTenLoai.Text = "";

                txtMaLoai.Enabled = true;
                txtTenLoai.Enabled = true;

                btnSua.Enabled = false;
                btnXoa.Enabled = false;
        //        btnTim.Enabled = false;

                txtMaLoai.Focus();

                dgrLoaiSP.ClearSelection();

                return;
            }

            //Xử lý
            string maLoaiSP = txtMaLoai.Text;
            string tenLoaiSP = txtTenLoai.Text;


            if (txtMaLoai.Enabled && string.IsNullOrEmpty(maLoaiSP))
            {
                return;
            }
            else
            {
                errorProvider1.SetError(txtMaLoai, "");
            }

            if (txtTenLoai.Enabled && string.IsNullOrEmpty(tenLoaiSP))
            {
                return;
            }
            else
            {
                errorProvider1.SetError(txtTenLoai, "");
            }

            if (KiemTraTonTaiMaLoaiSP(maLoaiSP))
            {
                MessageBox.Show("Mã loại sản phẩm đã tồn tại, vui lòng nhập mã mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (KiemTraTonTaiTenLoaiSP(tenLoaiSP))
            {
                MessageBox.Show("Tên loại sản phẩm đã tồn tại, vui lòng nhập tên mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(errorProvider1.GetError(txtMaLoai)) && string.IsNullOrEmpty(errorProvider1.GetError(txtTenLoai)))
            {
                ThemDuLieuVaoDB(maLoaiSP, tenLoaiSP);

                dgr_load();

                txtMaLoai.Text = "";
                txtTenLoai.Text = "";

                MessageBox.Show("Bạn vừa thêm thành công 1 loại sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            txtMaLoai.Enabled = false;
            txtTenLoai.Enabled = false;
            btnThem.Enabled = true;
      //      btnTim.Enabled = true;

            errorProvider1.SetError(txtTenLoai, "");
            errorProvider1.SetError(txtMaLoai, "");
        }

        private bool KiemTraTonTaiMaLoaiSP(string maLoaiSP)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblLoaiSanPham WHERE sMaLoaiSP = @MaLoaiSP", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@MaLoaiSP", maLoaiSP);
                    cnn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private bool KiemTraTonTaiTenLoaiSP(string tenLoaiSP)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblLoaiSanPham WHERE sTenLoai = @TenLoaiSP", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@TenLoaiSP", tenLoaiSP);
                    cnn.Open();
                    int count = (int)cmd.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        private void ThemDuLieuVaoDB(string maLoaiSP, string tenLoaiSP)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO tblLoaiSanPham (sMaLoaiSP, sTenLoai) VALUES (@MaLoaiSP, @TenLoaiSP)", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@MaLoaiSP", maLoaiSP);
                    cmd.Parameters.AddWithValue("@TenLoaiSP", tenLoaiSP);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void txtMaLoai_Validating(object sender, CancelEventArgs e)
        {
            if (txtMaLoai.Text == "")
            {
                errorProvider1.SetError(txtMaLoai, "Vui lòng nhập mã loại sản phẩm");
                return;
            }
            else
            {
                errorProvider1.SetError(txtMaLoai, "");
            }
        }

        private void txtTenLoai_Validating(object sender, CancelEventArgs e)
        {
            if (txtTenLoai.Text == "")
            {
                errorProvider1.SetError(txtTenLoai, "Vui lòng nhập tên loại sản phẩm");
                return;
            }
            else
            {
                errorProvider1.SetError(txtTenLoai, "");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //Ẩn chức năng khác
            /*btnThem.Enabled = false;
            btnTim.Enabled = false;
            btnXoa.Enabled = false;*/

            //Xử lý
            string maLoai = txtMaLoai.Text;
            string tenLoai = txtTenLoai.Text;

            if (txtTenLoai.Enabled == false)
            {
                txtTenLoai.Enabled = true;
                return;
            }

            if (string.IsNullOrEmpty(tenLoai))
            {
                errorProvider1.SetError(txtTenLoai, "Vui lòng nhập tên loại sản phẩm");
                return;
            }
            else
            {
                errorProvider1.SetError(txtTenLoai, "");
            }

            if (KiemTraTonTaiTenLoaiSP(tenLoai))
            {
                MessageBox.Show("Tên loại sản phẩm đã tồn tại, vui lòng nhập tên mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            suaDuLieuTrongDB(maLoai, tenLoai);

            dgr_load();
            dgrLoaiSP.ClearSelection();

            txtMaLoai.Text = "";
            txtTenLoai.Text = "";

            txtMaLoai.Enabled = false;
            txtTenLoai.Enabled = false;

            btnSua.Enabled = false;
      //      btnTim.Enabled = true;
            btnThem.Enabled = true;
        }

        private void suaDuLieuTrongDB(string maLoaiSP, string tenLoaiSp)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE tblLoaiSanPham SET sTenLoai = @tenLoaiSP WHERE sMaLoaiSP = @maLoaiSP", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@maLoaiSP", maLoaiSP);
                    cmd.Parameters.AddWithValue("@tenLoaiSP", tenLoaiSp);

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();

                    MessageBox.Show("Sửa thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /*private void btnTim_Click(object sender, EventArgs e)
        {
            //Check xem có phải ấn lần 1 không
            if (txtTenLoai.Enabled == false || !string.IsNullOrEmpty(txtTenLoai.Text) && !string.IsNullOrEmpty(txtMaLoai.Text))
            {
                txtTenLoai.Enabled = true;
                dgrLoaiSP.ClearSelection();

                txtMaLoai.Text = "";
                txtTenLoai.Text = "";
                txtMaLoai.Enabled = false;

                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                return;
            }

            //Xử lý

            string tenLoai = txtTenLoai.Text.Trim();

            if (string.IsNullOrEmpty(tenLoai))
            {
                errorProvider1.SetError(txtTenLoai, "Vui lòng nhập tên loại sản phẩm để tìm kiếm");
                return;
            }
            else
            {
                errorProvider1.SetError(txtTenLoai, "");
            }

            using (SqlConnection cnn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("SELECT sMaLoaiSP, sTenLoai FROM tblLoaiSanPham WHERE bttXoa = 0 AND sTenLoai LIKE @tenLoaiSP", cnn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@tenLoaiSP", "%" + tenLoai + "%");

                DataTable dataTable = new DataTable();

                try
                {
                    cnn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);

                    int resultCount = dataTable.Rows.Count;

                    if (resultCount > 0)
                    {
                        dgrLoaiSP.DataSource = dataTable;

                        // Hiển thị thông báo với số lượng kết quả tìm kiếm
                        MessageBox.Show("Tìm thấy " + resultCount + " loại sản phẩm có tên: " + tenLoai, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm loại sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dataTable.Rows.Count > 0)
                {
                    dgrLoaiSP.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy loại sản phẩm có tên: " + tenLoai, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }*/

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maLoai = txtMaLoai.Text;

            /*if (KiemTraKhoaNgoai(maLoai))
            {
                MessageBox.Show("Không thể xóa sản phẩm vì tồn tại đơn hàng liên quan", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa loại sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection cnn = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE tblLoaiSanPham SET bttXoa = 1 WHERE sMaLoaiSP = @MaLoaiSP", cnn))
                    {
                        cmd.Parameters.AddWithValue("@MaLoaiSP", maLoai);
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Xóa loại sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaLoai.Text = "";
                txtTenLoai.Text = "";
                dgr_load();

                txtMaLoai.Enabled = false;
                txtTenLoai.Enabled = false;

                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
    //            btnTim.Enabled = true;
            }
        }

        
    }
}
