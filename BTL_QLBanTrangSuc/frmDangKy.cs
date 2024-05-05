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
    public partial class frmDangKy : Form
    {
        public frmDangKy()
        {
            InitializeComponent();
        }
        string constr = "Data Source=ANPHATPC\\SQLEXPRESS;Initial Catalog=QuanLyBanTrangSuc;Integrated Security=True";
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (!checkMaNVandTenNV())
            {
                MessageBox.Show("Mã nhân viên hoặc tên nhân viên của bạn không hợp lệ!");
            }
            else if (checkDuplicatePrimarykey())
            {
                MessageBox.Show("Người này đã có tài khoản rồi! Vui lòng truy cập chức năng quên mật khẩu!");
            }
            else if (checkPassword())
            {
                using (SqlConnection cnn = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = cnn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "prc_singUp";
                        cmd.Parameters.AddWithValue("@sMaNV", txtMaNhanVien.Text);
                        cmd.Parameters.AddWithValue("@sMatKhau", txtPassword.Text);
                        cnn.Open();
                        int i= cmd.ExecuteNonQuery();
                        cnn.Close();
                        if (i > 0)
                        {
                            MessageBox.Show("Đăng ký thành công");
                            frmDangNhap formLogin = new frmDangNhap();
                            this.Visible = false;
                            formLogin.Show();
                        }
                    }
                }
            }
        }
        private bool checkMaNVandTenNV()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                SqlDataAdapter da = new SqlDataAdapter($"select * from tblNhanVien where sMaNV = '{txtMaNhanVien.Text}' and sTenNV=N'{txtTenNhanVien.Text}'", cnn);
                DataTable tblNhanVien = new DataTable();
                da.Fill(tblNhanVien);
                if (tblNhanVien.Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
        }
        private bool checkPassword()
        {
            if (txtPassword.Text == "")
            {
                errorProviderSignUp.SetError(txtPassword, "Bạn chưa nhập mật khẩu!");
                return false;
            }
            else if (txtConfirmPassword.Text != txtPassword.Text)
            {
                errorProviderSignUp.SetError(txtPassword, "");
                errorProviderSignUp.SetError(txtConfirmPassword, "Mật khẩu nhập lại không khớp!");
                return false;
            }
            return true;

        }
        private bool checkDuplicatePrimarykey()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                SqlDataAdapter da = new SqlDataAdapter($"select * from tblTaiKhoan where sMaNV = '{txtMaNhanVien.Text}'", cnn);
                DataTable tblTaiKhoan = new DataTable();
                da.Fill(tblTaiKhoan);
                if (tblTaiKhoan.Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDangNhap formLogin = new frmDangNhap();
            this.Visible = false;
            formLogin.ShowDialog();
            this.Close();
        }
    }
}
