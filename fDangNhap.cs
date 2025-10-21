using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

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

        // 🔹 Hàm mã hóa SHA256 mật khẩu
        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes) sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        // Kiểm tra chuỗi hex
        private bool IsHexString(string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            return s.All(c => Uri.IsHexDigit(c));
        }

        // Chuẩn hoá stored hash: remove 0x prefix và lower
        private string NormalizeStoredHash(string stored)
        {
            if (string.IsNullOrEmpty(stored)) return string.Empty;
            if (stored.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                stored = stored.Substring(2);
            return stored.ToLowerInvariant();
        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTaiKhoan.Text.Trim();
            string matKhauNhap = txtMatKhau.Text.Trim();
            string chucVu = cboChucVu.Text.Trim();

            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                MessageBox.Show("Vui lòng tắt Caps Lock để đăng nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(taiKhoan) || string.IsNullOrEmpty(matKhauNhap) || string.IsNullOrEmpty(chucVu))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tài khoản, Mật khẩu và Chức vụ.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hashedInput = ComputeSha256Hash(matKhauNhap);

            using (var context = new QuanLyCafeEntities2())
            {
                // Tìm user theo MaNV (và chức vụ nếu muốn)
                var user = context.NhanViens.FirstOrDefault(nv => nv.MaNV == taiKhoan && nv.Quyen.Trim() == chucVu.Trim());

                if (user == null)
                {
                    MessageBox.Show("Sai tài khoản hoặc chức vụ.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string stored = NormalizeStoredHash(user.MatKhau); // remove 0x, lowercase, handle null

                bool passwordOk = false;

                // Nếu stored có dạng SHA256 hex (64 hex chars)
                if (stored.Length == 64 && IsHexString(stored))
                {
                    passwordOk = string.Equals(stored, hashedInput, StringComparison.OrdinalIgnoreCase);
                }
                else
                {
                    // stored có thể là plaintext -> so sánh trực tiếp; nếu trùng thì nâng cấp lưu hash
                    if (stored == matKhauNhap)
                    {
                        passwordOk = true;
                        user.MatKhau = hashedInput; // nâng cấp lưu hash
                        context.SaveChanges();
                    }
                }

                if (passwordOk)
                {
                    // Lưu session/biến toàn cục
                    Program.MaNV_DangNhap = user.MaNV;
                    Program.Quyen_DangNhap = user.Quyen;
                    Program.MatKhau_DangNhap = user.MatKhau; // hash

                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    TableManeger mainForm = new TableManeger(user.MaNV, user.MatKhau, user.Quyen);
                    DialogResult dialogResult = mainForm.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Sai mật khẩu.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //MessageBox.Show($"Hash của mật khẩu bạn nhập là:\n{hashedInput}");
            }
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
            // Không cần xử lý gì thêm ở đây
        }

        private void cboChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
