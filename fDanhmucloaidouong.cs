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
    public partial class fDanhmucloaidouong : Form
    {
        QuanLyCafeEntities2 db = new QuanLyCafeEntities2();
        public fDanhmucloaidouong()
        {
            InitializeComponent();
        }

        private void fDanhmucloaidouong_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {

            var dsLoaiDoUong = db.LoaiDoUongs
                .Select(nv => new
                {
                    nv.MaLoai,
                    nv.TenLoai,
                })
                .ToList();

            dtgvTypeDrink.DataSource = dsLoaiDoUong;


            // Có thể ẩn cột nếu muốn
            // dtgvNhanVien.Columns["MatKhau"].Visible = false;
        }


        private void dtgvTypeDrink_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dtgvTypeDrink.Rows[e.RowIndex].Cells.Count > 0)
            {
                DataGridViewRow row = dtgvTypeDrink.Rows[e.RowIndex];

                txtIDTypeDrink.Text = row.Cells["MaLoai"]?.Value?.ToString() ?? string.Empty;
                txtTypeName.Text = row.Cells["TenLoai"]?.Value?.ToString() ?? string.Empty;
            }
        }

        private void dtgvTypeDrink_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTypeName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên loại đồ uống.");
                return;
            }

            int maxMaLoai = db.LoaiDoUongs.Any() ? db.LoaiDoUongs.Max(l => l.MaLoai) : 0;
            var newLoai = new LoaiDoUong
            {
                MaLoai = maxMaLoai + 1,
                TenLoai = txtTypeName.Text.Trim()
            };

            db.LoaiDoUongs.Add(newLoai);
            db.SaveChanges();
            LoadData();
            MessageBox.Show("Thêm loại đồ uống thành công.");
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtIDTypeDrink.Text, out int maLoai))
            {
                MessageBox.Show("Mã loại không hợp lệ.");
                return;
            }

            var loai = db.LoaiDoUongs.FirstOrDefault(l => l.MaLoai == maLoai);
            if (loai == null)
            {
                MessageBox.Show("Không tìm thấy loại đồ uống.");
                return;
            }

            loai.TenLoai = txtTypeName.Text.Trim();
            db.SaveChanges();
            LoadData();
            MessageBox.Show("Sửa thông tin loại đồ uống thành công.");
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtIDTypeDrink.Text, out int maLoai))
            {
                MessageBox.Show("Mã loại không hợp lệ.");
                return;
            }

            var loai = db.LoaiDoUongs.FirstOrDefault(l => l.MaLoai == maLoai);
            if (loai == null)
            {
                MessageBox.Show("Không tìm thấy loại đồ uống để xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa loại đồ uống này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                db.LoaiDoUongs.Remove(loai);
                db.SaveChanges();
                LoadData();
                MessageBox.Show("Đã xóa loại đồ uống.");
            }
        }

        private void xóaTrắngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtIDTypeDrink.Clear();
            txtTypeName.Clear();
        }

        private void btSearchNameDrink_Click(object sender, EventArgs e)
        {
            string keyword = txbSearchNameDrink.Text.Trim().ToLower();

            var result = db.LoaiDoUongs
                .Where(l => l.TenLoai.ToLower().Contains(keyword))
                .Select(l => new
                {
                    l.MaLoai,
                    l.TenLoai
                })
                .ToList();

            if (result.Count == 0)
            {
                MessageBox.Show("Không tìm thấy loại đồ uống nào.");
                dtgvTypeDrink.DataSource = null; // hoặc LoadData() nếu muốn load lại
                return;
            }

            dtgvTypeDrink.DataSource = result;
        }
    }
}
