using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using QLKS.INHOADON;

namespace QLKS
{
    static class Program
    {
        public static FormMain FormChinh;
        public static string manv;
        public static string ngaytruoc;
        public static int co = 0;
        public static string taikhoan = "";
        public static string matkhau = "";
        public static string nhom;
        public static string hoten;
        public static string hotennv;
        public static List<Chitiethoadon> hoadon = new List<Chitiethoadon>();
        public static string cmt;
        public static long idhd;
        public static double giaphong;
        public static double giadv;
        public static double tongtien;
        public static int flagkh = 0;
        public static string cmtkh;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            FormChinh = new FormMain();
            Application.Run(FormChinh);
        }
    }
}
