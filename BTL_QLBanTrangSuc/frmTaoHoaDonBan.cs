using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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
    public partial class frmTaoHoaDonBan : Form
    {
        string constr = "Data Source=ANPHATPC\\SQLEXPRESS;Initial Catalog=QuanLyBanTrangSuc;Integrated Security=True";

        private int viTri = -1;
        private string tenNguoiDung;
        private string maNguoiDung;
        private Panel frmHienThi;
        public frmTaoHoaDonBan(Panel panel,string ten, string ma)
        {
            InitializeComponent();
            frmHienThi = panel;
            tenNguoiDung = ten;
            maNguoiDung = ma;

        }
        
        private DataTable layDataTable(string sqlCommand,string sTentbl)
        {
            SqlConnection conn = new SqlConnection(constr);
            SqlDataAdapter sqlAp = new SqlDataAdapter();
            sqlAp.SelectCommand = new SqlCommand(sqlCommand, conn);
            DataTable dt = new DataTable(sTentbl);
            sqlAp.Fill(dt);
            return dt;
        }

        private DataTable layDataTable1( string sTentbl)
        {
            SqlConnection conn = new SqlConnection(constr);
            string sqlCommand = "SELECT * FROM " + sTentbl;
            SqlDataAdapter sqlAp = new SqlDataAdapter();
            sqlAp.SelectCommand = new SqlCommand(sqlCommand, conn);
            DataTable dt = new DataTable(sTentbl);
            sqlAp.Fill(dt);
            return dt;
        }

        private void huy()
        {
            cbxLoaiSP.Text = "";
            cbxTenSP.Text = "";
            cbxTenSP.Enabled = false;
            txtGiaBan.Text = "";
            txtSoLuong.Text = "";
        }

        private void resetFrom() 
        {
            huy();
            cbxTenKH.Text = "";
            dtpDate.Text = "";
            /*cbxTenNV.Text = "";*/
            dataGridView1.Rows.Clear();
        }

        

        private void frmTaoHoaDonBan_Load(object sender, EventArgs e)
        {
            //Gắn dữ liệu cho cbxTenKH
            cbxTenKH.DataSource = layDataTable1("tblKhachHang");
            cbxTenKH.DisplayMember = "sTenKH";
            cbxTenKH.ValueMember = "sMaKH";
            cbxTenKH.Text = "";

            //Gắn dữ liệu cho cbxTenNV
            /*cbxTenNV.DataSource = layDataTable1("tblNhanVien");
            cbxTenNV.DisplayMember = "sTenNV";
            cbxTenNV.ValueMember = "sMaNV";
            cbxTenNV.Text = "";*/

            //Gắn dữ liệu cho cbxLoaiSP
            cbxLoaiSP.DataSource = layDataTable1("tblLoaiSanPham");
            cbxLoaiSP.DisplayMember = "sTenLoai";
            cbxLoaiSP.ValueMember = "sMaLoaiSP";
            cbxLoaiSP.Text = "";
            cbxTenSP.Enabled = false;

            

        }


        // Hiện sản phẩm tương ứng khi thay đổi lại sản phẩm
        private void cbxLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxTenSP.Enabled = true;
            string sqlCommand = "SELECT * FROM vv_SanPham WHERE sTenLoai LIKE N'%" + cbxLoaiSP.Text.ToString() + "%'";
            cbxTenSP.DataSource = layDataTable(sqlCommand, "vv_SanPham");
            cbxTenSP.DisplayMember = "sTenSP";
            cbxTenSP.ValueMember = "sMaSP";
            cbxTenSP.Text = "";
            txtGiaBan.Text = "";
        }

        // Hiện giá bán tương ứng của từng sản phẩm
        private void cbxTenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlCommand = "SELECT * FROM vv_SanPham WHERE sTenSP LIKE N'%" + cbxTenSP.Text.ToString() + "%'";
            DataTable dt = layDataTable(sqlCommand, "vv_SanPham");
            DataRow dataRow = dt.Rows[0];
            txtGiaBan.Text = dataRow["fGiaBan"].ToString();
        }

        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            viTri = e.RowIndex;
            /*cbxTenSP.Enabled = true;*/
            cbxLoaiSP.Enabled = false;
            cbxTenSP.Text = dataGridView1.Rows[viTri].Cells[0].Value.ToString();
            txtSoLuong.Text = dataGridView1.Rows[viTri].Cells[2].Value.ToString();
            txtGiaBan.Text= dataGridView1.Rows[viTri].Cells[6].Value.ToString();
        }

        // Kiểm tra tránh chọn mua trùng sản phẩm
        private bool kiemTraSP(string maSP)
        {
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                if (maSP.Equals(row.Cells[0].Value.ToString()))
                {
                    return false;
                }
            }
            return true;
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {

            if(cbxTenSP.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm mua");
                cbxTenSP.Focus();
            }
            else if(txtSoLuong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số lượng sản phẩm mua");
                txtSoLuong.Focus();
            }
            else
            {
                if (kiemTraSP(cbxTenSP.SelectedValue.ToString()))
                {
                    string sqlCommand = "SELECT * FROM vv_SanPham WHERE sMaSP ='" + cbxTenSP.SelectedValue.ToString() + "'";
                    DataTable dt = layDataTable(sqlCommand, "vv_SanPham");
                    DataRow dataRow = dt.Rows[0];
                    dataGridView1.Rows.Add(dataRow["sMaSP"],dataRow["sTenSP"], txtSoLuong.Text, dataRow["sMauSac"], dataRow["sChatLieu"], dataRow["sDoDai"], txtGiaBan.Text);
                    float tien = float.Parse(txtTongTien.Text);
                    tien= tien + int.Parse(txtSoLuong.Text)* float.Parse(txtGiaBan.Text);
                    txtTongTien.Text = tien.ToString();
                    huy();
                }
                else
                {
                    MessageBox.Show("Sản phẩm này đã có");
                }
            }
        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            if (viTri < 0)
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm cần sửa");
            }
            else
            {
                DataGridViewRow dataRow = dataGridView1.Rows[viTri];
                float tien = float.Parse(txtTongTien.Text);
                
                tien = tien - int.Parse(dataRow.Cells[2].Value.ToString().Trim()) * float.Parse(txtGiaBan.Text);
                dataRow.Cells[2].Value=txtSoLuong.Text;
                
                tien = tien + int.Parse(txtSoLuong.Text) * float.Parse(txtGiaBan.Text);
                txtTongTien.Text = tien.ToString();
                huy();
                viTri = -1;
                cbxLoaiSP.Enabled = true;
            }
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if(viTri < 0)
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm cần xoá");
            }
            else
            {
                dataGridView1.Rows.RemoveAt(viTri);
                float tien = float.Parse(txtTongTien.Text);
                tien = tien - int.Parse(txtSoLuong.Text) * float.Parse(txtGiaBan.Text);
                txtTongTien.Text = tien.ToString();
                huy();
                viTri = -1;
                cbxLoaiSP.Enabled = true;
            }
        }

        public string layMa(string sTentbl)
        {
            string sqlCommand = "SELECT * FROM " + sTentbl;
            DataTable dt = layDataTable(sqlCommand, sTentbl);
            DataRow dr = dt.Rows[dt.Rows.Count-1];
            return (dt.Rows.Count + 1).ToString();
        }

        public int themHoaDonBan(string maHD, string maKH, string maNV, string ngayLap, string tongTien)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    string sqlInsert = "insert into tblHoaDonBan " +
                                        "VALUES (" + maHD.Trim() + ",'" +maKH.Trim() + "','" +maNV.Trim() + "','" + ngayLap + "'," + tongTien +" ,0)";
                    cmd.CommandText = sqlInsert;
                    conn.Open();
                    int i = cmd.ExecuteNonQuery();
                    conn.Close();
                    return i;
                }
            }
        }

        public void themCTHD_Ban(string maHD, string maSP, string soLuong, string donGia)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    string sqlInsert = "insert into tblCTHD_Ban " +
                                        "VALUES (" + maHD + ",'" + maSP.Trim() + "'," +soLuong + "," + donGia + ",0 )";
                    cmd.CommandText = sqlInsert;
                    conn.Open();
                    int i = cmd.ExecuteNonQuery();
                    conn.Close();
                   /* return i;*/
                }
            }
        }

        
        private void btnThemHD_Click(object sender, EventArgs e)
        {
            DateTime thoiGianLap = dtpDate.Value;
            if (cbxTenKH.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn khach hàng!");
                cbxTenKH.Focus();
            }
            else if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm cần mua");
            }
            else
            {
                string maHD = layMa("tblHoaDonBan");
                int ktThemHD = themHoaDonBan(maHD, cbxTenKH.SelectedValue.ToString(), maNguoiDung, thoiGianLap.ToString("MM/dd/yyyy"), txtTongTien.Text);
                if (ktThemHD > 0)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        themCTHD_Ban(maHD, row.Cells[0].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[6].Value.ToString());

                    }
                    MessageBox.Show("Thêm thành công");
                    resetFrom();
                    frmReport_SanPham reportSanPham = new frmReport_SanPham(maHD, tenNguoiDung);
                    reportSanPham.ShowDialog();

                }
            }
        }
        private void btnTroLai_Click(object sender, EventArgs e)
        {
            Close();
            frmHoaDonBan frmHoaDonBan = new frmHoaDonBan(frmHienThi,tenNguoiDung,maNguoiDung);
            frmHoaDonBan.TopLevel = false;
            frmHoaDonBan.FormBorderStyle = FormBorderStyle.None;
            frmHoaDonBan.Dock = DockStyle.Fill;
            frmHienThi.Controls.Add(frmHoaDonBan);
            frmHienThi.Tag = frmHoaDonBan;
            frmHoaDonBan.Show();
            /*frmTaoHoaDonBan.ShowDialog();*/
        }
        private bool ktSoLuongSP()
        {
            string sqlCommand = "SELECT * FROM vv_SanPham WHERE sMaSP = '" + cbxTenSP.SelectedValue + "'";
            DataTable dtSanPham = layDataTable(sqlCommand, "vv_SanPham");
            
            if (int.Parse(dtSanPham.Rows[0]["iSoLuong"].ToString()) < int.Parse(txtSoLuong.Text) ) return false;
            return true;
        }
        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if(txtSoLuong.Text != "")
            {
                if (!ktSoLuongSP())
                {
                    MessageBox.Show("Sô lượng trong kho không đủ!");
                    txtSoLuong.Clear();
                    txtSoLuong.Focus();
                }
            }
           
        }
        private void btbHuy_Click(object sender, EventArgs e)
        {
            resetFrom();
        }

        
    }
}
