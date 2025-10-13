namespace JazzCoffe
{
    partial class fDanhmucdouong
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
            this.lbIDDrink = new System.Windows.Forms.Label();
            this.mnfDanhmucdouong = new System.Windows.Forms.MenuStrip();
            this.thêmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sửaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaTrắngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtMaDU = new System.Windows.Forms.TextBox();
            this.lbNameDrink = new System.Windows.Forms.Label();
            this.txtTenDU = new System.Windows.Forms.TextBox();
            this.txtMaLDU = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.lbIDTypeDrink = new System.Windows.Forms.Label();
            this.lbValueDrink = new System.Windows.Forms.Label();
            this.dtgvDoUong = new System.Windows.Forms.DataGridView();
            this.lbSearchNameDrink = new System.Windows.Forms.Label();
            this.txbSearchNameDrink = new System.Windows.Forms.TextBox();
            this.btSearchNameDrink = new System.Windows.Forms.Button();
            this.mnfDanhmucdouong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDoUong)).BeginInit();
            this.SuspendLayout();
            // 
            // lbIDDrink
            // 
            this.lbIDDrink.AutoSize = true;
            this.lbIDDrink.Location = new System.Drawing.Point(12, 51);
            this.lbIDDrink.Name = "lbIDDrink";
            this.lbIDDrink.Size = new System.Drawing.Size(97, 20);
            this.lbIDDrink.TabIndex = 15;
            this.lbIDDrink.Text = "Mã đồ uống:";
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
            this.mnfDanhmucdouong.Size = new System.Drawing.Size(688, 33);
            this.mnfDanhmucdouong.TabIndex = 16;
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
            // txtMaDU
            // 
            this.txtMaDU.Location = new System.Drawing.Point(143, 51);
            this.txtMaDU.Name = "txtMaDU";
            this.txtMaDU.Size = new System.Drawing.Size(248, 26);
            this.txtMaDU.TabIndex = 17;
            // 
            // lbNameDrink
            // 
            this.lbNameDrink.AutoSize = true;
            this.lbNameDrink.Location = new System.Drawing.Point(12, 96);
            this.lbNameDrink.Name = "lbNameDrink";
            this.lbNameDrink.Size = new System.Drawing.Size(102, 20);
            this.lbNameDrink.TabIndex = 18;
            this.lbNameDrink.Text = "Tên đồ uống:";
            // 
            // txtTenDU
            // 
            this.txtTenDU.Location = new System.Drawing.Point(143, 96);
            this.txtTenDU.Name = "txtTenDU";
            this.txtTenDU.Size = new System.Drawing.Size(248, 26);
            this.txtTenDU.TabIndex = 19;
            // 
            // txtMaLDU
            // 
            this.txtMaLDU.Location = new System.Drawing.Point(143, 138);
            this.txtMaLDU.Name = "txtMaLDU";
            this.txtMaLDU.Size = new System.Drawing.Size(248, 26);
            this.txtMaLDU.TabIndex = 20;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(143, 181);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(248, 26);
            this.txtDonGia.TabIndex = 21;
            // 
            // lbIDTypeDrink
            // 
            this.lbIDTypeDrink.AutoSize = true;
            this.lbIDTypeDrink.Location = new System.Drawing.Point(12, 144);
            this.lbIDTypeDrink.Name = "lbIDTypeDrink";
            this.lbIDTypeDrink.Size = new System.Drawing.Size(105, 20);
            this.lbIDTypeDrink.TabIndex = 22;
            this.lbIDTypeDrink.Text = "Loại đồ uống:";
            // 
            // lbValueDrink
            // 
            this.lbValueDrink.AutoSize = true;
            this.lbValueDrink.Location = new System.Drawing.Point(12, 187);
            this.lbValueDrink.Name = "lbValueDrink";
            this.lbValueDrink.Size = new System.Drawing.Size(68, 20);
            this.lbValueDrink.TabIndex = 23;
            this.lbValueDrink.Text = "Đơn giá:";
            // 
            // dtgvDoUong
            // 
            this.dtgvDoUong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDoUong.Location = new System.Drawing.Point(0, 225);
            this.dtgvDoUong.Name = "dtgvDoUong";
            this.dtgvDoUong.RowHeadersWidth = 62;
            this.dtgvDoUong.RowTemplate.Height = 28;
            this.dtgvDoUong.Size = new System.Drawing.Size(688, 474);
            this.dtgvDoUong.TabIndex = 25;
            this.dtgvDoUong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvTypeDrink_CellClick);
            this.dtgvDoUong.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvDoUong_CellContentClick);
            // 
            // lbSearchNameDrink
            // 
            this.lbSearchNameDrink.AutoSize = true;
            this.lbSearchNameDrink.Location = new System.Drawing.Point(110, 724);
            this.lbSearchNameDrink.Name = "lbSearchNameDrink";
            this.lbSearchNameDrink.Size = new System.Drawing.Size(138, 20);
            this.lbSearchNameDrink.TabIndex = 26;
            this.lbSearchNameDrink.Text = "Tìm kiếm theo tên:";
            // 
            // txbSearchNameDrink
            // 
            this.txbSearchNameDrink.Location = new System.Drawing.Point(254, 721);
            this.txbSearchNameDrink.Name = "txbSearchNameDrink";
            this.txbSearchNameDrink.Size = new System.Drawing.Size(244, 26);
            this.txbSearchNameDrink.TabIndex = 27;
            // 
            // btSearchNameDrink
            // 
            this.btSearchNameDrink.Location = new System.Drawing.Point(504, 714);
            this.btSearchNameDrink.Name = "btSearchNameDrink";
            this.btSearchNameDrink.Size = new System.Drawing.Size(174, 41);
            this.btSearchNameDrink.TabIndex = 28;
            this.btSearchNameDrink.Text = "Tìm kiếm";
            this.btSearchNameDrink.UseVisualStyleBackColor = true;
            this.btSearchNameDrink.Click += new System.EventHandler(this.btSearchNameDrink_Click);
            // 
            // fDanhmucdouong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SandyBrown;
            this.ClientSize = new System.Drawing.Size(688, 783);
            this.Controls.Add(this.btSearchNameDrink);
            this.Controls.Add(this.txbSearchNameDrink);
            this.Controls.Add(this.lbSearchNameDrink);
            this.Controls.Add(this.dtgvDoUong);
            this.Controls.Add(this.lbValueDrink);
            this.Controls.Add(this.lbIDTypeDrink);
            this.Controls.Add(this.txtDonGia);
            this.Controls.Add(this.txtMaLDU);
            this.Controls.Add(this.txtTenDU);
            this.Controls.Add(this.lbNameDrink);
            this.Controls.Add(this.txtMaDU);
            this.Controls.Add(this.mnfDanhmucdouong);
            this.Controls.Add(this.lbIDDrink);
            this.Name = "fDanhmucdouong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fDanhmucdouong";
            this.Load += new System.EventHandler(this.fDanhmucdouong_Load);
            this.mnfDanhmucdouong.ResumeLayout(false);
            this.mnfDanhmucdouong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDoUong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbIDDrink;
        private System.Windows.Forms.MenuStrip mnfDanhmucdouong;
        private System.Windows.Forms.ToolStripMenuItem thêmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sửaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaTrắngToolStripMenuItem;
        private System.Windows.Forms.TextBox txtMaDU;
        private System.Windows.Forms.Label lbNameDrink;
        private System.Windows.Forms.TextBox txtTenDU;
        private System.Windows.Forms.TextBox txtMaLDU;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label lbIDTypeDrink;
        private System.Windows.Forms.Label lbValueDrink;
        private System.Windows.Forms.DataGridView dtgvDoUong;
        private System.Windows.Forms.Label lbSearchNameDrink;
        private System.Windows.Forms.TextBox txbSearchNameDrink;
        private System.Windows.Forms.Button btSearchNameDrink;
    }
}