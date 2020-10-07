using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLKS.INDON
{
    public partial class hoadon : DevExpress.XtraReports.UI.XtraReport
    {
        public double tien = Program.tongtien;
        public double giaphong = Program.giaphong;
        public double giadv = Program.giadv;
        public string tenkh = Program.hoten;
        public string nguoilap = Program.hotennv;
        public hoadon()
        {
            InitializeComponent();
        }

        private void hoadon_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lbtong.Text = string.Format("{0:#,##0}",tien) + " vnd";
            lbphong.Text = string.Format("{0:#,##0}", giaphong) + " vnd";

            lbdv.Text = string.Format("{0:#,##0}", giadv) + " vnd";
            lbhoten.Text = tenkh;
            lbnguoilap.Text = nguoilap;
        }
    }
}
