using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace JazzCoffe
{
    public partial class fCongThucDoUong : Form
    {
        QuanLyCafeEntities2 db = new QuanLyCafeEntities2();

        public fCongThucDoUong()
        {
            InitializeComponent();
        }

        private void fCongThucDoUong_Load(object sender, EventArgs e)
        {
            LoadDataCongThucDoUong();

            // Đặt tên cột rõ ràng (tùy chọn)
            dtgvCongThucDoUong.Columns["MaDoUong"].HeaderText = "Mã đồ uống";
            dtgvCongThucDoUong.Columns["TenDoUong"].HeaderText = "Tên đồ uống";
            dtgvCongThucDoUong.Columns["MaNguyenLieu"].HeaderText = "Mã nguyên liệu";
            dtgvCongThucDoUong.Columns["TenNguyenLieu"].HeaderText = "Tên nguyên liệu";
            dtgvCongThucDoUong.Columns["SoLuongDung"].HeaderText = "Số lượng dùng";
        }

        private void LoadDataCongThucDoUong()
        {
            var data = from ct in db.CongThucDoUongs
                       join du in db.DoUongs on ct.MaDU equals du.MaDU
                       join nl in db.NguyenLieux on ct.MaNL equals nl.MaNL
                       select new
                       {
                           MaDoUong = ct.MaDU,
                           TenDoUong = du.TenDU,
                           MaNguyenLieu = ct.MaNL,
                           TenNguyenLieu = nl.TenNL,
                           SoLuongDung = ct.SoLuongDung
                       };

            dtgvCongThucDoUong.DataSource = data.ToList();
        }

        // 🔹 Khi click chọn 1 dòng => đổ dữ liệu ra TextBox
        private void dtgvCongThucDoUong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvCongThucDoUong.Rows[e.RowIndex];

                txtMaDU.Text = row.Cells["MaDoUong"].Value.ToString();
                txtMaNL.Text = row.Cells["MaNguyenLieu"].Value.ToString();
                txtSoLuongCanDung.Text = row.Cells["SoLuongDung"].Value.ToString();
            }
        }

        // 🔹 THÊM công thức
        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string maDU = txtMaDU.Text.Trim();
                int maNL = int.Parse(txtMaNL.Text);
                double soLuongDung = double.Parse(txtSoLuongCanDung.Text);

                // Kiểm tra trùng (vì có thể là khóa chính kép)
                var tonTai = db.CongThucDoUongs.FirstOrDefault(x => x.MaDU == maDU && x.MaNL == maNL);
                if (tonTai != null)
                {
                    MessageBox.Show("Công thức này đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                CongThucDoUong ct = new CongThucDoUong()
                {
                    MaDU = maDU,
                    MaNL = maNL,
                    SoLuongDung = soLuongDung
                };

                db.CongThucDoUongs.Add(ct);
                db.SaveChanges();

                LoadDataCongThucDoUong();
                MessageBox.Show("Thêm công thức thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
        }

        // 🔹 XÓA công thức
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string maDU = txtMaDU.Text.Trim();
                if (!int.TryParse(txtMaNL.Text, out int maNL))
                {
                    MessageBox.Show("Vui lòng chọn một dòng hợp lệ để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var ct = db.CongThucDoUongs.FirstOrDefault(x => x.MaDU == maDU && x.MaNL == maNL);
                if (ct != null)
                {
                    DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa công thức này không?",
                                                      "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        db.CongThucDoUongs.Remove(ct);
                        db.SaveChanges();
                        LoadDataCongThucDoUong();
                        MessageBox.Show("Xóa thành công!");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy công thức để xóa!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            }
        }

        // 🔹 SỬA công thức (chỉ cho phép sửa Số lượng dùng)
        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string maDU = txtMaDU.Text.Trim();
                if (!int.TryParse(txtMaNL.Text, out int maNL))
                {
                    MessageBox.Show("Vui lòng chọn một dòng hợp lệ để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var ct = db.CongThucDoUongs.FirstOrDefault(x => x.MaDU == maDU && x.MaNL == maNL);
                if (ct != null)
                {
                    if (double.TryParse(txtSoLuongCanDung.Text, out double soLuongMoi))
                    {
                        ct.SoLuongDung = soLuongMoi;
                        db.SaveChanges();
                        LoadDataCongThucDoUong();
                        MessageBox.Show("Cập nhật thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Số lượng dùng không hợp lệ!");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy công thức cần sửa!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message);
            }
        }
    }
}
