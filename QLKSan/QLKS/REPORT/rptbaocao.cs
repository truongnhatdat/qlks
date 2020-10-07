using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLKS.REPORT
{
    public partial class rptbaocao : DevExpress.XtraReports.UI.XtraReport
    {
        
        public DateTime thang = DateTime.Parse(Program.ngaytruoc);
        public string hoten = Program.hotennv;
        public double doanhthu = Program.tongtien;
        public rptbaocao()
        {
            InitializeComponent();
        }

        private void rptbaocao_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lbThang.Text = "THỐNG KÊ DOANH THU THÁNG " + thang.ToString("MM/yyyy");
            lbtt.Text = (string.Format("{0:#,##0.00}", doanhthu));
            lbhoten.Text = hoten;
        }
    }
}
