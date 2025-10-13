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
    public partial class fKhachhang : Form
    {
        QuanLyCafeEntities2 db = new QuanLyCafeEntities2();
        public fKhachhang()
        {
            InitializeComponent();
        }
        private void fKhachhang_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        { 
            
                var dsNhanVien = db.KhachHangs
                    .Select(nv => new
                    {
                        nv.MaKH,
                        nv.TenKH,
                        nv.SDT,
                        nv.DiaChi,
                    })
                    .ToList();

                dtgvKhachHang.DataSource = dsNhanVien;
            

            // Có thể ẩn cột nếu muốn
            // dtgvNhanVien.Columns["MatKhau"].Visible = false;
        }

        private void dtgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dtgvKhachHang.Rows[e.RowIndex].Cells.Count > 0)
            {
                DataGridViewRow row = dtgvKhachHang.Rows[e.RowIndex];

                txtMaKH.Text = row.Cells["MaKH"]?.Value?.ToString() ?? string.Empty;
                txtTenKH.Text = row.Cells["TenKH"]?.Value?.ToString() ?? string.Empty;
                txtSDT.Text = row.Cells["SDT"]?.Value?.ToString() ?? string.Empty;
                txtDiaChi.Text = row.Cells["DiaChi"]?.Value?.ToString() ?? string.Empty;

            }
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tự động tạo MaKH mới tăng dần
            int maxMaKH = db.KhachHangs
                .Select(kh => kh.MaKH)
                .DefaultIfEmpty(0)
                .Max();

            var newKH = new KhachHang()
            {
                MaKH = maxMaKH + 1,
                TenKH = txtTenKH.Text,
                SDT = txtSDT.Text,
                DiaChi = txtDiaChi.Text
            };

            db.KhachHangs.Add(newKH);
            db.SaveChanges();
            LoadData();
            MessageBox.Show("Đã thêm khách hàng mới.");
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa.");
                return;
            }

            int maKH = int.Parse(txtMaKH.Text);

            var kh = db.KhachHangs.FirstOrDefault(k => k.MaKH == maKH);
            if (kh != null)
            {
                kh.TenKH = txtTenKH.Text;
                kh.SDT = txtSDT.Text;
                kh.DiaChi = txtDiaChi.Text;

                db.SaveChanges();
                LoadData();
                MessageBox.Show("Đã cập nhật thông tin khách hàng.");
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng để sửa.");
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa.");
                return;
            }

            int maKH = int.Parse(txtMaKH.Text);

            var kh = db.KhachHangs.FirstOrDefault(k => k.MaKH == maKH);
            if (kh != null)
            {
                db.KhachHangs.Remove(kh);
                db.SaveChanges();
                LoadData();
                MessageBox.Show("Đã xóa khách hàng.");
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng để xóa.");
            }
        }

        private void xóaTrắngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
        }

        private void btSearchNameCustomer_Click(object sender, EventArgs e)
        {
            string keyword = txbSearchNameCustomer.Text.Trim().ToLower();

            var result = db.KhachHangs
            .Where(kh => kh.TenKH.ToLower().Contains(keyword))
            .Select(kh => new
            {
                kh.MaKH,
                kh.TenKH,
                kh.SDT,
                kh.DiaChi
            })
            .ToList();

            dtgvKhachHang.DataSource = result;


        }
    }
}
