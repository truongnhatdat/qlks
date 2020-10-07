namespace QLKS
{
    partial class FormThongKe
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
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnlaydl = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dt1 = new System.Windows.Forms.DateTimePicker();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.txtdoanhthu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Yellow;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(277, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(648, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "BẢNG  THỐNG KÊ DOANH THU THEO THÁNG CỦA KHÁCH SẠN";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1220, 59);
            this.panelControl1.TabIndex = 1;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnlaydl);
            this.panelControl2.Controls.Add(this.label2);
            this.panelControl2.Controls.Add(this.dt1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 59);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1220, 42);
            this.panelControl2.TabIndex = 2;
            // 
            // btnlaydl
            // 
            this.btnlaydl.BackColor = System.Drawing.Color.White;
            this.btnlaydl.Location = new System.Drawing.Point(714, 15);
            this.btnlaydl.Name = "btnlaydl";
            this.btnlaydl.Size = new System.Drawing.Size(75, 23);
            this.btnlaydl.TabIndex = 4;
            this.btnlaydl.Text = "Lấy dữ liệu";
            this.btnlaydl.UseVisualStyleBackColor = false;
            this.btnlaydl.Click += new System.EventHandler(this.btnlaydl_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(468, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Chọn thời gian";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dt1
            // 
            this.dt1.CustomFormat = "MM/yyyy";
            this.dt1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt1.Location = new System.Drawing.Point(550, 16);
            this.dt1.Name = "dt1";
            this.dt1.Size = new System.Drawing.Size(121, 21);
            this.dt1.TabIndex = 0;
            // 
            // panelControl3
            // 
            this.panelControl3.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl3.Appearance.Options.UseBackColor = true;
            this.panelControl3.Controls.Add(this.txtdoanhthu);
            this.panelControl3.Controls.Add(this.label4);
            this.panelControl3.Controls.Add(this.dataGridView1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 101);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1220, 540);
            this.panelControl3.TabIndex = 3;
            // 
            // txtdoanhthu
            // 
            this.txtdoanhthu.Enabled = false;
            this.txtdoanhthu.Location = new System.Drawing.Point(1036, 420);
            this.txtdoanhthu.Name = "txtdoanhthu";
            this.txtdoanhthu.Size = new System.Drawing.Size(161, 21);
            this.txtdoanhthu.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(919, 422);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "DOANH THU";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1216, 402);
            this.dataGridView1.TabIndex = 0;
            // 
            // FormThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1220, 641);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "FormThongKe";
            this.Text = "FormThongKe";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Button btnlaydl;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private System.Windows.Forms.TextBox txtdoanhthu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.DateTimePicker dt1;
    }
}