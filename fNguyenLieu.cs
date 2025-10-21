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
    public partial class fNguyenLieu : Form
    {
        QuanLyCafeEntities2 db = new QuanLyCafeEntities2();
        public fNguyenLieu()
        {
            InitializeComponent();
        }

        private void fNguyenLieu_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            // Lấy dữ liệu từ bảng NguyenLieu và hiển thị lên DataGridView
            dtgvNguyenLieu.DataSource = db.NguyenLieux
                .Select(nl => new
                {
                    nl.MaNL,
                    nl.TenNL,
                    nl.DonViTinh,
                    nl.SoLuongTon,
                    nl.SoLuongToiThieu,
                    nl.GhiChu
                })
                .ToList();
            dtgvNguyenLieu.ReadOnly = true;
            dtgvNguyenLieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvNguyenLieu.Columns["SoLuongTon"].DefaultCellStyle.Format = "N4";
        }

        private void LamMoi()
        {
            txtTenNL.Clear();
            txtSLToiThieu.Clear();
            txtDonViTinh.Clear();
            txtGhiChu.Clear();
            LoadData();
        }

        private void themToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNL.Text) || string.IsNullOrWhiteSpace(txtDonViTinh.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên nguyên liệu và Đơn vị tính!");
                return;
            }

            NguyenLieu nl = new NguyenLieu()
            {
                TenNL = txtTenNL.Text,
                DonViTinh = txtDonViTinh.Text,
                SoLuongTon = 0, // mặc định ban đầu
                SoLuongToiThieu = double.TryParse(txtSLToiThieu.Text, out double sltt) ? sltt : 10,
                GhiChu = txtGhiChu.Text
            };

            db.NguyenLieux.Add(nl);
            db.SaveChanges();
            MessageBox.Show("Thêm nguyên liệu thành công!");
            LamMoi();
        }

        // Xóa
        private void xoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtgvNguyenLieu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nguyên liệu cần xóa!");
                return;
            }

            int maNL = Convert.ToInt32(dtgvNguyenLieu.SelectedRows[0].Cells["MaNL"].Value);
            var nl = db.NguyenLieux.FirstOrDefault(x => x.MaNL == maNL);

            if (nl != null)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa nguyên liệu này?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    db.NguyenLieux.Remove(nl);
                    db.SaveChanges();
                    MessageBox.Show("Xóa thành công!");
                    LamMoi();
                }
            }
        }

        // Sửa
        private void suaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtgvNguyenLieu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nguyên liệu cần sửa!");
                return;
            }

            int maNL = Convert.ToInt32(dtgvNguyenLieu.SelectedRows[0].Cells["MaNL"].Value);
            var nl = db.NguyenLieux.FirstOrDefault(x => x.MaNL == maNL);

            if (nl != null)
            {
                nl.TenNL = txtTenNL.Text;
                nl.DonViTinh = txtDonViTinh.Text;
                nl.SoLuongToiThieu = double.TryParse(txtSLToiThieu.Text, out double sltt) ? sltt : 10;
                nl.GhiChu = txtGhiChu.Text;

                db.SaveChanges();
                MessageBox.Show("Cập nhật thành công!");
                LamMoi();
            }
        }

        // Làm mới
        private void lamMoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        // Khi chọn dòng trong DataGridView
        private void dtgvNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dtgvNguyenLieu.Rows[e.RowIndex];
                txtTenNL.Text = row.Cells["TenNL"].Value.ToString();
                txtDonViTinh.Text = row.Cells["DonViTinh"].Value.ToString();
                txtSLToiThieu.Text = row.Cells["SoLuongToiThieu"].Value.ToString();
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();
            }
        }


        private void dtgvNguyenLieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

       

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dtgvNguyenLieu_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
