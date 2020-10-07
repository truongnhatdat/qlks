namespace QLKS
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sttmanv = new System.Windows.Forms.ToolStripStatusLabel();
            this.stthoten = new System.Windows.Forms.ToolStripStatusLabel();
            this.sttnhom = new System.Windows.Forms.ToolStripStatusLabel();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup10 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnthongke = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup11 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btninbaocao = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnnv = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnphong = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnloaiphong = new DevExpress.XtraBars.BarButtonItem();
            this.btnthietbi = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btndv = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btndatphong = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnkhachhang = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnlogin = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup12 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup13 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.tabFormContentContainer1 = new DevExpress.XtraBars.TabFormContentContainer();
            this.applicationMenu1 = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.tabFormPage1 = new DevExpress.XtraBars.TabFormPage();
            this.tabFormControl1 = new DevExpress.XtraBars.TabFormControl();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabFormControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sttmanv,
            this.stthoten,
            this.sttnhom});
            this.statusStrip1.Location = new System.Drawing.Point(0, 400);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1035, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sttmanv
            // 
            this.sttmanv.Name = "sttmanv";
            this.sttmanv.Size = new System.Drawing.Size(40, 17);
            this.sttmanv.Text = "MaNV";
            // 
            // stthoten
            // 
            this.stthoten.Name = "stthoten";
            this.stthoten.Size = new System.Drawing.Size(43, 17);
            this.stthoten.Text = "Họ tên";
            // 
            // sttnhom
            // 
            this.sttnhom.Name = "sttnhom";
            this.sttnhom.Size = new System.Drawing.Size(41, 17);
            this.sttnhom.Text = "Nhóm";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup10,
            this.ribbonPageGroup11});
            this.ribbonPage3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ribbonPage3.ImageOptions.Image")));
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "Thống kê & In ấn";
            // 
            // ribbonPageGroup10
            // 
            this.ribbonPageGroup10.ItemLinks.Add(this.btnthongke);
            this.ribbonPageGroup10.Name = "ribbonPageGroup10";
            this.ribbonPageGroup10.Text = "ribbonPageGroup10";
            // 
            // btnthongke
            // 
            this.btnthongke.Caption = "Thống kê";
            this.btnthongke.Id = 11;
            this.btnthongke.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnthongke.ImageOptions.Image")));
            this.btnthongke.Name = "btnthongke";
            this.btnthongke.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnthongke_ItemClick);
            // 
            // ribbonPageGroup11
            // 
            this.ribbonPageGroup11.ItemLinks.Add(this.btninbaocao);
            this.ribbonPageGroup11.Name = "ribbonPageGroup11";
            this.ribbonPageGroup11.Text = "ribbonPageGroup11";
            // 
            // btninbaocao
            // 
            this.btninbaocao.Caption = "In báo cáo";
            this.btninbaocao.Id = 12;
            this.btninbaocao.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btninbaocao.ImageOptions.Image")));
            this.btninbaocao.Name = "btninbaocao";
            this.btninbaocao.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btninbaocao_ItemClick);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3,
            this.ribbonPageGroup4,
            this.ribbonPageGroup5,
            this.ribbonPageGroup7,
            this.ribbonPageGroup8,
            this.ribbonPageGroup9});
            this.ribbonPage2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ribbonPage2.ImageOptions.Image")));
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Danh mục";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnnv);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "ribbonPageGroup3";
            // 
            // btnnv
            // 
            this.btnnv.Caption = "Nhân viên";
            this.btnnv.Id = 3;
            this.btnnv.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnnv.ImageOptions.Image")));
            this.btnnv.Name = "btnnv";
            this.btnnv.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnnv_ItemClick);
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnphong);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "ribbonPageGroup4";
            // 
            // btnphong
            // 
            this.btnphong.Caption = "Phòng";
            this.btnphong.Id = 4;
            this.btnphong.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnphong.ImageOptions.Image")));
            this.btnphong.Name = "btnphong";
            this.btnphong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnphong_ItemClick);
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.btnloaiphong);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "ribbonPageGroup5";
            // 
            // btnloaiphong
            // 
            this.btnloaiphong.Caption = "Loại phòng";
            this.btnloaiphong.Id = 5;
            this.btnloaiphong.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnloaiphong.ImageOptions.Image")));
            this.btnloaiphong.Name = "btnloaiphong";
            this.btnloaiphong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnloaiphong_ItemClick);
            // 
            // btnthietbi
            // 
            this.btnthietbi.Caption = "Thiết bị";
            this.btnthietbi.Id = 6;
            this.btnthietbi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnthietbi.ImageOptions.Image")));
            this.btnthietbi.Name = "btnthietbi";
            //this.btnthietbi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnthietbi_ItemClick);
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.ItemLinks.Add(this.btndv);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            this.ribbonPageGroup7.Text = "ribbonPageGroup7";
            // 
            // btndv
            // 
            this.btndv.Caption = "Dịch vụ";
            this.btndv.Id = 7;
            this.btndv.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btndv.ImageOptions.Image")));
            this.btndv.Name = "btndv";
            this.btndv.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btndv_ItemClick);
            // 
            // ribbonPageGroup8
            // 
            this.ribbonPageGroup8.ItemLinks.Add(this.btndatphong);
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            this.ribbonPageGroup8.Text = "ribbonPageGroup8";
            // 
            // btndatphong
            // 
            this.btndatphong.Caption = "Đặt phòng";
            this.btndatphong.Id = 9;
            this.btndatphong.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btndatphong.ImageOptions.Image")));
            this.btndatphong.Name = "btndatphong";
            this.btndatphong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btndatphong_ItemClick);
            // 
            // ribbonPageGroup9
            // 
            this.ribbonPageGroup9.ItemLinks.Add(this.btnkhachhang);
            this.ribbonPageGroup9.Name = "ribbonPageGroup9";
            this.ribbonPageGroup9.Text = "ribbonPageGroup9";
            // 
            // btnkhachhang
            // 
            this.btnkhachhang.Caption = "Khách hàng";
            this.btnkhachhang.Id = 10;
            this.btnkhachhang.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnkhachhang.ImageOptions.Image")));
            this.btnkhachhang.Name = "btnkhachhang";
            this.btnkhachhang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnkhachhang_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup12,
            this.ribbonPageGroup13});
            this.ribbonPage1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ribbonPage1.ImageOptions.Image")));
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Hệ thống";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnlogin);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // btnlogin
            // 
            this.btnlogin.Caption = "Đăng nhập";
            this.btnlogin.Id = 1;
            this.btnlogin.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnlogin.ImageOptions.Image")));
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnlogin_ItemClick);
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Đổi thông tin";
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // ribbonPageGroup12
            // 
            this.ribbonPageGroup12.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup12.Name = "ribbonPageGroup12";
            this.ribbonPageGroup12.Text = "ribbonPageGroup12";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Đăng xuất";
            this.barButtonItem1.Id = 13;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // ribbonPageGroup13
            // 
            this.ribbonPageGroup13.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup13.Name = "ribbonPageGroup13";
            this.ribbonPageGroup13.Text = "ribbonPageGroup13";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Tạo tài khoản";
            this.barButtonItem3.Id = 15;
            this.barButtonItem3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.Image")));
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Caption = "H";
            this.barButtonItem8.Id = 8;
            this.barButtonItem8.Name = "barButtonItem8";
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationButtonDropDownControl = this.tabFormContentContainer1;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnlogin,
            this.barButtonItem2,
            this.btnnv,
            this.btnphong,
            this.btnloaiphong,
            this.btnthietbi,
            this.btndv,
            this.barButtonItem8,
            this.btndatphong,
            this.btnkhachhang,
            this.btnthongke,
            this.btninbaocao,
            this.barButtonItem1,
            this.barButtonItem3});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 50);
            this.ribbonControl1.MaxItemId = 16;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPage3});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowPageHeadersInFormCaption = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl1.Size = new System.Drawing.Size(1035, 71);
            // 
            // tabFormContentContainer1
            // 
            this.tabFormContentContainer1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("tabFormContentContainer1.Appearance.Image")));
            this.tabFormContentContainer1.Appearance.Options.UseImage = true;
            this.tabFormContentContainer1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabFormContentContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFormContentContainer1.Location = new System.Drawing.Point(0, 50);
            this.tabFormContentContainer1.Name = "tabFormContentContainer1";
            this.tabFormContentContainer1.Size = new System.Drawing.Size(1035, 372);
            this.tabFormContentContainer1.TabIndex = 4;
            // 
            // applicationMenu1
            // 
            this.applicationMenu1.Name = "applicationMenu1";
            this.applicationMenu1.Ribbon = this.ribbonControl1;
            // 
            // tabFormPage1
            // 
            this.tabFormPage1.ContentContainer = this.tabFormContentContainer1;
            this.tabFormPage1.Name = "tabFormPage1";
            this.tabFormPage1.Text = "Page 0";
            // 
            // tabFormControl1
            // 
            this.tabFormControl1.Location = new System.Drawing.Point(0, 0);
            this.tabFormControl1.Name = "tabFormControl1";
            this.tabFormControl1.Pages.Add(this.tabFormPage1);
            this.tabFormControl1.SelectedPage = this.tabFormPage1;
            this.tabFormControl1.ShowAddPageButton = false;
            this.tabFormControl1.Size = new System.Drawing.Size(1035, 50);
            this.tabFormControl1.TabForm = this;
            this.tabFormControl1.TabIndex = 3;
            this.tabFormControl1.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 422);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.tabFormContentContainer1);
            this.Controls.Add(this.tabFormControl1);
            this.IsMdiContainer = true;
            this.Name = "FormMain";
            this.TabFormControl = this.tabFormControl1;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabFormControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        public System.Windows.Forms.ToolStripStatusLabel sttmanv;
        public System.Windows.Forms.ToolStripStatusLabel stthoten;
        public System.Windows.Forms.ToolStripStatusLabel sttnhom;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnlogin;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem btnnv;
        private DevExpress.XtraBars.BarButtonItem btnphong;
        private DevExpress.XtraBars.BarButtonItem btnloaiphong;
        private DevExpress.XtraBars.BarButtonItem btnthietbi;
        private DevExpress.XtraBars.BarButtonItem btndv;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.BarButtonItem btndatphong;
        private DevExpress.XtraBars.BarButtonItem btnkhachhang;
        private DevExpress.XtraBars.BarButtonItem btnthongke;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup9;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup10;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu1;
        private DevExpress.XtraBars.BarButtonItem btninbaocao;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup11;
        public DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup12;
        private DevExpress.XtraBars.TabFormContentContainer tabFormContentContainer1;
        private DevExpress.XtraBars.TabFormControl tabFormControl1;
        private DevExpress.XtraBars.TabFormPage tabFormPage1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup13;
    }
}

