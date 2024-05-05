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
    public partial class frmQLNhaCungCap : Form
    {
        string constr = "Data Source=ANPHATPC\\SQLEXPRESS;Initial Catalog=QuanLyBanTrangSuc;Integrated Security=True";

        public frmQLNhaCungCap()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgr_load();
            dgrNCC.ClearSelection();

            txtMaNCC.Enabled = false;
            txtTenNCC.Enabled = false;
            txtSDT.Enabled = false;
            txtDiaChi.Enabled = false;

            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void dgr_load()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT sMaNCC, sTenNCC, sSDT, sDiaChi FROM tblNCC WHERE bttXoa = 0", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dgrNCC.DataSource = tb;
                    }
                }
            }

            dgrNCC.Columns["sMaNCC"].HeaderText = "Mã nhà cung cấp";
            dgrNCC.Columns["sTenNCC"].HeaderText = "Tên nhà cung cấp";
            dgrNCC.Columns["sSDT"].HeaderText = "Số điện thoại";
            dgrNCC.Columns["sDiaChi"].HeaderText = "Địa chỉ";
        }

        

        private void dgrNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgrNCC.Rows[e.RowIndex];

                txtMaNCC.Text = row.Cells["sMaNCC"].Value.ToString();
                txtTenNCC.Text = row.Cells["sTenNCC"].Value.ToString();
                txtSDT.Text = row.Cells["sSDT"].Value.ToString();
                txtDiaChi.Text = row.Cells["sDiaChi"].Value.ToString();
            }

            errorProvider1.SetError(txtMaNCC, "");
            errorProvider1.SetError(txtTenNCC, "");
            errorProvider1.SetError(txtSDT, "");
            errorProvider1.SetError(txtDiaChi, "");

            txtMaNCC.Enabled = false;
            txtTenNCC.Enabled = true;
            txtSDT.Enabled = true;
            txtDiaChi.Enabled = true;

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
 //           btnTim.Enabled = true;
            btnThem.Enabled = true;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtMaNCC, "");
            errorProvider1.SetError(txtTenNCC, "");
            errorProvider1.SetError(txtSDT, "");
            errorProvider1.SetError(txtDiaChi, "");

            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";

            dgr_load();
            dgrNCC.ClearSelection();

            txtMaNCC.Enabled = false;
            txtTenNCC.Enabled = false;
            txtSDT.Enabled = false;
            txtDiaChi.Enabled = false;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
     //       btnTim.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Kiểm tra ấn lần 1
            if (txtMaNCC.Enabled == false)
            {
                txtMaNCC.Text = "";
                txtTenNCC.Text = "";
                txtSDT.Text = "";
                txtDiaChi.Text = "";

                txtMaNCC.Enabled = true;
                txtTenNCC.Enabled = true;
                txtSDT.Enabled = true;
                txtDiaChi.Enabled = true;

                btnSua.Enabled = false;
                btnXoa.Enabled = false;
 //               btnTim.Enabled = false;

                txtMaNCC.Focus();

                dgrNCC.ClearSelection();

                return;
            }

            //Xử lý
            string maNCC = txtMaNCC.Text;
            string tenNCC = txtTenNCC.Text;
            string sDT = txtSDT.Text;
            string diaChi = txtDiaChi.Text;

            if (txtMaNCC.Enabled && string.IsNullOrEmpty(maNCC))
            {
                return;
            }
            else
            {
                errorProvider1.SetError(txtMaNCC, "");
            }

            if (txtTenNCC.Enabled && string.IsNullOrEmpty(tenNCC))
            {
                return;
            }
            else
            {
                errorProvider1.SetError(txtTenNCC, "");
            }

            if (txtSDT.Enabled && string.IsNullOrEmpty(sDT))
            {
                return;
            }
            else
            {
                errorProvider1.SetError(txtSDT, "");
            }

            if (txtDiaChi.Enabled && string.IsNullOrEmpty(diaChi))
            {
                return;
            }
            else
            {
                errorProvider1.SetError(txtDiaChi, "");
            }

            if (KiemTraTonTaiMaNCC(maNCC))
            {
                MessageBox.Show("Mã nhà cung cấp đã tồn tại, vui lòng nhập mã mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (KiemTraTonTaiTenNCC(tenNCC))
            {
                MessageBox.Show("Tên nhà cung cấp đã tồn tại, vui lòng nhập tên mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(errorProvider1.GetError(txtMaNCC)) && string.IsNullOrEmpty(errorProvider1.GetError(txtTenNCC)) && string.IsNullOrEmpty(errorProvider1.GetError(txtSDT)) && string.IsNullOrEmpty(errorProvider1.GetError(txtDiaChi)))
            {
                ThemDuLieuVaoDB(maNCC, tenNCC, sDT, diaChi);

                dgr_load();
                dgrNCC.ClearSelection();

                txtMaNCC.Text = "";
                txtTenNCC.Text = "";
                txtSDT.Text = "";
                txtDiaChi.Text = "";

                MessageBox.Show("Bạn vừa thêm thành công 1 nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            txtMaNCC.Enabled = false;
            txtTenNCC.Enabled = false;
            txtSDT.Enabled = false;
            txtDiaChi.Enabled = false;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
  //          btnTim.Enabled = true;

            errorProvider1.SetError(txtMaNCC, "");
            errorProvider1.SetError(txtTenNCC, "");
            errorProvider1.SetError(txtSDT, "");
            errorProvider1.SetError(txtDiaChi, "");
        }

        private bool KiemTraTonTaiMaNCC(string maNCC)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblNCC WHERE sMaNCC = @MaNCC", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@MaNCC", maNCC);
                    cnn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private bool KiemTraTonTaiTenNCC(string tenNCC)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblNCC WHERE sTenNCC = @TenNCC", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@TenNCC", tenNCC);
                    cnn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void ThemDuLieuVaoDB(string maNCC, string tenNCC, string sDT, string diaChi)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO tblNCC (sMaNCC, sTenNCC, sSDT, sDiaChi) VALUES (@MaNCC, @TenNCC, @SDT, @DiaChi)", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@MaNCC", maNCC);
                    cmd.Parameters.AddWithValue("@TenNCC", tenNCC);
                    cmd.Parameters.AddWithValue("@SDT", sDT);
                    cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void txtMaNCC_Validating(object sender, CancelEventArgs e)
        {
            if (txtMaNCC.Text == "")
            {
                errorProvider1.SetError(txtMaNCC, "Vui lòng nhập mã nhà cung cấp");
                return;
            }
            else
            {
                errorProvider1.SetError(txtMaNCC, "");
            }
        }

        private void txtTenNCC_Validating(object sender, CancelEventArgs e)
        {
            if (txtTenNCC.Text == "")
            {
                errorProvider1.SetError(txtTenNCC, "Vui lòng nhập tên nhà cung cấp");
                return;
            }
            else
            {
                errorProvider1.SetError(txtTenNCC, "");
            }
        }

        private void txtSDT_Validating(object sender, CancelEventArgs e)
        {
            if (txtSDT.Text == "")
            {
                errorProvider1.SetError(txtSDT, "Vui lòng nhập số điện thoại");
                return;
            }
            else
            {
                errorProvider1.SetError(txtSDT, "");
            }
        }

        private void txtDiaChi_Validating(object sender, CancelEventArgs e)
        {
            if (txtDiaChi.Text == "")
            {
                errorProvider1.SetError(txtDiaChi, "Vui lòng nhập địa chỉ");
                return;
            }
            else
            {
                errorProvider1.SetError(txtDiaChi, "");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //Check ấn lần đầu
            if(txtTenNCC.Enabled == false)
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
   //             btnTim.Enabled = false;

                txtTenNCC.Enabled = true;
                txtSDT.Enabled = true;
                txtDiaChi.Enabled = true;

                return;
            }    
            

            //Xử lý
            string maNCC = txtMaNCC.Text;
            string tenNCC = txtTenNCC.Text;
            string sDT = txtSDT.Text;
            string diaChi = txtDiaChi.Text;

            if (string.IsNullOrEmpty(tenNCC))
            {
                errorProvider1.SetError(txtTenNCC, "Vui lòng nhập nhà cung cấp");
                return;
            }
            else
            {
                errorProvider1.SetError(txtTenNCC, "");
            }

            if (string.IsNullOrEmpty(sDT))
            {
                errorProvider1.SetError(txtSDT, "Vui lòng nhập số điện thoại");
                return;
            }
            else
            {
                errorProvider1.SetError(txtSDT, "");
            }

            if (string.IsNullOrEmpty(diaChi))
            {
                errorProvider1.SetError(txtDiaChi, "Vui lòng nhập địa chỉ");
                return;
            }
            else
            {
                errorProvider1.SetError(txtDiaChi, "");
            }


            if (KiemTraTonTaiTenNCC2(tenNCC, maNCC))
            {
                MessageBox.Show("Tên nhà cung cấp đã tồn tại, vui lòng nhập tên mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            suaDuLieuTrongDB(maNCC, tenNCC, sDT, diaChi);

            dgr_load();
            dgrNCC.ClearSelection();

            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";

            txtMaNCC.Enabled = false;
            txtTenNCC.Enabled = false;
            txtSDT.Enabled = false;
            txtDiaChi.Enabled = false;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
 //           btnTim.Enabled = true;

            errorProvider1.SetError(txtMaNCC, "");
            errorProvider1.SetError(txtTenNCC, "");
            errorProvider1.SetError(txtSDT, "");
            errorProvider1.SetError(txtDiaChi, "");
        }

        private bool KiemTraTonTaiTenNCC2(string tenNCC, string maNCC)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                string query = "SELECT COUNT(*) FROM tblNCC WHERE sTenNCC = @TenNCC AND sMaNCC != @MaNCC";

                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.AddWithValue("@TenNCC", tenNCC);
                    cmd.Parameters.AddWithValue("@MaNCC", maNCC);

                    cnn.Open();
                    int count = (int)cmd.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        private void suaDuLieuTrongDB(string maNCC, string tenNCC, string sDT, string diaChi)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE tblNCC SET sTenNCC = @TenNCC, sSDT = @SDT, sDiaChi = @DiaChi WHERE sMaNCC = @MaNCC", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@MaNCC", maNCC);
                    cmd.Parameters.AddWithValue("@TenNCC", tenNCC);
                    cmd.Parameters.AddWithValue("@SDT", sDT);
                    cmd.Parameters.AddWithValue("@DiaChi", diaChi);

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();

                    MessageBox.Show("Sửa thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maNCC = txtMaNCC.Text;

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection cnn = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE tblNCC SET bttXoa = 1 WHERE sMaNCC = @MaNCC", cnn))
                    {
                        cmd.Parameters.AddWithValue("@MaNCC", maNCC);
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Xóa nhà cung cấp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtMaNCC.Text = "";
                txtTenNCC.Text = "";
                txtSDT.Text = "";
                txtDiaChi.Text = "";

                dgr_load();
                dgrNCC.ClearSelection();

                txtMaNCC.Enabled = false;
                txtTenNCC.Enabled = false;
                txtSDT.Enabled = false;
                txtDiaChi.Enabled = false;

                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
      //          btnTim.Enabled = true;
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            //Check xem có phải ấn lần 1 không
            if (txtTenNCC.Enabled == false)
            {
                txtTenNCC.Enabled = true;

                dgrNCC.ClearSelection();

                txtMaNCC.Text = "";
                txtTenNCC.Text = "";
                txtSDT.Text = "";
                txtDiaChi.Text = "";

                txtMaNCC.Enabled = false;
                txtSDT.Enabled = false;
                txtDiaChi.Enabled = false;

                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                return;
            }

            String tenNCC = txtTenNCC.Text.Trim();

            if (string.IsNullOrEmpty(tenNCC))
            {
                errorProvider1.SetError(txtTenNCC, "Vui lòng nhập tên nhà cung cấp để tìm kiếm");
                return;
            }
            else
            {
                errorProvider1.SetError(txtTenNCC, "");
            }

            using (SqlConnection cnn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("SELECT sMaNCC, sTenNCC, sSDT, sDiaChi FROM tblNCC WHERE bttXoa = 0 AND sTenNCC LIKE @TenNCC", cnn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@TenNCC", "%" + tenNCC + "%");

                DataTable dataTable = new DataTable();

                try
                {
                    cnn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);

                    int resultCount = dataTable.Rows.Count;

                    if (resultCount > 0)
                    {
                        dgrNCC.DataSource = dataTable;

                        // Hiển thị thông báo với số lượng kết quả tìm kiếm
                        MessageBox.Show("Tìm thấy " + resultCount + " nhà cung cấp có tên: " + tenNCC, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dataTable.Rows.Count > 0)
                {
                    dgrNCC.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhà cung cấp có tên: " + tenNCC, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            errorProvider1.SetError(txtMaNCC, "");
            errorProvider1.SetError(txtTenNCC, "");
            errorProvider1.SetError(txtSDT, "");
            errorProvider1.SetError(txtDiaChi, "");

            txtMaNCC.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";

            txtMaNCC.Enabled = false;
            txtSDT.Enabled = false;
            txtDiaChi.Enabled = false;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
   //         btnTim.Enabled = true;
        }
    }
}
