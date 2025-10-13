using System;
using System.Linq;
using System.Windows.Forms;

namespace JazzCoffe
{
    public partial class fDoiMatKhau : Form
    {
        private string maNhanVienHienTai;
        private string matKhauHienTai;
        public fDoiMatKhau(string maNV, string matKhauDangNhap)
        {
            InitializeComponent();
            this.maNhanVienHienTai = maNV;
            this.matKhauHienTai = matKhauDangNhap;
            txtMaNV.Text = maNV;
            txtMaNV.Enabled = false;
        }

        private void btChangePassword_Click(object sender, EventArgs e)
        {
            string oldPass = txtOldPassword.Text.Trim();
            string newPass = txtNewPassword.Text.Trim();
            string confirmPass = txtConfirmPassword.Text.Trim();

            if (string.IsNullOrEmpty(oldPass) || string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(confirmPass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // So sánh mật khẩu cũ nhập vào với mật khẩu hiện tại từ lần đăng nhập
            if (oldPass != matKhauHienTai)
            {
                MessageBox.Show("Mật khẩu cũ không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPass != confirmPass)
            {
                MessageBox.Show("Mật khẩu mới không khớp nhau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var db = new QuanLyCafeEntities2())
            {
                var nhanVien = db.NhanViens.FirstOrDefault(nv => nv.MaNV == maNhanVienHienTai);

                if (nhanVien != null)
                {
                    nhanVien.MatKhau = newPass;
                    db.SaveChanges();

                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnChangePasswordExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fDoiMatKhau_Load(object sender, EventArgs e)
        {

        }
    }
}
