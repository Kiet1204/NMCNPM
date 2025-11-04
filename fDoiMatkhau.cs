using System;
using System.Linq;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;

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
            string oldPass = txtMatKhauCu.Text.Trim();
            string newPass = txtMatKhauMoi.Text.Trim();
            string confirmPass = txtXacNhanMK.Text.Trim();

            if (string.IsNullOrEmpty(oldPass) || string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(confirmPass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // So sánh mật khẩu cũ nhập vào (đã mã hóa) với mật khẩu hiện tại
            string hashedOld = HashPassword(oldPass);
            if (hashedOld != matKhauHienTai)
            {
                MessageBox.Show("Mật khẩu cũ không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 🔹 Kiểm tra mật khẩu mới trùng với mật khẩu cũ
            string hashedNew = HashPassword(newPass);
            if (hashedNew == matKhauHienTai)
            {
                MessageBox.Show("Mật khẩu mới không được trùng với mật khẩu cũ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPass != confirmPass)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var db = new QuanLyCafeEntities2())
            {
                var nhanVien = db.NhanViens.FirstOrDefault(nv => nv.MaNV == maNhanVienHienTai);

                if (nhanVien != null)
                {
                    nhanVien.MatKhau = hashedNew; // 🔹 Đã mã hóa ở trên
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


        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
        private void btnChangePasswordExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtMaNV.Text = Program.MaNV_DangNhap;
            txtMaNV.ReadOnly = true;
        }
    }
}
