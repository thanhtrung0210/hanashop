using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QuanLyBanTrangSuc
{
    public partial class frmQLHoaDonNhap : Form
    {
        public frmQLHoaDonNhap()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
                
        }

        private void dataGridView1hdn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string command = dataGridView1hdn.Columns[e.ColumnIndex].Name;
                if (command == "clXemCT")
                {
                   /* vitri = e.RowIndex;
                    DataTable dt = Lay_DataTable("vv_HoaDonBan");
                    DataRow row = dt.Rows[vitri];
                    frmCTHB_Ban form = new frmCTHB_Ban(row[0].ToString().Trim());
                    form.ShowDialog();*/
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
