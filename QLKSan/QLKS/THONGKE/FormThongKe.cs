
using QLKS.INHOADON;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS
{
    public partial class FormThongKe : Form
    {
        double doanhthu = 0;
        public FormThongKe()
        {
            InitializeComponent();
          
        }

        private void btnlaydl_Click(object sender, EventArgs e)
        {
            doanhthu = 0;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/thongke?ngay="+dt1.Value.ToString()+"").Result;
            var thongke = response.Content.ReadAsAsync<IEnumerable<LuuHD>>().Result;
            dataGridView1.DataSource = thongke;
            dataGridView1.Columns["Ngaylap"].HeaderText = "Ngày lập";
            dataGridView1.Columns["Tienphong"].HeaderText = "Tiền phòng";
            dataGridView1.Columns["Tiendichvu"].HeaderText = "Tiền dịch vụ";
            dataGridView1.Columns["VAT"].HeaderText = "Thuế VAT";
            dataGridView1.Columns["Khuyenmai"].HeaderText = "Khuyến  mãi";
            dataGridView1.Columns["IDDAT"].HeaderText = "ID Đặt";


            var t = thongke.ToList();
            foreach(var pi in t)
            {
                var vat = ((pi.VAT / 100) * (pi.Tienphong + pi.Tiendichvu));
                var km = ((pi.Khuyenmai / 100) * (pi.Tienphong + pi.Tiendichvu));
                doanhthu = doanhthu + (pi.Tienphong + pi.Tiendichvu + vat - km) ;
            }
          
            txtdoanhthu.Text = doanhthu.ToString() + " vnd";
            Program.ngaytruoc = dt1.Value.ToString();
            // Program.ngaysau = dt2.Value.ToString();
            Program.tongtien = doanhthu;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
