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
    public partial class fChiTietNhapKho : Form
    {
        QuanLyCafeEntities2 db = new QuanLyCafeEntities2();
        int maPhieuNhap;
        public fChiTietNhapKho(int maPN)
        {
            InitializeComponent();
            maPhieuNhap = maPN;
        }

        private void fChiTietNhapKho_Load(object sender, EventArgs e)
        {
            // Lấy phiếu nhập theo mã
            var phieu = db.PhieuNhapKhoes.FirstOrDefault(p => p.MaPN == maPhieuNhap);
            if (phieu == null)
            {
                MessageBox.Show("Không tìm thấy phiếu nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hiển thị thông tin chung
            lblMaPN.Text = phieu.MaPN.ToString();
            lblMaNV.Text = phieu.MaNV;

            // Định dạng ngày nhập dạng dd/MM/yyyy (nếu có)
            if (phieu.NgayNhap != null)
                lblNgayNhap.Text = ((DateTime)phieu.NgayNhap).ToString("dd/MM/yyyy");
            else
                lblNgayNhap.Text = "";

            // Định dạng tổng chi phí có dấu phân cách và đơn vị VNĐ
            lblTongChiPhi.Text = string.Format("{0:#,##0} VNĐ", phieu.TongTien);


            // Lấy tên nhân viên
            var nhanvien = db.NhanViens.FirstOrDefault(nv => nv.MaNV == phieu.MaNV);
            lblTenNV.Text = nhanvien != null ? nhanvien.TenNV : "(Không rõ)";

            // Hiển thị danh sách chi tiết
            /*var dsChiTiet = db.ChiTietPhieuNhaps
                .Where(ct => ct.MaPN == maPhieuNhap)
                .Select(ct => new
                {
                    ct.MaNL,
                    ct.NguyenLieu.TenNL,
                    ct.SoLuongNhap,
                    DonGiaNhap = ct.DonGiaNhap,
                    ThanhTien = ct.SoLuongNhap * ct.DonGiaNhap
                })
                .ToList();

            dtgvChiTietNhapKho.DataSource = dsChiTiet;
            dtgvChiTietNhapKho.Columns["DonGiaNhap"].DefaultCellStyle.Format = "#,##0 VNĐ";
            dtgvChiTietNhapKho.Columns["ThanhTien"].DefaultCellStyle.Format = "#,##0 VNĐ";

            dtgvChiTietNhapKho.Columns[0].HeaderText = "Mã NL";
            dtgvChiTietNhapKho.Columns[1].HeaderText = "Tên nguyên liệu";
            dtgvChiTietNhapKho.Columns[2].HeaderText = "Số lượng nhập";
            dtgvChiTietNhapKho.Columns[3].HeaderText = "Đơn giá nhập";
            dtgvChiTietNhapKho.Columns[4].HeaderText = "Thành tiền";*/
        }
    }
}
