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
    public partial class frmQLNhanVien : Form
    {
        //       string constr = ConfigurationManager.ConnectionStrings["db_BanTrangSuc"].ConnectionString;
        string constr = "Data Source=ANPHATPC\\SQLEXPRESS;Initial Catalog=QuanLyBanTrangSuc;Integrated Security=True";

        static Panel Main_Panel;
        public frmQLNhanVien(Panel main_Panel)
        {
            InitializeComponent();
            Main_Panel = main_Panel;
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormManagementEmployee_Load(object sender, EventArgs e)
        {
            getDataEmployee();
        }
        private void getDataEmployee()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(@"select sMaNV, sTenNV, sDiaChi, sSDT, dNgayVaoLam, case tblNhanVien.bVaiTro when 1 then 'Admin' when 0 then N'Nhân viên' end as 'sVaitro', case tblNhanVien.bTinhTrang when 1 then N'Hoạt động' when 0 then N'Ngưng hoạt động' end as 'sTinhTrang' FROM tblNhanVien where bTTXoa=0", cnn))
                {
                    DataTable tblNhanVien = new DataTable();
                    da.Fill(tblNhanVien);
                    dgvNhanVien.DataSource = tblNhanVien;
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (insert_NV())
            {
                MessageBox.Show("Thêm nhân viên thành công!");
                getDataEmployee();
                dgvNhanVien.Refresh();
                txtFullName.Text = "";
                txtMaNV.Text = "";

            }
        }
        private int checkRole()
        {
            RadioButton rad=null;
            foreach (RadioButton item in panelRole.Controls)
            {

                if (item != null)
                {
                    if (item.Checked)
                    {
                        rad = item;
                        break;
                    }
                }
            }
            if(rad.Text=="Nhân viên")
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        private int checkStatus()
        {
            RadioButton rad = null;
            foreach (RadioButton item in panelStatus.Controls)
            {

                if (item != null)
                {
                    if (item.Checked)
                    {
                        rad = item;
                        break;
                    }
                }
            }
            if (rad.Text == "Hoạt động")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        private bool insert_NV()
        {
            
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "intern_NV";
                    cmd.Parameters.AddWithValue("@sMaNV", txtMaNV.Text);
                    cmd.Parameters.AddWithValue("@sTenNV", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@sDiaChi", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@sSDT", txtSDT.Text);
                    cmd.Parameters.AddWithValue("@bVaiTro",checkRole() );
                    cmd.Parameters.AddWithValue("@bTinhTrang", checkStatus());
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    return i > 0;
                }
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Text = dgvNhanVien.CurrentRow.Cells[0].Value.ToString();
            txtFullName.Text = dgvNhanVien.CurrentRow.Cells[1].Value.ToString();
            txtAddress.Text = dgvNhanVien.CurrentRow.Cells[2].Value.ToString();
            txtSDT.Text = dgvNhanVien.CurrentRow.Cells[3].Value.ToString();
            txtMaNV.Enabled = false;
            btnAdd.Enabled = false;
            if (dgvNhanVien.CurrentRow.Cells[5].Value.ToString()=="Admin")
            {
                RBAdmin.Checked = true;
                RBNhanVien.Checked = false;
            }
            if(dgvNhanVien.CurrentRow.Cells[5].Value.ToString() == "Nhân viên")
            {
                RBAdmin.Checked = false;
                RBNhanVien.Checked = true;
            }
            if (dgvNhanVien.CurrentRow.Cells[6].Value.ToString() == "Hoạt động")
            {
                RBWork.Checked = true;
                RBStopWork.Checked = false;
            }
            if(dgvNhanVien.CurrentRow.Cells[6].Value.ToString() == "Ngưng hoạt động")
            {
                RBWork.Checked = false;
                RBStopWork.Checked = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (update_NV())
            {
                MessageBox.Show("Đã cập nhật thông tin nhân viên!");
                getDataEmployee();
                dgvNhanVien.Refresh();
            }
        }
        private bool update_NV()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "update_NV";
                    cmd.Parameters.AddWithValue("@sMaNV", txtMaNV.Text);
                    cmd.Parameters.AddWithValue("@sTenNV", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@sDiaChi", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@sSDT", txtSDT.Text);
                    cmd.Parameters.AddWithValue("@bVaiTro", checkRole());
                    cmd.Parameters.AddWithValue("@bTinhTrang", checkStatus());
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    return i > 0;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = "";
            txtFullName.Text = "";
            txtAddress.Text = "";
            txtSDT.Text = "";
            txtMaNV.Enabled = true;
            btnAdd.Enabled = true;
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            //txtSearch.Text = "";
        }

        /*private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                SqlDataAdapter da = new SqlDataAdapter($"select sMaNV, sTenNV, sDiaChi, sSDT, dNgayVaoLam, case tblNhanVien.bVaiTro when 1 then 'Admin' when 0 then N'Nhân viên' end as 'sVaitro', case tblNhanVien.bTinhTrang when 1 then N'Hoạt động' when 0 then N'Ngưng hoạt động' end as 'sTinhTrang' FROM tblNhanVien where sTenNV like '%{txtSearch.Text}%' and bTTXoa=0", cnn);
                DataTable tblNhanVien = new DataTable();
                da.Fill(tblNhanVien);
                dgvNhanVien.DataSource = tblNhanVien;
            }
        }*/

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc muốn xoá nhân viên này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                delete_NV();
                getDataEmployee();
                dgvNhanVien.Refresh();
            }
            else
            {

            }
        }
        private bool delete_NV()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "delete_NV";
                    cmd.Parameters.AddWithValue("@sMaNV", txtMaNV.Text);
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    return i > 0;
                }
            }
        }
    }
}
