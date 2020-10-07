using QLKS;
using QLKS.INHOADON;
using QLKS.REPORT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;


namespace QLKS.REPORT
{
    public partial class FormInBaoCao : Form
    {
      
     

        public FormInBaoCao()
        {
            InitializeComponent();
        }

        private void frmBangKeCPP_Load(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/thongke?ngay="+Program.ngaytruoc+"").Result;
            var thongke = response.Content.ReadAsAsync<IEnumerable<LuuHD>>().Result;
            var t = thongke.ToList();

            rptbaocao rpt = new rptbaocao();
            rpt.DataSource = t;

            printControl1.PrintingSystem = rpt.PrintingSystem;
            rpt.CreateDocument();
            
        }


        private void printPreviewBarItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void zoomBarEditItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewStaticItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barStaticItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void progressBarEditItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewStaticItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void zoomTrackBarEditItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarItem28_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barDockControlTop_Click(object sender, EventArgs e)
        {

        }

        private void barDockControlBottom_Click(object sender, EventArgs e)
        {

        }

        private void barDockControlLeft_Click(object sender, EventArgs e)
        {

        }

        private void barDockControlRight_Click(object sender, EventArgs e)
        {

        }

        private void printPreviewBarCheckItem1_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarCheckItem2_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarCheckItem3_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarCheckItem4_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarCheckItem5_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarCheckItem6_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarCheckItem7_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarCheckItem8_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarCheckItem9_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarCheckItem10_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarCheckItem11_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarCheckItem12_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarCheckItem13_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarCheckItem14_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarCheckItem15_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarCheckItem16_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarCheckItem17_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
