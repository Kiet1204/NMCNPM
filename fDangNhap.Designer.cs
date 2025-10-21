namespace JazzCoffe
{
    partial class FLogin
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
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.lbTaiKhoan = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.lbMatKhau = new System.Windows.Forms.Label();
            this.lbChucVu = new System.Windows.Forms.Label();
            this.cboChucVu = new System.Windows.Forms.ComboBox();
            this.btDangNhap = new System.Windows.Forms.Button();
            this.btThoat = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Location = new System.Drawing.Point(602, 46);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(337, 26);
            this.txtTaiKhoan.TabIndex = 3;
            // 
            // lbTaiKhoan
            // 
            this.lbTaiKhoan.AutoSize = true;
            this.lbTaiKhoan.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTaiKhoan.Location = new System.Drawing.Point(448, 46);
            this.lbTaiKhoan.Name = "lbTaiKhoan";
            this.lbTaiKhoan.Size = new System.Drawing.Size(133, 29);
            this.lbTaiKhoan.TabIndex = 2;
            this.lbTaiKhoan.Text = "Tài khoản:";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(602, 112);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(337, 26);
            this.txtMatKhau.TabIndex = 5;
            this.txtMatKhau.UseSystemPasswordChar = true;
            this.txtMatKhau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMatKhau_KeyDown);
            // 
            // lbMatKhau
            // 
            this.lbMatKhau.AutoSize = true;
            this.lbMatKhau.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMatKhau.Location = new System.Drawing.Point(456, 112);
            this.lbMatKhau.Name = "lbMatKhau";
            this.lbMatKhau.Size = new System.Drawing.Size(125, 29);
            this.lbMatKhau.TabIndex = 4;
            this.lbMatKhau.Text = "Mật khẩu:";
            // 
            // lbChucVu
            // 
            this.lbChucVu.AutoSize = true;
            this.lbChucVu.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChucVu.Location = new System.Drawing.Point(464, 171);
            this.lbChucVu.Name = "lbChucVu";
            this.lbChucVu.Size = new System.Drawing.Size(117, 29);
            this.lbChucVu.TabIndex = 6;
            this.lbChucVu.Text = "Chức vụ:";
            // 
            // cboChucVu
            // 
            this.cboChucVu.FormattingEnabled = true;
            this.cboChucVu.Location = new System.Drawing.Point(602, 175);
            this.cboChucVu.Name = "cboChucVu";
            this.cboChucVu.Size = new System.Drawing.Size(337, 28);
            this.cboChucVu.TabIndex = 7;
            this.cboChucVu.SelectedIndexChanged += new System.EventHandler(this.cboChucVu_SelectedIndexChanged);
            // 
            // btDangNhap
            // 
            this.btDangNhap.Location = new System.Drawing.Point(643, 227);
            this.btDangNhap.Name = "btDangNhap";
            this.btDangNhap.Size = new System.Drawing.Size(133, 47);
            this.btDangNhap.TabIndex = 8;
            this.btDangNhap.Text = "Đăng nhập";
            this.btDangNhap.UseVisualStyleBackColor = true;
            this.btDangNhap.Click += new System.EventHandler(this.btDangNhap_Click);
            // 
            // btThoat
            // 
            this.btThoat.Location = new System.Drawing.Point(806, 227);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(133, 47);
            this.btThoat.TabIndex = 9;
            this.btThoat.Text = "Thoát";
            this.btThoat.UseVisualStyleBackColor = true;
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::JazzCoffe.Properties.Resources._20250726_1944_image;
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(384, 368);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // FLogin
            // 
            this.BackColor = System.Drawing.Color.Chocolate;
            this.ClientSize = new System.Drawing.Size(964, 368);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btThoat);
            this.Controls.Add(this.btDangNhap);
            this.Controls.Add(this.cboChucVu);
            this.Controls.Add(this.lbChucVu);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.lbMatKhau);
            this.Controls.Add(this.txtTaiKhoan);
            this.Controls.Add(this.lbTaiKhoan);
            this.Name = "FLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FLogin_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txbAccount;
        private System.Windows.Forms.Label lbAccount;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txbPassWord;
        private System.Windows.Forms.Label lbPassWord;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbCV;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.Label lbTaiKhoan;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label lbMatKhau;
        private System.Windows.Forms.Label lbChucVu;
        private System.Windows.Forms.ComboBox cboChucVu;
        private System.Windows.Forms.Button btDangNhap;
        private System.Windows.Forms.Button btThoat;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

