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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Configuration;

namespace BTL_QLBanTrangSuc
{
    public partial class frmReportDanhThu : Form
    {
        string constr = "Data Source=ANPHATPC\\SQLEXPRESS;Initial Catalog=QuanLyBanTrangSuc;Integrated Security=True";

        public frmReportDanhThu()
        {
            InitializeComponent();
        }

        private void hienReportHDB(DateTime tgBatDau,DateTime tgKetThuc)
        {
            SqlConnection conn = new SqlConnection(constr);
            SqlDataAdapter sqlAp = new SqlDataAdapter();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conn;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "prHoaDonBan_ThoiGian";
            sqlCommand.Parameters.AddWithValue("@thoiGianBD", tgBatDau);
            sqlCommand.Parameters.AddWithValue("@thoiGianKT", tgKetThuc);
            sqlAp.SelectCommand = sqlCommand;
            DataTable dt = new DataTable();
            sqlAp.Fill(dt);
            rpHoaDonBanDanhThu crtRpt = new rpHoaDonBanDanhThu();

            crtRpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = crtRpt;
            crystalReportViewer1.Refresh();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnHien_Click(object sender, EventArgs e)
        {
            DateTime tgBatDau = dtpThoiGianBD.Value.Date;
            DateTime tgKetThuc = dtpThoiGianKT.Value;
            MessageBox.Show(tgBatDau.ToString());
            if(tgBatDau<= tgKetThuc)
            {
                hienReportHDB(tgBatDau, tgKetThuc);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thời gian hợp lý");
            }
            
        }

        private void frmReportDanhThu_Load(object sender, EventArgs e)
        {
            hienReportHDB(DateTime.Parse("1/1/2023"),DateTime.Now);
        }

    }
}
