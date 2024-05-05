using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QLBanTrangSuc
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }
        string constr = "Data Source=ANPHATPC\\SQLEXPRESS;Initial Catalog=QuanLyBanTrangSuc;Integrated Security=True";
 //       string constr = ConfigurationManager.ConnectionStrings["db_BanTrangSuc"].ConnectionString;
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            loadDatagridview();
        }
        private void loadDatagridview()
        {
            
            DataTable dt = Lay_Table("select sMaKH,sTenKH,sDiaChi,sSDT,sGioiTinh,dNgaysinh from tblKhachHang where bTTXoa = 0", "tblKhachHang");
            dtgvKhachHang.DataSource = dt;
            dtgvKhachHang.Refresh();
        }
        private DataTable Lay_Table(string sqlCommand, string sTentbl)
        {
            SqlConnection conn = new SqlConnection(constr);
            SqlDataAdapter sqlAp = new SqlDataAdapter();
            sqlAp.SelectCommand = new SqlCommand(sqlCommand, conn);
            DataTable dt = new DataTable(sTentbl);
            sqlAp.Fill(dt);
            return dt;
        }
        public void r_form()
        {
            txtMaKH.Enabled = true;
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtDiachi.Text = "";
            txtSDT.Text = "";
            cbxGioiTinh.Text = "";
            txtNgaysinh.Text = "";
        }
        public bool KiemTra_Ma(string sTentbl, string ma)
        {

            using (SqlConnection conn = new SqlConnection(constr))
            {
                string sqlCommand = "SELECT * FROM " + sTentbl;
                try
                {
                    SqlDataAdapter sqlAp = new SqlDataAdapter();
                    sqlAp.SelectCommand = new SqlCommand(sqlCommand, conn);

                    DataTable dt = new DataTable(sTentbl);
                    sqlAp.Fill(dt);

                    DataColumn dc = dt.Columns[0];

                    foreach (DataRow dr in dt.Rows)
                    {
                        if (ma.Trim().Equals(dr[dc.ColumnName].ToString().Trim()))
                        {
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                return false;
            }
        }
        private bool KiemTra_SDT(string sdt)
        {
            string sqlInsert = "select * from tblKhachHang " +
                "where sSDT = '" + sdt + "'";
            DataTable dataTable = Lay_Table(sqlInsert,"tblKhachHang");
            if (dataTable.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        private void txtMaKH_Validating(object sender, CancelEventArgs e)
        {
            if (txtMaKH.Text == "")
            {
                //errorProvider1.SetError(txtMaKH, "Bạn chưa nhập mã khách hàng");
            }
            else if (KiemTra_Ma("tblKhachHang", txtMaKH.Text))
            {
                    //errorProvider1.SetError(txtMaKH, "Mã khách hàng đã tồn tại");
                    txtMaKH.Focus();

            }
            else errorProvider1.SetError(txtMaKH, "");
        }

        private void txtTenKH_Validating(object sender, CancelEventArgs e)
        {
            if (txtTenKH.Text == "")
            {
                //errorProvider1.SetError(txtTenKH, "Bạn chưa nhập tên khách hàng");
                //MessageBox.Show("Bạn chưa nhập tên khách hàng","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else errorProvider1.SetError(txtTenKH, "");
        }

        private void txtDiachi_Validating(object sender, CancelEventArgs e)
        {
            if (txtDiachi.Text == "")
            {
               // errorProvider1.SetError(txtDiachi, "Bạn chưa nhập địa chỉ khách hàng");
               
            }
            else errorProvider1.SetError(txtDiachi, "");
        }

        private void txtSDT_Validating(object sender, CancelEventArgs e)
        {
            if (txtSDT.Text == "")
            {
                //errorProvider1.SetError(txtSDT, "Bạn chưa nhập số điện thoại");
            }
            else errorProvider1.SetError(txtSDT, "");
        }

        private void cbxGioiTinh_Validating(object sender, CancelEventArgs e)
        {
            if (cbxGioiTinh.Text == "")
            {
                //errorProvider1.SetError(cbxGioiTinh, "Bạn chưa nhập giới tính");
            }
            else errorProvider1.SetError(cbxGioiTinh, "");
        }

        int vitri = -1;
        private void dtgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;

            DataTable dt = Lay_Table("select sMaKH,sTenKH,sDiaChi,sSDT,sGioiTinh,dNgaysinh from tblKhachHang where bTTXoa = 0", "tblKhachHang");

            DataRow row = dt.Rows[vitri];
            txtMaKH.Text = row[0].ToString().Trim();
            txtTenKH.Text = row[1].ToString().Trim();
            txtDiachi.Text = row[2].ToString().Trim();
            txtSDT.Text = row[3].ToString().Trim();
            
            cbxGioiTinh.Text = row[4].ToString().Trim();
            txtNgaysinh.Text = row[5].ToString().Trim();
            errorProvider1.Clear();
            txtMaKH.Enabled = false;
        }
        private int ThemKhachHang(string makh, string tenkh, string diachi, string sdt, string gt,DateTime ngaysinh)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insert_kh_ngaysinh";
                    cmd.Parameters.AddWithValue("@makh", makh);
                    cmd.Parameters.AddWithValue("@tenkh", tenkh);
                    cmd.Parameters.AddWithValue("@diachi", diachi);
                    cmd.Parameters.AddWithValue("@sdt", sdt);
                    cmd.Parameters.AddWithValue("@gt", gt);
                    cmd.Parameters.AddWithValue("@ngaysinh", ngaysinh);
                    conn.Open();
                    int i = cmd.ExecuteNonQuery();
                    conn.Close();
                    return i;
                }
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtDiachi.Text=="" || txtMaKH.Text=="" || txtSDT.Text=="" || txtTenKH.Text=="" || txtNgaysinh.Text=="")
            {
                MessageBox.Show("Vui long nhập đầy đủ thông tin ");
            }
            else if (KiemTra_SDT(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại đã tồn tại");
                txtSDT.Clear();
                txtSDT.Focus();
            }
            else
            {
                string makh = txtMaKH.Text.ToString().Trim();
                string tenkh = txtTenKH.Text.ToString().Trim();
                string diachi = txtDiachi.Text.ToString().Trim();
                string sdt = txtSDT.Text.ToString().Trim();
                string gt = cbxGioiTinh.Text;
                DateTime ngaysinh = DateTime.Parse(txtNgaysinh.Text);

                int kq = ThemKhachHang(makh, tenkh, diachi, sdt, gt, ngaysinh);
                if (kq > 0)
                {
                    dtgvKhachHang.DataSource = Lay_Table("select sMaKH,sTenKH,sDiaChi,sSDT,sGioiTinh,dNgaysinh from tblKhachHang where bTTXoa = 0", "tblKhachHang");
                }
                else
                {
                    MessageBox.Show("Them khong thanh cong!");
                }
                r_form();
            }
                
        }

        public int SuaKhachHang(string maKH, string tenKH,string diaChi, string sdt, string gioiTinh, string ngaysinh)
        {

            string sqlUpdate = "update tblKhachHang " +
                                "SET sMaKH='" + maKH + "', sTenKH=N'" + tenKH + "', sDiaChi=N'" + diaChi + "', sSDT='" + sdt+ "', sGioiTinh=N'" + gioiTinh + "', dNgaysinh='" + ngaysinh + "' "+
                                "WHERE sMaKH='" + maKH+ "'";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sqlUpdate;
                    conn.Open();
                    int i = cmd.ExecuteNonQuery();
                    conn.Close();
                    return i;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (vitri < 0)
            {
                MessageBox.Show("Bạn chưa chọn khách hàng cần sửa!");
                return;
            }
            string maKH = txtMaKH.Text.ToString().Trim();
            string tenKH = txtTenKH.Text.ToString().Trim();
            string diaChi = txtDiachi.Text.ToString().Trim();
            string sdt = txtSDT.Text.ToString().Trim();
            string gioiTinh = cbxGioiTinh.Text.ToString().Trim();
            DateTime time = DateTime.Parse(txtNgaysinh.Text);
            string ngaysinh = time.ToString("MM/dd/yyyy");

            int kq = SuaKhachHang( maKH,tenKH, diaChi, sdt, gioiTinh,ngaysinh);
            if (kq > 0)
            {
                dtgvKhachHang.DataSource = Lay_Table("SELECT sMaKH,sTenKH,sDiaChi,sSDT,sGioiTinh,dNgaysinh FROM tblKhachHang where bTTXoa = 0", "tblKhachHang");

            }
            else
            {
                MessageBox.Show("Sửa không thành công!");
            }
            r_form();
        }

        private int XoaKhachHang(string maKH)
        {
            string sqlDel = "update tblKhachHang " +
                            "set bTTXoa = 1 " +
                             "where sMaKH= '" + maKH + "'";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sqlDel;
                    conn.Open();
                    int i = cmd.ExecuteNonQuery();
                    conn.Close();
                    return i;

                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (vitri < 0)
            {
                MessageBox.Show("Bạn chưa chọn khách hàng cần xoá!");
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xoá khách hàng này không ?", "Xoá khách hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                string maKH = txtMaKH.Text.ToString().Trim();
                int i = XoaKhachHang(maKH);
                if (i > 0)
                {
                    dtgvKhachHang.DataSource = Lay_Table("SELECT sMaKH,sTenKH,sDiaChi,sSDT,sGioiTinh,dNgaysinh FROM tblKhachHang where bTTXoa = 0", "tblKhachHang");
                }
                else
                {
                    MessageBox.Show("Xoa khong thanh cong!");
                }
                r_form();
                
            }
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            r_form();
            loadDatagridview();
        }

        

        private void txtTimKiem_Click(object sender, EventArgs e)
        {
            string sqlCommand = "";
            if (txtTenKH.Text.ToString().Trim().Length != 0)
            {
                sqlCommand = "SELECT sMaKH,sTenKH,sDiaChi,sSDT,sGioiTinh,dNgaysinh FROM tblKhachHang where bTTXoa = 0 and sTenKH LIKE N'%" + txtTenKH.Text.ToString().Trim() + "%'";
            }
            else
            {
                sqlCommand = "SELECT sMaKH,sTenKH,sDiaChi,sSDT,sGioiTinh,dNgaysinh FROM tblKhachHang where bTTXoa = 0";
            }
            dtgvKhachHang.DataSource = Lay_Table(sqlCommand, "tblKhachHang");
            r_form();
        }
    }
}
