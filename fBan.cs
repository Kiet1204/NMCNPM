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
    public partial class fBan : Form
    {
        QuanLyCafeEntities2 db = new QuanLyCafeEntities2();

        public fBan()
        {
            InitializeComponent();
        }
        private void fBan_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            using (var db = new QuanLyCafeEntities2()) // DbContext của bạn
            {
                var dsBan = db.Bans
                    .Select(ba => new
                    {
                        ba.MaBan,
                        ba.SucChua,
                        ba.TrangThai,

                    })
                    .ToList();

                dtgvBan.DataSource = dsBan;
            }

            // Có thể ẩn cột nếu muốn
            // dtgvNhanVien.Columns["MatKhau"].Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgvBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dtgvBan.Rows[e.RowIndex].Cells.Count > 0)
            {
                DataGridViewRow row = dtgvBan.Rows[e.RowIndex];

                txtMaBan.Text = row.Cells["MaBan"]?.Value?.ToString() ?? string.Empty;
                txtSucChua.Text = row.Cells["SucChua"]?.Value?.ToString() ?? string.Empty;
                

            }
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSucChua.Text))
            {
                MessageBox.Show("Vui lòng nhập sức chứa.");
                return;
            }

            int nextMaBan = 1;
            if (db.Bans.Any())
            {
                var last = db.Bans.OrderByDescending(b => b.MaBan).FirstOrDefault();
                nextMaBan = last.MaBan + 1;
            }

            Ban ban = new Ban
            {
                MaBan = nextMaBan,
                SucChua = int.Parse(txtSucChua.Text),
                TrangThai = "Trống"
            };

            db.Bans.Add(ban);
            db.SaveChanges();
            LoadData();
            MessageBox.Show("Thêm bàn thành công.");
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaBan.Text))
            {
                MessageBox.Show("Vui lòng chọn bàn cần sửa.");
                return;
            }

            int maBan = int.Parse(txtMaBan.Text);
            var ban = db.Bans.FirstOrDefault(b => b.MaBan == maBan);
            if (ban != null)
            {
                ban.SucChua = int.Parse(txtSucChua.Text);
                db.SaveChanges();
                LoadData();
                MessageBox.Show("Cập nhật thông tin bàn thành công.");
            }
            else
            {
                MessageBox.Show("Không tìm thấy bàn.");
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaBan.Text))
            {
                MessageBox.Show("Vui lòng chọn bàn cần xóa.");
                return;
            }

            int maBan = int.Parse(txtMaBan.Text);
            var ban = db.Bans.FirstOrDefault(b => b.MaBan == maBan);
            if (ban != null)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    db.Bans.Remove(ban);
                    db.SaveChanges();
                    LoadData();
                    MessageBox.Show("Xóa bàn thành công.");
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy bàn để xóa.");
            }
        }

        private void xóaTrắngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMaBan.Clear();
            txtSucChua.Clear();
        }

        private void btSearchIDTable_Click(object sender, EventArgs e)
        {
            string keyword = txtMaBan.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadData();
                return;
            }

            int maBan;
            if (int.TryParse(keyword, out maBan))
            {
                var result = db.Bans
                    .Where(b => b.MaBan == maBan)
                    .Select(b => new
                    {
                        b.MaBan,
                        b.SucChua,
                        b.TrangThai
                    })
                    .ToList();

                dtgvBan.DataSource = result;
            }
            else
            {
                MessageBox.Show("Mã bàn không hợp lệ.");
            }
        }
    }
}
