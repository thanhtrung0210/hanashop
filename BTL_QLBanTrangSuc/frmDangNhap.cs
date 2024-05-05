using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
namespace BTL_QLBanTrangSuc
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        string constr = "Data Source=ADMIN\\SQLEXPRESS;Initial Catalog=QuanLyBanTrangSuc;Integrated Security=True";

        private void linkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDangKy formSingUp = new frmDangKy();
            this.Visible = false;
            formSingUp.ShowDialog();
        }
        private bool checkNullInput()
        {
            if (txtUserName.Text == "")
            {
                errorProviderCheckLogin.SetError(txtUserName, "Bạn chưa nhập tên đăng nhập");
                txtUserName.Focus();
                return false;
            }
            else if (txtPassword.Text == "")
            {
                errorProviderCheckLogin.SetError(txtPassword, "Bạn chưa nhập mật khẩu");
                txtPassword.Focus();
                return false;
            }
            errorProviderCheckLogin.SetError(txtPassword, "");
            errorProviderCheckLogin.SetError(txtUserName, "");
            return true;
        }
        private bool checkEmployeeHaveExists()
        {
            using(SqlConnection cnn = new SqlConnection(constr))
            {
                SqlDataAdapter da = new SqlDataAdapter($"select * from tblNhanVien where sMaNV='{txtUserName.Text}' and bTTXoa=0", cnn);
                DataTable tblNhanVien = new DataTable();
                da.Fill(tblNhanVien);
                if (tblNhanVien.Rows.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!checkEmployeeHaveExists())
            {
                MessageBox.Show("Nhân viên này đã bị vô hiệu hoá!");
                return;
            }
            if (checkNullInput())
            {
                using (SqlConnection cnn = new SqlConnection(constr))
                {
                    SqlDataAdapter da = new SqlDataAdapter($"select * from tblTaiKhoan inner join tblNhanVien on tblTaiKhoan.sMaNV = tblNhanVien.sMaNV where tblTaiKhoan.sMaNV = '{txtUserName.Text}' and tblTaiKhoan.sMatKhau = '{txtPassword.Text}' and tblNhanVien.bttXoa=0", cnn);
                    DataTable tblTaiKhoan = new DataTable();
                    da.Fill(tblTaiKhoan);
                    if (tblTaiKhoan.Rows.Count > 0)
                    {
                        
                        frmHome formHome = new frmHome(tblTaiKhoan.Rows[0].Field<string>("sTenNV"), tblTaiKhoan.Rows[0].Field<string>("sMaNV"), bool.Parse( tblTaiKhoan.Rows[0]["bVaiTro"].ToString()));
                        this.Visible = false;
                        formHome.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Mã nhân viên hoặc mật khẩu không chính xác!");
                    }
                }
            }           
        }
    }
}
