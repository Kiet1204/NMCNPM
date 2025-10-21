using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;


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
            LoadChartDoanhThu(DateTime.MinValue, DateTime.MaxValue);
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

            // Gọi lại hàm hiển thị biểu đồ
            LoadChartDoanhThu(tuNgay, denNgay);
        }
        private void btnLocPhieuNhap_Click(object sender, EventArgs e)
        {
            LocHoaDon();
            LocPhieuNhapKho();
            TinhTongLoiNhuan();
        }

        private void LoadChartDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            chartDoanhThu.Series.Clear();
            chartDoanhThu.ChartAreas.Clear();

            ChartArea area = new ChartArea();
            chartDoanhThu.ChartAreas.Add(area);

            Series series = new Series("Doanh thu theo ngày");
            series.ChartType = SeriesChartType.Column;
            series.XValueType = ChartValueType.String;
            series.IsValueShownAsLabel = true; // hiển thị giá trị trên cột
            chartDoanhThu.Series.Add(series);

            using (var db = new QuanLyCafeEntities2())
            {
                var doanhThuTheoNgay = db.HoaDons
                    .Where(hd => hd.TrangThai == "Đã thanh toán"
                              && hd.NgayLap >= tuNgay
                              && hd.NgayLap <= denNgay)
                    .GroupBy(hd => DbFunctions.TruncateTime(hd.NgayLap))
                    .Select(g => new
                    {
                        Ngay = g.Key,
                        TongTien = g.Sum(x => x.TongTien)
                    })
                    .OrderBy(x => x.Ngay)
                    .ToList();

                foreach (var item in doanhThuTheoNgay)
                {
                    if (item.Ngay.HasValue)
                    {
                        series.Points.AddXY(item.Ngay.Value.ToString("dd/MM/yyyy"), item.TongTien);
                    }
                }
            }

            chartDoanhThu.Titles.Clear();
            chartDoanhThu.Titles.Add("Biểu đồ doanh thu theo ngày");
        }

        private void btnXuatBaoCaoPDF_Click(object sender, EventArgs e)
        {
            var danhSachHoaDon = dtgvHoaDon.Rows.Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow)
                .Select(r => new
                {
                    MaHD = r.Cells["MaHD"].Value?.ToString(),
                    NgayLap = r.Cells["NgayLap"].Value?.ToString(),
                    TenNhanVien = r.Cells["TenNV"]?.Value?.ToString() ?? r.Cells["TenNhanVien"]?.Value?.ToString(),
                    TongTien = Convert.ToDecimal(r.Cells["TongTien"].Value ?? 0),
                    TrangThai = r.Cells["TrangThai"].Value?.ToString()
                }).ToList();

            var danhSachPhieuNhap = dtgvPhieuNhapKho.Rows.Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow)
                .Select(r => new
                {
                    MaPN = r.Cells["MaPN"].Value?.ToString(),
                    NgayNhap = r.Cells["NgayNhap"].Value?.ToString(),
                    MaNV = r.Cells["MaNV"].Value?.ToString(),
                    TongTien = Convert.ToDecimal(r.Cells["TongTien"].Value ?? 0)
                }).ToList();

            decimal tongDoanhThu = TinhTongDoanhThu();
            decimal tongChiPhi = TinhTongChiPhi();
            decimal loiNhuan = tongDoanhThu - tongChiPhi;

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "PDF File|*.pdf";
            saveFile.FileName = "BaoCaoThongKe.pdf";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                Document doc = new Document(PageSize.A4, 36, 36, 50, 50);
                using (FileStream fs = new FileStream(saveFile.FileName, FileMode.Create))
                {
                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    // Font
                    string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf");
                    BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font fontHeader = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(bf, 11, iTextSharp.text.Font.NORMAL);
                    // 🔹 Tiêu đề
                    Paragraph title = new Paragraph("BÁO CÁO THỐNG KÊ DOANH THU - CHI PHÍ - LỢI NHUẬN", fontTitle);
                    title.Alignment = Element.ALIGN_CENTER;
                    title.SpacingAfter = 20;
                    doc.Add(title);
                    // ========== PHẦN I ==========
                    Paragraph doanhThuHeader = new Paragraph("I. Danh sách hóa đơn", fontHeader);
                    doanhThuHeader.SpacingAfter = 8;
                    doc.Add(doanhThuHeader);

                    PdfPTable table1 = new PdfPTable(5);
                    table1.WidthPercentage = 100;
                    table1.SpacingAfter = 10;
                    table1.SetWidths(new float[] { 1.2f, 2f, 2f, 1.5f, 1.5f });

                    string[] headers1 = { "Mã HĐ", "Ngày lập", "Tên nhân viên", "Tổng tiền", "Trạng thái" };
                    foreach (var h in headers1)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(h, fontHeader));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.BackgroundColor = new BaseColor(230, 230, 230);
                        table1.AddCell(cell);
                    }

                    foreach (var hd in danhSachHoaDon)
                    {
                        table1.AddCell(new Phrase(hd.MaHD, fontNormal));
                        table1.AddCell(new Phrase(hd.NgayLap, fontNormal));
                        table1.AddCell(new Phrase(hd.TenNhanVien, fontNormal));
                        table1.AddCell(new Phrase($"{hd.TongTien:#,##0 VNĐ}", fontNormal));
                        table1.AddCell(new Phrase(hd.TrangThai, fontNormal));
                    }
                    doc.Add(table1);

                    Paragraph tongDT = new Paragraph($"Tổng doanh thu: {tongDoanhThu:#,##0 VNĐ}\n\n", fontHeader);
                    tongDT.SpacingAfter = 10;
                    doc.Add(tongDT);

                    // ========== PHẦN II ==========
                    Paragraph chiPhiHeader = new Paragraph("II. Danh sách phiếu nhập kho", fontHeader);
                    chiPhiHeader.SpacingBefore = 10;
                    chiPhiHeader.SpacingAfter = 8;
                    doc.Add(chiPhiHeader);

                    PdfPTable table2 = new PdfPTable(4);
                    table2.WidthPercentage = 100;
                    table2.SpacingAfter = 10;
                    table2.SetWidths(new float[] { 1.2f, 2f, 1.5f, 1.5f });

                    string[] headers2 = { "Mã phiếu nhập", "Ngày nhập", "Mã NV", "Tổng tiền" };
                    foreach (var h in headers2)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(h, fontHeader));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.BackgroundColor = new BaseColor(230, 230, 230);
                        table2.AddCell(cell);
                    }

                    foreach (var pn in danhSachPhieuNhap)
                    {
                        table2.AddCell(new Phrase(pn.MaPN, fontNormal));
                        table2.AddCell(new Phrase(pn.NgayNhap, fontNormal));
                        table2.AddCell(new Phrase(pn.MaNV, fontNormal));
                        table2.AddCell(new Phrase($"{pn.TongTien:#,##0 VNĐ}", fontNormal));
                    }
                    doc.Add(table2);

                    Paragraph tongCP = new Paragraph($"Tổng chi phí: {tongChiPhi:#,##0 VNĐ}\n\n", fontHeader);
                    tongCP.SpacingAfter = 10;
                    doc.Add(tongCP);


                    // ========== PHẦN III ==========
                    Paragraph tongKetHeader = new Paragraph("III. Tổng kết", fontHeader);
                    tongKetHeader.SpacingBefore = 10;
                    tongKetHeader.SpacingAfter = 8;
                    doc.Add(tongKetHeader);

                    PdfPTable summaryTable = new PdfPTable(2);
                    summaryTable.WidthPercentage = 60;
                    summaryTable.HorizontalAlignment = Element.ALIGN_LEFT;
                    summaryTable.SpacingBefore = 5;

                    summaryTable.AddCell(new Phrase("Tổng doanh thu:", fontHeader));
                    summaryTable.AddCell(new Phrase($"{tongDoanhThu:#,##0 VNĐ}", fontNormal));
                    summaryTable.AddCell(new Phrase("Tổng chi phí:", fontHeader));
                    summaryTable.AddCell(new Phrase($"{tongChiPhi:#,##0 VNĐ}", fontNormal));
                    summaryTable.AddCell(new Phrase("Lợi nhuận:", fontHeader));
                    summaryTable.AddCell(new Phrase($"{loiNhuan:#,##0 VNĐ}", fontNormal));

                    doc.Add(summaryTable);

                    doc.Close();
                }

                MessageBox.Show("Xuất báo cáo PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
