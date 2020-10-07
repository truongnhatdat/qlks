using QLKS.INDON;
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

namespace QLKS.QUANTRI
{
    public partial class FormHoaDon : Form
    {
        public int xn = 0;
        List<Chitiethoadonphong> cthd = new List<Chitiethoadonphong>();
        List<Chitiethoadondv> ctdv = new List<Chitiethoadondv>();
        List<Chitiethoadon> cthdin = new List<Chitiethoadon>();
        public float vat;
        public float khuyenmai;
        double thanhtien;
        public FormHoaDon()
        {
            InitializeComponent();

            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response1 = client1.GetAsync("api/ChitietHDPhong?iddat=" + Program.idhd + "").Result;
            var ctbillphong = response1.Content.ReadAsAsync<IEnumerable<CTDP>>().Result;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/TypeRoom").Result;
            var loai = response.Content.ReadAsAsync<IEnumerable<LoaiPhong>>().Result;

            HttpClient client3 = new HttpClient();
            client3.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response3 = client3.GetAsync("api/Room").Result;
            var room = response3.Content.ReadAsAsync<IEnumerable<Room>>().Result;

            var query1 = from t1 in ctbillphong
                         from t2 in loai
                         from t3 in room
                         where t1.Sophong == t3.Sophong && t3.Loaiphong == t2.Loaiphong1 && t1.IDDAT == Program.idhd
                         select new
                         {
                             t1.Ngayden,
                             t1.Ngaydi,
                             Sophong = t3.Sophong,
                             Tien = t2.Gia,
                       
                         };
       
            HttpClient client2 = new HttpClient();
            client2.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response2 = client2.GetAsync("api/CTHDDV?idhd=" + Program.idhd + "").Result;
            var cthddv = response2.Content.ReadAsAsync<IEnumerable<CTDDV>>().Result;


            HttpClient client4 = new HttpClient();
            client4.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response4 = client4.GetAsync("api/Service").Result;
            var service = response4.Content.ReadAsAsync<IEnumerable<Service>>().Result;
            var query2 = from t1 in cthddv
                         from t2 in service
                         where t1.IDDV == t2.IDDV && t1.IDDAT == Program.idhd
                         select new
                         {
                             Tendv = t2.TenDV,
                             Gia = t2.GiaDV,
                             soluong = t1.Soluong
                         };
            if (query1 == null && query2 == null)
            {
                MessageBox.Show("Hóa đơn này không hợp lệ", "", MessageBoxButtons.OK);
                this.Close();
                //return;
            }
            else if (query2 == null)
            {
                var x1 = query1.ToList();
                foreach (var pi in x1)
                {
                    // thiet lap de in ra
                    Chitiethoadon ct2 = new Chitiethoadon();
                    ct2.sophong = pi.Sophong;
                    ct2.Ngayden = pi.Ngayden;
                    ct2.Ngaydi = pi.Ngaydi;
                    ct2.giaphong = pi.Tien;
                    // thiet lap hien thi
                    Chitiethoadonphong ct = new Chitiethoadonphong();
                    ct.sophong = pi.Sophong;
                    ct.Ngayden = pi.Ngayden;
                    ct.Ngaydi = pi.Ngaydi;
                    ct.giaphong = pi.Tien;
                    DateTime n1 = new DateTime(pi.Ngayden.Year, pi.Ngayden.Month, pi.Ngayden.Day);
                    DateTime n2 = new DateTime(pi.Ngaydi.Year, pi.Ngaydi.Month, pi.Ngaydi.Day);
                    if (DateTime.Compare(n1, n2) == 0)
                    {
                        ct.songayo = 1;
                        ct2.songayo = 1;
                    }
                    else
                    {
                        TimeSpan time = n2 - n1;
                        ct.songayo = time.Days;
                        ct2.songayo = time.Days;
                    }
                    cthd.Add(ct);
                    cthdin.Add(ct2);
                }
                //return;
            }
            else if (query1 == null)
            {
                var x2  = query2.ToList();
                foreach(var pi in x2)
                {
                    // thiet lap de in ra
                    Chitiethoadon ct2 = new Chitiethoadon();
                    ct2.tendv = pi.Tendv;
                    ct2.soluong = pi.soluong;
                    ct2.giadv = pi.Gia;
                    // hien thi
                    Chitiethoadondv ct = new Chitiethoadondv();
                    ct.TenDV = pi.Tendv;
                    ct.soluong = pi.soluong;
                    ct.giadv = pi.Gia;
                    ctdv.Add(ct);
                    cthdin.Add(ct2);
                }
            }
            else
            {
                var x1 = query1.ToList();
                var x2 = query2.ToList();
                if (x1.Count > x2.Count)
                {
                    for (int i = 0; i < x2.Count; i++)
                    {
                        // thiet lap de in ra
                        Chitiethoadon ct1 = new Chitiethoadon();
                        ct1.sophong = x1[i].Sophong;
                        ct1.Ngayden = x1[i].Ngayden;
                        ct1.Ngaydi = x1[i].Ngaydi;
                        ct1.giaphong = x1[i].Tien;
                        ct1.tendv= x2[i].Tendv;
                        ct1.soluong = x2[i].soluong;
                        ct1.giadv = x2[i].Gia;
                        // hien thi
                        Chitiethoadonphong ct = new Chitiethoadonphong();
                        ct.sophong = x1[i].Sophong;
                        ct.Ngayden = x1[i].Ngayden;
                        ct.Ngaydi = x1[i].Ngaydi;
                        ct.giaphong = x1[i].Tien;
                        DateTime n1 = new DateTime(x1[i].Ngayden.Year, x1[i].Ngayden.Month, x1[i].Ngayden.Day);
                        DateTime n2 = new DateTime(x1[i].Ngaydi.Year, x1[i].Ngaydi.Month, x1[i].Ngaydi.Day);
                        if (DateTime.Compare(n1, n2) == 0)
                        {
                            ct.songayo = 1;
                            ct1.songayo = 1;
                        }
                        else
                        {

                            TimeSpan time = n2 - n1;
                            ct.songayo = time.Days;
                            ct1.songayo = time.Days;
                        }
                        cthd.Add(ct);
                        Chitiethoadondv ct2 = new Chitiethoadondv();
                        ct2.TenDV = x2[i].Tendv;
                        ct2.soluong = x2[i].soluong;
                        ct2.giadv = x2[i].Gia;
                        ctdv.Add(ct2);
                        cthdin.Add(ct1);
                        
                    }
                    for(int k=x1.Count-1;k>=x2.Count;k--)
                    {
                        // thiet lap de in ra
                        Chitiethoadon ct1 = new Chitiethoadon();
                        ct1.sophong = x1[k].Sophong;
                        ct1.Ngayden = x1[k].Ngayden;
                        ct1.Ngaydi = x1[k].Ngaydi;
                        ct1.giaphong = x1[k].Tien;
                        ct1.tendv = "";
                        ct1.soluong = null;
                        ct1.giadv = null;
                        // hien thi
                        Chitiethoadonphong ct = new Chitiethoadonphong();
                        ct.sophong = x1[k].Sophong;
                        ct.Ngayden = x1[k].Ngayden;
                        ct.Ngaydi = x1[k].Ngaydi;
                        ct.giaphong = x1[k].Tien;
                        DateTime n1 = new DateTime(x1[k].Ngayden.Year, x1[k].Ngayden.Month, x1[k].Ngayden.Day);
                        DateTime n2 = new DateTime(x1[k].Ngaydi.Year, x1[k].Ngaydi.Month, x1[k].Ngaydi.Day);
                        if (DateTime.Compare(n1, n2) == 0)
                        {
                            ct.songayo = 1;
                            ct1.songayo = 1;
                        }
                        else
                        {

                            TimeSpan time = n2 - n1;
                            ct.songayo = time.Days;
                            ct1.songayo = time.Days;
                        }
                      
                        cthd.Add(ct);
                        Chitiethoadondv ct2 = new Chitiethoadondv();
                        ct2.TenDV = "";
                        ct2.soluong = null;
                        ct2.giadv = null;
                        ctdv.Add(ct2);
                        cthdin.Add(ct1);
                    }
                    //return;
                }
                else if(x2.Count>x1.Count)
                {
                    for (int i = 0; i < x1.Count; i++)
                    {
                        // thiet lap de in ra
                        Chitiethoadon ct1 = new Chitiethoadon();
                        ct1.sophong = x1[i].Sophong;
                        ct1.Ngayden = x1[i].Ngayden;
                        ct1.Ngaydi = x1[i].Ngaydi;
                        ct1.giaphong = x1[i].Tien;
                        ct1.tendv = x2[i].Tendv;
                        ct1.soluong = x2[i].soluong;
                        ct1.giadv = x2[i].Gia;
                        // hien thi
                        Chitiethoadonphong ct = new Chitiethoadonphong();
                        ct.sophong = x1[i].Sophong;
                        ct.Ngayden = x1[i].Ngayden;
                        ct.Ngaydi = x1[i].Ngaydi;
                        ct.giaphong = x1[i].Tien;
                        DateTime n1 = new DateTime(x1[i].Ngayden.Year, x1[i].Ngayden.Month, x1[i].Ngayden.Day);
                        DateTime n2 = new DateTime(x1[i].Ngaydi.Year, x1[i].Ngaydi.Month, x1[i].Ngaydi.Day);
                        if (DateTime.Compare(n1, n2) == 0)
                        {
                            ct.songayo = 1;
                            ct1.songayo = 1;
                        }
                        else
                        {

                            TimeSpan time = n2 - n1;
                            ct.songayo = time.Days;
                            ct1.songayo = time.Days;
                        }
                        cthd.Add(ct);
                        Chitiethoadondv ct2 = new Chitiethoadondv();
                        ct2.TenDV = x2[i].Tendv;
                        ct2.soluong = x2[i].soluong;
                        ct2.giadv = x2[i].Gia;
                        ctdv.Add(ct2);
                        cthdin.Add(ct1);
                    }
                    for (int k = x2.Count - 1; k >= x1.Count; k--)
                    {
                        // thiet lap de in ra
                        Chitiethoadon ct1 = new Chitiethoadon();
                        ct1.sophong = null;
                        ct1.Ngayden = null;
                        ct1.Ngaydi = null;
                        ct1.giaphong = null;
                        ct1.tendv= x2[k].Tendv;
                        ct1.soluong = x2[k].soluong;
                        ct1.giadv = x2[k].Gia;
                        // hien thi
                        Chitiethoadonphong ct = new Chitiethoadonphong();
                        ct.sophong = null;
                        ct.Ngayden = null;
                        ct.Ngaydi = null;
                        ct.giaphong = null;
                        cthd.Add(ct);
                        Chitiethoadondv ct2 = new Chitiethoadondv();
                        ct2.TenDV = x2[k].Tendv;
                        ct2.soluong = x2[k].soluong;
                        ct2.giadv = x2[k].Gia;
                        ctdv.Add(ct2);
                        cthdin.Add(ct1);
                    }
                }
                else
                {
                    for (int i = 0; i < x2.Count; i++)
                    {
                        // thiet lap de in ra
                        Chitiethoadon ct1 = new Chitiethoadon();
                        ct1.sophong = x1[i].Sophong;
                        ct1.Ngayden = x1[i].Ngayden;
                        ct1.Ngaydi = x1[i].Ngaydi;
                        ct1.giaphong = x1[i].Tien;
                        ct1.tendv = x2[i].Tendv;
                        ct1.soluong = x2[i].soluong;
                        ct1.giadv = x2[i].Gia;
                        // hien thi
                        Chitiethoadonphong ct = new Chitiethoadonphong();
                        ct.sophong = x1[i].Sophong;
                        ct.Ngayden = x1[i].Ngayden;
                        ct.Ngaydi = x1[i].Ngaydi;
                        ct.giaphong = x1[i].Tien;
                        DateTime n1 = new DateTime(x1[i].Ngayden.Year, x1[i].Ngayden.Month, x1[i].Ngayden.Day);
                        DateTime n2 = new DateTime(x1[i].Ngaydi.Year, x1[i].Ngaydi.Month, x1[i].Ngaydi.Day);
                        if (DateTime.Compare(n1, n2) == 0)
                        {
                            ct.songayo = 1;
                            ct1.songayo = 1;
                        }
                        else
                        {

                            TimeSpan time = n2 - n1;
                            ct.songayo = time.Days;
                            ct1.songayo = time.Days;
                        }
                        cthd.Add(ct);
                        Chitiethoadondv ct2 = new Chitiethoadondv();
                        ct2.TenDV = x2[i].Tendv;
                        ct2.soluong = x2[i].soluong;
                        ct2.giadv = x2[i].Gia;
                        ctdv.Add(ct2);
                        cthdin.Add(ct1);
                    }
                }
            }
            Program.hoadon = cthdin;
            txttienphong.Text = Program.giaphong.ToString() + " vnd";
            txttiendv.Text = Program.giadv.ToString() + " vnd";
            
            dataGridView1.DataSource = cthd;
            dataGridView2.DataSource = ctdv;
            dataGridView1.Columns["sophong"].HeaderText = "Số phòng";
            dataGridView1.Columns["Ngayden"].HeaderText = "Ngày đến";
            dataGridView1.Columns["Ngaydi"].HeaderText = "Ngày đi";
            dataGridView1.Columns["giaphong"].HeaderText = "Giá phòng";
            dataGridView1.Columns["songayo"].HeaderText = "Số ngày ở";
            dataGridView2.Columns["Tendv"].HeaderText = "Tên dịch vụ";
            dataGridView2.Columns["soluong"].HeaderText = "Số lượng";
            dataGridView2.Columns["giadv"].HeaderText = "Giá dịch vụ";
            

        }

