using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace JazzCoffe
{
    public partial class fChiTietHoaDon : Form
    {
        private int maHD; // Vì MaHD là kiểu int trong CSDL
        private string tenNhanVien;
        private string maBan;
        private DateTime ngay;
        private int tongTien;
        private List<TableManeger.DoUongDaChon> danhSach;

        public fChiTietHoaDon(int maHD, string tenNhanVien, string maBan, DateTime ngay, int tongTien, List<TableManeger.DoUongDaChon> danhSach)
        {
            InitializeComponent();

            // Gán giá trị cho các biến thành viên
            this.maHD = maHD;
            this.tenNhanVien = tenNhanVien;
            this.maBan = maBan;
            this.ngay = ngay;
            this.tongTien = tongTien;
            this.danhSach = danhSach;

            // Gọi phương thức hiển thị
            HienThiThongTin();
        }

        private void HienThiThongTin()
        {
            // Hiển thị thông tin lên các label
            lbMaHD.Text = maHD.ToString();
            lbThuNgan.Text = tenNhanVien;
            lbMaBan.Text = maBan;

            // Đảm bảo đang dùng DateTime thật
            if (ngay is DateTime)
            {
                lbDate.Text = ngay.ToString("dd/MM/yyyy");
            }
            else
            {
                lbDate.Text = DateTime.Parse(ngay.ToString()).ToString("dd/MM/yyyy");
            }

            // ✅ Định dạng tiền tệ có dấu phân cách hàng nghìn
            lbTong.Text = tongTien.ToString("N0") + " VND";

            // Gán dữ liệu cho DataGridView
            dtgvChiTietHoaDon.DataSource = danhSach;
        }


        public class DoUongDaChon
        {
            public string MaDU { get; set; }
            public string TenDU { get; set; }
            public string TenLoai { get; set; }
            public int DonGia { get; set; }
            public int SoLuong { get; set; }
            public int ThanhTien => DonGia * SoLuong;
        }

        private void fChiTietHoaDon_Load(object sender, EventArgs e)
        {
            lbMaHD.Text = maHD.ToString();
            lbThuNgan.Text = tenNhanVien;
            lbMaBan.Text = maBan;
            lbDate.Text = ngay.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            lbTong.Text = tongTien.ToString("N0") + " VND";

            dtgvChiTietHoaDon.DataSource = danhSach;
            if (dtgvChiTietHoaDon.Columns.Contains("MaDU"))
                dtgvChiTietHoaDon.Columns["MaDU"].Visible = false;


            if (dtgvChiTietHoaDon.Columns.Contains("DonGia"))
                dtgvChiTietHoaDon.Columns["DonGia"].DefaultCellStyle.Format = "N0";

            if (dtgvChiTietHoaDon.Columns.Contains("ThanhTien"))
                dtgvChiTietHoaDon.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
        }

        private string FormatMaHD(int maHD)
        {
            return "HD" + maHD.ToString().PadLeft(5, '0');
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font fontTitle = new Font("Arial", 16, FontStyle.Bold);
            Font font = new Font("Arial", 12);
            Brush brush = Brushes.Black;
            int x = 50;
            int y = 100;

            e.Graphics.DrawString("THÔNG TIN HÓA ĐƠN", fontTitle, brush, x + 200, y - 60);
            e.Graphics.DrawString($"Mã HD: {maHD}", font, brush, x, y);
            e.Graphics.DrawString($"Thu ngân: {tenNhanVien}", font, brush, x + 300, y);
            y += 30;
            e.Graphics.DrawString($"Bàn: {maBan}", font, brush, x, y);
            e.Graphics.DrawString($"Ngày: {ngay.ToString("dd/MM/yyyy HH:mm")}", font, brush, x + 300, y);

            y += 40;

            e.Graphics.DrawString("Tên ĐU", font, brush, x, y);
            e.Graphics.DrawString("Tên Loại", font, brush, x + 150, y);
            e.Graphics.DrawString("Đơn Giá", font, brush, x + 300, y);
            e.Graphics.DrawString("Số Lượng", font, brush, x + 400, y);
            y += 30;

            foreach (var douong in danhSach)
            {
                e.Graphics.DrawString(douong.TenDU, font, brush, x, y);
                e.Graphics.DrawString(douong.TenLoai, font, brush, x + 150, y);
                e.Graphics.DrawString(douong.DonGia.ToString("N0"), font, brush, x + 300, y);
                e.Graphics.DrawString(douong.SoLuong.ToString(), font, brush, x + 400, y);
                y += 25;
            }

            y += 30;
            e.Graphics.DrawString($"TỔNG TIỀN: {tongTien.ToString("N0")} VND", font, brush, x, y);
        }

        private void btPrintBill_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}


