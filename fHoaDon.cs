using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JazzCoffe
{
    public partial class fHoaDon : Form
    {
        QuanLyCafeEntities2 context = new QuanLyCafeEntities2();

        public fHoaDon()
        {
            InitializeComponent();
        }

        private void fHoaDon_Load(object sender, EventArgs e)
        {
            LoadHoaDon();

            cbxTrangThai.Items.Clear();
            cbxTrangThai.Items.Add("Tất cả");
            cbxTrangThai.Items.Add("Đã thanh toán");
            cbxTrangThai.Items.Add("Chưa thanh toán");
            cbxTrangThai.SelectedIndex = 0;

            LoadData();
            TinhTongChiPhi();
            TinhTongLoiNhuan();
        }

        private void LoadHoaDon()
        {
            var ds = context.HoaDons
                .Select(hd => new
                {
                    hd.MaHD,
                    NgayLap = hd.NgayLap,
                    TenNhanVien = hd.NhanVien.TenNV,
                    hd.TongTien,
                    hd.TrangThai
                })
                .ToList();

            dtgvHoaDon.DataSource = ds;

            DinhDangCot();
            TinhTongDoanhThu();
        }
        private void btnFill_Click(object sender, EventArgs e)
        {
           /* DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddTicks(-1);
            string trangThai = cbxTrangThai.SelectedItem.ToString();

            var danhSachHoaDon = context.HoaDons
                .Where(h => h.NgayLap >= tuNgay && h.NgayLap <= denNgay);

            if (trangThai == "Đã thanh toán")
                danhSachHoaDon = danhSachHoaDon.Where(h => h.TrangThai == "Đã thanh toán");
            else if (trangThai == "Chưa thanh toán")
                danhSachHoaDon = danhSachHoaDon.Where(h => h.TrangThai == "Chưa thanh toán");

            var ketQua = danhSachHoaDon
                .Select(hd => new
                {
                    hd.MaHD,
                    NgayLap = hd.NgayLap,
                    TenNhanVien = hd.NhanVien.TenNV,
                    hd.TongTien,
                    hd.TrangThai
                })
                .ToList();

            dtgvHoaDon.DataSource = ketQua;

            DinhDangCot();
            TinhTongDoanhThu();*/
        }

        private void DinhDangCot()
        {
            if (dtgvHoaDon.Columns["TongTien"] != null)
            {
                dtgvHoaDon.Columns["TongTien"].DefaultCellStyle.Format = "c0";
                dtgvHoaDon.Columns["TongTien"].DefaultCellStyle.FormatProvider = new CultureInfo("vi-VN");
            }

            if (dtgvHoaDon.Columns["NgayLap"] != null)
            {
                dtgvHoaDon.Columns["NgayLap"].HeaderText = "Ngày lập";
            }
          
        }

        // Không dùng đến nữa nhưng giữ lại nếu sau này cần
        public void CapNhatDanhSachHoaDon()
        {
            using (var db = new QuanLyCafeEntities2())
            {
                var dsHoaDon = db.HoaDons
                                 .Select(hd => new
                                 {
                                     hd.MaHD,
                                     NgayLap = hd.NgayLap,
                                     TenNhanVien = hd.NhanVien.TenNV,
                                     hd.TongTien,
                                     hd.TrangThai
                                 })
                                 .ToList()
                                 .Select(hd => new
                                 {
                                     hd.MaHD,
                                     NgayLap = hd.NgayLap?.ToString("dd/MM/yyyy") ?? "",
                                     hd.TenNhanVien,
                                     hd.TongTien,
                                     hd.TrangThai
                                 })
                                 .ToList();

                dtgvHoaDon.DataSource = dsHoaDon;
                DinhDangCot();
                TinhTongDoanhThu();
            }
        }

        private void dtgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e) { }

        private void dtgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void label1_Click(object sender, EventArgs e) { }

        private void dtgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtgvHoaDon.Columns[e.ColumnIndex].Name == "NgayLap" && e.Value != null)
            {
                DateTime dateValue;
                if (DateTime.TryParse(e.Value.ToString(), out dateValue))
                {
                    e.Value = dateValue.ToString("dd/MM/yyyy HH:mm");
                    e.FormattingApplied = true;
                }
            }
        }
        void LoadData()
        {
            var data = context.PhieuNhapKhoes
                .Select(p => new
                {
                    p.MaPN,
                    p.NgayNhap,
                    p.MaNV,
                    p.TongTien
                })
                .ToList();


            dtgvPhieuNhapKho.DataSource = data;
            dtgvPhieuNhapKho.Columns["TongTien"].DefaultCellStyle.Format = "#,##0 VNĐ";
            dtgvPhieuNhapKho.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgvPhieuNhapKho.Columns[0].HeaderText = "Mã phiếu nhập";
            dtgvPhieuNhapKho.Columns[1].HeaderText = "Ngày nhập";
            dtgvPhieuNhapKho.Columns[2].HeaderText = "Mã nhân viên";
            dtgvPhieuNhapKho.Columns[3].HeaderText = "Tổng tiền";
        }

        private decimal TinhTongDoanhThu()
        {
            decimal tong = 0;

            foreach (DataGridViewRow row in dtgvHoaDon.Rows)
            {
                if (row.Cells["TongTien"].Value != null)
                {
                    decimal giaTri;
                    if (decimal.TryParse(row.Cells["TongTien"].Value.ToString(), out giaTri))
                    {
                        tong += giaTri;
                    }
                }
            }

            lblTongDoanhThu.Text = tong.ToString("c0", new CultureInfo("vi-VN"));
            return tong; // 👈 trả về tổng doanh thu
        }

        // Hàm tính tổng chi phí và trả về giá trị
        private decimal TinhTongChiPhi()
        {
            decimal tongChiPhi = 0;

            foreach (DataGridViewRow row in dtgvPhieuNhapKho.Rows)
            {
                if (row.Cells["TongTien"].Value != null)
                    tongChiPhi += Convert.ToDecimal(row.Cells["TongTien"].Value);
            }

            lblTongChiPhi.Text = string.Format("{0:#,##0} VNĐ", tongChiPhi);
            return tongChiPhi; // 👈 trả về tổng chi phí
        }

        // 👉 Hàm tính tổng lợi nhuận
        private void TinhTongLoiNhuan()
        {
            decimal doanhThu = TinhTongDoanhThu();
            decimal chiPhi = TinhTongChiPhi();
            decimal loiNhuan = doanhThu - chiPhi;

            // Hiển thị lợi nhuận định dạng tiền tệ VNĐ
            txtTongLoiNhuan.Text = loiNhuan.ToString("#,##0 VNĐ", CultureInfo.InvariantCulture);
        }

        private void LocPhieuNhapKho()
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddTicks(-1);

            var phieuLoc = context.PhieuNhapKhoes
                .Where(pn => pn.NgayNhap >= tuNgay && pn.NgayNhap <= denNgay)
                .Select(pn => new
                {
                    pn.MaPN,
                    pn.NgayNhap,
                    pn.MaNV,
                    pn.TongTien
                })
                .ToList();

            dtgvPhieuNhapKho.DataSource = phieuLoc;
        }
        private void LocHoaDon()
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddTicks(-1);

            var hoaDonLoc = context.HoaDons
                .Where(hd => hd.NgayLap >= tuNgay && hd.NgayLap <= denNgay)
                .Select(hd => new
                {
                    hd.MaHD,
                    hd.NgayLap,
                    hd.NhanVien.TenNV,
                    hd.TongTien,
                    hd.TrangThai
                })
                .ToList();

            dtgvHoaDon.DataSource = hoaDonLoc;
        }
        private void btnLocPhieuNhap_Click(object sender, EventArgs e)
        {
            LocHoaDon();
            LocPhieuNhapKho();
            TinhTongLoiNhuan();
        }
    }
}
