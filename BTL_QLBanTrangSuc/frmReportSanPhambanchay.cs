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


namespace BTL_QLBanTrangSuc
{
    public partial class frmReportSanPhambanchay : Form
    {
        string constr = "Data Source=ANPHATPC\\SQLEXPRESS;Initial Catalog=QuanLyBanTrangSuc;Integrated Security=True";

        public frmReportSanPhambanchay()
        {
            InitializeComponent();
        }

        private void frmReportSanPhambanchay_Load(object sender, EventArgs e)
        {
            hienReport();
        }
        private void hienReport()
        {
            SqlConnection conn = new SqlConnection(constr);
            SqlDataAdapter sqlAp = new SqlDataAdapter();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conn;
            sqlCommand.CommandText = "select * from vv_sanphambanchay";
            sqlAp.SelectCommand = sqlCommand;
            DataTable dt = new DataTable();
            sqlAp.Fill(dt);
            crpSanphambanchay crtRpt = new crpSanphambanchay();

            crtRpt.SetDataSource(dt);
            crystalReportView.ReportSource = crtRpt;
            crystalReportView.Refresh();
        }
    }
}
