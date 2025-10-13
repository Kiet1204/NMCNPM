namespace JazzCoffe
{
    partial class fNhanVien
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
            this.mnfNhanVien = new System.Windows.Forms.MenuStrip();
            this.thêmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sửaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbIDNV = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.lbNVName = new System.Windows.Forms.Label();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.lbNVPassword = new System.Windows.Forms.Label();
            this.txtNVPassword = new System.Windows.Forms.TextBox();
            this.lbNumberPhone = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.dtgvNhanVien = new System.Windows.Forms.DataGridView();
            this.btSearchNameNV = new System.Windows.Forms.Button();
            this.txtSearchNameNV = new System.Windows.Forms.TextBox();
            this.lbSearchName = new System.Windows.Forms.Label();
            this.mnfNhanVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // mnfNhanVien
            // 
            this.mnfNhanVien.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mnfNhanVien.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnfNhanVien.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmToolStripMenuItem,
            this.sửaToolStripMenuItem,
            this.xóaToolStripMenuItem,
            this.RefreshToolStripMenuItem});
            this.mnfNhanVien.Location = new System.Drawing.Point(0, 0);
            this.mnfNhanVien.Name = "mnfNhanVien";
            this.mnfNhanVien.Size = new System.Drawing.Size(700, 33);
            this.mnfNhanVien.TabIndex = 0;
            this.mnfNhanVien.Text = "menuStrip1";
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
            // RefreshToolStripMenuItem
            // 
            this.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem";
            this.RefreshToolStripMenuItem.Size = new System.Drawing.Size(97, 29);
            this.RefreshToolStripMenuItem.Text = "Làm mới";
            this.RefreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // lbIDNV
            // 
            this.lbIDNV.AutoSize = true;
            this.lbIDNV.Location = new System.Drawing.Point(12, 46);
            this.lbIDNV.Name = "lbIDNV";
            this.lbIDNV.Size = new System.Drawing.Size(107, 20);
            this.lbIDNV.TabIndex = 13;
            this.lbIDNV.Text = "Mã nhân viên:";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(125, 46);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(200, 26);
            this.txtMaNV.TabIndex = 14;
            // 
            // lbNVName
            // 
            this.lbNVName.AutoSize = true;
            this.lbNVName.Location = new System.Drawing.Point(12, 89);
            this.lbNVName.Name = "lbNVName";
            this.lbNVName.Size = new System.Drawing.Size(112, 20);
            this.lbNVName.TabIndex = 15;
            this.lbNVName.Text = "Tên nhân viên:";
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(125, 86);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(200, 26);
            this.txtTenNV.TabIndex = 16;
            // 
            // lbNVPassword
            // 
            this.lbNVPassword.AutoSize = true;
            this.lbNVPassword.Location = new System.Drawing.Point(374, 46);
            this.lbNVPassword.Name = "lbNVPassword";
            this.lbNVPassword.Size = new System.Drawing.Size(79, 20);
            this.lbNVPassword.TabIndex = 19;
            this.lbNVPassword.Text = "Mật khẩu:";
            this.lbNVPassword.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtNVPassword
            // 
            this.txtNVPassword.Location = new System.Drawing.Point(459, 46);
            this.txtNVPassword.Name = "txtNVPassword";
            this.txtNVPassword.Size = new System.Drawing.Size(186, 26);
            this.txtNVPassword.TabIndex = 20;
            // 
            // lbNumberPhone
            // 
            this.lbNumberPhone.AutoSize = true;
            this.lbNumberPhone.Location = new System.Drawing.Point(347, 92);
            this.lbNumberPhone.Name = "lbNumberPhone";
            this.lbNumberPhone.Size = new System.Drawing.Size(106, 20);
            this.lbNumberPhone.TabIndex = 21;
            this.lbNumberPhone.Text = "Số điện thoại:";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(459, 92);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(186, 26);
            this.txtSDT.TabIndex = 22;
            // 
            // dtgvNhanVien
            // 
            this.dtgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvNhanVien.Location = new System.Drawing.Point(0, 136);
            this.dtgvNhanVien.Name = "dtgvNhanVien";
            this.dtgvNhanVien.RowHeadersWidth = 62;
            this.dtgvNhanVien.RowTemplate.Height = 28;
            this.dtgvNhanVien.Size = new System.Drawing.Size(699, 474);
            this.dtgvNhanVien.TabIndex = 23;
            this.dtgvNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvNhanVien_CellClick);
            this.dtgvNhanVien.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvNhanVien_CellContentClick);
            // 
            // btSearchNameNV
            // 
            this.btSearchNameNV.Location = new System.Drawing.Point(514, 627);
            this.btSearchNameNV.Name = "btSearchNameNV";
            this.btSearchNameNV.Size = new System.Drawing.Size(174, 41);
            this.btSearchNameNV.TabIndex = 26;
            this.btSearchNameNV.Text = "Tìm kiếm";
            this.btSearchNameNV.UseVisualStyleBackColor = true;
            this.btSearchNameNV.Click += new System.EventHandler(this.btSearchNameNV_Click);
            // 
            // txtSearchNameNV
            // 
            this.txtSearchNameNV.Location = new System.Drawing.Point(260, 634);
            this.txtSearchNameNV.Name = "txtSearchNameNV";
            this.txtSearchNameNV.Size = new System.Drawing.Size(248, 26);
            this.txtSearchNameNV.TabIndex = 25;
            // 
            // lbSearchName
            // 
            this.lbSearchName.AutoSize = true;
            this.lbSearchName.Location = new System.Drawing.Point(116, 637);
            this.lbSearchName.Name = "lbSearchName";
            this.lbSearchName.Size = new System.Drawing.Size(138, 20);
            this.lbSearchName.TabIndex = 24;
            this.lbSearchName.Text = "Tìm kiếm theo tên:";
            this.lbSearchName.Click += new System.EventHandler(this.lbSearchName_Click);
            // 
            // fNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SandyBrown;
            this.ClientSize = new System.Drawing.Size(700, 703);
            this.Controls.Add(this.btSearchNameNV);
            this.Controls.Add(this.txtSearchNameNV);
            this.Controls.Add(this.lbSearchName);
            this.Controls.Add(this.dtgvNhanVien);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.lbNumberPhone);
            this.Controls.Add(this.txtNVPassword);
            this.Controls.Add(this.lbNVPassword);
            this.Controls.Add(this.txtTenNV);
            this.Controls.Add(this.lbNVName);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.lbIDNV);
            this.Controls.Add(this.mnfNhanVien);
            this.MainMenuStrip = this.mnfNhanVien;
            this.Name = "fNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fNhanVien";
            this.Load += new System.EventHandler(this.fNhanVien_Load);
            this.mnfNhanVien.ResumeLayout(false);
            this.mnfNhanVien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvNhanVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnfNhanVien;
        private System.Windows.Forms.ToolStripMenuItem thêmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sửaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RefreshToolStripMenuItem;
        private System.Windows.Forms.Label lbIDNV;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label lbNVName;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.Label lbNVPassword;
        private System.Windows.Forms.TextBox txtNVPassword;
        private System.Windows.Forms.Label lbNumberPhone;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.DataGridView dtgvNhanVien;
        private System.Windows.Forms.Button btSearchNameNV;
        private System.Windows.Forms.TextBox txtSearchNameNV;
        private System.Windows.Forms.Label lbSearchName;
    }
}