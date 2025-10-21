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
    public partial class fDanhmucdouong : Form
    {
        QuanLyCafeEntities2 db = new QuanLyCafeEntities2();
        public fDanhmucdouong()
        {
            InitializeComponent();
        }

        private void fDanhmucdouong_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var dsDoUong = (from du in db.DoUongs
                            join loai in db.LoaiDoUongs
                            on du.MaLoai equals loai.MaLoai
                            select new
                            {
                                du.MaDU,
                                du.TenDU,
                                TenLoai = loai.TenLoai,
                                du.DonGia
                            }).ToList();

            dtgvDoUong.DataSource = dsDoUong;

            // 🔹 Format VNĐ
            if (dtgvDoUong.Columns["DonGia"] != null)
            {
                dtgvDoUong.Columns["DonGia"].DefaultCellStyle.Format = "#,##0 'VNĐ'";
            }
        }
        private void dtgvTypeDrink_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvDoUong.Rows[e.RowIndex];
                txtMaDU.Text = row.Cells["MaDU"]?.Value?.ToString();
                txtTenDU.Text = row.Cells["TenDU"]?.Value?.ToString();
                txtMaLDU.Text = row.Cells["TenLoai"]?.Value?.ToString();
                txtDonGia.Text = row.Cells["DonGia"]?.Value?.ToString()?.Replace("VNĐ", "").Trim();
            }
        }

        private void ClearTextBoxes()
        {
            txtMaDU.Clear();
            txtTenDU.Clear();
            txtMaLDU.Clear();
            txtDonGia.Clear();
        }

        private void dtgvDoUong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private string GenerateNewMaDU()
        {
            string lastMaDU = db.DoUongs
                .OrderByDescending(d => d.MaDU)
                .Select(d => d.MaDU)
                .FirstOrDefault();

            if (string.IsNullOrEmpty(lastMaDU))
                return "DU001";

            int number = int.Parse(lastMaDU.Substring(2)) + 1;
            return "DU" + number.ToString("D3");
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenDU.Text) ||
                    string.IsNullOrWhiteSpace(txtMaLDU.Text) ||
                    string.IsNullOrWhiteSpace(txtDonGia.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔹 Lấy mã loại theo tên loại
                var maLoai = db.LoaiDoUongs
                    .Where(l => l.TenLoai == txtMaLDU.Text.Trim())
                    .Select(l => l.MaLoai)
                    .FirstOrDefault();

                if (maLoai == 0)
                {
                    MessageBox.Show("Loại đồ uống không tồn tại trong danh mục LoaiDoUong!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 🔹 Tạo mã đồ uống mới
                string newMaDU = GenerateNewMaDU();

                // 🔹 Tạo đối tượng
                DoUong douong = new DoUong
                {
                    MaDU = newMaDU,
                    TenDU = txtTenDU.Text.Trim(),
                    MaLoai = maLoai,
                    DonGia = decimal.Parse(txtDonGia.Text.Trim())
                };

                db.DoUongs.Add(douong);
                db.SaveChanges();

                LoadData();
                ClearTextBoxes();
                MessageBox.Show("✅ Thêm đồ uống thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                // Xem chi tiết lỗi trong Output
                foreach (var eve in ex.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine($"Thuộc tính: {ve.PropertyName} - Lỗi: {ve.ErrorMessage}");
                    }
                }
                MessageBox.Show("Lỗi khi thêm đồ uống. Kiểm tra Output để xem chi tiết.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm đồ uống:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaDU.Text))
            {
                MessageBox.Show("Vui lòng chọn đồ uống cần sửa.");
                return;
            }

            var douong = db.DoUongs.FirstOrDefault(d => d.MaDU == txtMaDU.Text.Trim());
            if (douong != null)
            {
                var maLoai = db.LoaiDoUongs
                    .Where(l => l.TenLoai == txtMaLDU.Text.Trim())
                    .Select(l => l.MaLoai)
                    .FirstOrDefault();

                if (maLoai == 0)
                {
                    MessageBox.Show("Loại đồ uống không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                douong.TenDU = txtTenDU.Text.Trim();
                douong.MaLoai = maLoai;
                douong.DonGia = decimal.Parse(txtDonGia.Text.Trim());

                db.SaveChanges();
                LoadData();
                ClearTextBoxes();
                MessageBox.Show("✅ Cập nhật thành công!");
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaDU.Text))
            {
                MessageBox.Show("Vui lòng chọn đồ uống cần xóa.");
                return;
            }

            string maDU = txtMaDU.Text.Trim();
            var douong = db.DoUongs.FirstOrDefault(d => d.MaDU == maDU);

            if (douong != null)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa đồ uống này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.DoUongs.Remove(douong);
                    db.SaveChanges();
                    LoadData();
                    ClearTextBoxes();
                    MessageBox.Show("✅ Xóa thành công.");
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy đồ uống để xóa.");
            }
        }

       

        private void xóaTrắngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void btSearchNameDrink_Click(object sender, EventArgs e)
        {
            string keyword = txbSearchNameDrink.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show("Vui lòng nhập tên đồ uống cần tìm.");
                return;
            }

            var result = (from du in db.DoUongs
                          join loai in db.LoaiDoUongs
                          on du.MaLoai equals loai.MaLoai
                          where du.TenDU.ToLower().Contains(keyword)
                          select new
                          {
                              du.MaDU,
                              du.TenDU,
                              TenLoai = loai.TenLoai,
                              du.DonGia
                          }).ToList();

            if (result.Count == 0)
            {
                MessageBox.Show("Không tìm thấy đồ uống nào phù hợp!");
            }

            dtgvDoUong.DataSource = result;
        }
    }
}
