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

        List<PhieuNhapTam> phieuNhapTam = new List<PhieuNhapTam>();
        int maPhieuNhapHienTai = 1;  // Mã phiếu nhập cho lượt hiện tại
        //bool daNhapThanhCong = false; // Kiểm tra xem đã hoàn tất lượt nhập chưa
        public fNhapkho()
        {
            InitializeComponent();
        }

        private void fNhapkho_Load(object sender, EventArgs e)
        {
            LoadNguyenLieu();
            //LoadPhieuNhapKho();
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
                MessageBox.Show("Vui lòng chọn nguyên liệu!");
                return;
            }

            int maNL = Convert.ToInt32(dtgvNguyenLieu.CurrentRow.Cells["MaNL"].Value);
            string tenNL = dtgvNguyenLieu.CurrentRow.Cells["TenNL"].Value.ToString();

            if (!double.TryParse(txtSoLuongNhap.Text, out double soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số hợp lệ!");
                return;
            }
            if (!decimal.TryParse(txtDonGiaNhap.Text, out decimal donGia) || donGia <= 0)
            {
                MessageBox.Show("Đơn giá phải là số hợp lệ!");
                return;
            }

            string maNV = txtMaNV.Text.Trim();
            int maPN = maPhieuNhapHienTai;

            var item = new PhieuNhapTam
            {
                MaPN = maPN,
                MaNV = maNV,
                MaNL = maNL,
                TenNL = tenNL,
                SoLuongNhap = soLuong,
                DonGiaNhap = donGia,
                NgayNhap = dtpNgayNhap.Value
            };

            phieuNhapTam.Add(item);

            CapNhatBangTam();
        }

        private void CapNhatBangTam()
        {
            dtgvPhieuNhapKhoTam.DataSource = null;
            dtgvPhieuNhapKhoTam.DataSource = phieuNhapTam;

            dtgvPhieuNhapKhoTam.Columns["MaPN"].HeaderText = "Mã phiếu nhập";
            dtgvPhieuNhapKhoTam.Columns["MaNV"].HeaderText = "Mã nhân viên";
            dtgvPhieuNhapKhoTam.Columns["MaNL"].HeaderText = "Mã nguyên liệu";
            dtgvPhieuNhapKhoTam.Columns["TenNL"].HeaderText = "Tên nguyên liệu";
            dtgvPhieuNhapKhoTam.Columns["SoLuongNhap"].HeaderText = "Số lượng";
            dtgvPhieuNhapKhoTam.Columns["DonGiaNhap"].HeaderText = "Đơn giá";
            dtgvPhieuNhapKhoTam.Columns["NgayNhap"].HeaderText = "Ngày nhập";

            dtgvPhieuNhapKhoTam.Columns["DonGiaNhap"].DefaultCellStyle.Format = "N0"; // Có dấu phân cách hàng nghìn
            dtgvPhieuNhapKhoTam.Columns["DonGiaNhap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgvPhieuNhapKhoTam.Columns["DonGiaNhap"].HeaderText = "Đơn giá nhập (VNĐ)";

            // 🔹 Định dạng cột Ngày nhập (hiển thị dd/MM/yyyy)
            dtgvPhieuNhapKhoTam.Columns["NgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dtgvPhieuNhapKhoTam.Columns["NgayNhap"].HeaderText = "Ngày nhập";
            decimal tong = phieuNhapTam.Sum(x => (decimal)x.DonGiaNhap);
            txtTongChiPhi.Text = tong.ToString("N0") + " VNĐ";
        }
        private void btnNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (phieuNhapTam.Count == 0)
                {
                    MessageBox.Show("Chưa có nguyên liệu nào để nhập!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMaNV.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã nhân viên!");
                    return;
                }

                decimal tongTien = phieuNhapTam.Sum(x => (decimal)x.DonGiaNhap);

                PhieuNhapKho pn = new PhieuNhapKho
                {
                    MaNV = txtMaNV.Text.Trim(),
                    NgayNhap = dtpNgayNhap.Value,
                    TongTien = tongTien
                };

                db.PhieuNhapKhoes.Add(pn);
                db.SaveChanges();

                foreach (var item in phieuNhapTam)
                {
                    ChiTietPhieuNhap ct = new ChiTietPhieuNhap
                    {
                        MaPN = pn.MaPN,
                        MaNL = item.MaNL,
                        SoLuongNhap = item.SoLuongNhap,
                        DonGiaNhap = item.DonGiaNhap
                    };

                    db.ChiTietPhieuNhaps.Add(ct);

                    var nl = db.NguyenLieux.FirstOrDefault(n => n.MaNL == item.MaNL);
                    if (nl != null)
                        nl.SoLuongTon += (float)item.SoLuongNhap;
                }

                db.SaveChanges();
                MessageBox.Show("Nhập kho thành công!");

                phieuNhapTam.Clear();
                CapNhatBangTam();
                LoadNguyenLieu();

                var lastPN = db.PhieuNhapKhoes.OrderByDescending(p => p.MaPN).FirstOrDefault();
                maPhieuNhapHienTai = (lastPN != null) ? lastPN.MaPN + 1 : 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nhập kho: " + ex.Message);
            }
        }
        private void dtgvPhieuNhapKhoTam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtgvPhieuNhapKhoTam.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
                return;
            }

            int maNL = Convert.ToInt32(dtgvPhieuNhapKhoTam.CurrentRow.Cells["MaNL"].Value);

            phieuNhapTam.RemoveAll(x => x.MaNL == maNL);
            CapNhatBangTam();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dtgvPhieuNhapKhoTam.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!");
                return;
            }

            int maNL = Convert.ToInt32(dtgvPhieuNhapKhoTam.CurrentRow.Cells["MaNL"].Value);
            var item = phieuNhapTam.FirstOrDefault(x => x.MaNL == maNL);

            if (item == null) return;

            if (double.TryParse(txtSoLuongNhap.Text, out double sl))
                item.SoLuongNhap = sl;
            if (decimal.TryParse(txtDonGiaNhap.Text, out decimal dg))
                item.DonGiaNhap = dg;

            item.NgayNhap = dtpNgayNhap.Value;
            CapNhatBangTam();
        }





        private void dtgvPhieuNhapKhoTam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dtgvPhieuNhapKhoTam.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["MaNV"].Value?.ToString();
                txtSoLuongNhap.Text = row.Cells["SoLuongNhap"].Value?.ToString();
                txtDonGiaNhap.Text = row.Cells["DonGiaNhap"].Value?.ToString();
                if (DateTime.TryParse(row.Cells["NgayNhap"].Value?.ToString(), out DateTime ngay))
                    dtpNgayNhap.Value = ngay;
            }
        }

       
    }
    public class PhieuNhapTam
    {
        public int MaPN { get; set; }
        public string MaNV { get; set; }
        public int MaNL { get; set; }
        public string TenNL { get; set; }
        public double SoLuongNhap { get; set; }
        public decimal DonGiaNhap { get; set; }
        public DateTime NgayNhap { get; set; }
    }
}