namespace QLKS
{
    partial class Formdv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formdv));
            BaiqiSoft.HtmlEditorControl.FormatHtmlOptions formatHtmlOptions1 = new BaiqiSoft.HtmlEditorControl.FormatHtmlOptions();
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gvdv = new System.Windows.Forms.DataGridView();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtiddv = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtnd = new BaiqiSoft.HtmlEditorControl.MstHtmlEditor();
            this.btnbrowse = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtdvt = new System.Windows.Forms.TextBox();
            this.txtgia = new System.Windows.Forms.TextBox();
            this.txttendv = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picturedv = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvdv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturedv)).BeginInit();
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
            this.btnxoa.Caption = "Xóa";
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
            this.btnxacnhan.Caption = "xác nhận";
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
            this.barDockControlTop.Size = new System.Drawing.Size(1370, 40);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 512);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1370, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 472);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1370, 40);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 472);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gvdv);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 40);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1370, 180);
            this.panelControl1.TabIndex = 4;
            // 
            // gvdv
            // 
            this.gvdv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvdv.BackgroundColor = System.Drawing.Color.White;
            this.gvdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvdv.Dock = System.Windows.Forms.DockStyle.Top;
            this.gvdv.Location = new System.Drawing.Point(2, 2);
            this.gvdv.Name = "gvdv";
            this.gvdv.Size = new System.Drawing.Size(1366, 162);
            this.gvdv.TabIndex = 0;
            this.gvdv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvdv_CellContentClick);
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.Controls.Add(this.txtiddv);
            this.panelControl2.Controls.Add(this.label4);
            this.panelControl2.Controls.Add(this.txtnd);
            this.panelControl2.Controls.Add(this.btnbrowse);
            this.panelControl2.Controls.Add(this.label6);
            this.panelControl2.Controls.Add(this.txtdvt);
            this.panelControl2.Controls.Add(this.txtgia);
            this.panelControl2.Controls.Add(this.txttendv);
            this.panelControl2.Controls.Add(this.label5);
            this.panelControl2.Controls.Add(this.label3);
            this.panelControl2.Controls.Add(this.label2);
            this.panelControl2.Controls.Add(this.picturedv);
            this.panelControl2.Controls.Add(this.label1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 220);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1370, 292);
            this.panelControl2.TabIndex = 5;
            // 
            // txtiddv
            // 
            this.txtiddv.Enabled = false;
            this.txtiddv.Location = new System.Drawing.Point(297, 32);
            this.txtiddv.Name = "txtiddv";
            this.txtiddv.Size = new System.Drawing.Size(222, 21);
            this.txtiddv.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(220, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "ID Dịch vụ";
            // 
            // txtnd
            // 
            formatHtmlOptions1.BreakBeforeBR = true;
            formatHtmlOptions1.ClosingSingleTags = true;
            formatHtmlOptions1.IndentHtmlTags = true;
            formatHtmlOptions1.IndentScript = true;
            formatHtmlOptions1.IndentSpaces = 4;
            formatHtmlOptions1.IndentWithTabs = false;
            formatHtmlOptions1.LowercaseTags = true;
            formatHtmlOptions1.QuoteAttributeValues = true;
            this.txtnd.FormatHtmlOptions = formatHtmlOptions1;
            this.txtnd.LanguageConfig = null;
            this.txtnd.Location = new System.Drawing.Point(541, 22);
            this.txtnd.Name = "txtnd";
            this.txtnd.SelectionLength = 0;
            this.txtnd.SelectionStart = 0;
            this.txtnd.Size = new System.Drawing.Size(746, 244);
            this.txtnd.TabIndex = 13;
            // 
            // btnbrowse
            // 
            this.btnbrowse.Location = new System.Drawing.Point(51, 155);
            this.btnbrowse.Name = "btnbrowse";
            this.btnbrowse.Size = new System.Drawing.Size(75, 23);
            this.btnbrowse.TabIndex = 12;
            this.btnbrowse.Text = "Lấy hình";
            this.btnbrowse.UseVisualStyleBackColor = true;
            this.btnbrowse.Click += new System.EventHandler(this.btnbrowse_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(804, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Nội dung";
            // 
            // txtdvt
            // 
            this.txtdvt.Location = new System.Drawing.Point(298, 120);
            this.txtdvt.Name = "txtdvt";
            this.txtdvt.Size = new System.Drawing.Size(221, 21);
            this.txtdvt.TabIndex = 8;
            // 
            // txtgia
            // 
            this.txtgia.Location = new System.Drawing.Point(297, 91);
            this.txtgia.Name = "txtgia";
            this.txtgia.Size = new System.Drawing.Size(222, 21);
            this.txtgia.TabIndex = 7;
            // 
            // txttendv
            // 
            this.txttendv.Location = new System.Drawing.Point(297, 64);
            this.txttendv.Name = "txttendv";
            this.txttendv.Size = new System.Drawing.Size(222, 21);
            this.txttendv.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(217, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Đơn vị tính";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(254, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Giá";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên dịch vụ";
            // 
            // picturedv
            // 
            this.picturedv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picturedv.Location = new System.Drawing.Point(13, 35);
            this.picturedv.Name = "picturedv";
            this.picturedv.Size = new System.Drawing.Size(176, 104);
            this.picturedv.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturedv.TabIndex = 1;
            this.picturedv.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hình ảnh";
            // 
            // Formdv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 512);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "Formdv";
            this.Text = "Formdv";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvdv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturedv)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem btnthem;
        private DevExpress.XtraBars.BarButtonItem btnxoa;
        private DevExpress.XtraBars.BarButtonItem btnsua;
        private DevExpress.XtraBars.BarButtonItem btnxacnhan;
        private DevExpress.XtraBars.BarButtonItem btnquaylai;
        private DevExpress.XtraBars.BarButtonItem btnthoat;
        private DevExpress.XtraBars.BarButtonItem btnreload;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.DataGridView gvdv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picturedv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtdvt;
        private System.Windows.Forms.TextBox txtgia;
        private System.Windows.Forms.TextBox txttendv;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnbrowse;
        private BaiqiSoft.HtmlEditorControl.MstHtmlEditor txtnd;
        private System.Windows.Forms.TextBox txtiddv;
        private System.Windows.Forms.Label label4;
    }
}