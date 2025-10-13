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

            // Tùy chọn: Đặt tiêu đề cột rõ ràng hơn
           
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


        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string maDU = txtMaDU.Text.Trim(); // MaDU là VARCHAR(10)
                int maNL = int.Parse(txtMaNL.Text); // MaNL là INT
                double soLuongDung = double.Parse(txtSoLuongCanDung.Text); // FLOAT

                // Tạo đối tượng mới
                CongThucDoUong ct = new CongThucDoUong()
                {
                    MaDU = maDU,
                    MaNL = maNL,
                    SoLuongDung = soLuongDung
                };

                // Thêm vào CSDL
                db.CongThucDoUongs.Add(ct);
                db.SaveChanges();

                // Load lại dữ liệu
                LoadDataCongThucDoUong();
                MessageBox.Show("Thêm công thức thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
        }
    }
}
