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
            using (var context = new QuanLyCafeEntities2())
            {
                var dsDoUong = (from du in context.DoUongs
                                join loai in context.LoaiDoUongs
                                on du.MaLoai equals loai.MaLoai
                                select new
                                {
                                    du.MaDU,
                                    du.TenDU,
                                    TenLoai = loai.TenLoai,  // 🟢 Thay vì MaLoai
                                    du.DonGia
                                }).ToList();

                dtgvDoUong.DataSource = dsDoUong;

                //  Format cột DonGia (đảm bảo cột tồn tại mới format)
                if (dtgvDoUong.Columns["DonGia"] != null)
                {
                    //dtgvMenuQuanLyCaPhe.Columns["DonGia"].DefaultCellStyle.Format = "N0"; // số nguyên có dấu phẩy
                    dtgvDoUong.Columns["DonGia"].DefaultCellStyle.Format = "#,##0 'VNĐ'";                                                                     // hoặc nếu muốn có đơn vị:
                    // dtgvMenuQuanLyCaPhe.Columns["DonGia"].DefaultCellStyle.Format = "#,##0 'VNĐ'";
                }
            }
        }
        private void dtgvTypeDrink_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dtgvDoUong.Rows[e.RowIndex].Cells.Count > 0)
            {
                DataGridViewRow row = dtgvDoUong.Rows[e.RowIndex];

                txtMaDU.Text = row.Cells["MaDU"]?.Value?.ToString() ?? string.Empty;
                txtTenDU.Text = row.Cells["TenDU"]?.Value?.ToString() ?? string.Empty;
                txtMaLDU.Text = row.Cells["TenLoai"]?.Value?.ToString() ?? string.Empty;
                txtDonGia.Text = row.Cells["DonGia"]?.Value?.ToString() ?? string.Empty;

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

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDU.Text) ||
        string.IsNullOrWhiteSpace(txtMaLDU.Text) ||
        string.IsNullOrWhiteSpace(txtDonGia.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin.");
                return;
            }

            var douong = new DoUong
            {
                TenDU = txtTenDU.Text.Trim(),
                MaLoai = db.LoaiDoUongs
                          .Where(l => l.TenLoai == txtMaLDU.Text.Trim())
                          .Select(l => l.MaLoai).FirstOrDefault(),
                DonGia = decimal.Parse(txtDonGia.Text.Trim())
            };

            db.DoUongs.Add(douong);
            db.SaveChanges();
            LoadData();
            ClearTextBoxes();
            MessageBox.Show("Thêm thành công!");
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaDU.Text))
            {
                MessageBox.Show("Vui lòng chọn đồ uống cần sửa.");
                return;
            }

            string maDU = txtMaDU.Text;
            var douong = db.DoUongs.FirstOrDefault(d => d.MaDU == maDU);
            if (douong != null)
            {
                douong.TenDU = txtTenDU.Text.Trim();
                douong.MaLoai = db.LoaiDoUongs
                                  .Where(l => l.TenLoai == txtMaLDU.Text.Trim())
                                  .Select(l => l.MaLoai).FirstOrDefault();
                douong.DonGia = decimal.Parse(txtDonGia.Text.Trim());

                db.SaveChanges();
                LoadData();
                MessageBox.Show("Cập nhật thành công!");
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaDU.Text))
            {
                MessageBox.Show("Vui lòng chọn đồ uống cần xóa.");
                return;
            }

            string maDU = txtMaDU.Text;
            var douong = db.DoUongs.FirstOrDefault(d => d.MaDU == maDU);

            if (douong != null)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    db.DoUongs.Remove(douong);
                    db.SaveChanges();
                    LoadData();
                    MessageBox.Show("Đã xóa thành công.");
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
            string keyword = txtTenDU.Text.Trim().ToLower();

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
                MessageBox.Show("Không tìm thấy đồ uống nào.");
            }

            dtgvDoUong.DataSource = result;
        }
    }
}
