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
    public partial class fNhapkho : Form
    {
        QuanLyCafeEntities2 db = new QuanLyCafeEntities2();

        List<dynamic> phieuNhapTam = new List<dynamic>();
        int maPhieuNhapHienTai = 1;  // Mã phiếu nhập cho lượt hiện tại
        bool daNhapThanhCong = false; // Kiểm tra xem đã hoàn tất lượt nhập chưa
        public fNhapkho()
        {
            InitializeComponent();
        }

        private void fNhapkho_Load(object sender, EventArgs e)
        {
            LoadNguyenLieu();
            var lastPN = db.PhieuNhapKhoes.OrderByDescending(p => p.MaPN).FirstOrDefault();
            maPhieuNhapHienTai = (lastPN != null) ? lastPN.MaPN + 1 : 1;

        }

        private void LoadNguyenLieu()
        {
            // Lấy dữ liệu từ bảng NguyenLieu và hiển thị lên DataGridView
            dtgvNguyenLieu.DataSource = db.NguyenLieux
                .Select(nl => new
                {
                    nl.MaNL,
                    nl.TenNL,
                    nl.DonViTinh,
                })
                .ToList();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dtgvNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvNguyenLieu.Rows[e.RowIndex];
                txtDonGiaNhap.Clear();
                txtSoLuongNhap.Clear();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (dtgvNguyenLieu.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn nguyên liệu trước!");
                return;
            }

            // Lấy thông tin nguyên liệu đang chọn
            int maNL = Convert.ToInt32(dtgvNguyenLieu.CurrentRow.Cells["MaNL"].Value);
            string tenNL = dtgvNguyenLieu.CurrentRow.Cells["TenNL"].Value.ToString();

            // Lấy thông tin từ textbox
            string maNV = txtMaNV.Text.Trim();
            double soLuong = 0, donGia = 0;
            if (!double.TryParse(txtSoLuongNhap.Text, out soLuong) || !double.TryParse(txtDonGiaNhap.Text, out donGia))
            {
                MessageBox.Show("Số lượng và đơn giá phải là số hợp lệ!");
                return;
            }

            // Tạo mã phiếu nhập tạm (ví dụ tăng tự động)
            int maPN = maPhieuNhapHienTai;

            // Thêm vào danh sách tạm
            phieuNhapTam.Add(new
            {
                MaPN = maPN,
                MaNV = maNV,
                MaNL = maNL,
                TenNL = tenNL,
                SoLuongNhap = soLuong,
                DonGiaNhap = donGia,
                NgayNhap = dtpNgayNhap.Value
            });

            // Cập nhật hiển thị
            dtgvPhieuNhapKhoTam.DataSource = null;
            dtgvPhieuNhapKhoTam.DataSource = phieuNhapTam;
            dtgvPhieuNhapKhoTam.Columns["DonGiaNhap"].DefaultCellStyle.Format = "#,##0 VNĐ";
            dtgvPhieuNhapKhoTam.Columns["NgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dtgvPhieuNhapKhoTam.Columns[0].HeaderText = "Mã phiếu nhập";
            dtgvPhieuNhapKhoTam.Columns[1].HeaderText = "Mã nhân viên";
            dtgvPhieuNhapKhoTam.Columns[2].HeaderText = "Mã nguyên liệu";
            dtgvPhieuNhapKhoTam.Columns[3].HeaderText = "Tên nguyên liệu";
            dtgvPhieuNhapKhoTam.Columns[4].HeaderText = "Số lượng nhập";
            dtgvPhieuNhapKhoTam.Columns[5].HeaderText = "Đơn giá nhập";
            dtgvPhieuNhapKhoTam.Columns[6].HeaderText = "Ngày nhập";

            double tong = 0;
            foreach (DataGridViewRow row in dtgvPhieuNhapKhoTam.Rows)
            {
                if (row.Cells["DonGiaNhap"].Value != null)
                {
                    double gia;
                    if (double.TryParse(row.Cells["DonGiaNhap"].Value.ToString(), out gia))
                        tong += gia;
                }
            }

            txtTongChiPhi.Text = tong.ToString("N0") + " VNĐ";

        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (phieuNhapTam.Count == 0)
                {
                    MessageBox.Show("Chưa có nguyên liệu nào được thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMaNV.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Tính tổng chi phí (decimal)
                decimal tongChiPhi = phieuNhapTam.Sum(item => (decimal)item.DonGiaNhap);

                // ✅ Tạo đối tượng phiếu nhập kho mới
                PhieuNhapKho pn = new PhieuNhapKho()
                {
                    MaNV = txtMaNV.Text.Trim(),
                    NgayNhap = dtpNgayNhap.Value,
                    TongTien = tongChiPhi
                };

                db.PhieuNhapKhoes.Add(pn);
                db.SaveChanges(); // Lưu để có MaPN tự tăng

                // ✅ Lưu chi tiết phiếu nhập
                foreach (var item in phieuNhapTam)
                {
                    ChiTietPhieuNhap ct = new ChiTietPhieuNhap()
                    {
                        MaPN = pn.MaPN,
                        MaNL = item.MaNL,
                        SoLuongNhap = item.SoLuongNhap,
                        DonGiaNhap = (decimal)item.DonGiaNhap
                    };

                    db.ChiTietPhieuNhaps.Add(ct);

                    // Cập nhật số lượng tồn kho cho nguyên liệu
                    int maNL = (int)item.MaNL;
                    var nl = db.NguyenLieux.FirstOrDefault(n => n.MaNL == maNL);

                    if (nl != null)
                    {
                        nl.SoLuongTon = (float)((double)nl.SoLuongTon + (double)item.SoLuongNhap);
                    }
                }

                db.SaveChanges();

                MessageBox.Show("Nhập kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ✅ Mở form chi tiết phiếu nhập
                fChiTietNhapKho f = new fChiTietNhapKho(pn.MaPN);
                f.ShowDialog();


                // Xóa dữ liệu tạm và cập nhật giao diện
                phieuNhapTam.Clear();
                dtgvPhieuNhapKhoTam.DataSource = null;
                txtTongChiPhi.Clear();

                // Cập nhật lại danh sách nguyên liệu sau khi nhập
                LoadNguyenLieu();

                // Tạo mã phiếu nhập mới cho lượt tiếp theo
                var lastPN = db.PhieuNhapKhoes.OrderByDescending(p => p.MaPN).FirstOrDefault();
                maPhieuNhapHienTai = (lastPN != null) ? lastPN.MaPN + 1 : 1;

                daNhapThanhCong = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nhập kho: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}