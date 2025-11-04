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
    public partial class fChamCong : Form
    {
        QuanLyCafeEntities2 db = new QuanLyCafeEntities2();

        public fChamCong()
        {
            InitializeComponent();

            dtpGioVao.Format = DateTimePickerFormat.Custom;
            dtpGioVao.CustomFormat = "hh:mm tt";   // 12h format có AM/PM
            dtpGioVao.ShowUpDown = true;           // Dạng spinner, không có lịch

            dtpGioRa.Format = DateTimePickerFormat.Custom;
            dtpGioRa.CustomFormat = "hh:mm tt";
            dtpGioRa.ShowUpDown = true;
        }

        private void fChamCong_Load(object sender, EventArgs e)
        {
            cbMaNV.DataSource = db.NhanViens.ToList();
            cbMaNV.DisplayMember = "MaNV";
            cbMaNV.ValueMember = "MaNV";

            LoadChamCong();
        }

        private void LoadChamCong()
        {
            var list = from cc in db.ChamCongs
                       join nv in db.NhanViens on cc.MaNV equals nv.MaNV
                       select new
                       {
                           cc.MaCC,
                           cc.MaNV,
                           nv.TenNV,
                           cc.NgayLam,
                           cc.GioVao,
                           cc.GioRa,
                           cc.SoGioLam,
                           cc.TrangThai,
                           cc.GhiChu
                       };

            dtgvChamCong.DataSource = list.ToList();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ giao diện
                string maNV = cbMaNV.SelectedValue.ToString();
                DateTime ngayLam = dtpNgayLam.Value.Date;
                TimeSpan gioVao = dtpGioVao.Value.TimeOfDay;
                TimeSpan gioRa = dtpGioRa.Value.TimeOfDay;
                string trangThai = txtTrangThai.Text.Trim();
                string ghiChu = txtGhiChu.Text.Trim();

                // 🔹 Kiểm tra hợp lệ giờ vào - giờ ra
                if (gioVao == gioRa)
                {
                    MessageBox.Show("Giờ vào không được trùng với giờ ra!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (gioRa < gioVao)
                {
                    MessageBox.Show("Giờ ra không được sớm hơn giờ vào!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔹 Kiểm tra ngày làm có phải là hôm nay không
                DateTime ngayHienTai = DateTime.Now.Date;
                if (ngayLam != ngayHienTai)
                {
                    MessageBox.Show("Ngày chấm công phải là ngày hiện tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔹 Tạo đối tượng chấm công mới
                ChamCong cc = new ChamCong()
                {
                    MaNV = maNV,
                    NgayLam = ngayLam,
                    GioVao = gioVao,
                    GioRa = gioRa,
                    TrangThai = trangThai,
                    GhiChu = ghiChu
                };

                // 🔹 Lưu vào cơ sở dữ liệu
                db.ChamCongs.Add(cc);
                db.SaveChanges();

                LoadChamCong();
                MessageBox.Show("Thêm chấm công thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm chấm công: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dtgvChamCong.CurrentRow != null)
            {
                int maCC = Convert.ToInt32(dtgvChamCong.CurrentRow.Cells["MaCC"].Value);
                ChamCong cc = db.ChamCongs.FirstOrDefault(x => x.MaCC == maCC);

                if (cc != null)
                {
                    cc.NgayLam = dtpNgayLam.Value.Date;
                    cc.GioVao = dtpGioVao.Value.TimeOfDay;
                    cc.GioRa = dtpGioRa.Value.TimeOfDay;
                    cc.TrangThai = txtTrangThai.Text;
                    cc.GhiChu = txtGhiChu.Text;

                    db.SaveChanges();
                    LoadChamCong();
                    MessageBox.Show("Cập nhật thành công!");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtgvChamCong.CurrentRow != null)
            {
                int maCC = Convert.ToInt32(dtgvChamCong.CurrentRow.Cells["MaCC"].Value);
                ChamCong cc = db.ChamCongs.FirstOrDefault(x => x.MaCC == maCC);

                if (cc != null)
                {
                    db.ChamCongs.Remove(cc);
                    db.SaveChanges();
                    LoadChamCong();
                    MessageBox.Show("Xóa chấm công thành công!");
                }
            }
        }

        private void cbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maNV = cbMaNV.SelectedValue.ToString();
            var nv = db.NhanViens.FirstOrDefault(x => x.MaNV == maNV);
            if (nv != null)
                txtTenNV.Text = nv.TenNV;
        }
    }
}
