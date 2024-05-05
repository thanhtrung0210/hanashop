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
    public partial class frmCTHB_Ban : Form
    {
        string constr = "Data Source=ANPHATPC\\SQLEXPRESS;Initial Catalog=QuanLyBanTrangSuc;Integrated Security=True";
        private string soHD;
        public frmCTHB_Ban(string sohd)
        {
            InitializeComponent();
            this.soHD = sohd;
        }

        private DataTable Lay_DataTable(string sqlCommand)
        {
            
            string sTentbl="tblChiTietHD";
            SqlConnection conn = new SqlConnection(constr);
            SqlDataAdapter sqlAp = new SqlDataAdapter();
            sqlAp.SelectCommand = new SqlCommand(sqlCommand, conn);
            DataTable dt = new DataTable(sTentbl);
            sqlAp.Fill(dt);
            return dt;
        }

        private void frmCTHB_Ban_Load(object sender, EventArgs e)
        {
            string sqlCommand = "SELECT sTenSP,iSoLuong,fDonGia,iSoLuong*fDonGia as [fThanhTien] FROM vv_CTHD_Ban WHERE iSoHDB = '" + soHD + "'";
            dgvSanPham_Mua.DataSource = Lay_DataTable(sqlCommand);
           
            sqlCommand = "SELECT sTenKH,sTenNV,dTgianThanhToan,fTongTien FROM vv_HoaDonBan WHERE iSoHDB = '" + soHD + "'";
            DataTable dt = Lay_DataTable(sqlCommand);
            DataRow dw = dt.Rows[0];
            lbSoHD.Text = soHD;
            lbTenKH.Text = dw["sTenKH"].ToString();
            lbTenNV.Text = dw["sTenNV"].ToString();
            lbTongGia.Text = dw["fTongTien"].ToString();
        }

        private void dgvSanPham_Mua_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
