namespace JazzCoffe
{
    partial class fDoiMatKhau
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtMatKhauCu = new System.Windows.Forms.TextBox();
            this.txtMatKhauMoi = new System.Windows.Forms.TextBox();
            this.txtXacNhanMK = new System.Windows.Forms.TextBox();
            this.lbOldPassword = new System.Windows.Forms.Label();
            this.lbNewPassword = new System.Windows.Forms.Label();
            this.lbConfirmPassword = new System.Windows.Forms.Label();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnChangePasswordExit = new System.Windows.Forms.Button();
            this.lbMaNV = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtMatKhauCu
            // 
            this.txtMatKhauCu.Location = new System.Drawing.Point(188, 67);
            this.txtMatKhauCu.Name = "txtMatKhauCu";
            this.txtMatKhauCu.Size = new System.Drawing.Size(248, 26);
            this.txtMatKhauCu.TabIndex = 0;
            this.txtMatKhauCu.UseSystemPasswordChar = true;
            // 
            // txtMatKhauMoi
            // 
            this.txtMatKhauMoi.Location = new System.Drawing.Point(188, 114);
            this.txtMatKhauMoi.Name = "txtMatKhauMoi";
            this.txtMatKhauMoi.Size = new System.Drawing.Size(248, 26);
            this.txtMatKhauMoi.TabIndex = 1;
            this.txtMatKhauMoi.UseSystemPasswordChar = true;
            // 
            // txtXacNhanMK
            // 
            this.txtXacNhanMK.Location = new System.Drawing.Point(188, 156);
            this.txtXacNhanMK.Name = "txtXacNhanMK";
            this.txtXacNhanMK.Size = new System.Drawing.Size(248, 26);
            this.txtXacNhanMK.TabIndex = 2;
            this.txtXacNhanMK.UseSystemPasswordChar = true;
            // 
            // lbOldPassword
            // 
            this.lbOldPassword.AutoSize = true;
            this.lbOldPassword.Location = new System.Drawing.Point(12, 67);
            this.lbOldPassword.Name = "lbOldPassword";
            this.lbOldPassword.Size = new System.Drawing.Size(100, 20);
            this.lbOldPassword.TabIndex = 3;
            this.lbOldPassword.Text = "Mật khẩu cũ:";
            // 
            // lbNewPassword
            // 
            this.lbNewPassword.AutoSize = true;
            this.lbNewPassword.Location = new System.Drawing.Point(12, 114);
            this.lbNewPassword.Name = "lbNewPassword";
            this.lbNewPassword.Size = new System.Drawing.Size(108, 20);
            this.lbNewPassword.TabIndex = 4;
            this.lbNewPassword.Text = "Mật khẩu mới:";
            // 
            // lbConfirmPassword
            // 
            this.lbConfirmPassword.AutoSize = true;
            this.lbConfirmPassword.Location = new System.Drawing.Point(12, 159);
            this.lbConfirmPassword.Name = "lbConfirmPassword";
            this.lbConfirmPassword.Size = new System.Drawing.Size(170, 20);
            this.lbConfirmPassword.TabIndex = 5;
            this.lbConfirmPassword.Text = "Xác nhận lại mật khẩu:";
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(73, 212);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(174, 41);
            this.btnChangePassword.TabIndex = 6;
            this.btnChangePassword.Text = "Đổi mật khẩu";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btChangePassword_Click);
            // 
            // btnChangePasswordExit
            // 
            this.btnChangePasswordExit.Location = new System.Drawing.Point(262, 212);
            this.btnChangePasswordExit.Name = "btnChangePasswordExit";
            this.btnChangePasswordExit.Size = new System.Drawing.Size(174, 41);
            this.btnChangePasswordExit.TabIndex = 7;
            this.btnChangePasswordExit.Text = "Thoát";
            this.btnChangePasswordExit.UseVisualStyleBackColor = true;
            this.btnChangePasswordExit.Click += new System.EventHandler(this.btnChangePasswordExit_Click);
            // 
            // lbMaNV
            // 
            this.lbMaNV.AutoSize = true;
            this.lbMaNV.Location = new System.Drawing.Point(12, 25);
            this.lbMaNV.Name = "lbMaNV";
            this.lbMaNV.Size = new System.Drawing.Size(82, 20);
            this.lbMaNV.TabIndex = 8;
            this.lbMaNV.Text = "Tài khoản:";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(188, 25);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(248, 26);
            this.txtMaNV.TabIndex = 9;
            // 
            // fDoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SandyBrown;
            this.ClientSize = new System.Drawing.Size(456, 370);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.lbMaNV);
            this.Controls.Add(this.btnChangePasswordExit);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.lbConfirmPassword);
            this.Controls.Add(this.lbNewPassword);
            this.Controls.Add(this.lbOldPassword);
            this.Controls.Add(this.txtXacNhanMK);
            this.Controls.Add(this.txtMatKhauMoi);
            this.Controls.Add(this.txtMatKhauCu);
            this.Name = "fDoiMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi mật khẩu";
            this.Load += new System.EventHandler(this.fDoiMatKhau_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMatKhauCu;
        private System.Windows.Forms.TextBox txtMatKhauMoi;
        private System.Windows.Forms.TextBox txtXacNhanMK;
        private System.Windows.Forms.Label lbOldPassword;
        private System.Windows.Forms.Label lbNewPassword;
        private System.Windows.Forms.Label lbConfirmPassword;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnChangePasswordExit;
        private System.Windows.Forms.Label lbMaNV;
        private System.Windows.Forms.TextBox txtMaNV;
    }
}
