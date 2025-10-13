namespace JazzCoffe
{
    partial class fKhachhang
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
            this.lbIDCustomer = new System.Windows.Forms.Label();
            this.mnfDanhmucdouong = new System.Windows.Forms.MenuStrip();
            this.thêmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sửaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaTrắngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbNameCustomer = new System.Windows.Forms.Label();
            this.lbNBPCustomer = new System.Windows.Forms.Label();
            this.lbCustomerAddress = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.dtgvKhachHang = new System.Windows.Forms.DataGridView();
            this.lbSearchNameCustomer = new System.Windows.Forms.Label();
            this.txbSearchNameCustomer = new System.Windows.Forms.TextBox();
            this.btSearchNameCustomer = new System.Windows.Forms.Button();
            this.mnfDanhmucdouong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvKhachHang)).BeginInit();
            this.SuspendLayout();
            // 
            // lbIDCustomer
            // 
            this.lbIDCustomer.AutoSize = true;
            this.lbIDCustomer.Location = new System.Drawing.Point(12, 63);
            this.lbIDCustomer.Name = "lbIDCustomer";
            this.lbIDCustomer.Size = new System.Drawing.Size(122, 20);
            this.lbIDCustomer.TabIndex = 16;
            this.lbIDCustomer.Text = "Mã khách hàng:";
            // 
            // mnfDanhmucdouong
            // 
            this.mnfDanhmucdouong.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mnfDanhmucdouong.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnfDanhmucdouong.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmToolStripMenuItem,
            this.sửaToolStripMenuItem,
            this.xóaToolStripMenuItem,
            this.xóaTrắngToolStripMenuItem});
            this.mnfDanhmucdouong.Location = new System.Drawing.Point(0, 0);
            this.mnfDanhmucdouong.Name = "mnfDanhmucdouong";
            this.mnfDanhmucdouong.Size = new System.Drawing.Size(733, 33);
            this.mnfDanhmucdouong.TabIndex = 17;
            this.mnfDanhmucdouong.Text = "menuStrip1";
            // 
            // thêmToolStripMenuItem
            // 
            this.thêmToolStripMenuItem.Name = "thêmToolStripMenuItem";
            this.thêmToolStripMenuItem.Size = new System.Drawing.Size(72, 29);
            this.thêmToolStripMenuItem.Text = "Thêm";
            this.thêmToolStripMenuItem.Click += new System.EventHandler(this.thêmToolStripMenuItem_Click);
            // 
            // sửaToolStripMenuItem
            // 
            this.sửaToolStripMenuItem.Name = "sửaToolStripMenuItem";
            this.sửaToolStripMenuItem.Size = new System.Drawing.Size(58, 29);
            this.sửaToolStripMenuItem.Text = "Sửa";
            this.sửaToolStripMenuItem.Click += new System.EventHandler(this.sửaToolStripMenuItem_Click);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(59, 29);
            this.xóaToolStripMenuItem.Text = "Xóa";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // xóaTrắngToolStripMenuItem
            // 
            this.xóaTrắngToolStripMenuItem.Name = "xóaTrắngToolStripMenuItem";
            this.xóaTrắngToolStripMenuItem.Size = new System.Drawing.Size(97, 29);
            this.xóaTrắngToolStripMenuItem.Text = "Làm mới";
            this.xóaTrắngToolStripMenuItem.Click += new System.EventHandler(this.xóaTrắngToolStripMenuItem_Click);
            // 
            // lbNameCustomer
            // 
            this.lbNameCustomer.AutoSize = true;
            this.lbNameCustomer.Location = new System.Drawing.Point(12, 111);
            this.lbNameCustomer.Name = "lbNameCustomer";
            this.lbNameCustomer.Size = new System.Drawing.Size(127, 20);
            this.lbNameCustomer.TabIndex = 19;
            this.lbNameCustomer.Text = "Tên khách hàng:";
            // 
            // lbNBPCustomer
            // 
            this.lbNBPCustomer.AutoSize = true;
            this.lbNBPCustomer.Location = new System.Drawing.Point(366, 63);
            this.lbNBPCustomer.Name = "lbNBPCustomer";
            this.lbNBPCustomer.Size = new System.Drawing.Size(106, 20);
            this.lbNBPCustomer.TabIndex = 20;
            this.lbNBPCustomer.Text = "Số điện thoại:";
            // 
            // lbCustomerAddress
            // 
            this.lbCustomerAddress.AutoSize = true;
            this.lbCustomerAddress.Location = new System.Drawing.Point(400, 111);
            this.lbCustomerAddress.Name = "lbCustomerAddress";
            this.lbCustomerAddress.Size = new System.Drawing.Size(61, 20);
            this.lbCustomerAddress.TabIndex = 21;
            this.lbCustomerAddress.Text = "Địa chỉ:";
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(150, 57);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(176, 26);
            this.txtMaKH.TabIndex = 22;
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(150, 111);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(176, 26);
            this.txtTenKH.TabIndex = 23;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(478, 60);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(226, 26);
            this.txtSDT.TabIndex = 24;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(478, 108);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(226, 26);
            this.txtDiaChi.TabIndex = 25;
            // 
            // dtgvKhachHang
            // 
            this.dtgvKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvKhachHang.Location = new System.Drawing.Point(0, 166);
            this.dtgvKhachHang.Name = "dtgvKhachHang";
            this.dtgvKhachHang.RowHeadersWidth = 62;
            this.dtgvKhachHang.RowTemplate.Height = 28;
            this.dtgvKhachHang.Size = new System.Drawing.Size(733, 474);
            this.dtgvKhachHang.TabIndex = 26;
            this.dtgvKhachHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvKhachHang_CellClick);
            this.dtgvKhachHang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvKhachHang_CellContentClick);
            // 
            // lbSearchNameCustomer
            // 
            this.lbSearchNameCustomer.AutoSize = true;
            this.lbSearchNameCustomer.Location = new System.Drawing.Point(146, 681);
            this.lbSearchNameCustomer.Name = "lbSearchNameCustomer";
            this.lbSearchNameCustomer.Size = new System.Drawing.Size(138, 20);
            this.lbSearchNameCustomer.TabIndex = 27;
            this.lbSearchNameCustomer.Text = "Tìm kiếm theo tên:";
            // 
            // txbSearchNameCustomer
            // 
            this.txbSearchNameCustomer.Location = new System.Drawing.Point(293, 675);
            this.txbSearchNameCustomer.Name = "txbSearchNameCustomer";
            this.txbSearchNameCustomer.Size = new System.Drawing.Size(248, 26);
            this.txbSearchNameCustomer.TabIndex = 28;
            // 
            // btSearchNameCustomer
            // 
            this.btSearchNameCustomer.Location = new System.Drawing.Point(547, 668);
            this.btSearchNameCustomer.Name = "btSearchNameCustomer";
            this.btSearchNameCustomer.Size = new System.Drawing.Size(174, 41);
            this.btSearchNameCustomer.TabIndex = 29;
            this.btSearchNameCustomer.Text = "Tìm kiếm";
            this.btSearchNameCustomer.UseVisualStyleBackColor = true;
            this.btSearchNameCustomer.Click += new System.EventHandler(this.btSearchNameCustomer_Click);
            // 
            // fKhachhang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SandyBrown;
            this.ClientSize = new System.Drawing.Size(733, 742);
            this.Controls.Add(this.btSearchNameCustomer);
            this.Controls.Add(this.txbSearchNameCustomer);
            this.Controls.Add(this.lbSearchNameCustomer);
            this.Controls.Add(this.dtgvKhachHang);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtTenKH);
            this.Controls.Add(this.txtMaKH);
            this.Controls.Add(this.lbCustomerAddress);
            this.Controls.Add(this.lbNBPCustomer);
            this.Controls.Add(this.lbNameCustomer);
            this.Controls.Add(this.mnfDanhmucdouong);
            this.Controls.Add(this.lbIDCustomer);
            this.Name = "fKhachhang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fKhachhang";
            this.Load += new System.EventHandler(this.fKhachhang_Load);
            this.mnfDanhmucdouong.ResumeLayout(false);
            this.mnfDanhmucdouong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvKhachHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbIDCustomer;
        private System.Windows.Forms.MenuStrip mnfDanhmucdouong;
        private System.Windows.Forms.ToolStripMenuItem thêmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sửaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaTrắngToolStripMenuItem;
        private System.Windows.Forms.Label lbNameCustomer;
        private System.Windows.Forms.Label lbNBPCustomer;
        private System.Windows.Forms.Label lbCustomerAddress;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.DataGridView dtgvKhachHang;
        private System.Windows.Forms.Label lbSearchNameCustomer;
        private System.Windows.Forms.TextBox txbSearchNameCustomer;
        private System.Windows.Forms.Button btSearchNameCustomer;
    }
}