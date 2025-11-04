using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace JazzCoffe
{
    public partial class TableManeger : Form
    {
        // Tạo ở đầu class
        private Dictionary<string, List<DoUongDaChon>> hoaDonTamDict = new Dictionary<string, List<DoUongDaChon>>();
        private string maBanDangChon = null;
        Dictionary<string, List<DoUongDaChon>> hoaDonTamTheoBan = new Dictionary<string, List<DoUongDaChon>>();
        private Ban banDangChon ;
        private bool isLoading = false;
        private List<DoUongDaChon> danhSachChon = new List<DoUongDaChon>();
        private List<DoUong> danhSachMenu = new List<DoUong>();
        private int currentSelectedRowIndex = -1; // Lưu chỉ số hàng được chọn
        private DoUongDaChon doUongDangChon = null;
        // private string tenDangNhap;
        private string maNV;
        private string matKhau;
        string chucVu;


        public TableManeger(string maNV, string matKhau, string chucVu)
        {
            InitializeComponent();
            //this.tenDangNhap = tenDangNhap;
            this.maNV = maNV;
            this.matKhau = matKhau;
            this.chucVu = chucVu;
            PhanQuyenNguoiDung();
        }

        private void PhanQuyenNguoiDung()
        {
            // Nếu là nhân viên bình thường
            if (chucVu == "Nhân viên")
            {
                // ✅ Hiện các mục được phép
                đổiMậtKhẩuToolStripMenuItem.Visible = true;
                chấmCôngToolStripMenuItem.Visible = true;
                kháchHàngToolStripMenuItem.Visible = true;

                // ❌ Ẩn các mục quản trị
                quảnLýNhânViênToolStripMenuItem.Visible = false;
                thốngKêToolStripMenuItem.Visible = false;
                danhMụcToolStripMenuItem.Visible = false;
            }
            else if (chucVu == "Quản trị viên")
            {
                // ✅ Hiện toàn bộ
                đổiMậtKhẩuToolStripMenuItem.Visible = true;
                chấmCôngToolStripMenuItem.Visible = true;
                kháchHàngToolStripMenuItem.Visible = true;
                quảnLýNhânViênToolStripMenuItem.Visible = true;
                thốngKêToolStripMenuItem.Visible = true;
                danhMụcToolStripMenuItem.Visible = true;
            }
            else
            {
                // Trường hợp không xác định -> ẩn hết cho an toàn
                đổiMậtKhẩuToolStripMenuItem.Visible = true;
                chấmCôngToolStripMenuItem.Visible = false;
                kháchHàngToolStripMenuItem.Visible = false;
                quảnLýNhânViênToolStripMenuItem.Visible = false;
                thốngKêToolStripMenuItem.Visible = false;
                danhMụcToolStripMenuItem.Visible = false;
            }
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDoiMatKhau doiMK = new fDoiMatKhau(maNV, matKhau);
            doiMK.ShowDialog();
        }
        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fNhanVien nhanVien = new fNhanVien();
            nhanVien.ShowDialog(); // Mở dưới dạng hộp thoại
        }

        private void Loaidouong_Click(object sender, EventArgs e)
        {
            fDanhmucloaidouong loaidouong = new fDanhmucloaidouong();
            loaidouong.ShowDialog();
        }

        private void Douong_Click(object sender, EventArgs e)
        {
            fDanhmucdouong douong = new fDanhmucdouong();
            douong.ShowDialog();
        }

        private void Ban_Click(object sender, EventArgs e)
        {
            fBan ban = new fBan();
            ban.ShowDialog();
        }

        private void QLKhachHang_Click(object sender, EventArgs e)
        {
            fKhachhang khachhang = new fKhachhang();
            khachhang.ShowDialog();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fHoaDon hoaDon = new fHoaDon();
            hoaDon.ShowDialog();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private void LoadDanhSachBan()
        {
            listView1.Items.Clear(); // Xóa bàn cũ (nếu có)
            listView1.LargeImageList = imageList1;
            listView1.View = View.LargeIcon;


            using (var context = new QuanLyCafeEntities2())
            {
                var dsBan = context.Bans.ToList();

                foreach (var ban in dsBan)
                {
                    ListViewItem item = new ListViewItem("Bàn " + ban.MaBan);
                    item.Tag = ban.MaBan;

                    if (ban.TrangThai == "Trống")
                        item.ImageIndex = 0; // hình màu xanh trong ImageList
                    else
                        item.ImageIndex = 1; // hình màu hồng trong ImageList

                    listView1.Items.Add(item);
                }
            }
        }
        private void LoadDanhSachDoUong()
        {
            using (var context = new QuanLyCafeEntities2())
            {
                var dsDoUong = (from du in context.DoUongs
                                join loai in context.LoaiDoUongs
                                on du.MaLoai equals loai.MaLoai
                                select new
                                {
                                    du.MaDU,
                                    du.TenDU,
                                    TenLoai = loai.TenLoai,  // 🟢 Thay vì MaLoai
                                    du.DonGia
                                }).ToList();

                dtgvMenuQuanLyCaPhe.DataSource = dsDoUong;

                //  Format cột DonGia (đảm bảo cột tồn tại mới format)
                if (dtgvMenuQuanLyCaPhe.Columns["DonGia"] != null)
                {
                    //dtgvMenuQuanLyCaPhe.Columns["DonGia"].DefaultCellStyle.Format = "N0"; // số nguyên có dấu phẩy
                    dtgvMenuQuanLyCaPhe.Columns["DonGia"].DefaultCellStyle.Format = "#,##0 'VNĐ'";                                                                     // hoặc nếu muốn có đơn vị:
                    // dtgvMenuQuanLyCaPhe.Columns["DonGia"].DefaultCellStyle.Format = "#,##0 'VNĐ'";
                }
            }
        }

        private void QLquancafeLoad(object sender, EventArgs e)
        {
            // 1. Cài đặt ListView để hiển thị ảnh lớn
            listView1.View = View.LargeIcon;
            listView1.LargeImageList = imageList1;

            // 2. Tải danh sách bàn từ CSDL và hiển thị
            LoadDanhSachBan();

            // 3. Tải danh sách đồ uống lên menu
            LoadDanhSachDoUong();

            // 4. Gán các sự kiện xử lý tương tác
            dtgvMenuQuanLyCaPhe.CellClick += dtgvMenuQuanLyCaPhe_CellClick;
            btAddNew.Click -= btAddNew_Click;
            btAddNew.Click += btAddNew_Click;
            dtgvHoaDonTam.CellValueChanged += dtgvHoaDonTam_CellValueChanged;

            // 5. Hiển thị tên nhân viên thu ngân
            using (var context = new QuanLyCafeEntities2())
            {
                var nv = context.NhanViens.FirstOrDefault(n => n.MaNV == maNV);
                if (nv != null)
                {
                    txtNhanVienThuNgan.Text = nv.TenNV;
                }
            }
        }


        private void dtgvMenuQuanLyCaPhe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgvHoaDonTam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dtgvHoaDonTam.SelectedRows.Count > 0)
            {
                string maDU = dtgvHoaDonTam.SelectedRows[0].Cells["MaDU"].Value.ToString();
                danhSachChon.RemoveAll(d => d.MaDU == maDU);

                dtgvHoaDonTam.DataSource = null;
                dtgvHoaDonTam.DataSource = danhSachChon;

                TinhTongTien();
            }

        }

        public class DoUongDaChon
        {
            public string MaDU { get; set; }
            public string TenDU { get; set; }
            public string TenLoai { get; set; }
            public decimal DonGia { get; set; }
            public int SoLuong { get; set; }
            public int ThanhTien => (int)(SoLuong * DonGia);
        }
        private void dtgvMenuQuanLyCaPhe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dtgvMenuQuanLyCaPhe.Rows[e.RowIndex];
                string maDU = row.Cells["MaDU"].Value.ToString();
                string tenDU = row.Cells["TenDU"].Value.ToString();
                string tenLoai = row.Cells["TenLoai"].Value.ToString();
                int donGia = Convert.ToInt32(row.Cells["DonGia"].Value);

                // Gán vào biến toàn cục
                doUongDangChon = new DoUongDaChon
                {
                    MaDU = maDU,
                    TenDU = tenDU,
                    TenLoai = tenLoai,
                    DonGia = donGia
                };
            }
        }

        private void CapNhatDtgvHoaDonTam()
        {
            dtgvHoaDonTam.Rows.Clear(); // Chỉ xóa khi không dùng DataSource

            if (hoaDonTamTheoBan.ContainsKey(maBanDangChon))
            {
                foreach (var item in hoaDonTamTheoBan[maBanDangChon])
                {
                    
                    dtgvHoaDonTam.Rows.Add(item.TenDU, item.TenLoai, item.DonGia, item.SoLuong);
                }
            }
        }

        private void CapNhatDanhSachDaChon()
        {
            if (dtgvMenuQuanLyCaPhe.SelectedRows.Count > 0 && maBanDangChon != null)
            {
                var row = dtgvMenuQuanLyCaPhe.SelectedRows[0];
                string maDU = row.Cells["MaDU"].Value.ToString();
                string tenDU = row.Cells["TenDU"].Value.ToString();
                string tenLoai = row.Cells["TenLoai"].Value.ToString();
                int donGia = Convert.ToInt32(row.Cells["DonGia"].Value);
                int soLuong = (int)cbxSoLuong.Value;

                // Tạo danh sách nếu chưa có
                if (!hoaDonTamTheoBan.ContainsKey(maBanDangChon))
                    hoaDonTamTheoBan[maBanDangChon] = new List<DoUongDaChon>();

                var danhSachChon = hoaDonTamTheoBan[maBanDangChon];

                // Kiểm tra món đã tồn tại chưa
                var daCo = danhSachChon.FirstOrDefault(x => x.MaDU == maDU);
                if (daCo != null)
                {
                    daCo.SoLuong += soLuong;
                }
                else
                {
                    danhSachChon.Add(new DoUongDaChon
                    {
                        MaDU = maDU,
                        TenDU = tenDU,
                        TenLoai = tenLoai,
                        DonGia = donGia,
                        SoLuong = soLuong
                    });
                }

                // Hiển thị lại
                CapNhatDtgvHoaDonTam();
                TinhTongTien();
            }
        }

        private void btAddNew_Click(object sender, EventArgs e)
        {
            Console.WriteLine("===> Sự kiện btAddNew_Click được gọi");
            if (string.IsNullOrEmpty(maBanDangChon))
            {
                MessageBox.Show("Vui lòng chọn bàn!");
                return;
            }

            if (dtgvMenuQuanLyCaPhe.SelectedRows.Count > 0)
            {
                var row = dtgvMenuQuanLyCaPhe.SelectedRows[0];
                string maDU = row.Cells["MaDU"].Value.ToString();
                string tenDU = row.Cells["TenDU"].Value.ToString();
                string tenLoai = row.Cells["TenLoai"].Value.ToString();
                decimal donGia = Convert.ToDecimal(row.Cells["DonGia"].Value);
                int soLuong = int.Parse(cbxSoLuong.Text);

                if (!hoaDonTamTheoBan.ContainsKey(maBanDangChon))
                    hoaDonTamTheoBan[maBanDangChon] = new List<DoUongDaChon>();

                danhSachChon = hoaDonTamTheoBan[maBanDangChon];

                var daCo = danhSachChon.FirstOrDefault(d => d.MaDU == maDU);
                if (daCo != null)
                    daCo.SoLuong += soLuong;
                else
                {
                    danhSachChon.Add(new DoUongDaChon
                    {
                        MaDU = maDU,
                        TenDU = tenDU,
                        TenLoai = tenLoai,
                        DonGia = donGia,
                        SoLuong = soLuong
                    });
                    
                }
                dtgvHoaDonTam.DataSource = null;
                dtgvHoaDonTam.DataSource = danhSachChon;

                if (dtgvHoaDonTam.Columns.Contains("DonGia"))
                    dtgvHoaDonTam.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                if (dtgvHoaDonTam.Columns.Contains("ThanhTien"))
                    dtgvHoaDonTam.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";

                TinhTongTien();

                // Cập nhật trạng thái bàn
                using (var context = new QuanLyCafeEntities2())
                {
                    int maBan = int.Parse(maBanDangChon);
                    var ban = context.Bans.FirstOrDefault(b => b.MaBan == maBan);
                    if (ban != null && ban.TrangThai != "Có khách")
                    {
                        ban.TrangThai = "Có khách";
                        context.SaveChanges();
                        LoadDanhSachBan();
                    }
                }
                Console.WriteLine($"So luong them: {soLuong}");

            }
        }
        private int TinhTongTien()
        {
            int tongTien = 0;

            foreach (DataGridViewRow row in dtgvHoaDonTam.Rows)
            {
                if (row.Cells["ThanhTien"].Value != null &&
                    int.TryParse(row.Cells["ThanhTien"].Value.ToString(), out int thanhTien))
                {
                    tongTien += thanhTien;
                }
            }

            lblTongTien.Text = tongTien.ToString("N0") + " VND";
            return tongTien;
        }

        private void dtgvHoaDonTam_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dtgvHoaDonTam.Columns["DonGia"] != null)
                dtgvHoaDonTam.Columns["DonGia"].DefaultCellStyle.Format = "N0";

            if (dtgvHoaDonTam.Columns["ThanhTien"] != null)
                dtgvHoaDonTam.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";

            if (dtgvHoaDonTam.Columns["MaDU"] != null)
                dtgvHoaDonTam.Columns["MaDU"].Visible = false;
        }

        private void dtgvHoaDonTam_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dtgvHoaDonTam.Rows[e.RowIndex];

                if (decimal.TryParse(row.Cells["DonGia"].Value?.ToString(), out decimal donGia) &&
                    int.TryParse(row.Cells["SoLuong"].Value?.ToString(), out int soLuong))
                {
                    row.Cells["ThanhTien"].Value = donGia * soLuong;
                }
            }

            TinhTongTien(); // cập nhật tổng tiền sau khi chỉnh sửa
        }

        private void lblTongTien_Click(object sender, EventArgs e)
        {

        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            QuanLyCafeEntities2 context = new QuanLyCafeEntities2();
            string tenCanTim = txtTimKiem.Text.Trim().ToLower();

            if (!string.IsNullOrEmpty(tenCanTim))
            {
                var ketQua = context.DoUongs
                    .Where(d => d.TenDU.ToLower().Contains(tenCanTim))
                    .Select(d => new
                    {
                        d.MaDU,
                        d.TenDU,
                        d.MaLoai,
                        d.DonGia
                    })
                    .ToList();

                dtgvMenuQuanLyCaPhe.DataSource = ketQua;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên đồ uống cần tìm.");
            }
        }
        private int LayMaBanTuText(string text)
        {
            // "Bàn 4" => 4
            string so = new string(text.Where(char.IsDigit).ToArray());
            if (int.TryParse(so, out int maBan))
            {
                return maBan;
            }
            else
            {
                throw new FormatException("Không thể lấy mã bàn từ chuỗi: " + text);
            }
        }

        // Dưới đây là phần đã điều chỉnh trong sự kiện btPay_Click
        private void btPay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maBanDangChon) || danhSachChon.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bàn và thêm đồ uống trước khi thanh toán.");
                return;
            }

            string tenNhanVien = txtNhanVienThuNgan.Text;
            int maBan = LayMaBanTuText(maBanDangChon);
            DateTime ngay = DateTime.Now;
            int tongTien = TinhTongTien();
            string maNV;

            // 1. Lấy mã nhân viên từ tên
            using (var db = new QuanLyCafeEntities2())
            {
                var nv = db.NhanViens.FirstOrDefault(n => n.TenNV == tenNhanVien);
                if (nv == null)
                {
                    MessageBox.Show("Không tìm thấy nhân viên!");
                    return;
                }
                maNV = nv.MaNV;
            }

            // 2. Kiểm tra tồn kho trước khi tạo hóa đơn
            using (var db = new QuanLyCafeEntities2())
            {
                foreach (var item in danhSachChon)
                {
                    string maDU = item.MaDU;
                    int soLuongDoUong = Convert.ToInt32(item.SoLuong);

                    var congThucList = db.CongThucDoUongs.Where(ct => ct.MaDU == maDU).ToList();

                    foreach (var ct in congThucList)
                    {
                        decimal soLuongDungTrongCT = Convert.ToDecimal(ct.SoLuongDung);
                        decimal soLuongTru = Math.Round(soLuongDoUong * soLuongDungTrongCT, 4);

                        var nguyenLieu = db.NguyenLieux.FirstOrDefault(nl => nl.MaNL == ct.MaNL);
                        if (nguyenLieu != null)
                        {
                            decimal tonHienTai = Convert.ToDecimal(nguyenLieu.SoLuongTon);
                            decimal tonMoi = Math.Round(tonHienTai - soLuongTru, 4);

                            // 🔹 Nếu nguyên liệu đã hết hoặc không đủ => chặn thanh toán
                            if (tonMoi < 0)
                            {
                                MessageBox.Show(
                                    $"Nguyên liệu '{nguyenLieu.TenNL}' không đủ để pha chế món '{item.TenDU}'.\n" +
                                    $"Hiện còn {tonHienTai:F4} {nguyenLieu.DonViTinh}, cần {soLuongTru:F4} {nguyenLieu.DonViTinh}.",
                                    "Nguyên liệu không đủ",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                                return; // ❌ Dừng thanh toán
                            }
                            if (tonMoi == 0)
                            {
                                MessageBox.Show(
                                    $"Nguyên liệu '{nguyenLieu.TenNL}' đã hết!\nKhông thể thanh toán hóa đơn này.",
                                    "Nguyên liệu hết hàng",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                                return; // ❌ Dừng thanh toán
                            }
                        }
                    }
                }
            }

            // 3. Nếu đủ nguyên liệu -> tiến hành lưu hóa đơn và trừ tồn kho
            using (var db = new QuanLyCafeEntities2())
            {
                HoaDon hoaDon = new HoaDon()
                {
                    NgayLap = ngay,
                    MaNV = maNV,
                    MaBan = maBan,
                    TongTien = tongTien,
                    TrangThai = "Đã thanh toán"
                };
                db.HoaDons.Add(hoaDon);
                db.SaveChanges();

                int maHD = hoaDon.MaHD;

                // Tạo khách hàng mặc định
                KhachHang kh = new KhachHang()
                {
                    MaKH = maHD,
                    TenKH = "Khách lẻ",
                    SDT = "",
                    DiaChi = ""
                };
                db.KhachHangs.Add(kh);
                db.SaveChanges();

                hoaDon.MaKH = maHD;
                db.SaveChanges();

                // 🧩 4. Cập nhật tồn kho nguyên liệu
                List<string> danhSachCanhBao = new List<string>();

                foreach (var item in danhSachChon)
                {
                    string maDU = item.MaDU;
                    int soLuongDoUong = Convert.ToInt32(item.SoLuong);

                    var congThucList = db.CongThucDoUongs.Where(ct => ct.MaDU == maDU).ToList();

                    foreach (var ct in congThucList)
                    {
                        decimal soLuongDungTrongCT = Convert.ToDecimal(ct.SoLuongDung);
                        decimal soLuongTru = Math.Round(soLuongDoUong * soLuongDungTrongCT, 4);

                        var nguyenLieu = db.NguyenLieux.FirstOrDefault(nl => nl.MaNL == ct.MaNL);
                        if (nguyenLieu != null)
                        {
                            decimal tonHienTai = Convert.ToDecimal(nguyenLieu.SoLuongTon);
                            decimal tonMoi = Math.Round(tonHienTai - soLuongTru, 4);

                            nguyenLieu.SoLuongTon = (float)tonMoi;

                            // Thêm cảnh báo nếu gần hết
                            if (tonMoi <= Convert.ToDecimal(nguyenLieu.SoLuongToiThieu))
                            {
                                string canhBao = $"- {nguyenLieu.TenNL}: còn {tonMoi:F4} {nguyenLieu.DonViTinh} (Tối thiểu: {nguyenLieu.SoLuongToiThieu})";
                                danhSachCanhBao.Add(canhBao);
                            }
                        }
                    }
                }

                db.SaveChanges();

                // 🧾 5. Hiển thị form chi tiết hóa đơn
                fChiTietHoaDon chiTiet = new fChiTietHoaDon(
                    maHD: hoaDon.MaHD,
                    tenNhanVien: tenNhanVien,
                    maBan: maBan.ToString(),
                    ngay: ngay,
                    tongTien: tongTien,
                    danhSach: danhSachChon
                );
                chiTiet.ShowDialog();

                // ⚠️ 6. Hiển thị cảnh báo nếu có nguyên liệu sắp hết
                if (danhSachCanhBao.Count > 0)
                {
                    string noiDung = "⚠️ Các nguyên liệu sau sắp hết, cần nhập thêm:\n\n" +
                                     string.Join("\n", danhSachCanhBao);

                    MessageBox.Show(noiDung, "Cảnh báo kho", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            // 7. Xóa hóa đơn tạm
            if (hoaDonTamTheoBan.ContainsKey(maBanDangChon))
            {
                hoaDonTamTheoBan.Remove(maBanDangChon);
            }

            // 8. Đổi trạng thái bàn thành "Trống"
            using (var context = new QuanLyCafeEntities2())
            {
                var ban = context.Bans.FirstOrDefault(b => b.MaBan.ToString() == maBanDangChon);
                if (ban != null)
                {
                    ban.TrangThai = "Trống";
                    context.SaveChanges();
                }
            }

            // 9. Làm mới giao diện
            maBanDangChon = "";
            danhSachChon.Clear();
            dtgvHoaDonTam.DataSource = null;
            txtChonBan.Text = "";
            lblTongTien.Text = "0 VND";
            LoadDanhSachBan();

            MessageBox.Show("Thanh toán thành công và đã cập nhật tồn kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void LoadHoaDonTamTheoBan(int maBan)
        {
            using (var db = new QuanLyCafeEntities2())
            {
                var hoaDonChuaThanhToan = db.HoaDons
                    .Where(h => h.MaBan == maBan && h.TrangThai == "Chưa thanh toán")
                    .OrderByDescending(h => h.NgayLap)
                    .FirstOrDefault();

                danhSachChon.Clear();

                if (hoaDonChuaThanhToan != null)
                {
                    var chiTiet = db.ChiTietHoaDons.Where(c => c.MaHD == hoaDonChuaThanhToan.MaHD).ToList();

                    foreach (var item in chiTiet)
                    {
                        var doUong = db.DoUongs.FirstOrDefault(d => d.MaDU == item.MaDU);
                        var loai = db.LoaiDoUongs.FirstOrDefault(l => l.MaLoai == doUong.MaLoai);

                        if (doUong != null && loai != null)
                        {
                            danhSachChon.Add(new DoUongDaChon
                            {
                                MaDU = doUong.MaDU,
                                TenDU = doUong.TenDU,
                                TenLoai = loai.TenLoai,
                                DonGia = (int)(doUong.DonGia ?? 0),
                                SoLuong = item.SoLuong ?? 0
                            });
                        }
                    }

                    dtgvHoaDonTam.DataSource = null;
                    dtgvHoaDonTam.DataSource = danhSachChon;

                    if (dtgvHoaDonTam.Columns.Contains("MaDU"))
                        dtgvHoaDonTam.Columns["MaDU"].Visible = false;

                    dtgvHoaDonTam.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                    dtgvHoaDonTam.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";

                    TinhTongTien();
                }
                else
                {
                    dtgvHoaDonTam.DataSource = null;
                    lblTongTien.Text = "0 VND";
                }
            }
        }

        private void LuuHoaDonTam(string maBan)
        {
            List<DoUongDaChon> dsTam = new List<DoUongDaChon>();

            foreach (DataGridViewRow row in dtgvHoaDonTam.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["TenDU"].Value != null &&
                    row.Cells["TenLoai"].Value != null &&
                    row.Cells["DonGia"].Value != null &&
                    row.Cells["SoLuong"].Value != null)
                {
                    dsTam.Add(new DoUongDaChon
                    {
                        TenDU = row.Cells["TenDU"].Value.ToString(),
                        TenLoai = row.Cells["TenLoai"].Value.ToString(),
                        DonGia = Convert.ToInt32(row.Cells["DonGia"].Value),
                        SoLuong = Convert.ToInt32(row.Cells["SoLuong"].Value),
                        
                    });
                }
            }

            hoaDonTamTheoBan[maBan] = dsTam;
        }

        private void KhoiTaoCotHoaDonTam()
        {
            if (dtgvHoaDonTam.Columns.Count == 0)
            {
                dtgvHoaDonTam.Columns.Add("TenDU", "Tên Đồ Uống");
                dtgvHoaDonTam.Columns.Add("TenLoai", "Loại");
                dtgvHoaDonTam.Columns.Add("DonGia", "Đơn Giá");
                dtgvHoaDonTam.Columns.Add("SoLuong", "Số Lượng");
                dtgvHoaDonTam.Columns.Add("ThanhTien", "Thành Tiền");
            }
        }

        private void HienThiHoaDonTam(string maBan)
        {
            if (hoaDonTamTheoBan.ContainsKey(maBan))
            {
                var danhSach = hoaDonTamTheoBan[maBan]
                    .Select(x => new
                    {
                        x.TenDU,
                        x.TenLoai,
                        x.DonGia,
                        x.SoLuong,
                        ThanhTien = x.DonGia * x.SoLuong
                    }).ToList();

                dtgvHoaDonTam.DataSource = danhSach;
            }
            else
            {
                dtgvHoaDonTam.DataSource = null;
            }

            TinhTongTien();
        }


        private void listView1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    var selectedItem = listView1.SelectedItems[0];
                    string maBan = selectedItem.Tag.ToString();
                    txtChonBan.Text = "Bàn " + maBan;
                }
                string maBanMoi = listView1.SelectedItems[0].Tag.ToString();

                // Nếu đang chọn bàn cũ khác bàn mới → lưu hóa đơn tạm cho bàn cũ
                if (!string.IsNullOrEmpty(maBanDangChon) && maBanDangChon != maBanMoi)
                {
                    LuuHoaDonTam(maBanDangChon); // Lưu danh sách đồ uống hiện tại cho bàn cũ
                }

                // Cập nhật bàn đang chọn
                maBanDangChon = maBanMoi;

                //KhoiTaoCotHoaDonTam();

                // Hiển thị hóa đơn tạm nếu có cho bàn mới
                HienThiHoaDonTam(maBanDangChon);

                // Đặt lại số lượng về 1 (mỗi khi chọn bàn mới)
                cbxSoLuong.Value = 1;

                // (Tùy chọn) Cập nhật tiêu đề, label, hoặc trạng thái giao diện nếu bạn có
                // lblBanDangChon.Text = $"Bàn {maBanDangChon}";
            }
        }

        private void nguye6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fNguyenLieu f = new fNguyenLieu();
            // chỉ định form chính làm cha
            f.ShowDialog(); // hiển thị dạng con trong form chính
        }

        private void nhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fNhapkho f = new fNhapkho();
            f.ShowDialog();
        }

        private void côngThứcPhaChếToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fCongThucDoUong f = new fCongThucDoUong();
            f.ShowDialog();
        }

        private void chấmCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fChamCong f = new fChamCong();
            f.ShowDialog();
        }
    }
}

