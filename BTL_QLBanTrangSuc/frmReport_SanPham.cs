using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

using System.Data.SqlClient;
using System.Configuration;

namespace BTL_QLBanTrangSuc
{
    public partial class frmReport_SanPham : Form
    {
        string constr = "Data Source=ANPHATPC\\SQLEXPRESS;Initial Catalog=QuanLyBanTrangSuc;Integrated Security=True";

        private string maHD;
        private string tenND;
        public frmReport_SanPham(string ma,string ten)
        {
            InitializeComponent();
            maHD = ma;
            tenND = ten;
        }

       

        /*private void button1_Click(object sender, EventArgs e)
        {
            ReportDocument crtRpt = new ReportDocument();
            crtRpt.Load(@"C:\Users\Admin\source\repos\BTL_QLBanTrangSuc\BTL_QLBanTrangSuc\CrystalReport2.rpt");
            TableLogOnInfo logOn = new TableLogOnInfo();
            logOn.ConnectionInfo.ServerName = @"ADMIN\SQLEXPRESS";
            logOn.ConnectionInfo.DatabaseName = "QuanLyBanTrangSuc";
            logOn.ConnectionInfo.IntegratedSecurity = true;
            foreach(Table t in crtRpt.Database.Tables)
            {
                t.ApplyLogOnInfo(logOn);
            }

            ParameterFieldDefinition pfv = crtRpt.DataDefinition.ParameterFields["NguoiLap"];
            ParameterValues pv = new ParameterValues();
            ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            pdv.Value = txtNguoiLap.Text;
            pv.Add(pdv);
            pfv.CurrentValues.Clear();
            pfv.ApplyCurrentValues(pv);
            crtRpt.RecordSelectionFormula = "{vv_SanPham.iSoLuong} = 20";
            crystalReportViewer1.ReportSource = crtRpt;
            crystalReportViewer1.Refresh();
        }*/
        private void hienReportHDB()
        {
            SqlConnection conn = new SqlConnection(constr);
            SqlDataAdapter sqlAp = new SqlDataAdapter();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conn;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "spHoaDonBan_maHD";
            sqlCommand.Parameters.AddWithValue("@maHD", maHD);
            sqlAp.SelectCommand = sqlCommand;
            DataTable dt = new DataTable();
            sqlAp.Fill(dt);
            rpHoaDonBan crtRpt = new rpHoaDonBan();
            
            crtRpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = crtRpt;
            crystalReportViewer1.Refresh();
        }
        private void frmReport_SanPham_Load(object sender, EventArgs e)
        {
            hienReportHDB();
        }
    }
}
