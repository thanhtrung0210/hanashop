using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Configuration;

namespace BTL_QLBanTrangSuc
{
    class clXuLyData
    {
        public string constr = "Data Source=ANPHATPC\\SQLEXPRESS;Initial Catalog=QuanLyBanTrangSuc;Integrated Security=True";
        public SqlConnection conn = new SqlConnection();
        public bool KT_ketNoi()
        {
            try
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                conn.ConnectionString = constr;
                conn.Open();
                return true;
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu!", "Thông báo");
                return false;
            }
        }

        public DataTable Lay_DataTable(string sTentbl)
        {
            string sqlCommand = "SELECT * FROM " + sTentbl;
            conn.ConnectionString = constr;
            SqlDataAdapter sqlAp = new SqlDataAdapter();
            sqlAp.SelectCommand = new SqlCommand(sqlCommand, conn);
            DataTable dt = new DataTable(sTentbl);
            sqlAp.Fill(dt);
            return dt;
        }
        public DataTable Lay_DataTable(string sqlCommand, string sTentbl)
        {
            conn.ConnectionString = constr;
            SqlDataAdapter sqlAp = new SqlDataAdapter();
            sqlAp.SelectCommand = new SqlCommand(sqlCommand, conn);
            DataTable dt = new DataTable(sTentbl);
            sqlAp.Fill(dt);
            return dt;
        }

        public void loadCbb(ComboBox cbb, string nameTable)
        {
            DataTable tb = Lay_DataTable(nameTable);
            cbb.DataSource = tb;
            cbb.DisplayMember = tb.Columns[1].ColumnName;
            cbb.ValueMember = tb.Columns[0].ColumnName;
        }
        public void loadCbb(ComboBox cbb, string tenBang,string tenCotHien,string tenCotLienKet)
        {
            DataTable tb = Lay_DataTable(tenBang);
            cbb.DataSource = tb;
            cbb.DisplayMember = tenCotHien;
            cbb.ValueMember = tenCotLienKet;
        }
        public void loadCbb(DataTable data,ComboBox cbb, string tenCotHien, string tenCotLienKet)
        {
            cbb.DataSource = data;
            cbb.DisplayMember = tenCotHien;
            cbb.ValueMember = tenCotLienKet;
        }

        public void loadCbb(DataTable data, ComboBox cbb)
        {
            cbb.DataSource = data;
            cbb.DisplayMember = data.Columns[1].ColumnName;
            cbb.ValueMember = data.Columns[0].ColumnName;
        }

        public bool ktDuLieu_VarCharTonTai(string tenBang,string tenCot,string duLieuKT)
        {
            string sqlString = $"SELECT * FROM {tenBang} WHERE {tenCot} = '{duLieuKT}'";
            DataTable dt=Lay_DataTable(sqlString, tenBang);
            if (dt.Rows.Count > 0) return true;
            else return false;
        }

        public bool ktDuLieu_NVarCharTonTai(string tenBang, string tenCot, string duLieuKT)
        {
            string sqlString = $"SELECT * FROM {tenBang} WHERE {tenCot} = N'{duLieuKT}'";
            DataTable dt = Lay_DataTable(sqlString, tenBang);
            if (dt.Rows.Count > 0) return true;
            else return false;
        }


    }
}
