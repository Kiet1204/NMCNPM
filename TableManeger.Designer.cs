namespace JazzCoffe
{
    partial class TableManeger
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableManeger));
            this.mnTableManeger = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đổiMậtKhẩuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bánhNgọtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bànToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nguye6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.côngThứcPhaChếToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýKháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbChoice = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lbQuantity = new System.Windows.Forms.Label();
            this.cbxSoLuong = new System.Windows.Forms.NumericUpDown();
            this.btAddNew = new System.Windows.Forms.Button();
            this.lbSearchDrink = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.dtgvMenuQuanLyCaPhe = new System.Windows.Forms.DataGridView();
            this.lbNVPay = new System.Windows.Forms.Label();
            this.txtNhanVienThuNgan = new System.Windows.Forms.TextBox();
            this.dtpkToDate = new System.Windows.Forms.DateTimePicker();
            this.btDeleteDrink = new System.Windows.Forms.Button();
            this.dtgvHoaDonTam = new System.Windows.Forms.DataGridView();
            this.lbSum = new System.Windows.Forms.Label();
            this.btPay = new System.Windows.Forms.Button();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.txtChonBan = new System.Windows.Forms.TextBox();
            this.chấmCôngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnTableManeger.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvMenuQuanLyCaPhe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHoaDonTam)).BeginInit();
            this.SuspendLayout();
            // 
            // mnTableManeger
            // 
            this.mnTableManeger.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mnTableManeger.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnTableManeger.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.danhMụcToolStripMenuItem,
            this.kháchHàngToolStripMenuItem,
            this.thốngKêToolStripMenuItem});
            this.mnTableManeger.Location = new System.Drawing.Point(0, 0);
            this.mnTableManeger.Name = "mnTableManeger";
            this.mnTableManeger.Size = new System.Drawing.Size(1194, 33);
            this.mnTableManeger.TabIndex = 0;
            this.mnTableManeger.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đổiMậtKhẩuToolStripMenuItem,
            this.quảnLýNhânViênToolStripMenuItem,
            this.chấmCôngToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(103, 29);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // đổiMậtKhẩuToolStripMenuItem
            // 
            this.đổiMậtKhẩuToolStripMenuItem.Name = "đổiMậtKhẩuToolStripMenuItem";
            this.đổiMậtKhẩuToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.đổiMậtKhẩuToolStripMenuItem.Text = "Đổi mật khẩu";
            this.đổiMậtKhẩuToolStripMenuItem.Click += new System.EventHandler(this.đổiMậtKhẩuToolStripMenuItem_Click);
            // 
            // quảnLýNhânViênToolStripMenuItem
            // 
            this.quảnLýNhânViênToolStripMenuItem.Name = "quảnLýNhânViênToolStripMenuItem";
            this.quảnLýNhânViênToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.quảnLýNhânViênToolStripMenuItem.Text = "Quản lý nhân viên";
            this.quảnLýNhânViênToolStripMenuItem.Click += new System.EventHandler(this.quảnLýNhânViênToolStripMenuItem_Click);
            // 
            // danhMụcToolStripMenuItem
            // 
            this.danhMụcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dToolStripMenuItem,
            this.bánhNgọtToolStripMenuItem,
            this.bànToolStripMenuItem,
            this.nguye6ToolStripMenuItem,
            this.côngThứcPhaChếToolStripMenuItem});
            this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(109, 29);
            this.danhMụcToolStripMenuItem.Text = "Danh mục";
            // 
            // dToolStripMenuItem
            // 
            this.dToolStripMenuItem.Name = "dToolStripMenuItem";
            this.dToolStripMenuItem.Size = new System.Drawing.Size(264, 34);
            this.dToolStripMenuItem.Text = "Loại đồ uống ";
            this.dToolStripMenuItem.Click += new System.EventHandler(this.Loaidouong_Click);
            // 
            // bánhNgọtToolStripMenuItem
            // 
            this.bánhNgọtToolStripMenuItem.Name = "bánhNgọtToolStripMenuItem";
            this.bánhNgọtToolStripMenuItem.Size = new System.Drawing.Size(264, 34);
            this.bánhNgọtToolStripMenuItem.Text = "Đồ uống";
            this.bánhNgọtToolStripMenuItem.Click += new System.EventHandler(this.Douong_Click);
            // 
            // bànToolStripMenuItem
            // 
            this.bànToolStripMenuItem.Name = "bànToolStripMenuItem";
            this.bànToolStripMenuItem.Size = new System.Drawing.Size(264, 34);
            this.bànToolStripMenuItem.Text = "Bàn";
            this.bànToolStripMenuItem.Click += new System.EventHandler(this.Ban_Click);
            // 
            // nguye6ToolStripMenuItem
            // 
            this.nguye6ToolStripMenuItem.Name = "nguye6ToolStripMenuItem";
            this.nguye6ToolStripMenuItem.Size = new System.Drawing.Size(264, 34);
            this.nguye6ToolStripMenuItem.Text = "Nguyên liệu";
            this.nguye6ToolStripMenuItem.Click += new System.EventHandler(this.nguye6ToolStripMenuItem_Click);
            // 
            // côngThứcPhaChếToolStripMenuItem
            // 
            this.côngThứcPhaChếToolStripMenuItem.Name = "côngThứcPhaChếToolStripMenuItem";
            this.côngThứcPhaChếToolStripMenuItem.Size = new System.Drawing.Size(264, 34);
            this.côngThứcPhaChếToolStripMenuItem.Text = "Công thức pha chế";
            this.côngThứcPhaChếToolStripMenuItem.Click += new System.EventHandler(this.côngThứcPhaChếToolStripMenuItem_Click);
            // 
            // kháchHàngToolStripMenuItem
            // 
            this.kháchHàngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýKháchHàngToolStripMenuItem});
            this.kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            this.kháchHàngToolStripMenuItem.Size = new System.Drawing.Size(120, 29);
            this.kháchHàngToolStripMenuItem.Text = "Khách hàng";
            // 
            // quảnLýKháchHàngToolStripMenuItem
            // 
            this.quảnLýKháchHàngToolStripMenuItem.Name = "quảnLýKháchHàngToolStripMenuItem";
            this.quảnLýKháchHàngToolStripMenuItem.Size = new System.Drawing.Size(271, 34);
            this.quảnLýKháchHàngToolStripMenuItem.Text = "Quản lý khách hàng";
            this.quảnLýKháchHàngToolStripMenuItem.Click += new System.EventHandler(this.QLKhachHang_Click);
            // 
            // thốngKêToolStripMenuItem
            // 
            this.thốngKêToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hóaĐơnToolStripMenuItem,
            this.nhậpKhoToolStripMenuItem});
            this.thốngKêToolStripMenuItem.Name = "thốngKêToolStripMenuItem";
            this.thốngKêToolStripMenuItem.Size = new System.Drawing.Size(102, 29);
            this.thốngKêToolStripMenuItem.Text = "Thống kê";
            // 
            // hóaĐơnToolStripMenuItem
            // 
            this.hóaĐơnToolStripMenuItem.Name = "hóaĐơnToolStripMenuItem";
            this.hóaĐơnToolStripMenuItem.Size = new System.Drawing.Size(192, 34);
            this.hóaĐơnToolStripMenuItem.Text = "Lợi nhuận";
            this.hóaĐơnToolStripMenuItem.Click += new System.EventHandler(this.hóaĐơnToolStripMenuItem_Click);
            // 
            // nhậpKhoToolStripMenuItem
            // 
            this.nhậpKhoToolStripMenuItem.Name = "nhậpKhoToolStripMenuItem";
            this.nhậpKhoToolStripMenuItem.Size = new System.Drawing.Size(192, 34);
            this.nhậpKhoToolStripMenuItem.Text = "Nhập kho";
            this.nhậpKhoToolStripMenuItem.Click += new System.EventHandler(this.nhậpKhoToolStripMenuItem_Click);
            // 
            // lbChoice
            // 
            this.lbChoice.AutoSize = true;
            this.lbChoice.Location = new System.Drawing.Point(13, 53);
            this.lbChoice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbChoice.Name = "lbChoice";
            this.lbChoice.Size = new System.Drawing.Size(82, 17);
            this.lbChoice.TabIndex = 1;
            this.lbChoice.Text = "Chọn bàn:";
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(0, 117);
            this.listView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(346, 491);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.Click += new System.EventHandler(this.listView1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "hinh-nen-mau-xanh_3.jpg");
            this.imageList1.Images.SetKeyName(1, "mau-hong-canh-sen.jpg");
            // 
            // lbQuantity
            // 
            this.lbQuantity.AutoSize = true;
            this.lbQuantity.Location = new System.Drawing.Point(343, 44);
            this.lbQuantity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbQuantity.Name = "lbQuantity";
            this.lbQuantity.Size = new System.Drawing.Size(77, 17);
            this.lbQuantity.TabIndex = 4;
            this.lbQuantity.Text = "Số lượng:";
            // 
            // cbxSoLuong
            // 
            this.cbxSoLuong.Location = new System.Drawing.Point(415, 42);
            this.cbxSoLuong.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbxSoLuong.Name = "cbxSoLuong";
            this.cbxSoLuong.Size = new System.Drawing.Size(80, 23);
            this.cbxSoLuong.TabIndex = 5;
            // 
            // btAddNew
            // 
            this.btAddNew.BackColor = System.Drawing.Color.OrangeRed;
            this.btAddNew.Location = new System.Drawing.Point(496, 35);
            this.btAddNew.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btAddNew.Name = "btAddNew";
            this.btAddNew.Size = new System.Drawing.Size(175, 35);
            this.btAddNew.TabIndex = 6;
            this.btAddNew.Text = "Thêm mới";
            this.btAddNew.UseVisualStyleBackColor = false;
            this.btAddNew.Click += new System.EventHandler(this.btAddNew_Click);
            // 
            // lbSearchDrink
            // 
            this.lbSearchDrink.AutoSize = true;
            this.lbSearchDrink.Location = new System.Drawing.Point(343, 88);
            this.lbSearchDrink.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSearchDrink.Name = "lbSearchDrink";
            this.lbSearchDrink.Size = new System.Drawing.Size(168, 17);
            this.lbSearchDrink.TabIndex = 7;
            this.lbSearchDrink.Text = "Tìm theo tên đồ uống:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(503, 87);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(168, 23);
            this.txtTimKiem.TabIndex = 8;
            // 
            // btSearch
            // 
            this.btSearch.BackColor = System.Drawing.Color.OrangeRed;
            this.btSearch.Location = new System.Drawing.Point(686, 79);
            this.btSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(175, 35);
            this.btSearch.TabIndex = 9;
            this.btSearch.Text = "Tìm";
            this.btSearch.UseVisualStyleBackColor = false;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // dtgvMenuQuanLyCaPhe
            // 
            this.dtgvMenuQuanLyCaPhe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvMenuQuanLyCaPhe.Location = new System.Drawing.Point(346, 116);
            this.dtgvMenuQuanLyCaPhe.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtgvMenuQuanLyCaPhe.Name = "dtgvMenuQuanLyCaPhe";
            this.dtgvMenuQuanLyCaPhe.RowHeadersWidth = 62;
            this.dtgvMenuQuanLyCaPhe.RowTemplate.Height = 28;
            this.dtgvMenuQuanLyCaPhe.Size = new System.Drawing.Size(452, 492);
            this.dtgvMenuQuanLyCaPhe.TabIndex = 10;
            this.dtgvMenuQuanLyCaPhe.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvMenuQuanLyCaPhe_CellContentClick);
            // 
            // lbNVPay
            // 
            this.lbNVPay.AutoSize = true;
            this.lbNVPay.Location = new System.Drawing.Point(779, 47);
            this.lbNVPay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNVPay.Name = "lbNVPay";
            this.lbNVPay.Size = new System.Drawing.Size(155, 17);
            this.lbNVPay.TabIndex = 12;
            this.lbNVPay.Text = "Nhân viên thu ngân:";
            // 
            // txtNhanVienThuNgan
            // 
            this.txtNhanVienThuNgan.Location = new System.Drawing.Point(932, 44);
            this.txtNhanVienThuNgan.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNhanVienThuNgan.Name = "txtNhanVienThuNgan";
            this.txtNhanVienThuNgan.Size = new System.Drawing.Size(155, 23);
            this.txtNhanVienThuNgan.TabIndex = 14;
            // 
            // dtpkToDate
            // 
            this.dtpkToDate.Location = new System.Drawing.Point(869, 72);
            this.dtpkToDate.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dtpkToDate.Name = "dtpkToDate";
            this.dtpkToDate.Size = new System.Drawing.Size(218, 23);
            this.dtpkToDate.TabIndex = 15;
            // 
            // btDeleteDrink
            // 
            this.btDeleteDrink.BackColor = System.Drawing.Color.OrangeRed;
            this.btDeleteDrink.Location = new System.Drawing.Point(806, 117);
            this.btDeleteDrink.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btDeleteDrink.Name = "btDeleteDrink";
            this.btDeleteDrink.Size = new System.Drawing.Size(175, 35);
            this.btDeleteDrink.TabIndex = 16;
            this.btDeleteDrink.Text = "Xóa đồ uống";
            this.btDeleteDrink.UseVisualStyleBackColor = false;
            this.btDeleteDrink.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtgvHoaDonTam
            // 
            this.dtgvHoaDonTam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvHoaDonTam.Location = new System.Drawing.Point(797, 156);
            this.dtgvHoaDonTam.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtgvHoaDonTam.Name = "dtgvHoaDonTam";
            this.dtgvHoaDonTam.RowHeadersWidth = 62;
            this.dtgvHoaDonTam.RowTemplate.Height = 28;
            this.dtgvHoaDonTam.Size = new System.Drawing.Size(397, 452);
            this.dtgvHoaDonTam.TabIndex = 17;
            this.dtgvHoaDonTam.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvMenuQuanLyCaPhe_CellClick);
            this.dtgvHoaDonTam.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvHoaDonTam_CellContentClick);
            this.dtgvHoaDonTam.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgvHoaDonTam_DataBindingComplete);
            // 
            // lbSum
            // 
            this.lbSum.AutoSize = true;
            this.lbSum.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSum.Location = new System.Drawing.Point(759, 632);
            this.lbSum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSum.Name = "lbSum";
            this.lbSum.Size = new System.Drawing.Size(77, 16);
            this.lbSum.TabIndex = 18;
            this.lbSum.Text = "Tổng tiền:";
            // 
            // btPay
            // 
            this.btPay.Location = new System.Drawing.Point(991, 623);
            this.btPay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btPay.Name = "btPay";
            this.btPay.Size = new System.Drawing.Size(175, 35);
            this.btPay.TabIndex = 19;
            this.btPay.Text = "Thanh toán";
            this.btPay.UseVisualStyleBackColor = true;
            this.btPay.Click += new System.EventHandler(this.btPay_Click);
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Location = new System.Drawing.Point(834, 631);
            this.lblTongTien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(45, 17);
            this.lblTongTien.TabIndex = 21;
            this.lblTongTien.Text = "Tổng";
            this.lblTongTien.Click += new System.EventHandler(this.lblTongTien_Click);
            // 
            // txtChonBan
            // 
            this.txtChonBan.Location = new System.Drawing.Point(92, 50);
            this.txtChonBan.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtChonBan.Name = "txtChonBan";
            this.txtChonBan.Size = new System.Drawing.Size(123, 23);
            this.txtChonBan.TabIndex = 22;
            // 
            // chấmCôngToolStripMenuItem
            // 
            this.chấmCôngToolStripMenuItem.Name = "chấmCôngToolStripMenuItem";
            this.chấmCôngToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.chấmCôngToolStripMenuItem.Text = "Chấm công";
            this.chấmCôngToolStripMenuItem.Click += new System.EventHandler(this.chấmCôngToolStripMenuItem_Click);
            // 
            // TableManeger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SandyBrown;
            this.ClientSize = new System.Drawing.Size(1194, 675);
            this.Controls.Add(this.txtChonBan);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.btPay);
            this.Controls.Add(this.lbSum);
            this.Controls.Add(this.dtgvHoaDonTam);
            this.Controls.Add(this.btDeleteDrink);
            this.Controls.Add(this.dtpkToDate);
            this.Controls.Add(this.txtNhanVienThuNgan);
            this.Controls.Add(this.lbNVPay);
            this.Controls.Add(this.dtgvMenuQuanLyCaPhe);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.lbSearchDrink);
            this.Controls.Add(this.btAddNew);
            this.Controls.Add(this.cbxSoLuong);
            this.Controls.Add(this.lbQuantity);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.lbChoice);
            this.Controls.Add(this.mnTableManeger);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.mnTableManeger;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "TableManeger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý quán coffe";
            this.Load += new System.EventHandler(this.QLquancafeLoad);
            this.mnTableManeger.ResumeLayout(false);
            this.mnTableManeger.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvMenuQuanLyCaPhe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHoaDonTam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnTableManeger;
        private System.Windows.Forms.ToolStripMenuItem danhMụcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thốngKêToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bánhNgọtToolStripMenuItem;
        private System.Windows.Forms.Label lbChoice;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label lbQuantity;
        private System.Windows.Forms.NumericUpDown cbxSoLuong;
        private System.Windows.Forms.Button btAddNew;
        private System.Windows.Forms.Label lbSearchDrink;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.DataGridView dtgvMenuQuanLyCaPhe;
        private System.Windows.Forms.Label lbNVPay;
        private System.Windows.Forms.TextBox txtNhanVienThuNgan;
        private System.Windows.Forms.DateTimePicker dtpkToDate;
        private System.Windows.Forms.Button btDeleteDrink;
        private System.Windows.Forms.DataGridView dtgvHoaDonTam;
        private System.Windows.Forms.Label lbSum;
        private System.Windows.Forms.Button btPay;
        private System.Windows.Forms.ToolStripMenuItem bànToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýKháchHàngToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.ToolStripMenuItem hóaĐơnToolStripMenuItem;
        private System.Windows.Forms.TextBox txtChonBan;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đổiMậtKhẩuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýNhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nguye6ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem côngThứcPhaChếToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhậpKhoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chấmCôngToolStripMenuItem;
    }
}