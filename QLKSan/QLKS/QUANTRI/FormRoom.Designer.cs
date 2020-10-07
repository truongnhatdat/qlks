namespace QLKS
{
    partial class FormRoom
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRoom));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btninsertroom = new DevExpress.XtraBars.BarButtonItem();
            this.btnxoaroom = new DevExpress.XtraBars.BarButtonItem();
            this.btnsuaroom = new DevExpress.XtraBars.BarButtonItem();
            this.btnconfirm = new DevExpress.XtraBars.BarButtonItem();
            this.btnback = new DevExpress.XtraBars.BarButtonItem();
            this.btnexit = new DevExpress.XtraBars.BarButtonItem();
            this.btnreload = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btntim = new System.Windows.Forms.Button();
            this.txttim = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gvroom = new System.Windows.Forms.DataGridView();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbloaiphong = new System.Windows.Forms.ComboBox();
            this.cmbtinhtrang = new System.Windows.Forms.ComboBox();
            this.txtghichu = new System.Windows.Forms.TextBox();
            this.txtsophong = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvroom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btninsertroom,
            this.btnxoaroom,
            this.btnsuaroom,
            this.btnconfirm,
            this.btnback,
            this.btnexit,
            this.btnreload});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 7;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btninsertroom, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnxoaroom, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnsuaroom, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnconfirm, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnback, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnexit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnreload, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btninsertroom
            // 
            this.btninsertroom.Caption = "Thêm";
            this.btninsertroom.Id = 0;
            this.btninsertroom.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btninsertroom.ImageOptions.Image")));
            this.btninsertroom.Name = "btninsertroom";
            this.btninsertroom.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btninsertroom_ItemClick);
            // 
            // btnxoaroom
            // 
            this.btnxoaroom.Caption = "Xóa";
            this.btnxoaroom.Id = 1;
            this.btnxoaroom.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnxoaroom.ImageOptions.Image")));
            this.btnxoaroom.Name = "btnxoaroom";
            this.btnxoaroom.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnxoaroom_ItemClick);
            // 
            // btnsuaroom
            // 
            this.btnsuaroom.Caption = "Sửa";
            this.btnsuaroom.Id = 2;
            this.btnsuaroom.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnsuaroom.ImageOptions.Image")));
            this.btnsuaroom.Name = "btnsuaroom";
            this.btnsuaroom.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnsuaroom_ItemClick);
            // 
            // btnconfirm
            // 
            this.btnconfirm.Caption = "Xác nhận";
            this.btnconfirm.Id = 3;
            this.btnconfirm.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnconfirm.ImageOptions.Image")));
            this.btnconfirm.Name = "btnconfirm";
            this.btnconfirm.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnconfirm_ItemClick);
            // 
            // btnback
            // 
            this.btnback.Caption = "Quay lại";
            this.btnback.Id = 4;
            this.btnback.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnback.ImageOptions.Image")));
            this.btnback.Name = "btnback";
            this.btnback.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnback_ItemClick);
            // 
            // btnexit
            // 
            this.btnexit.Caption = "Thoát";
            this.btnexit.Id = 5;
            this.btnexit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnexit.ImageOptions.Image")));
            this.btnexit.Name = "btnexit";
            this.btnexit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnexit_ItemClick);
            // 
            // btnreload
            // 
            this.btnreload.Caption = "Reload";
            this.btnreload.Id = 6;
            this.btnreload.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnreload.ImageOptions.Image")));
            this.btnreload.Name = "btnreload";
            this.btnreload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnreload_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1117, 40);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 677);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1117, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 637);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1117, 40);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 637);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btntim);
            this.panelControl1.Controls.Add(this.txttim);
            this.panelControl1.Controls.Add(this.label6);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 40);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1117, 35);
            this.panelControl1.TabIndex = 4;
            // 
            // btntim
            // 
            this.btntim.Location = new System.Drawing.Point(875, 11);
            this.btntim.Name = "btntim";
            this.btntim.Size = new System.Drawing.Size(48, 18);
            this.btntim.TabIndex = 2;
            this.btntim.Text = "Tìm";
            this.btntim.UseVisualStyleBackColor = true;
            this.btntim.Click += new System.EventHandler(this.btntim_Click);
            // 
            // txttim
            // 
            this.txttim.Location = new System.Drawing.Point(679, 8);
            this.txttim.Name = "txttim";
            this.txttim.Size = new System.Drawing.Size(187, 21);
            this.txttim.TabIndex = 1;
            this.txttim.Text = "Nhập số phòng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(617, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tìm phòng";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gvroom);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 75);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1117, 292);
            this.panelControl2.TabIndex = 5;
            // 
            // gvroom
            // 
            this.gvroom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvroom.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gvroom.BackgroundColor = System.Drawing.Color.White;
            this.gvroom.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.gvroom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvroom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvroom.GridColor = System.Drawing.SystemColors.Control;
            this.gvroom.Location = new System.Drawing.Point(2, 2);
            this.gvroom.Name = "gvroom";
            this.gvroom.Size = new System.Drawing.Size(1113, 288);
            this.gvroom.TabIndex = 0;
            this.gvroom.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvroom_CellContentClick);
            this.gvroom.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvroom_CellFormatting);
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.label8);
            this.panelControl3.Controls.Add(this.textBox2);
            this.panelControl3.Controls.Add(this.textBox1);
            this.panelControl3.Controls.Add(this.label7);
            this.panelControl3.Controls.Add(this.cmbloaiphong);
            this.panelControl3.Controls.Add(this.cmbtinhtrang);
            this.panelControl3.Controls.Add(this.txtghichu);
            this.panelControl3.Controls.Add(this.txtsophong);
            this.panelControl3.Controls.Add(this.label5);
            this.panelControl3.Controls.Add(this.label4);
            this.panelControl3.Controls.Add(this.label2);
            this.panelControl3.Controls.Add(this.label1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 367);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1117, 310);
            this.panelControl3.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(582, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Không được thuê";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Red;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(585, 70);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(44, 21);
            this.textBox2.TabIndex = 12;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(517, 70);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(47, 21);
            this.textBox1.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(514, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Được thuê";
            // 
            // cmbloaiphong
            // 
            this.cmbloaiphong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbloaiphong.FormattingEnabled = true;
            this.cmbloaiphong.Location = new System.Drawing.Point(448, 35);
            this.cmbloaiphong.Name = "cmbloaiphong";
            this.cmbloaiphong.Size = new System.Drawing.Size(276, 21);
            this.cmbloaiphong.TabIndex = 9;
            // 
            // cmbtinhtrang
            // 
            this.cmbtinhtrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtinhtrang.FormattingEnabled = true;
            this.cmbtinhtrang.Items.AddRange(new object[] {
            "Đã thuê",
            "Sẵn sàng",
            "Đang bảo trì",
            "Đang dọn"});
            this.cmbtinhtrang.Location = new System.Drawing.Point(99, 73);
            this.cmbtinhtrang.Name = "cmbtinhtrang";
            this.cmbtinhtrang.Size = new System.Drawing.Size(232, 21);
            this.cmbtinhtrang.TabIndex = 7;
            // 
            // txtghichu
            // 
            this.txtghichu.Location = new System.Drawing.Point(784, 27);
            this.txtghichu.Multiline = true;
            this.txtghichu.Name = "txtghichu";
            this.txtghichu.Size = new System.Drawing.Size(321, 133);
            this.txtghichu.TabIndex = 6;
            // 
            // txtsophong
            // 
            this.txtsophong.Location = new System.Drawing.Point(99, 30);
            this.txtsophong.Name = "txtsophong";
            this.txtsophong.Size = new System.Drawing.Size(232, 21);
            this.txtsophong.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(900, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ghi chú";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(386, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Loại phòng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tình trạng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số phòng";
            // 
            // FormRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 677);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FormRoom";
            this.Text = "FormRoom";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvroom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btninsertroom;
        private DevExpress.XtraBars.BarButtonItem btnxoaroom;
        private DevExpress.XtraBars.BarButtonItem btnsuaroom;
        private DevExpress.XtraBars.BarButtonItem btnconfirm;
        private DevExpress.XtraBars.BarButtonItem btnback;
        private DevExpress.XtraBars.BarButtonItem btnexit;
        private DevExpress.XtraBars.BarButtonItem btnreload;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.DataGridView gvroom;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.ComboBox cmbloaiphong;
        private System.Windows.Forms.ComboBox cmbtinhtrang;
        private System.Windows.Forms.TextBox txtghichu;
        private System.Windows.Forms.TextBox txtsophong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btntim;
        private System.Windows.Forms.TextBox txttim;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
    }
}