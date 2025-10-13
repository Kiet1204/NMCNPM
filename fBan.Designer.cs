namespace JazzCoffe
{
    partial class fBan
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
            this.mnfDanhmucdouong = new System.Windows.Forms.MenuStrip();
            this.thêmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sửaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaTrắngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbIDTable = new System.Windows.Forms.Label();
            this.txtMaBan = new System.Windows.Forms.TextBox();
            this.lbCapacity = new System.Windows.Forms.Label();
            this.txtSucChua = new System.Windows.Forms.TextBox();
            this.dtgvBan = new System.Windows.Forms.DataGridView();
            this.lbSearchIDTable = new System.Windows.Forms.Label();
            this.txbSearchIDTable = new System.Windows.Forms.TextBox();
            this.btSearchIDTable = new System.Windows.Forms.Button();
            this.mnfDanhmucdouong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBan)).BeginInit();
            this.SuspendLayout();
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
            this.mnfDanhmucdouong.Size = new System.Drawing.Size(546, 33);
            this.mnfDanhmucdouong.TabIndex = 2;
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
            // lbIDTable
            // 
            this.lbIDTable.AutoSize = true;
            this.lbIDTable.Location = new System.Drawing.Point(12, 67);
            this.lbIDTable.Name = "lbIDTable";
            this.lbIDTable.Size = new System.Drawing.Size(66, 20);
            this.lbIDTable.TabIndex = 15;
            this.lbIDTable.Text = "Mã bàn:";
            // 
            // txtMaBan
            // 
            this.txtMaBan.Location = new System.Drawing.Point(98, 67);
            this.txtMaBan.Name = "txtMaBan";
            this.txtMaBan.Size = new System.Drawing.Size(248, 26);
            this.txtMaBan.TabIndex = 16;
            // 
            // lbCapacity
            // 
            this.lbCapacity.AutoSize = true;
            this.lbCapacity.Location = new System.Drawing.Point(12, 109);
            this.lbCapacity.Name = "lbCapacity";
            this.lbCapacity.Size = new System.Drawing.Size(80, 20);
            this.lbCapacity.TabIndex = 17;
            this.lbCapacity.Text = "Sức chứa:";
            // 
            // txtSucChua
            // 
            this.txtSucChua.Location = new System.Drawing.Point(98, 109);
            this.txtSucChua.Name = "txtSucChua";
            this.txtSucChua.Size = new System.Drawing.Size(248, 26);
            this.txtSucChua.TabIndex = 18;
            // 
            // dtgvBan
            // 
            this.dtgvBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvBan.Location = new System.Drawing.Point(0, 157);
            this.dtgvBan.Name = "dtgvBan";
            this.dtgvBan.RowHeadersWidth = 62;
            this.dtgvBan.RowTemplate.Height = 28;
            this.dtgvBan.Size = new System.Drawing.Size(545, 474);
            this.dtgvBan.TabIndex = 25;
            this.dtgvBan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvBan_CellClick);
            this.dtgvBan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // lbSearchIDTable
            // 
            this.lbSearchIDTable.AutoSize = true;
            this.lbSearchIDTable.Location = new System.Drawing.Point(12, 661);
            this.lbSearchIDTable.Name = "lbSearchIDTable";
            this.lbSearchIDTable.Size = new System.Drawing.Size(137, 20);
            this.lbSearchIDTable.TabIndex = 26;
            this.lbSearchIDTable.Text = "Tìm kiếm theo mã:";
            // 
            // txbSearchIDTable
            // 
            this.txbSearchIDTable.Location = new System.Drawing.Point(145, 658);
            this.txbSearchIDTable.Name = "txbSearchIDTable";
            this.txbSearchIDTable.Size = new System.Drawing.Size(201, 26);
            this.txbSearchIDTable.TabIndex = 27;
            // 
            // btSearchIDTable
            // 
            this.btSearchIDTable.Location = new System.Drawing.Point(352, 651);
            this.btSearchIDTable.Name = "btSearchIDTable";
            this.btSearchIDTable.Size = new System.Drawing.Size(174, 41);
            this.btSearchIDTable.TabIndex = 28;
            this.btSearchIDTable.Text = "Tìm kiếm";
            this.btSearchIDTable.UseVisualStyleBackColor = true;
            this.btSearchIDTable.Click += new System.EventHandler(this.btSearchIDTable_Click);
            // 
            // fBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SandyBrown;
            this.ClientSize = new System.Drawing.Size(546, 710);
            this.Controls.Add(this.btSearchIDTable);
            this.Controls.Add(this.txbSearchIDTable);
            this.Controls.Add(this.lbSearchIDTable);
            this.Controls.Add(this.dtgvBan);
            this.Controls.Add(this.txtSucChua);
            this.Controls.Add(this.lbCapacity);
            this.Controls.Add(this.txtMaBan);
            this.Controls.Add(this.lbIDTable);
            this.Controls.Add(this.mnfDanhmucdouong);
            this.Name = "fBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fBan";
            this.Load += new System.EventHandler(this.fBan_Load);
            this.mnfDanhmucdouong.ResumeLayout(false);
            this.mnfDanhmucdouong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnfDanhmucdouong;
        private System.Windows.Forms.ToolStripMenuItem thêmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sửaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaTrắngToolStripMenuItem;
        private System.Windows.Forms.Label lbIDTable;
        private System.Windows.Forms.TextBox txtMaBan;
        private System.Windows.Forms.Label lbCapacity;
        private System.Windows.Forms.TextBox txtSucChua;
        private System.Windows.Forms.DataGridView dtgvBan;
        private System.Windows.Forms.Label lbSearchIDTable;
        private System.Windows.Forms.TextBox txbSearchIDTable;
        private System.Windows.Forms.Button btSearchIDTable;
    }
}