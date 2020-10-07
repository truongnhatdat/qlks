namespace QLKS
{
    partial class FormDoiMK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDoiMK));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtmkcu = new System.Windows.Forms.TextBox();
            this.txtmkmoi = new System.Windows.Forms.TextBox();
            this.btndoi = new System.Windows.Forms.Button();
            this.btnthoat = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtxnmkmoi = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(669, 65);
            this.panelControl1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(280, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "ĐỔI THÔNG TIN TÀI KHOẢN";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.pictureBox1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(0, 65);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(321, 271);
            this.panelControl2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(317, 267);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(347, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "MẬT KHẨU CŨ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(342, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "MẬT KHẨU MỚI";
            // 
            // txtmkcu
            // 
            this.txtmkcu.Location = new System.Drawing.Point(443, 103);
            this.txtmkcu.Name = "txtmkcu";
            this.txtmkcu.PasswordChar = '*';
            this.txtmkcu.Size = new System.Drawing.Size(190, 20);
            this.txtmkcu.TabIndex = 7;
            // 
            // txtmkmoi
            // 
            this.txtmkmoi.Location = new System.Drawing.Point(443, 140);
            this.txtmkmoi.Name = "txtmkmoi";
            this.txtmkmoi.PasswordChar = '*';
            this.txtmkmoi.Size = new System.Drawing.Size(190, 20);
            this.txtmkmoi.TabIndex = 9;
            // 
            // btndoi
            // 
            this.btndoi.BackColor = System.Drawing.Color.Tomato;
            this.btndoi.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btndoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndoi.Location = new System.Drawing.Point(431, 217);
            this.btndoi.Name = "btndoi";
            this.btndoi.Size = new System.Drawing.Size(56, 23);
            this.btndoi.TabIndex = 10;
            this.btndoi.Text = "Đổi";
            this.btndoi.UseVisualStyleBackColor = false;
            this.btndoi.Click += new System.EventHandler(this.btndoi_Click);
            // 
            // btnthoat
            // 
            this.btnthoat.BackColor = System.Drawing.Color.Tomato;
            this.btnthoat.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnthoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnthoat.Location = new System.Drawing.Point(576, 217);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(57, 23);
            this.btnthoat.TabIndex = 11;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.UseVisualStyleBackColor = false;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Xác nhận mật khẩu";
            // 
            // txtxnmkmoi
            // 
            this.txtxnmkmoi.Location = new System.Drawing.Point(443, 174);
            this.txtxnmkmoi.Name = "txtxnmkmoi";
            this.txtxnmkmoi.PasswordChar = '*';
            this.txtxnmkmoi.Size = new System.Drawing.Size(190, 20);
            this.txtxnmkmoi.TabIndex = 13;
            // 
            // FormDoiMK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(669, 336);
            this.Controls.Add(this.txtxnmkmoi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.btndoi);
            this.Controls.Add(this.txtmkmoi);
            this.Controls.Add(this.txtmkcu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.MaximizeBox = false;
            this.Name = "FormDoiMK";
            this.Text = "s";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtmkcu;
        private System.Windows.Forms.TextBox txtmkmoi;
        private System.Windows.Forms.Button btndoi;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtxnmkmoi;
    }
}