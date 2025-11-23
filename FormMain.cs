using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThuVien
{
    public partial class FormMain : Form
    {
        private string taiKhoan;

        public FormMain(string taiKhoan)
        {
            InitializeComponent();
            this.taiKhoan = taiKhoan;
        }

        // Sự kiện nút Quản lý Sách
        private void btnQuanLySach_Click(object sender, EventArgs e)
        {
            FormQuanLySach frm = new FormQuanLySach();
            frm.ShowDialog();
        }

        // Sự kiện nút Quản lý Độc giả
        private void btnQuanLyDocGia_Click(object sender, EventArgs e)
        {
            FormQuanLyDocGia frm = new FormQuanLyDocGia();
            frm.ShowDialog();
        }

        // Sự kiện nút Mượn Trả Sách
        private void btnMuonTraSach_Click(object sender, EventArgs e)
        {
            FormMuonTraSach frm = new FormMuonTraSach();
            frm.ShowDialog();
        }

        // Sự kiện nút Đổi mật khẩu
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            FormDoiMatKhau frm = new FormDoiMatKhau(taiKhoan);
            frm.ShowDialog();
        }

        // Sự kiện nút Đăng xuất
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn đăng xuất?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                FormDangNhap frmLogin = new FormDangNhap();
                frmLogin.ShowDialog();
                this.Close();
            }
        }

        // Sự kiện nút Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn thoát ứng dụng?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

    }
}
