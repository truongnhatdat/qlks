namespace QLKS
{
    partial class FormThietBi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormThietBi));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btntim = new System.Windows.Forms.Button();
            this.txttim = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnthem = new DevExpress.XtraBars.BarButtonItem();
            this.btnxoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnsua = new DevExpress.XtraBars.BarButtonItem();
            this.btnxacnhan = new DevExpress.XtraBars.BarButtonItem();
            this.btnquaylai = new DevExpress.XtraBars.BarButtonItem();
            this.btnthoat = new DevExpress.XtraBars.BarButtonItem();
            this.btnreload = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gvdevice = new System.Windows.Forms.DataGridView();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.cmbtinhtrang = new System.Windows.Forms.ComboBox();
            this.cmbsophong = new System.Windows.Forms.ComboBox();
            this.txtghichu = new System.Windows.Forms.TextBox();
            this.txtsoluong = new System.Windows.Forms.TextBox();
            this.txtthietbi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvdevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btntim);
            this.panelControl1.Controls.Add(this.txttim);
            this.panelControl1.Controls.Add(this.label6);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 40);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1255, 53);
            this.panelControl1.TabIndex = 0;
            // 
            // btntim
            // 
            this.btntim.Location = new System.Drawing.Point(795, 6);
            this.btntim.Name = "btntim";
            this.btntim.Size = new System.Drawing.Size(75, 23);
            this.btntim.TabIndex = 2;
            this.btntim.Text = "Tìm";
            this.btntim.UseVisualStyleBackColor = true;
            this.btntim.Click += new System.EventHandler(this.btntim_Click);
            // 
            // txttim
            // 
            this.txttim.Location = new System.Drawing.Point(593, 6);
            this.txttim.Name = "txttim";
            this.txttim.Size = new System.Drawing.Size(186, 21);
            this.txttim.TabIndex = 1;
            this.txttim.Text = "Nhập vào số phòng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(536, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tìm kiếm";
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
            this.btnthem,
            this.btnxoa,
            this.btnsua,
            this.btnxacnhan,
            this.btnquaylai,
            this.btnthoat,
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnthem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnxoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnsua, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnxacnhan, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnquaylai, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnthoat, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnreload, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnthem
            // 
            this.btnthem.Caption = "Thêm";
            this.btnthem.Id = 0;
            this.btnthem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnthem.ImageOptions.Image")));
            this.btnthem.Name = "btnthem";
            this.btnthem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnthem_ItemClick);
            // 
            // btnxoa
            // 
            this.btnxoa.Caption = "Xóa ";
            this.btnxoa.Id = 1;
            this.btnxoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnxoa.ImageOptions.Image")));
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnxoa_ItemClick);
            // 
            // btnsua
            // 
            this.btnsua.Caption = "Sửa";
            this.btnsua.Id = 2;
            this.btnsua.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnsua.ImageOptions.Image")));
            this.btnsua.Name = "btnsua";
            this.btnsua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnsua_ItemClick);
            // 
            // btnxacnhan
            // 
            this.btnxacnhan.Caption = "Xác nhận";
            this.btnxacnhan.Id = 3;
            this.btnxacnhan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnxacnhan.ImageOptions.Image")));
            this.btnxacnhan.Name = "btnxacnhan";
            this.btnxacnhan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnxacnhan_ItemClick);
            // 
            // btnquaylai
            // 
            this.btnquaylai.Caption = "Quay lại";
            this.btnquaylai.Id = 4;
            this.btnquaylai.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnquaylai.ImageOptions.Image")));
            this.btnquaylai.Name = "btnquaylai";
            this.btnquaylai.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnquaylai_ItemClick);
            // 
            // btnthoat
            // 
            this.btnthoat.Caption = "Thoát";
            this.btnthoat.Id = 5;
            this.btnthoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnthoat.ImageOptions.Image")));
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnthoat_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(1255, 40);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 719);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1255, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 679);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1255, 40);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 679);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gvdevice);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 93);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1255, 189);
            this.panelControl2.TabIndex = 5;
            // 
            // gvdevice
            // 
            this.gvdevice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvdevice.BackgroundColor = System.Drawing.Color.White;
            this.gvdevice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvdevice.Dock = System.Windows.Forms.DockStyle.Top;
            this.gvdevice.Location = new System.Drawing.Point(2, 2);
            this.gvdevice.Name = "gvdevice";
            this.gvdevice.Size = new System.Drawing.Size(1251, 181);
            this.gvdevice.TabIndex = 0;
            this.gvdevice.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvdevice_CellContentClick);
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.cmbtinhtrang);
            this.panelControl3.Controls.Add(this.cmbsophong);
            this.panelControl3.Controls.Add(this.txtghichu);
            this.panelControl3.Controls.Add(this.txtsoluong);
            this.panelControl3.Controls.Add(this.txtthietbi);
            this.panelControl3.Controls.Add(this.label5);
            this.panelControl3.Controls.Add(this.label4);
            this.panelControl3.Controls.Add(this.label3);
            this.panelControl3.Controls.Add(this.label2);
            this.panelControl3.Controls.Add(this.label1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 282);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1255, 437);
            this.panelControl3.TabIndex = 6;
            // 
            // cmbtinhtrang
            // 
            this.cmbtinhtrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtinhtrang.FormattingEnabled = true;
            this.cmbtinhtrang.Items.AddRange(new object[] {
            "Tốt",
            "Không tốt"});
            this.cmbtinhtrang.Location = new System.Drawing.Point(555, 73);
            this.cmbtinhtrang.Name = "cmbtinhtrang";
            this.cmbtinhtrang.Size = new System.Drawing.Size(260, 21);
            this.cmbtinhtrang.TabIndex = 9;
            // 
            // cmbsophong
            // 
            this.cmbsophong.FormattingEnabled = true;
            this.cmbsophong.Location = new System.Drawing.Point(105, 72);
            this.cmbsophong.Name = "cmbsophong";
            this.cmbsophong.Size = new System.Drawing.Size(288, 21);
            this.cmbsophong.TabIndex = 8;
            // 
            // txtghichu
            // 
            this.txtghichu.Location = new System.Drawing.Point(870, 23);
            this.txtghichu.Multiline = true;
            this.txtghichu.Name = "txtghichu";
            this.txtghichu.Size = new System.Drawing.Size(350, 145);
            this.txtghichu.TabIndex = 7;
            // 
            // txtsoluong
            // 
            this.txtsoluong.Location = new System.Drawing.Point(555, 26);
            this.txtsoluong.Name = "txtsoluong";
            this.txtsoluong.Size = new System.Drawing.Size(260, 21);
            this.txtsoluong.TabIndex = 6;
            // 
            // txtthietbi
            // 
            this.txtthietbi.Location = new System.Drawing.Point(105, 26);
            this.txtthietbi.Name = "txtthietbi";
            this.txtthietbi.Size = new System.Drawing.Size(288, 21);
            this.txtthietbi.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1013, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ghi chú";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(484, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tình trạng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(484, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số lượng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số phòng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên thiết bị";
            // 
            // FormThietBi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 719);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FormThietBi";
            this.Text = "FormThietBi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvdevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnthem;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnxoa;
        private DevExpress.XtraBars.BarButtonItem btnsua;
        private DevExpress.XtraBars.BarButtonItem btnxacnhan;
        private DevExpress.XtraBars.BarButtonItem btnquaylai;
        private DevExpress.XtraBars.BarButtonItem btnthoat;
        private DevExpress.XtraBars.BarButtonItem btnreload;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.DataGridView gvdevice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbtinhtrang;
        private System.Windows.Forms.ComboBox cmbsophong;
        private System.Windows.Forms.TextBox txtghichu;
        private System.Windows.Forms.TextBox txtsoluong;
        private System.Windows.Forms.TextBox txtthietbi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btntim;
        private System.Windows.Forms.TextBox txttim;
        private System.Windows.Forms.Label label6;
    }
}