namespace JazzCoffe
{
    partial class fDanhmucloaidouong
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
            this.mnfDanhmucloaidouong = new System.Windows.Forms.MenuStrip();
            this.thêmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sửaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaTrắngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbIDTypeDrink = new System.Windows.Forms.Label();
            this.txtIDTypeDrink = new System.Windows.Forms.TextBox();
            this.lbTypeName = new System.Windows.Forms.Label();
            this.txtTypeName = new System.Windows.Forms.TextBox();
            this.dtgvTypeDrink = new System.Windows.Forms.DataGridView();
            this.lbSearchNameDrink = new System.Windows.Forms.Label();
            this.txbSearchNameDrink = new System.Windows.Forms.TextBox();
            this.btSearchNameDrink = new System.Windows.Forms.Button();
            this.mnfDanhmucloaidouong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTypeDrink)).BeginInit();
            this.SuspendLayout();
            // 
            // mnfDanhmucloaidouong
            // 
            this.mnfDanhmucloaidouong.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mnfDanhmucloaidouong.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnfDanhmucloaidouong.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmToolStripMenuItem,
            this.sửaToolStripMenuItem,
            this.xóaToolStripMenuItem,
            this.xóaTrắngToolStripMenuItem});
            this.mnfDanhmucloaidouong.Location = new System.Drawing.Point(0, 0);
            this.mnfDanhmucloaidouong.Name = "mnfDanhmucloaidouong";
            this.mnfDanhmucloaidouong.Size = new System.Drawing.Size(389, 33);
            this.mnfDanhmucloaidouong.TabIndex = 1;
            this.mnfDanhmucloaidouong.Text = "menuStrip1";
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
            // lbIDTypeDrink
            // 
            this.lbIDTypeDrink.AutoSize = true;
            this.lbIDTypeDrink.Location = new System.Drawing.Point(12, 45);
            this.lbIDTypeDrink.Name = "lbIDTypeDrink";
            this.lbIDTypeDrink.Size = new System.Drawing.Size(63, 20);
            this.lbIDTypeDrink.TabIndex = 14;
            this.lbIDTypeDrink.Text = "Mã loại:";
            // 
            // txtIDTypeDrink
            // 
            this.txtIDTypeDrink.Location = new System.Drawing.Point(125, 45);
            this.txtIDTypeDrink.Name = "txtIDTypeDrink";
            this.txtIDTypeDrink.Size = new System.Drawing.Size(248, 26);
            this.txtIDTypeDrink.TabIndex = 15;
            // 
            // lbTypeName
            // 
            this.lbTypeName.AutoSize = true;
            this.lbTypeName.Location = new System.Drawing.Point(7, 86);
            this.lbTypeName.Name = "lbTypeName";
            this.lbTypeName.Size = new System.Drawing.Size(68, 20);
            this.lbTypeName.TabIndex = 16;
            this.lbTypeName.Text = "Tên loại:";
            // 
            // txtTypeName
            // 
            this.txtTypeName.Location = new System.Drawing.Point(125, 86);
            this.txtTypeName.Name = "txtTypeName";
            this.txtTypeName.Size = new System.Drawing.Size(248, 26);
            this.txtTypeName.TabIndex = 17;
            // 
            // dtgvTypeDrink
            // 
            this.dtgvTypeDrink.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvTypeDrink.Location = new System.Drawing.Point(0, 225);
            this.dtgvTypeDrink.Name = "dtgvTypeDrink";
            this.dtgvTypeDrink.RowHeadersWidth = 62;
            this.dtgvTypeDrink.RowTemplate.Height = 28;
            this.dtgvTypeDrink.Size = new System.Drawing.Size(387, 371);
            this.dtgvTypeDrink.TabIndex = 24;
            this.dtgvTypeDrink.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvTypeDrink_CellClick);
            this.dtgvTypeDrink.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvTypeDrink_CellContentClick);
            // 
            // lbSearchNameDrink
            // 
            this.lbSearchNameDrink.AutoSize = true;
            this.lbSearchNameDrink.Location = new System.Drawing.Point(7, 125);
            this.lbSearchNameDrink.Name = "lbSearchNameDrink";
            this.lbSearchNameDrink.Size = new System.Drawing.Size(138, 20);
            this.lbSearchNameDrink.TabIndex = 25;
            this.lbSearchNameDrink.Text = "Tìm kiếm theo tên:";
            // 
            // txbSearchNameDrink
            // 
            this.txbSearchNameDrink.Location = new System.Drawing.Point(151, 122);
            this.txbSearchNameDrink.Name = "txbSearchNameDrink";
            this.txbSearchNameDrink.Size = new System.Drawing.Size(222, 26);
            this.txbSearchNameDrink.TabIndex = 26;
            // 
            // btSearchNameDrink
            // 
            this.btSearchNameDrink.Location = new System.Drawing.Point(11, 169);
            this.btSearchNameDrink.Name = "btSearchNameDrink";
            this.btSearchNameDrink.Size = new System.Drawing.Size(174, 41);
            this.btSearchNameDrink.TabIndex = 27;
            this.btSearchNameDrink.Text = "Tìm kiếm";
            this.btSearchNameDrink.UseVisualStyleBackColor = true;
            this.btSearchNameDrink.Click += new System.EventHandler(this.btSearchNameDrink_Click);
            // 
            // fDanhmucloaidouong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SandyBrown;
            this.ClientSize = new System.Drawing.Size(389, 598);
            this.Controls.Add(this.btSearchNameDrink);
            this.Controls.Add(this.txbSearchNameDrink);
            this.Controls.Add(this.lbSearchNameDrink);
            this.Controls.Add(this.dtgvTypeDrink);
            this.Controls.Add(this.txtTypeName);
            this.Controls.Add(this.lbTypeName);
            this.Controls.Add(this.txtIDTypeDrink);
            this.Controls.Add(this.lbIDTypeDrink);
            this.Controls.Add(this.mnfDanhmucloaidouong);
            this.Name = "fDanhmucloaidouong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fDanhmucloaidouong";
            this.Load += new System.EventHandler(this.fDanhmucloaidouong_Load);
            this.mnfDanhmucloaidouong.ResumeLayout(false);
            this.mnfDanhmucloaidouong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTypeDrink)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnfDanhmucloaidouong;
        private System.Windows.Forms.ToolStripMenuItem thêmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sửaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaTrắngToolStripMenuItem;
        private System.Windows.Forms.Label lbIDTypeDrink;
        private System.Windows.Forms.TextBox txtIDTypeDrink;
        private System.Windows.Forms.Label lbTypeName;
        private System.Windows.Forms.TextBox txtTypeName;
        private System.Windows.Forms.DataGridView dtgvTypeDrink;
        private System.Windows.Forms.Label lbSearchNameDrink;
        private System.Windows.Forms.TextBox txbSearchNameDrink;
        private System.Windows.Forms.Button btSearchNameDrink;
    }
}