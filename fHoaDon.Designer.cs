namespace JazzCoffe
{
    partial class fHoaDon
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
            this.lbStartdate = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lbEndDate = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.cbxTrangThai = new System.Windows.Forms.ComboBox();
            this.btnFill = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgvHoaDon = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.dtgvPhieuNhapKho = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLocPhieuNhap = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTongChiPhi = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTongLoiNhuan = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvPhieuNhapKho)).BeginInit();
            this.SuspendLayout();
            // 
            // lbStartdate
            // 
            this.lbStartdate.AutoSize = true;
            this.lbStartdate.Location = new System.Drawing.Point(12, 25);
            this.lbStartdate.Name = "lbStartdate";
            this.lbStartdate.Size = new System.Drawing.Size(69, 20);
            this.lbStartdate.TabIndex = 19;
            this.lbStartdate.Text = "Từ ngày:";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Location = new System.Drawing.Point(87, 25);
            this.dtpTuNgay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(342, 26);
            this.dtpTuNgay.TabIndex = 20;
            // 
            // lbEndDate
            // 
            this.lbEndDate.AutoSize = true;
            this.lbEndDate.Location = new System.Drawing.Point(465, 25);
            this.lbEndDate.Name = "lbEndDate";
            this.lbEndDate.Size = new System.Drawing.Size(81, 20);
            this.lbEndDate.TabIndex = 21;
            this.lbEndDate.Text = "Đến ngày:";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Location = new System.Drawing.Point(552, 25);
            this.dtpDenNgay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(342, 26);
            this.dtpDenNgay.TabIndex = 22;
            // 
            // cbxTrangThai
            // 
            this.cbxTrangThai.FormattingEnabled = true;
            this.cbxTrangThai.Location = new System.Drawing.Point(543, 438);
            this.cbxTrangThai.Name = "cbxTrangThai";
            this.cbxTrangThai.Size = new System.Drawing.Size(145, 28);
            this.cbxTrangThai.TabIndex = 23;
            this.cbxTrangThai.Text = "Trạng thái";
            // 
            // btnFill
            // 
            this.btnFill.Location = new System.Drawing.Point(714, 434);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(170, 34);
            this.btnFill.TabIndex = 24;
            this.btnFill.Text = "Lọc";
            this.btnFill.UseVisualStyleBackColor = true;
            this.btnFill.Click += new System.EventHandler(this.btnFill_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(370, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "Danh sách hóa đơn";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dtgvHoaDon
            // 
            this.dtgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvHoaDon.Location = new System.Drawing.Point(2, 124);
            this.dtgvHoaDon.Name = "dtgvHoaDon";
            this.dtgvHoaDon.RowHeadersWidth = 62;
            this.dtgvHoaDon.RowTemplate.Height = 28;
            this.dtgvHoaDon.Size = new System.Drawing.Size(892, 286);
            this.dtgvHoaDon.TabIndex = 26;
            this.dtgvHoaDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvHoaDon_CellClick);
            this.dtgvHoaDon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvHoaDon_CellContentClick);
            this.dtgvHoaDon.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgvHoaDon_CellFormatting);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 438);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "Tổng doanh thu:";
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Location = new System.Drawing.Point(143, 438);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(43, 20);
            this.lblTongDoanhThu.TabIndex = 28;
            this.lblTongDoanhThu.Text = "VNĐ";
            // 
            // dtgvPhieuNhapKho
            // 
            this.dtgvPhieuNhapKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvPhieuNhapKho.Location = new System.Drawing.Point(2, 531);
            this.dtgvPhieuNhapKho.Name = "dtgvPhieuNhapKho";
            this.dtgvPhieuNhapKho.RowHeadersWidth = 62;
            this.dtgvPhieuNhapKho.RowTemplate.Height = 28;
            this.dtgvPhieuNhapKho.Size = new System.Drawing.Size(892, 267);
            this.dtgvPhieuNhapKho.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(338, 498);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 20);
            this.label3.TabIndex = 30;
            this.label3.Text = "Danh sách phiếu nhập kho";
            // 
            // btnLocPhieuNhap
            // 
            this.btnLocPhieuNhap.Location = new System.Drawing.Point(714, 825);
            this.btnLocPhieuNhap.Name = "btnLocPhieuNhap";
            this.btnLocPhieuNhap.Size = new System.Drawing.Size(170, 34);
            this.btnLocPhieuNhap.TabIndex = 31;
            this.btnLocPhieuNhap.Text = "Lọc";
            this.btnLocPhieuNhap.UseVisualStyleBackColor = true;
            this.btnLocPhieuNhap.Click += new System.EventHandler(this.btnLocPhieuNhap_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 839);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 20);
            this.label4.TabIndex = 32;
            this.label4.Text = "Tổng chi phí:";
            // 
            // lblTongChiPhi
            // 
            this.lblTongChiPhi.AutoSize = true;
            this.lblTongChiPhi.Location = new System.Drawing.Point(143, 839);
            this.lblTongChiPhi.Name = "lblTongChiPhi";
            this.lblTongChiPhi.Size = new System.Drawing.Size(43, 20);
            this.lblTongChiPhi.TabIndex = 33;
            this.lblTongChiPhi.Text = "VNĐ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(239, 911);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 20);
            this.label6.TabIndex = 34;
            this.label6.Text = "Lợi nhuận:";
            // 
            // txtTongLoiNhuan
            // 
            this.txtTongLoiNhuan.Location = new System.Drawing.Point(328, 908);
            this.txtTongLoiNhuan.Name = "txtTongLoiNhuan";
            this.txtTongLoiNhuan.Size = new System.Drawing.Size(218, 26);
            this.txtTongLoiNhuan.TabIndex = 35;
            // 
            // fHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SandyBrown;
            this.ClientSize = new System.Drawing.Size(896, 967);
            this.Controls.Add(this.txtTongLoiNhuan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTongChiPhi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnLocPhieuNhap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtgvPhieuNhapKho);
            this.Controls.Add(this.lblTongDoanhThu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtgvHoaDon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFill);
            this.Controls.Add(this.cbxTrangThai);
            this.Controls.Add(this.dtpDenNgay);
            this.Controls.Add(this.lbEndDate);
            this.Controls.Add(this.dtpTuNgay);
            this.Controls.Add(this.lbStartdate);
            this.Name = "fHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fHoaDon";
            this.Load += new System.EventHandler(this.fHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvPhieuNhapKho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbStartdate;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lbEndDate;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.ComboBox cbxTrangThai;
        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgvHoaDon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.DataGridView dtgvPhieuNhapKho;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLocPhieuNhap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTongChiPhi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTongLoiNhuan;
    }
}