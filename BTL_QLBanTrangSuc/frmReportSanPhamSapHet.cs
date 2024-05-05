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
    public partial class frmReportSanPhamSapHet : Form
    {
        string constr = "Data Source=ANPHATPC\\SQLEXPRESS;Initial Catalog=QuanLyBanTrangSuc;Integrated Security=True";

        public frmReportSanPhamSapHet()
        {
            InitializeComponent();
        }
        private void hienReportSP(int slBatDau, int slKetThuc)
        {
            SqlConnection conn = new SqlConnection(constr);
            SqlDataAdapter sqlAp = new SqlDataAdapter();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conn;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "prSanPham_SoLuongconlai";
            sqlCommand.Parameters.AddWithValue("@soLuongBD", slBatDau);
            sqlCommand.Parameters.AddWithValue("@soLuongKT", slKetThuc);
            sqlAp.SelectCommand = sqlCommand;
            DataTable dt = new DataTable();
            sqlAp.Fill(dt);
            rpSanPham crtRpt = new rpSanPham();

            crtRpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = crtRpt;
            crystalReportViewer1.Refresh();
        }
        private void frmReportSanPhamSapHet_Load(object sender, EventArgs e)
        {
            hienReportSP(0, 8);
        }
    }
}
