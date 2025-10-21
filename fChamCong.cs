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
            ChamCong cc = new ChamCong();
            cc.MaNV = cbMaNV.SelectedValue.ToString();
            cc.NgayLam = dtpNgayLam.Value.Date;
            cc.GioVao = dtpGioVao.Value.TimeOfDay;
            cc.GioRa = dtpGioRa.Value.TimeOfDay;
            cc.TrangThai = txtTrangThai.Text;
            cc.GhiChu = txtGhiChu.Text;

            db.ChamCongs.Add(cc);
            db.SaveChanges();
            LoadChamCong();
            MessageBox.Show("Thêm chấm công thành công!");
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
