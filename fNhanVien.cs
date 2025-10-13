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
                    })
                    .ToList();

                dtgvNhanVien.DataSource = dsNhanVien;
            

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

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtMaNV.Text) ||
        string.IsNullOrWhiteSpace(txtTenNV.Text) ||
        string.IsNullOrWhiteSpace(txtNVPassword.Text) ||
        string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            var existing = db.NhanViens.FirstOrDefault(n => n.MaNV == txtMaNV.Text);
            if (existing != null)
            {
                MessageBox.Show("Mã nhân viên đã tồn tại.");
                return;
            }

            var nv = new NhanVien()
            {
                MaNV = txtMaNV.Text,
                TenNV = txtTenNV.Text,
                MatKhau = txtNVPassword.Text,
                SDT = txtSDT.Text
            };

            try
            {
                db.NhanViens.Add(nv);
                db.SaveChanges();
                LoadData();
                MessageBox.Show("Đã thêm nhân viên.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.InnerException?.InnerException?.Message);
            }
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            var nv = db.NhanViens.FirstOrDefault(n => n.MaNV == maNV);

            if (nv != null)
            {
                nv.TenNV = txtTenNV.Text;
                nv.MatKhau = txtNVPassword.Text;
                nv.SDT = txtSDT.Text;

                db.SaveChanges();
                LoadData();
                MessageBox.Show("Đã sửa nhân viên.");
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên để sửa.");
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            var nv = db.NhanViens.FirstOrDefault(n => n.MaNV == maNV);

            if (nv != null)
            {
                db.NhanViens.Remove(nv);
                db.SaveChanges();
                LoadData();
                MessageBox.Show("Đã xóa nhân viên.");
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên để xóa.");
            }
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtNVPassword.Clear();
            txtSDT.Clear();
            LoadData();
        }

        private void btSearchNameNV_Click(object sender, EventArgs e)
        {
            string keyword = txtSearchNameNV.Text.Trim().ToLower();

            var result = db.NhanViens
                .Where(nv => nv.TenNV.ToLower().Contains(keyword))
                .Select(nv => new
                {
                    nv.MaNV,
                    nv.TenNV,
                    nv.MatKhau,
                    nv.SDT,
                }).ToList();

            dtgvNhanVien.DataSource = result;
        }
    }
}

