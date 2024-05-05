using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace BTL_QLBanTrangSuc
{
    public partial class frmTaoHoaDonNhap : Form
    {
        
        clXuLyData clXuLy = new clXuLyData();
        
        string queryConnect ="Data Source=ANPHATPC\\SQLEXPRESS;Initial Catalog=QuanLyBanTrangSuc;Integrated Security=True";
        private static int vitri = -1;
        private string tenNguoiDung;
        private string maNguoiDung;
        private Panel frmHienThi;


        public frmTaoHoaDonNhap(Panel frmHienThi, string ten, string ma)
        {
            InitializeComponent();
            this.tenNguoiDung = ten;
            this.maNguoiDung = ma;
            this.frmHienThi = frmHienThi;
        }
        private void reset_SP()
        {
            cbbLoaiSP.Text = " ";
            cbbTenSanPham.Text = " ";
            cbbTenSanPham.Enabled = false;
            cbbLoaiSP.Enabled = true;
            txtGiaNhap.Text = " ";
            txtSoLuong.Text = " ";
        }
        private void reset()
        {
            
            cbbLoaiSP.Text = " ";
            cbbTenSanPham.Text = " ";
            cbbTenSanPham.Enabled = false;
            txtGiaNhap.Text = " ";
            txtSoLuong.Text = " ";
            txtTongTien.Text = " ";
            dtpNgayNhap.Text = "";
        }

        private void TaoHoaDonNhap_Load(object sender, EventArgs e)
        {
            //load data cho combobox ten san pham 
            clXuLy.loadCbb(cbbLoaiSP, "tblLoaiSanPham");
            cbbLoaiSP.Text = " ";
            //load data cho combobox ten san pham 
            cbbTenSanPham.Text = "";
            cbbTenSanPham.Enabled = false;
            
        }

        // hiện sản phẩm khi thay đổi loại sản phẩm 
        private void cbbLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "select * from vv_SanPham where sTenLoai like N'%" + cbbLoaiSP.Text.ToString() + "%'";
            cbbTenSanPham.Enabled = true;
            DataTable dt = clXuLy.Lay_DataTable(query, "SanPham");
            clXuLy.loadCbb(dt, cbbTenSanPham, "sTenSP", "sMaSP");
            cbbTenSanPham.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
            cbbLoaiSP.Enabled = false;
            cbbTenSanPham.Text = dataGridView1.Rows[vitri].Cells[1].Value.ToString();
            txtSoLuong.Text = dataGridView1.Rows[vitri].Cells[2].Value.ToString();
            txtGiaNhap.Text = dataGridView1.Rows[vitri].Cells[6].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtSoLuong.Text == " " || txtGiaNhap.Text == " " || cbbTenSanPham.Text == " " || cbbLoaiSP.Text == " ")
            {
                MessageBox.Show("bạn chưa nhập thông tin vui lòng nhập lại ", "thông báo");
            }
            else
            {
                string query = "select * from tblSanPham where sMaSP = '" + cbbTenSanPham.SelectedValue.ToString() + "'";
                DataTable tb = clXuLy.Lay_DataTable(query, "tblSanPham");
                DataRow dtr = tb.Rows[0];
                dataGridView1.Rows.Add(dtr["sMaSP"], dtr["sTenSP"], txtSoLuong.Text, dtr["sMauSac"], dtr["sChatLieu"], dtr["fDoDai"], txtGiaNhap.Text);
                float tien = float.Parse(txtTongTien.Text);
                tien = tien + float.Parse(txtGiaNhap.Text) * int.Parse(txtSoLuong.Text);
                MessageBox.Show(tien.ToString());
                txtTongTien.Text = tien.ToString();
                reset_SP();
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(vitri>-1)
            {
                DataGridViewRow newDataRow = dataGridView1.Rows[vitri];
                float tien = float.Parse(txtTongTien.Text);
                tien = tien - int.Parse(newDataRow.Cells[2].Value.ToString().Trim()) * float.Parse(newDataRow.Cells[6].Value.ToString());
                
                newDataRow.Cells[2].Value = txtSoLuong.Text;
                newDataRow.Cells[6].Value = txtGiaNhap.Text;
                
                tien = tien + (int.Parse(txtSoLuong.Text) * float.Parse(txtGiaNhap.Text));
                txtTongTien.Text = tien.ToString();
                reset_SP();
                vitri = -1;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (vitri > -1)
            {
                dataGridView1.Rows.RemoveAt(vitri);
                float tien = float.Parse(txtTongTien.Text);
                tien = tien - (int.Parse(txtSoLuong.Text) * float.Parse(txtGiaNhap.Text));
                txtTongTien.Text = tien.ToString();
                reset_SP();
                cbbLoaiSP.Enabled = true;
                vitri = -1;
            }
            
        }
        private void btnHuyHD_Click(object sender, EventArgs e)
        {
            reset();
        }

        public int themHoaDonNhap(string maHD, string maNV, string ngayLap, string tongTien)
        {
            using (SqlConnection conn = new SqlConnection(queryConnect))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    string sqlInsert = "insert into tblHoaDonNhap " +
                                        "VALUES (" + maHD.Trim() + ",'" + maNV.Trim() + "','" + ngayLap + "'," + tongTien + " ,0)";
                    cmd.CommandText = sqlInsert;
                    conn.Open();
                    int i = cmd.ExecuteNonQuery();
                    conn.Close();
                    return i;
                }
            }
        }

        public void themCTHD_Nhap(string maHD, string maSP, string soLuong, string donGia)
        {
            using (SqlConnection conn = new SqlConnection(queryConnect))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    string sqlInsert = "insert into tblCTHD_Nhap " +
                                        "VALUES (" + maHD + ",'" + maSP.Trim() + "'," + soLuong + "," + donGia + ",0 )";
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
            DateTime time = dtpNgayNhap.Value;
            string maHD = txtHoaDon.Text;
            /*float TongTien = float.Parse(txtTongTien.Text);*/
            if(txtHoaDon.Text=="" || txtTongTien.Text == "0") 
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                int check_addData = themHoaDonNhap(maHD, maNguoiDung, time.ToString("MM/dd/yyyy"), txtTongTien.Text);
                if (check_addData > 0)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        themCTHD_Nhap(maHD, row.Cells[0].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[6].Value.ToString());
                    }
                    MessageBox.Show("Thêm chi tiết hóa đơn thành công");
                    reset();
                }
            }
        }

        private void btnTroLai_Click(object sender, EventArgs e)
        {
            Close();
            frmHoaDonNhap frmHoaDonBan = new frmHoaDonNhap(frmHienThi, tenNguoiDung, maNguoiDung);
            frmHoaDonBan.TopLevel = false;
            frmHoaDonBan.FormBorderStyle = FormBorderStyle.None;
            frmHoaDonBan.Dock = DockStyle.Fill;
            frmHienThi.Controls.Add(frmHoaDonBan);
            frmHienThi.Tag = frmHoaDonBan;
            frmHoaDonBan.Show();
            /*frmTaoHoaDonBan.ShowDialog();*/
        }
    }
}
