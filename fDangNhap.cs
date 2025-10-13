using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JazzCoffe
{
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();
            this.AcceptButton = btDangNhap;
        }

        

        private void FLogin_Load_1(object sender, EventArgs e)
        {
            cboChucVu.Items.Add("Quản trị viên");
            cboChucVu.Items.Add("Nhân viên");
            cboChucVu.SelectedIndex = 0; // chọn mặc định
        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTaiKhoan.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            string chucVu = cboChucVu.Text.Trim();

            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                MessageBox.Show("Vui lòng tắt Caps Lock để đăng nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(taiKhoan) || string.IsNullOrEmpty(matKhau) || string.IsNullOrEmpty(chucVu))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tài khoản, Mật khẩu và Chức vụ.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var context = new QuanLyCafeEntities2())
            {
                var user = context.NhanViens.FirstOrDefault(nv =>
                    nv.MaNV == taiKhoan &&
                    nv.MatKhau == matKhau &&
                    nv.Quyen == chucVu);

                if (user != null)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Ẩn form đăng nhập
                    this.Hide();

                    // Mở form chính và TRUYỀN MaNV + MatKhau
                    TableManeger mainForm = new TableManeger(user.MaNV, user.MatKhau, user.Quyen);
                    mainForm.ShowDialog();

                    // Sau khi đóng TableManeger, quay lại đăng nhập
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản, mật khẩu hoặc chức vụ.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool IsValidLogin(string username, string password)
        {
            return username == "admin" && password == "123"; // Kiểm tra đơn giản
                                                             // Hoặc gọi đến CSDL / DAO để kiểm tra tài khoản thực tế
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát khỏi chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
           
        }
    }
}
