using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QLBanTrangSuc
{
    public partial class frmHome : Form
    {
        private string tenNguoiDung;
        private string maNguoiDung;
        private bool vaiTro;
        public frmHome(string ten,string ma,bool vaitro)
        {
            tenNguoiDung = ten;
            maNguoiDung = ma;
            vaiTro = vaitro;
            InitializeComponent();
            datSubMenu();
            lbTenNguoi.Text = "Tên: " + tenNguoiDung;
        }

        // Thiết lập menu
        private void datSubMenu()
        {
            pnHoaDonMenu.Visible = false;
            pnSanPhamMenu.Visible = false;
            pnBaoCaoMenu.Visible = false;
            
            if (!vaiTro)
            {
                btnNhanvien.Visible = false;
                pnHoaDonMenu.Height = 30;
                btnHoaDonNhap.Visible = false;
                btnBaoCao.Visible = false;
            }
        }

        private void anSubMenu()
        {
            if(pnHoaDonMenu.Visible== true)
            {
                pnHoaDonMenu.Visible = false;
            }
            if (pnSanPhamMenu.Visible == true)
            {
                pnSanPhamMenu.Visible = false;
            }
            if (pnBaoCaoMenu.Visible == true)
            {
                pnBaoCaoMenu.Visible = false;
            }
        }

        private void hienSubMenu(Panel sulPanel)
        {
            if(sulPanel.Visible == false)
            {
                anSubMenu();
                sulPanel.Visible = true;
            }
            else
                sulPanel.Visible= false;
        }

        private Form activeForm;
        private void moChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            pnChildFrom.Controls.Clear();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnChildFrom.Controls.Add(childForm);
            pnChildFrom.Tag = childForm;
            childForm.Show();
        }
        //
        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            hienSubMenu(pnHoaDonMenu);
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            hienSubMenu(pnSanPhamMenu);
        }

        private void btnHoaDonBan_Click(object sender, EventArgs e)
        {
            this.Width = 1000;
            this.Height = 540;
            frmHoaDonBan nhap=new frmHoaDonBan(pnChildFrom,tenNguoiDung,maNguoiDung);
            moChildForm(nhap);
            anSubMenu();
        }


        //
        private void btnHoaDonNhap_Click(object sender, EventArgs e)
        {
            this.Width = 1000;
            this.Height = 540;
            frmHoaDonNhap nhap = new frmHoaDonNhap(pnChildFrom, tenNguoiDung, maNguoiDung);
            moChildForm(nhap);
            anSubMenu();
        }

        private void btnDSSanPham_Click(object sender, EventArgs e)
        {
            this.Width = 1180;
            this.Height = 600;
            frmQLSanPham nhap = new frmQLSanPham();
            moChildForm(nhap);
            anSubMenu();
        }

        private void btnLoaiSP_Click(object sender, EventArgs e)
        {
            this.Width = 900;
            this.Height = 500;
            frmQLLoaiSanPham nhap = new frmQLLoaiSanPham();
            moChildForm(nhap);
            anSubMenu();
        }

        private void btnNhaCC_Click(object sender, EventArgs e)
        {
            this.Width = 1000;
            this.Height = 540;
            frmQLNhaCungCap nhap = new frmQLNhaCungCap();
            moChildForm(nhap);
            anSubMenu();
        }

        

        private void btnTrangchu_Click(object sender, EventArgs e)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            this.Width = 1000;
            this.Height = 540;
            frmKhachHang nhap = new frmKhachHang();
            moChildForm(nhap);
            anSubMenu();
        }

        private void btnNhanvien_Click(object sender, EventArgs e)
        {
            this.Width = 1000;
            this.Height = 540;
            frmQLNhanVien nhap = new frmQLNhanVien(pnChildFrom);
            moChildForm(nhap);
            anSubMenu();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            frmDangNhap formLogin = new frmDangNhap();
            this.Visible = false;
            formLogin.ShowDialog();
            this.Close();
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            hienSubMenu(pnBaoCaoMenu);
        }
        private void btnBCHoaDonBan_Click(object sender, EventArgs e)
        {
            this.Width = 1050;
            this.Height = 580;
            frmReportDanhThu reportDanhThu = new frmReportDanhThu();
            moChildForm(reportDanhThu);
            anSubMenu();
        }
        private void btnBCSanPham_Click(object sender, EventArgs e)
        {
            this.Width = 1050;
            this.Height = 580;
            frmReportSanPhamSapHet reportSanPham = new frmReportSanPhamSapHet();
            moChildForm(reportSanPham);
            anSubMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Width = 1050;
            this.Height = 580;
            frmReportSanPhambanchay reportSanphambanchay = new frmReportSanPhambanchay();
            moChildForm(reportSanphambanchay);
            anSubMenu();
        }
    }
}