        private void FormHoaDon_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int i;
            try
            {
                i = dataGridView1.CurrentRow.Index;
                if (dataGridView1.Rows[i].Cells[0].Value == null)
                {
                    txttenphong.Text = "";
                    txtngayden.Text = "";
                    txtngaydi.Text = "";
                    txtgiaphong.Text = "";
                    return;

                }

             
                else
                {
                    txttenphong.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    txtngayden.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    txtngaydi.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    txtgiaphong.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                 
                    return;
                }
            }
            catch(Exception ex)
            {

            }
           
           
        }

        private void btnsaoluu_Click(object sender, EventArgs e)
        {
            if(xn==0)
            {
                MessageBox.Show("Bạn chưa xuất hóa đơn", "", MessageBoxButtons.OK);
                return;
            }
            if(radioButton1.Checked==true && txtvat.Text == "")
            {
                MessageBox.Show("Thiếu thông tin vat", "", MessageBoxButtons.OK);
                return;
            }
            if(radioButton2.Checked==true && txtkhuyenmai.Text=="")
            {
                MessageBox.Show("Thiếu thông tin khuyến mãi", "", MessageBoxButtons.OK);
                return;
            }
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/kiemtrahd").Result;
            var kt = response.Content.ReadAsAsync<IEnumerable<LuuHD>>().Result;
            var kh = from t in kt where t.IDDAT == Program.idhd select t;
            var c = kh.ToList();
            foreach(var pi in c)
            {
                if (pi.IDDAT.Equals(Program.idhd))
                {
                    MessageBox.Show("Hóa đơn đã có.Không lưu được", "", MessageBoxButtons.OK);
                    return;
                }
            }
           
            var khach = kh.ToList();
            LuuHD luuhd = new LuuHD();
           
            luuhd.Tienphong = Program.giaphong;
            luuhd.Tiendichvu = Program.giadv;
            if(radioButton1.Checked==true)
            {
                luuhd.VAT = double.Parse(txtvat.Text);
            }
            else
            {
                luuhd.VAT = 10;
            }
            if(radioButton2.Checked==true)
            {
                luuhd.Khuyenmai = double.Parse(txtkhuyenmai.Text);
            }
            else
            {
                luuhd.Khuyenmai = 0;
            }
            luuhd.Ngaylap = DateTime.Now;
            luuhd.IDDAT = Program.idhd;
     
            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response1 = client1.PostAsJsonAsync<LuuHD>("api/luuhoadon", luuhd).Result;
            if (response1.IsSuccessStatusCode == true)
            {
                MessageBox.Show("Đã lưu vào cơ sở dữ liệu", "", MessageBoxButtons.OK);
               // var up = from d in kt where d.IDDAT == Program.idhd select d.IDDAT;
                HttpClient client3 = new HttpClient();
                client3.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage response3 = client3.GetAsync("api/ChitietHDPhong?iddat=" + Program.idhd + "").Result;
                var ct = response3.Content.ReadAsAsync<IEnumerable<CTDP>>().Result;
                var up = from d in ct where d.IDDAT == Program.idhd select d.Sophong;
                var a = up.ToList();
                foreach(var pi in a)
                {
                    Room room = new Room();
                    room.Tinhtrang = "Sẵn sàng";
                    HttpClient client2 = new HttpClient();
                    client2.BaseAddress = new Uri("https://localhost:44326/");
                    HttpResponseMessage response2 = client2.PutAsJsonAsync<Room>("api/update1?sophong=" + pi + "", room).Result;
                }
                return;
            }
            else
            {
                MessageBox.Show("Lỗi khi lưu", "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btninhd_Click(object sender, EventArgs e)
        {
            if(txttongtien.Text=="")
            {
                MessageBox.Show("Chưa tổng tiền.Vui lòng tính tổng tiền", "", MessageBoxButtons.OK);
                return;
            }
            Program.tongtien = thanhtien;
            xn = 1;
            FormInHD frmin = new FormInHD();
            frmin.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtvat.Enabled = true;
           
           // radioButton2.Enabled  = true;
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtkhuyenmai.Enabled = true;
           
        }

        private void btntongtien_Click(object sender, EventArgs e)
        {
            thanhtien = 0;
            vat = 10;
            vat = vat / 100;
            if (radioButton1.Checked == true)
            {
                //txtvat.Enabled = true;
                if (txtvat.Text == "")
                {
                    MessageBox.Show("Điền vào vat", "", MessageBoxButtons.OK);
                    return;
                }
                vat = float.Parse(txtvat.Text);
                vat = vat / 100;
            }

            if (radioButton2.Checked == true)
            {
                if (txtkhuyenmai.Text == "")
                {
                    MessageBox.Show("Điền vào khuyến mãi", "", MessageBoxButtons.OK);
                    return;
                }
                khuyenmai = float.Parse(txtkhuyenmai.Text);
                khuyenmai = khuyenmai / 100;
            }
            
            thanhtien = Math.Round(Program.giaphong + Program.giadv + (Program.giaphong + Program.giadv) *vat - (Program.giaphong + Program.giadv) *khuyenmai);
            txttongtien.Text = thanhtien.ToString() + " vnd";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Formchinhsach fcs = new Formchinhsach();
            fcs.Show();
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            txtvat.Enabled = false;

            vat = 0;
        }

        private void radioButton4_CheckedChanged_1(object sender, EventArgs e)
        {
            txtkhuyenmai.Enabled = false;
            khuyenmai = 0;
            
           
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            int i;
            try
            {
                i = dataGridView2.CurrentRow.Index;
         

                if (dataGridView2.Rows[i].Cells[0] == null)
                {
                    
                    txttendv.Text = "";
                    txtsoluong.Text = "";
                    txtgiadv.Text = "";
                    return;
                }
                else
                {
                 
                    txttendv.Text = dataGridView2.Rows[i].Cells[0].Value.ToString();

                    txtsoluong.Text = dataGridView2.Rows[i].Cells[1].Value.ToString();
                    txtgiadv.Text = dataGridView2.Rows[i].Cells[2].Value.ToString();
                    return;
                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}
