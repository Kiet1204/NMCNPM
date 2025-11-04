using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JazzCoffe
{
    public partial class fNhanVien : Form
    {
        QuanLyCafeEntities2 db = new QuanLyCafeEntities2();
        public fNhanVien()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lbSearchName_Click(object sender, EventArgs e)
        {

        }

        private void fNhanVien_Load(object sender, EventArgs e)
        {
            cbChucVu.Items.Add("Quản trị viên");
            cbChucVu.Items.Add("Nhân viên");
            cbChucVu.SelectedIndex = 0; // chọn mặc định
            LoadData();
        }

        private void LoadData()
        {
            
                var dsNhanVien = db.NhanViens
                    .Select(nv => new
                    {
                        nv.MaNV,
                        nv.TenNV,
                        nv.MatKhau,
                        nv.SDT,
                        nv.Quyen,
                        nv.LuongCoBanTheoGio,
                    })
                    .ToList();

                dtgvNhanVien.DataSource = dsNhanVien;
            dtgvNhanVien.Columns["LuongCoBanTheoGio"].DefaultCellStyle.Format = "#,##0 VNĐ";
            dtgvNhanVien.Columns["LuongCoBanTheoGio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;




            // Có thể ẩn cột nếu muốn
            // dtgvNhanVien.Columns["MatKhau"].Visible = false;
        }


        private void dtgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dtgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dtgvNhanVien.Rows[e.RowIndex].Cells.Count > 0)
            {
                DataGridViewRow row = dtgvNhanVien.Rows[e.RowIndex];

                txtMaNV.Text = row.Cells["MaNV"]?.Value?.ToString() ?? string.Empty;
                txtTenNV.Text = row.Cells["TenNV"]?.Value?.ToString() ?? string.Empty;
                txtNVPassword.Text = row.Cells["MatKhau"]?.Value?.ToString() ?? string.Empty;
                txtSDT.Text = row.Cells["SDT"]?.Value?.ToString() ?? string.Empty;
               
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("x2")); // chuyển mỗi byte sang dạng hex
                }
                return sb.ToString();
            }
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 🔹 Kiểm tra nhập liệu trước
            if (string.IsNullOrWhiteSpace(txtMaNV.Text) ||
                string.IsNullOrWhiteSpace(txtTenNV.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) ||
                string.IsNullOrWhiteSpace(cbChucVu.Text) ||
                string.IsNullOrWhiteSpace(txtLuongCoBan.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhân viên trước khi thêm!",
                                "Thiếu thông tin",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string maNV = txtMaNV.Text.Trim();
                string tenNV = txtTenNV.Text.Trim();
                string sdt = txtSDT.Text.Trim();
                string quyen = cbChucVu.Text;
                decimal luong = 0;

                // 🔹 Kiểm tra lương có hợp lệ không
                if (!decimal.TryParse(txtLuongCoBan.Text, out luong) || luong <= 0)
                {
                    MessageBox.Show("Vui lòng nhập lương hợp lệ (số dương)!",
                                    "Giá trị không hợp lệ",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // 🔹 Mã hóa mật khẩu mặc định là "123"
                string matKhauMaHoa = HashPassword("123");

                // 🔹 Tạo đối tượng nhân viên mới
                NhanVien nv = new NhanVien()
                {
                    MaNV = maNV,
                    TenNV = tenNV,
                    MatKhau = matKhauMaHoa,
                    SDT = sdt,
                    Quyen = quyen,
                    LuongCoBanTheoGio = luong
                };

                // 🔹 Thêm vào DB
                db.NhanViens.Add(nv);
                db.SaveChanges();

                LoadData();
                MessageBox.Show("Thêm nhân viên thành công!\nMật khẩu mặc định là 123 (đã mã hóa).",
                                "Thành công",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message,
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }


        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();

            // Kiểm tra nhập thiếu
            if (string.IsNullOrWhiteSpace(txtMaNV.Text) ||
                string.IsNullOrWhiteSpace(txtTenNV.Text) ||
                string.IsNullOrWhiteSpace(txtNVPassword.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) ||
                string.IsNullOrWhiteSpace(txtLuongCoBan.Text) ||
                string.IsNullOrWhiteSpace(cbChucVu.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin để sửa.");
                return;
            }

            // Kiểm tra lương hợp lệ
            if (!decimal.TryParse(txtLuongCoBan.Text, out decimal luongCoBan))
            {
                MessageBox.Show("Lương cơ bản phải là số hợp lệ.");
                return;
            }

            // Tìm nhân viên cần sửa
            var nv = db.NhanViens.FirstOrDefault(n => n.MaNV == maNV);
            if (nv == null)
            {
                MessageBox.Show("Không tìm thấy nhân viên để sửa.");
                return;
            }

            // Cập nhật thông tin
            nv.TenNV = txtTenNV.Text.Trim();
            nv.MatKhau = txtNVPassword.Text.Trim();
            nv.SDT = txtSDT.Text.Trim();
            nv.Quyen = cbChucVu.Text;
            nv.LuongCoBanTheoGio = luongCoBan;

            try
            {
                db.SaveChanges();
                LoadData();
                MessageBox.Show("Đã sửa thông tin nhân viên thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.InnerException?.InnerException?.Message);
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();

            // Kiểm tra có nhập mã chưa
            if (string.IsNullOrWhiteSpace(maNV))
            {
                MessageBox.Show("Vui lòng nhập hoặc chọn mã nhân viên cần xóa.");
                return;
            }

            // Tìm nhân viên cần xóa
            var nv = db.NhanViens.FirstOrDefault(n => n.MaNV == maNV);
            if (nv == null)
            {
                MessageBox.Show("Không tìm thấy nhân viên để xóa.");
                return;
            }

            // Xác nhận xóa
            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa nhân viên '{nv.TenNV}' không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            try
            {
                db.NhanViens.Remove(nv);
                db.SaveChanges();
                LoadData();

                MessageBox.Show("Đã xóa nhân viên thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa nhân viên này. Có thể nhân viên đang được tham chiếu ở bảng khác.\n\nChi tiết lỗi: "
                    + ex.InnerException?.InnerException?.Message);
            }
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Xóa nội dung các ô nhập
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtNVPassword.Clear();
            txtSDT.Clear();
            txtLuongCoBan.Clear();
            txtSearchNameNV.Clear();

            // Tải lại toàn bộ dữ liệu
            LoadData();

            // Đưa con trỏ về ô đầu tiên
            txtTenNV.Focus();
        }

        private void btSearchNameNV_Click(object sender, EventArgs e)
        {
            string keyword = txtSearchNameNV.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên cần tìm.");
                return;
            }

            // Lọc danh sách nhân viên theo tên
            var result = db.NhanViens
                .Where(nv => nv.TenNV.ToLower().Contains(keyword))
                .Select(nv => new
                {
                    nv.MaNV,
                    nv.TenNV,
                    nv.MatKhau,
                    nv.SDT,
                    nv.LuongCoBanTheoGio,
                    nv.Quyen
                })
                .ToList();

            // Gán kết quả vào DataGridView
            dtgvNhanVien.DataSource = result;

            // Nếu không tìm thấy kết quả
            if (result.Count == 0)
            {
                MessageBox.Show("Không tìm thấy nhân viên nào phù hợp với từ khóa đã nhập.");
            }
        }

    }
}

