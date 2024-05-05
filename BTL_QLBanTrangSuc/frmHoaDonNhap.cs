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
    public partial class frmHoaDonNhap : Form
    {
        string constr = "Data Source=ANPHATPC\\SQLEXPRESS;Initial Catalog=QuanLyBanTrangSuc;Integrated Security=True";

        private int viTriChon = -1;
        private string tenNguoiDung;
        private string maNguoiDung;
        private Panel frmHienThi;

        public frmHoaDonNhap(Panel frmHienThi, string ten, string ma)
        {
            InitializeComponent();
            this.tenNguoiDung = ten;
            this.maNguoiDung = ma;
            this.frmHienThi = frmHienThi;
        }

        private void frmHoaDonBan_Load(object sender, EventArgs e)
        {
            //Gắn dữ liệu cho dataView
            dataViewHDB.DataSource = layDataTable("vv_HoaDonNhap");


            //Gắn dữ liệu cho cbxTenNV
            cbxTenNV.DataSource = layDataTable("tblNhanVien");
            cbxTenNV.DisplayMember = "sTenNV";
            cbxTenNV.ValueMember = "sMaNV";
            cbxTenNV.Text = "";
        }
        private void huy()
        {
            txtSoHDB.Text = "";
            txtNgay.Text = "";
            txtTongTien.Text = "";
            cbxTenNV.Text = "";
            txtSoHDB.Enabled = true;
        }
        private DataTable layDataTable(string sTentbl)
        {
            SqlConnection conn = new SqlConnection(constr);
            string sqlCommand = "SELECT * FROM " + sTentbl;
            SqlDataAdapter sqlAp = new SqlDataAdapter();
            sqlAp.SelectCommand = new SqlCommand(sqlCommand, conn);
            DataTable dt = new DataTable(sTentbl);
            sqlAp.Fill(dt);
            return dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            viTriChon = e.RowIndex;
            DataTable dt = layDataTable("vv_HoaDonNhap");
            DataRow row = dt.Rows[viTriChon];
            txtSoHDB.Text = row[0].ToString().Trim();
            cbxTenNV.Text = row[1].ToString().Trim();
            DateTime time = DateTime.Parse(row[2].ToString());
            txtNgay.Text = time.ToString("dd/MM/yyyy");
            txtTongTien.Text = row[3].ToString().Trim();

            /*txtTongTien.Enabled = false;*/
            txtSoHDB.Enabled = false;
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = dtpDate.Value;
            txtNgay.Text = dt.ToString("dd/MM/yyyy");

        }

        

        private void btnHuy_Click(object sender, EventArgs e)
        {
            huy();
        }

        private int Xoa_HoaDonBan(string soHDB)
        {

            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    string sqlDel_tblCTHDB = "UPDATE tblCTHD_Nhap SET bttXoa=1" +
                                    "Where iSoHDN= '" + soHDB + "'";
                    conn.Open();
                    cmd.CommandText = sqlDel_tblCTHDB;
                    cmd.ExecuteNonQuery();
                    string sqlDel_tblHDB = "UPDATE tblHoaDonNhap SET bttXoa=1" +
                                    "Where iSoHDN= '" + soHDB + "'";
                    cmd.CommandText = sqlDel_tblHDB;

                    int i = cmd.ExecuteNonQuery();
                    conn.Close();
                    return i;

                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (viTriChon < 0)
            {
                MessageBox.Show("Bạn chưa chọn hoá đơn cần xoá!");
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá sản phẩm hay không ?", "Xoá sản phẩm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                string masp = txtSoHDB.Text.ToString().Trim();
                int i = Xoa_HoaDonBan(masp);
                if (i > 0)
                {
                    MessageBox.Show("Xoa Thanh cong!");
                    dataViewHDB.DataSource = layDataTable("vv_HoaDonNhap");
                }
                else
                {
                    MessageBox.Show("Xoa khong thanh cong!");
                }
                huy();

            }

        }

        public int suaHoaDonNhap(string soHD, string maNV, string date)
        {

            string sqlUpdate = "UPDATE tblHoaDonNhap " +
                                "SET sMaNV='" + maNV + "', dTgianNhap='" + date + "'" +
                                " WHERE iSoHDN='" + soHD + "'";
            MessageBox.Show(sqlUpdate);
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
            if (viTriChon < 0)
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm cần sửa!");
                return;
            }
            string soHD = txtSoHDB.Text.ToString().Trim();
            
            string maNV = cbxTenNV.SelectedValue.ToString().Trim();
            DateTime time = DateTime.Parse(txtNgay.Text);
            string TGlap = time.ToString("MM/dd/yyyy");


            int kq = suaHoaDonNhap(soHD, maNV, TGlap);
            if (kq > 0)
            {
                MessageBox.Show("Sửa Thanh cong!");
                dataViewHDB.DataSource = layDataTable("vv_HoaDonNhap");
            }
            else
            {
                MessageBox.Show("Sửa khong thanh cong!");
            }
            huy();
        }

        public DataTable layDatatable1(string sqlCommand, string sTentbl)
        {
            SqlConnection conn = new SqlConnection(constr);
            SqlDataAdapter sqlAp = new SqlDataAdapter();
            sqlAp.SelectCommand = new SqlCommand(sqlCommand, conn);
            DataTable dt = new DataTable(sTentbl);
            sqlAp.Fill(dt);
            return dt;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string sqlCommand = "SELECT * FROM vv_HoaDonNhap WHERE ";

            if (txtSoHDB.Text.Trim().Length != 0)
            {

                sqlCommand = sqlCommand + "iSoHDN LIKE '%" + txtSoHDB.Text.Trim() + "%'";
            }
            if (cbxTenNV.Text.Trim().Length != 0)
            {
                if (sqlCommand.Length > 36)
                {
                    sqlCommand = sqlCommand + "AND sTenNV LIKE N'%" + cbxTenNV.Text.Trim() + "%'";
                }
                else
                {
                    sqlCommand = "SELECT * FROM vv_HoaDonNhap WHERE sTenNV LIKE N'%" + cbxTenNV.Text.Trim() + "%'";
                }

            }
            if (txtNgay.Text.Trim().Length > 4)
            {
                DateTime time = DateTime.Parse(txtNgay.Text);
                string TGlap = time.ToString("MM/dd/yyyy");

                if (sqlCommand.Length > 36)
                {
                    sqlCommand = sqlCommand + " AND dTgianNhap >= '" + TGlap + "'";
                }
                else
                {
                    sqlCommand = "SELECT * FROM vv_HoaDonNhap WHERE dTgianNhap >= '" + TGlap + "'";
                }
            }
            if (txtTongTien.Text.Trim().Length != 0)
            {
                float gia = float.Parse(txtTongTien.Text.Trim());
                if (sqlCommand.Length > 36)
                {
                    sqlCommand = sqlCommand + " AND fTongTienNhap < " + gia;
                }
                else
                {
                    sqlCommand = "SELECT * FROM vv_HoaDonNhap WHERE fTongTienNhap < " + gia;
                }
            }
            if (sqlCommand.Length < 45)
            {
                sqlCommand = "SELECT * FROM vv_HoaDonNhap";
            }

            dataViewHDB.DataSource = layDatatable1(sqlCommand, "vv_HoaDonNhap");
            huy();
        }

        // Hiện thị chi tiêt hoá đơn cho từng hoá đơn tương ứng
        /*private void dataViewHDB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string command = dataViewHDB.Columns[e.ColumnIndex].Name;
                if (command == "clXemCT")
                {
                    viTriChon = e.RowIndex;
                    DataTable dt = layDataTable("vv_HoaDonBan");
                    DataRow row = dt.Rows[viTriChon];
                    frmCTHB_Ban form = new frmCTHB_Ban(row[0].ToString().Trim());
                    form.ShowDialog();
                }
            }
        }*/


        private void btnThem_Click(object sender, EventArgs e)
        {
            Close();
            frmTaoHoaDonNhap frmTaoHoaDonBan = new frmTaoHoaDonNhap(frmHienThi, tenNguoiDung, maNguoiDung);
            frmTaoHoaDonBan.TopLevel = false;
            frmTaoHoaDonBan.FormBorderStyle = FormBorderStyle.None;
            frmTaoHoaDonBan.Dock = DockStyle.Fill;
            frmHienThi.Controls.Add(frmTaoHoaDonBan);
            frmHienThi.Tag = frmTaoHoaDonBan;
            frmTaoHoaDonBan.Show();

        }
    }
}
