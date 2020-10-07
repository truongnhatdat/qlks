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
using Microsoft.VisualBasic;
using QLKS.INHOADON;
using QLKS.QUANTRI;

namespace QLKS
{
    public partial class FormDatphong : Form
    {
        private static int flag1 = 0;
        private static int flag2 = 0;
        private static int flag3 = 0;
        private static int x1 = 0;
        private static int x2 = 0;
        private static int x3 = 0;
        private static int y1 = 0;
        private static int y2 = 0;
        private static int y3 = 0;
      
        public string idhd = "";
        TypeAssistant assistant;
        public string cmt;
        public string sdt;
        public string hoten;
     
        public FormDatphong()
        {
            InitializeComponent();
 
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/Bill").Result;
            var bill = response.Content.ReadAsAsync<IEnumerable<Datphong>>().Result;
            gvbill.DataSource = bill;
          
            gvbill.Columns["IDDAT"].HeaderText = "ID Đặt";
            gvbill.Columns["Ngaydat"].HeaderText = "Ngày đặt";
            gvbill.Columns["MaNV"].HeaderText = "Mã nhân viên";
            gvbill.Columns["CMT"].HeaderText = "Chứng minh thư";
            gvbill.Columns["Ghichu"].HeaderText = "Ghi chú";
            //this.gvbill.Sort(this.gvbill.Columns["IDDAT"], ListSortDirection.Descending);
            txtmanv.Enabled = txtidhd.Enabled = txtkh.Enabled
              = btnquaylaihd.Enabled = btnxacnhanhd.Enabled = txtghichu.Enabled = txttongtien.Enabled = false;

        }
        private void gvbill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
      
            int i;
            i = gvbill.CurrentRow.Index;
            txtidhd.Text = gvbill.Rows[i].Cells[0].Value.ToString();
            dtngaylap.Text = gvbill.Rows[i].Cells[1].Value.ToString();
            txtmanv.Text = gvbill.Rows[i].Cells[2].Value.ToString();
            txtkh.Text = gvbill.Rows[i].Cells[3].Value.ToString();
            if (gvbill.Rows[i].Cells[4].Value == null)
            {
                txtghichu.Text = "";
            }
            else
            {
                txtghichu.Text = gvbill.Rows[i].Cells[4].Value.ToString();
            }
           
            ThanhTien(long.Parse(gvbill.Rows[i].Cells[0].Value.ToString()));

            gvctphong.Columns["IDDAT"].HeaderText = "ID Đặt";
            gvctphong.Columns["sophong"].HeaderText = "Số phòng";
            gvctphong.Columns["loaiphong"].HeaderText = "Loại phòng";
            gvctphong.Columns["Ngayden"].HeaderText = "Ngày đến";
            gvctphong.Columns["Ngaydi"].HeaderText = "Ngày đi";

            gvcthddv.Columns["TenDV"].HeaderText = "Tên dịch vụ";
            gvcthddv.Columns["IDDV"].HeaderText = "ID Dịch vụ";
            gvcthddv.Columns["IDDAT"].HeaderText = "ID Đặt";
            gvcthddv.Columns["Soluong"].HeaderText = "Số lượng";
            ThanhTien(long.Parse(gvbill.Rows[i].Cells[0].Value.ToString()));


        }
      
        public void ThanhTien(long iddat)
        {
            double gia1 = 0;
            double gia2 = 0;
            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response1 = client1.GetAsync("api/ChitietHDPhong?iddat=" + iddat + "").Result;
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
                         where t1.Sophong == t3.Sophong && t3.Loaiphong == t2.Loaiphong1 && t1.IDDAT == long.Parse(txtidhd.Text)
                         select new
                         {
                             loaip = t2.Loaiphong1,
                             Tien = t2.Gia,
                             ngayden = t1.Ngayden,
                             ngaydi = t1.Ngaydi
                    
                         };
            var t = query1.ToList();
            var tx = ctbillphong.ToList();
            List<chitietdatphong> listctdatphong = new List<chitietdatphong>();
            for (int i=0;i<tx.Count;i++)
            {
                chitietdatphong ct = new chitietdatphong();
                ct.IDDAT = tx[i].IDDAT;
                ct.sophong = tx[i].Sophong;
                var k = from t2 in loai from t3 in room where tx[i].Sophong == t3.Sophong && t3.Loaiphong==t2.Loaiphong1 select t2.Loaiphong1;
                var c = k.ToList();
                ct.loaiphong = c[0];
                ct.Ngayden = tx[i].Ngayden;
                ct.Ngaydi = tx[i].Ngaydi;
                listctdatphong.Add(ct);
               
            }
            gvctphong.DataSource = listctdatphong;
            for (int k = 0; k < t.Count; k++)
            {
                TimeSpan Ngay = t[k].ngaydi - t[k].ngayden;
                if (Ngay.Days == 0)
                {
                    gia1 = gia1 + t[k].Tien;
                }
                else
                {
                    gia1 = gia1 + t[k].Tien * Ngay.Days;
                }

            }
            txttienphong.Text = gia1.ToString() + " vnd";
            txtidhdp.Text = txtidhd.Text;
            btnthemctphong.Enabled = btnxoactphong.Enabled = btnsuactphong.Enabled = btnreloadctphong.Enabled = true;
            btnquaylaictphong.Enabled = btnxacnhanctphong.Enabled = txtidhdp.Enabled = cmbsophong.Enabled = dtngayden.Enabled = dtngaydi.Enabled = txttienphong.Enabled = false;

            HttpClient client2 = new HttpClient();
            client2.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response2 = client2.GetAsync("api/CTHDDV?idhd=" + iddat + "").Result;
            var cthddv = response2.Content.ReadAsAsync<IEnumerable<CTDDV>>().Result;
            txtidhddv.Text = txtidhd.Text;

            HttpClient client4 = new HttpClient();
            client4.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response4 = client4.GetAsync("api/Service").Result;
            var service = response4.Content.ReadAsAsync<IEnumerable<Service>>().Result;

            var dv = from d1 in service from d2 in cthddv where d1.IDDV == d2.IDDV select d1.TenDV;
            List<chitietdatdv> ctdv = new List<chitietdatdv>();

            var tdv = cthddv.ToList();
            for(int i=0;i<tdv.Count;i++)
            {
                chitietdatdv ct = new chitietdatdv();
                ct.IDDAT = tdv[i].IDDAT;
                ct.IDDV = tdv[i].IDDV;
                var c = dv.ToList();
                ct.TenDV = c[i];
                ct.soluong = tdv[i].Soluong;
                ctdv.Add(ct);
            }
            gvcthddv.DataSource = ctdv;
            var query2 = from t1 in cthddv
                         from t2 in service
                         where t1.IDDV == t2.IDDV && t1.IDDAT == long.Parse(txtidhd.Text)
                         select new
                         {

                             Gia = t2.GiaDV,
                             soluong = t1.Soluong
                         };

            var l = query2.ToList();
            for (int j = 0; j < l.Count; j++)
            {
                gia2 = gia2 + l[j].Gia * l[j].soluong;
            }
            txttiendv.Text = gia2.ToString() + " vnd";
            double gia = gia1 + gia2;
            txttongtien.Text = gia.ToString() + " vnd";
            btnthemdv.Enabled = btnxoadv.Enabled = btnsuadv.Enabled = btnreloaddv.Enabled = true;
            btnquaylaidv.Enabled = btnxacnhandv.Enabled = txtdv.Enabled = txtidhddv.Enabled = txtsl.Enabled = txttiendv.Enabled = false;
            Program.giaphong = gia1;
            Program.giadv = gia2;
            idhd = txtidhd.Text;
         
        }
        private void btnthemhd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtidhd.Text = txtsdt.Text = txtkh.Text = txttenkh.Text = txtghichu.Text = txttongtien.Text
               = txtidhdp.Text = cmbsophong.Text = txttienphong.Text
               = txtidhddv.Text = txtiddv.Text = txtdv.Text = txtsl.Text = txttiendv.Text = "";
            dtngayden.Value = dtngaydi.Value = dtngaylap.Value = DateTime.Now;
            gvctphong.DataSource = gvcthddv.DataSource = null;
            txtmanv.Text = Program.manv;
            txtkh.Enabled = true;
            btnthemhd.Enabled = btnxoahd.Enabled = btnsuahd.Enabled = btnthoathd.Enabled = btnreloadhd.Enabled = false;

            btnquaylaihd.Enabled = btnxacnhanhd.Enabled = txtghichu.Enabled = true;
            flag1 = 1;
        }


        private void btnxoahd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("Bạn có chắc xóa", "", MessageBoxButtons.OK);
            btnthemhd.Enabled = btnxoahd.Enabled = btnsuahd.Enabled = btnthoathd.Enabled = btnreloadhd.Enabled = false;
            btnquaylaihd.Enabled = btnxacnhanhd.Enabled = true;
            flag2 = 1;
        }

        private void btnsuahd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            btnthemhd.Enabled = btnxoahd.Enabled = btnsuahd.Enabled = btnthoathd.Enabled = btnreloadhd.Enabled = false;
            txtkh.Enabled
              = btnquaylaihd.Enabled = btnxacnhanhd.Enabled = txtghichu.Enabled = txtkh.Enabled = true;
            flag3 = 1;
        }

        private void btnxacnhanhd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (flag1 == 1)
            {
                if (txtmanv.Text == "")
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin", "", MessageBoxButtons.OK);
                    return;
                }
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44326/");
                Datphong bill = new Datphong();

                bill.Ngaydat = DateTime.Now;
                bill.MaNV = Program.manv;
                bill.CMT = txtkh.Text;
                bill.Ghichu = txtghichu.Text;

                HttpResponseMessage response = client.PostAsJsonAsync<Datphong>("api/Bill", bill).Result;
                if (response.IsSuccessStatusCode == true)
                {
                    MessageBox.Show("Thêm thành công", "", MessageBoxButtons.OK);
                    //gvbill.Sort(gvbill.Columns[0], ListSortDirection.Descending);
                    HttpClient clientt = new HttpClient();
                    clientt.BaseAddress = new Uri("https://localhost:44326/");
                    HttpResponseMessage responset = clientt.GetAsync("api/Bill").Result;
                    var billt = responset.Content.ReadAsAsync<IEnumerable<Datphong>>().Result;
                    gvbill.DataSource = billt;
                    // reset textbox
                    txtidhd.Text = txtsdt.Text = txtkh.Text = txttenkh.Text = txtghichu.Text = txttongtien.Text
         = txtidhdp.Text = cmbsophong.Text = txttienphong.Text
         = txtidhddv.Text = txtiddv.Text = txtdv.Text = txtsl.Text = txttiendv.Text = "";
                    dtngayden.Value = dtngaydi.Value = dtngaylap.Value = DateTime.Now;

                    btnthemhd.Enabled = btnxoahd.Enabled = btnsuahd.Enabled = btnthoathd.Enabled = btnreloadhd.Enabled = true;
                    txtmanv.Enabled = txtidhd.Enabled = txtkh.Enabled = dtngaylap.Enabled
                      = btnquaylaihd.Enabled = btnxacnhanhd.Enabled = txtghichu.Enabled = false;
                    
                    flag1 = 0;
                    return;
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "", MessageBoxButtons.OK);
                    btnthemhd.Enabled = btnxoahd.Enabled = btnsuahd.Enabled = btnthoathd.Enabled = btnreloadhd.Enabled = true;
                    txtmanv.Enabled = txtidhd.Enabled = txtkh.Enabled = dtngaylap.Enabled
                      = btnquaylaihd.Enabled = btnxacnhanhd.Enabled = txtghichu.Enabled = false;
                    flag1 = 0;
                    return;
                }
            }
            if (flag2 == 1)
            {
                HttpClient clienta = new HttpClient();
                clienta.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage responsea = clienta.GetAsync("api/kiemtrahd").Result;
                var kt = responsea.Content.ReadAsAsync<IEnumerable<LuuHD>>().Result;
                var kh = from tn in kt where tn.IDDAT == long.Parse(txtidhd.Text) select tn;
                var d = kh.ToList();
                foreach (var pi in d)
                {
                    if (pi.IDDAT.Equals(long.Parse(txtidhd.Text)))
                    {
                        MessageBox.Show("Phiếu đặt đã xuất hóa đơn.Không thể xóa", "", MessageBoxButtons.OK);
                        return;
                    }
                }

                // thiết lập trạng thái phòng
                HttpClient client2 = new HttpClient();
                client2.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage response2 = client2.GetAsync("api/ChitietHDPhong?iddat=" + long.Parse(txtidhd.Text) + "").Result;
                var ctbillphong = response2.Content.ReadAsAsync<IEnumerable<CTDP>>().Result;
                //// update trang thai phong
                var t = ctbillphong.ToList();
                if (t.Count != 0)
                {

                    for (int i = 0; i < t.Count; i++)
                    {
                        XoaCTHDP(long.Parse(txtidhd.Text), t[i].Sophong);
                    }
                }

                // xoa chi tiet dich vu
                HttpClient client3 = new HttpClient();
                client3.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage response3 = client3.GetAsync("api/CTHDDV?idhd=" + long.Parse(txtidhd.Text) + "").Result;
                var cthddv = response3.Content.ReadAsAsync<IEnumerable<CTDDV>>().Result;
                var tx = cthddv.ToList();
                if (tx.Count != 0)
                {

                    for (int i = 0; i < tx.Count; i++)
                    {
                        XoaCTHDDV(long.Parse(txtidhd.Text), tx[i].IDDV);
                    }
                }
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage response = client.DeleteAsync("api/Bill?iddat=" + txtidhd.Text + "").Result;
                if (response.IsSuccessStatusCode == true)
                {



                    MessageBox.Show("Xóa thành công", "", MessageBoxButtons.OK);
                    HttpClient clientt = new HttpClient();
                    clientt.BaseAddress = new Uri("https://localhost:44326/");
                    HttpResponseMessage responset = clientt.GetAsync("api/Bill").Result;
                    var billt = responset.Content.ReadAsAsync<IEnumerable<Datphong>>().Result;
                    gvbill.DataSource = billt;
                    // reset textbox
                    txtidhd.Text = txtsdt.Text = txtkh.Text = txttenkh.Text = txtghichu.Text = txttongtien.Text
         = txtidhdp.Text = cmbsophong.Text = txttienphong.Text
         = txtidhddv.Text = txtiddv.Text = txtdv.Text = txtsl.Text = txttiendv.Text = "";
                    dtngayden.Value = dtngaydi.Value = dtngaylap.Value = DateTime.Now;

                    btnthemhd.Enabled = btnxoahd.Enabled = btnsuahd.Enabled = btnthoathd.Enabled = btnreloadhd.Enabled = true;
                    txtmanv.Enabled = txtidhd.Enabled = txtkh.Enabled = dtngaylap.Enabled
                      = btnquaylaihd.Enabled = btnxacnhanhd.Enabled = txtghichu.Enabled = false;
                    flag2 = 0;
                    return;
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "", MessageBoxButtons.OK);
                    btnthemhd.Enabled = btnxoahd.Enabled = btnsuahd.Enabled = btnthoathd.Enabled = btnreloadhd.Enabled = true;
                    txtmanv.Enabled = txtidhd.Enabled = txtkh.Enabled = dtngaylap.Enabled
                      = btnquaylaihd.Enabled = btnxacnhanhd.Enabled = txtghichu.Enabled = false;
                    flag2 = 0;
                    return;
                }
            }
            if (flag3 == 1)
            {
                HttpClient clienta = new HttpClient();
                clienta.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage responsea = clienta.GetAsync("api/kiemtrahd").Result;
                var kt = responsea.Content.ReadAsAsync<IEnumerable<LuuHD>>().Result;
                var kh = from t in kt where t.IDDAT == long.Parse(txtidhd.Text) select t;
                var d = kh.ToList();
                foreach (var pi in d)
                {
                    if (pi.IDDAT.Equals(long.Parse(txtidhd.Text)))
                    {
                        MessageBox.Show("Phiếu đặt đã xuất hóa đơn.Không thể sửa", "", MessageBoxButtons.OK);
                        return;
                    }
                }
                if (txtidhd.Text == "")
                {
                    MessageBox.Show("Mã phiếu đặt rỗng", "", MessageBoxButtons.OK);
                    return;
                }
                if (txtkh.Text == "" || txtmanv.Text == "")
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin", "", MessageBoxButtons.OK);
                    return;
                }
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44326/");
                Datphong bill = new Datphong();
                bill.IDDAT = long.Parse(txtidhd.Text);

                bill.Ngaydat = DateTime.Now;
                bill.MaNV = Program.manv;
                bill.CMT = txtkh.Text;
                bill.Ghichu = txtghichu.Text;

                HttpResponseMessage response = client.PutAsJsonAsync<Datphong>("api/Bill?iddat=" + txtidhd.Text + "", bill).Result;
                if (response.IsSuccessStatusCode == true)
                {
                    MessageBox.Show("Sửa thành công", "", MessageBoxButtons.OK);
                    HttpClient clientt = new HttpClient();
                    clientt.BaseAddress = new Uri("https://localhost:44326/");
                    HttpResponseMessage responset = clientt.GetAsync("api/Bill").Result;
                    var billt = responset.Content.ReadAsAsync<IEnumerable<Datphong>>().Result;
                    gvbill.DataSource = billt;
                    // reset textbox
                    txtidhd.Text = txtsdt.Text = txtkh.Text = txttenkh.Text = txtghichu.Text = txttongtien.Text
         = txtidhdp.Text = cmbsophong.Text = txttienphong.Text
         = txtidhddv.Text = txtiddv.Text = txtdv.Text = txtsl.Text = txttiendv.Text = "";
                    dtngayden.Value = dtngaydi.Value = dtngaylap.Value = DateTime.Now;

                    btnthemhd.Enabled = btnxoahd.Enabled = btnsuahd.Enabled = btnthoathd.Enabled = btnreloadhd.Enabled = true;
                    txtmanv.Enabled = txtidhd.Enabled = txtkh.Enabled = dtngaylap.Enabled
                      = btnquaylaihd.Enabled = btnxacnhanhd.Enabled = txtghichu.Enabled = false;
                    flag3 = 0;
                    return;
                }
                else
                {
                    MessageBox.Show("Sửa thất bại", "", MessageBoxButtons.OK);
                    btnthemhd.Enabled = btnxoahd.Enabled = btnsuahd.Enabled = btnthoathd.Enabled = btnreloadhd.Enabled = true;
                    txtmanv.Enabled = txtidhd.Enabled = txtkh.Enabled = dtngaylap.Enabled
                      = btnquaylaihd.Enabled = btnxacnhanhd.Enabled = txtghichu.Enabled = false;
                    flag3 = 0;
                    return;
                }
            }
        }

        private void btnquaylaihd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtidhd.Text = txtsdt.Text = txtkh.Text = txttenkh.Text = txtghichu.Text = txttongtien.Text
         = txtidhdp.Text = cmbsophong.Text = txttienphong.Text
         = txtidhddv.Text = txtiddv.Text = txtdv.Text = txtsl.Text = txttiendv.Text = "";
            dtngayden.Value = dtngaydi.Value = dtngaylap.Value = DateTime.Now;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/Bill").Result;
            var bill = response.Content.ReadAsAsync<IEnumerable<Datphong>>().Result;
            gvbill.DataSource = bill;
            btnthemhd.Enabled = btnxoahd.Enabled = btnsuahd.Enabled = btnthoathd.Enabled = btnreloadhd.Enabled = true;
            txtmanv.Enabled = txtidhd.Enabled = txtkh.Enabled = dtngaylap.Enabled
              = btnquaylaihd.Enabled = btnxacnhanhd.Enabled = txtghichu.Enabled = false;
            flag1 = flag2 = flag3 = 0;
        }

        private void btnthoathd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnreloadhd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtidhd.Text = txtsdt.Text = txtkh.Text = txttenkh.Text = txtghichu.Text = txttongtien.Text
         = txtidhdp.Text = cmbsophong.Text = txttienphong.Text
         = txtidhddv.Text = txtiddv.Text = txtdv.Text = txtsl.Text = txttiendv.Text = "";
            dtngayden.Value = dtngaydi.Value = dtngaylap.Value = DateTime.Now;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/Bill").Result;
            var bill = response.Content.ReadAsAsync<IEnumerable<Datphong>>().Result;
            gvbill.DataSource = bill;
            btnthemhd.Enabled = btnxoahd.Enabled = btnsuahd.Enabled = btnthoathd.Enabled = btnreloadhd.Enabled = true;
            txtmanv.Enabled = txtidhd.Enabled = txtkh.Enabled = dtngaylap.Enabled
              = btnquaylaihd.Enabled = btnxacnhanhd.Enabled = txtghichu.Enabled = false;
        }

        private void btnthemctphong_Click(object sender, EventArgs e)
        {
            cmbsophong.Text = "";
            dtngayden.Value = dtngaydi.Value = DateTime.Now;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/TypeRoom").Result;
            var loai = response.Content.ReadAsAsync<IEnumerable<LoaiPhong>>().Result;
            cmbloaip.DataSource = loai;
            cmbloaip.DisplayMember = "Loaiphong1";


            btnthemctphong.Enabled = btnxoactphong.Enabled = btnsuactphong.Enabled = btnreloadctphong.Enabled = false;
            btnquaylaictphong.Enabled = btnxacnhanctphong.Enabled = cmbloaip.Enabled = dtngayden.Enabled = dtngaydi.Enabled = cmbsophong.Enabled = true;
            x1 = 1;
        }

        private void btnxoactphong_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Bạn có chắc xóa", "", MessageBoxButtons.OK);
            btnthemctphong.Enabled = btnxoactphong.Enabled = btnsuactphong.Enabled = btnreloadctphong.Enabled = false;
            btnquaylaictphong.Enabled = btnxacnhanctphong.Enabled = true;
            x2 = 1;
        }

        private void btnsuactphong_Click(object sender, EventArgs e)
        {

            btnthemctphong.Enabled = btnxoactphong.Enabled = btnsuactphong.Enabled = btnreloadctphong.Enabled = cmbloaip.Enabled = cmbsophong.Enabled = false;
            btnquaylaictphong.Enabled = btnxacnhanctphong.Enabled = dtngayden.Enabled = dtngaydi.Enabled = true;
            x3 = 1;
        }
        public void XoaCTHDP(long idhd, long sophong)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.DeleteAsync("api/ChitietHDPhong?sophong=" + sophong + "&iddat=" + idhd + "").Result;
            Room room = new Room();
            room.Tinhtrang = "Sẵn sàng";
            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response1 = client1.PutAsJsonAsync<Room>("api/update1?sophong=" + sophong + "", room).Result;
        }
        public void XoaCTHDDV(long idhd, long iddv)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.DeleteAsync("api/CTHDDV?iddvdv=" + iddv + "&idhd=" + idhd + "").Result;
        }
        private void btnxacnhanctphong_Click(object sender, EventArgs e)
        {
            if (x1 == 1)
            {
                if (cmbsophong.Text == "" || txtidhdp.Text == "")
                {
                    MessageBox.Show("Vui lòng điền thông tin đầy đủ", "", MessageBoxButtons.OK);
                    return;
                }
                HttpClient clienta = new HttpClient();
                clienta.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage responsea = clienta.GetAsync("api/kiemtrahd").Result;
                var kt = responsea.Content.ReadAsAsync<IEnumerable<LuuHD>>().Result;
                var kh = from t in kt where t.IDDAT == long.Parse(txtidhd.Text) select t;
                var d = kh.ToList();
                foreach (var pi in d)
                {
                    if (pi.IDDAT.Equals(long.Parse(txtidhd.Text)))
                    {
                        MessageBox.Show("Phiếu đặt đã xuất hóa đơn.Không thể thêm", "", MessageBoxButtons.OK);
                        return;
                    }
                }
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44326/");
                CTDP cthd = new CTDP();
                cthd.Sophong = long.Parse(cmbsophong.Text);
                cthd.IDDAT = long.Parse(txtidhd.Text);
                cthd.Ngayden = dtngayden.Value;
                cthd.Ngaydi = dtngaydi.Value;
                DateTime n1 = new DateTime(dtngayden.Value.Year, dtngayden.Value.Month, dtngayden.Value.Day);
                DateTime n2 = new DateTime(dtngaydi.Value.Year, dtngaydi.Value.Month, dtngaydi.Value.Day);
                DateTime n3 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                if (DateTime.Compare(n1, n2) > 0 || DateTime.Compare(n2,n3)<0 || DateTime.Compare(n1,n3)<0)
                {
                    MessageBox.Show("Ngày chọn không phù hợp", "", MessageBoxButtons.OK);
                    return;
                }
                HttpResponseMessage response = client.PostAsJsonAsync<CTDP>("api/ChitietHDPhong", cthd).Result;
                if (response.IsSuccessStatusCode == true)
                {
                    MessageBox.Show("Thêm thành công", "", MessageBoxButtons.OK);
                    ThanhTien(long.Parse(txtidhdp.Text));
                    
                    Room room = new Room();
                    room.Tinhtrang = "Đã thuê";
                    HttpClient client1 = new HttpClient();
                    client1.BaseAddress = new Uri("https://localhost:44326/");
                    HttpResponseMessage response1 = client1.PutAsJsonAsync<Room>("api/update1?sophong=" + cmbsophong.Text + "", room).Result;
                    btnthemctphong.Enabled = btnxoactphong.Enabled = btnsuactphong.Enabled = btnreloadctphong.Enabled = true;
                    btnquaylaictphong.Enabled = btnxacnhanctphong.Enabled = cmbloaip.Enabled = txtidhdp.Enabled = cmbsophong.Enabled = dtngayden.Enabled = dtngaydi.Enabled = false;
                    x1 = 0;
                    cmbsophong.Text = cmbloaip.Text = "";
                    dtngaydi.Value = dtngayden.Value = DateTime.Now;
                    return;
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "", MessageBoxButtons.OK);
                    btnthemctphong.Enabled = btnxoactphong.Enabled = btnsuactphong.Enabled = btnreloadctphong.Enabled = true;
                    btnquaylaictphong.Enabled = btnxacnhanctphong.Enabled = cmbloaip.Enabled = txtidhdp.Enabled = cmbsophong.Enabled = dtngayden.Enabled = dtngaydi.Enabled = false;
                    x1 = 0;
                    return;
                }
            }
            if (x2 == 1)
            {
                HttpClient clienta = new HttpClient();
                clienta.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage responsea = clienta.GetAsync("api/kiemtrahd").Result;
                var kt = responsea.Content.ReadAsAsync<IEnumerable<LuuHD>>().Result;
                var kh = from t in kt where t.IDDAT == long.Parse(txtidhd.Text) select t;
                var d = kh.ToList();
                foreach (var pi in d)
                {
                    if (pi.IDDAT.Equals(long.Parse(txtidhd.Text)))
                    {
                        MessageBox.Show("Phiếu đặt đã xuất hóa đơn.Không thể xóa", "", MessageBoxButtons.OK);
                        return;
                    }
                }
                if (cmbsophong.Text == "")
                {
                    MessageBox.Show("Thông tin rỗng,không thể xóa", "", MessageBoxButtons.OK);
                    return;
                }
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage response = client.DeleteAsync("api/ChitietHDPhong?sophong=" + long.Parse(cmbsophong.Text) + "&iddat=" + long.Parse(txtidhdp.Text) + "").Result;
                if (response.IsSuccessStatusCode == true)
                {
                    MessageBox.Show("Xóa thành công", "", MessageBoxButtons.OK);
                    ThanhTien(long.Parse(txtidhdp.Text));
                    Room room = new Room();
                    room.Tinhtrang = "Sẵn sàng";
                    HttpClient client1 = new HttpClient();
                    client1.BaseAddress = new Uri("https://localhost:44326/");
                    HttpResponseMessage response1 = client1.PutAsJsonAsync<Room>("api/update1?sophong=" + long.Parse(cmbsophong.Text) + "", room).Result;
                    btnthemctphong.Enabled = btnxoactphong.Enabled = btnsuactphong.Enabled = btnreloadctphong.Enabled = true;
                    btnquaylaictphong.Enabled = btnxacnhanctphong.Enabled = cmbloaip.Enabled = txtidhdp.Enabled = cmbsophong.Enabled = dtngayden.Enabled = dtngaydi.Enabled = false;
                    x2 = 0;
                    cmbsophong.Text = cmbloaip.Text = "";
                    dtngaydi.Value = dtngayden.Value = DateTime.Now;
                    return;
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "", MessageBoxButtons.OK);
                    btnthemctphong.Enabled = btnxoactphong.Enabled = btnsuactphong.Enabled = btnreloadctphong.Enabled = true;
                    btnquaylaictphong.Enabled = btnxacnhanctphong.Enabled = txtidhdp.Enabled = cmbsophong.Enabled = dtngayden.Enabled = dtngaydi.Enabled = cmbloaip.Enabled = false;
                    x2 = 0;
                    return;
                }
            }
            if (x3 == 1)
            {
                if (cmbsophong.Text.Equals("") == true)
                {
                    MessageBox.Show("Số phòng rỗng", "", MessageBoxButtons.OK);
                    return;
                }
                HttpClient clienta = new HttpClient();
                clienta.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage responsea = clienta.GetAsync("api/kiemtrahd").Result;
                var kt = responsea.Content.ReadAsAsync<IEnumerable<LuuHD>>().Result;
                var kh = from t in kt where t.IDDAT == long.Parse(txtidhd.Text) select t;
                var d = kh.ToList();
                foreach (var pi in d)
                {
                    if (pi.IDDAT.Equals(long.Parse(txtidhd.Text)))
                    {
                        MessageBox.Show("Phiếu đặt đã xuất hóa đơn.Không thể sửa", "", MessageBoxButtons.OK);
                        return;
                    }
                }
                DateTime n1 = new DateTime(dtngayden.Value.Year, dtngayden.Value.Month, dtngayden.Value.Day);
                DateTime n2 = new DateTime(dtngaydi.Value.Year, dtngaydi.Value.Month, dtngaydi.Value.Day);
                DateTime n3 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                if (DateTime.Compare(n1,n2)>0 || DateTime.Compare(n2,n3) < 0 || DateTime.Compare(n1,n3)<0)
                {
                    MessageBox.Show("Ngày chọn không phù hợp", "", MessageBoxButtons.OK);
                    return;
                }
                CTDP cthd = new CTDP();
  
                cthd.Ngayden = dtngayden.Value;
                cthd.Ngaydi = dtngaydi.Value;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage response = client.PutAsJsonAsync<CTDP>("api/ChitietHDPhong?sophong=" + long.Parse(cmbsophong.Text) + "&iddat=" + long.Parse(txtidhdp.Text) + "", cthd).Result;
                if (response.IsSuccessStatusCode == true)
                {
                    MessageBox.Show("Sửa thành công", "", MessageBoxButtons.OK);
                    ThanhTien(long.Parse(txtidhdp.Text));
                    btnthemctphong.Enabled = btnxoactphong.Enabled = btnsuactphong.Enabled = btnreloadctphong.Enabled = true;
                    btnquaylaictphong.Enabled = btnxacnhanctphong.Enabled = cmbloaip.Enabled = txtidhdp.Enabled = cmbsophong.Enabled = dtngayden.Enabled = dtngaydi.Enabled = false;
                    x3 = 0;
                    cmbsophong.Text = cmbloaip.Text = "";
                    dtngaydi.Value = dtngayden.Value = DateTime.Now;
                    return;
                }
                else
                {
                    MessageBox.Show("Sửa thất bại", "", MessageBoxButtons.OK);
                    btnthemctphong.Enabled = btnxoactphong.Enabled = btnsuactphong.Enabled = btnreloadctphong.Enabled = true;
                    btnquaylaictphong.Enabled = btnxacnhanctphong.Enabled = cmbloaip.Enabled = txtidhdp.Enabled = cmbsophong.Enabled = dtngayden.Enabled = dtngaydi.Enabled = false;
                    x3 = 0;
                    return;
                }
            }
        }

        private void btnquaylaictphong_Click(object sender, EventArgs e)
        {
            x1 = x2 = x3 = 0;
     
            ThanhTien(long.Parse(txtidhd.Text));
            btnthemctphong.Enabled = btnxoactphong.Enabled = btnsuactphong.Enabled = cmbloaip.Enabled = btnreloadctphong.Enabled = true;
            btnquaylaictphong.Enabled = btnxacnhanctphong.Enabled = txtidhdp.Enabled = cmbsophong.Enabled = dtngayden.Enabled = dtngaydi.Enabled = cmbloaip.Enabled = false;
        }

        private void btnreloadctphong_Click(object sender, EventArgs e)
        {
            
            ThanhTien(long.Parse(txtidhd.Text));
            btnthemctphong.Enabled = btnxoactphong.Enabled = btnsuactphong.Enabled = cmbloaip.Enabled = btnreloadctphong.Enabled = true;
            btnquaylaictphong.Enabled = btnxacnhanctphong.Enabled = cmbloaip.Enabled = txtidhdp.Enabled = cmbsophong.Enabled = dtngayden.Enabled = dtngaydi.Enabled = false;
        }

        private void gvcthddv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = gvcthddv.CurrentRow.Index;
            txtdv.Text = gvcthddv.Rows[i].Cells[2].Value.ToString();
            txtiddv.Text = gvcthddv.Rows[i].Cells[1].Value.ToString();
            txtsl.Text = gvcthddv.Rows[i].Cells[3].Value.ToString();

        }

        private void btnthemdv_Click(object sender, EventArgs e)
        {
            txtsl.Text = txtiddv.Text = txtdv.Text= "";
            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response1 = client1.GetAsync("api/ChitietHDPhong?iddat=" + long.Parse(txtidhd.Text) + "").Result;
            var ctbillphong = response1.Content.ReadAsAsync<IEnumerable<CTDP>>().Result;
            if (ctbillphong.ToList().Count == 0)
            {
                MessageBox.Show("Bạn chưa lập chi tiết phòng", "", MessageBoxButtons.OK);
                return;
            }
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/Service").Result;
            var service = response.Content.ReadAsAsync<IEnumerable<Service>>().Result;
            txtdv.DataSource = service;
            txtdv.DisplayMember = "TenDV";
            btnthemdv.Enabled = btnxoadv.Enabled = btnsuadv.Enabled = btnreloaddv.Enabled = false;
            btnquaylaidv.Enabled = btnxacnhandv.Enabled = txtdv.Enabled = txtsl.Enabled = true;
            y1 = 1;
        }

        private void btnxoadv_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn thực sự muốn xóa ?", "", MessageBoxButtons.OK);
            btnthemdv.Enabled = btnxoadv.Enabled = btnsuadv.Enabled = btnreloaddv.Enabled = false;
            btnquaylaidv.Enabled = btnxacnhandv.Enabled = true;
            y2 = 1;
        }

        private void btnsuadv_Click(object sender, EventArgs e)
        {
            btnthemdv.Enabled = btnxoadv.Enabled = btnsuadv.Enabled = btnreloaddv.Enabled = false;
            btnquaylaidv.Enabled = btnxacnhandv.Enabled = txtsl.Enabled = true;
            y3 = 1;
        }

        private void btnxacnhandv_Click(object sender, EventArgs e)
        {
            if (y1 == 1)
            {
                if (txtdv.Text == "" || txtsl.Text == "")
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin", "", MessageBoxButtons.OK);
                    return;
                }
                HttpClient clienta = new HttpClient();
                clienta.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage responsea = clienta.GetAsync("api/kiemtrahd").Result;
                var kt1 = responsea.Content.ReadAsAsync<IEnumerable<LuuHD>>().Result;
                var kh = from t in kt1 where t.IDDAT == long.Parse(txtidhddv.Text) select t;
                var d = kh.ToList();
                foreach (var pi in d)
                {
                    if (pi.IDDAT.Equals(long.Parse(txtidhd.Text)))
                    {
                        MessageBox.Show("Phiếu đặt đã xuất hóa đơn.Không thể thêm", "", MessageBoxButtons.OK);
                        return;
                    }
                }
                HttpClient client2 = new HttpClient();
                client2.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage response2 = client2.GetAsync("api/CTHDDV?idhd=" + txtidhddv.Text + "").Result;
                var cthddv = response2.Content.ReadAsAsync<IEnumerable<CTDDV>>().Result;
                var kt = cthddv.FirstOrDefault(a => a.IDDV == long.Parse(txtiddv.Text));
                try
                {
                    if (kt != null)
                    {
                        MessageBox.Show("Đã có dịch vụ này.Vui lòng thêm dịch vụ khác hoặc sửa dịch vụ này", "", MessageBoxButtons.OK);
                        btnthemdv.Enabled = btnxoadv.Enabled = btnsuadv.Enabled = btnreloaddv.Enabled = true;
                        btnquaylaidv.Enabled = btnxacnhandv.Enabled = txtdv.Enabled = txtsl.Enabled = false;
                        y1 = 0;
                        return;

                    }
                    else
                    {


                        HttpClient client = new HttpClient();
                        client.BaseAddress = new Uri("https://localhost:44326/");
                        CTDDV dv = new CTDDV();
                    
                        dv.IDDV = long.Parse(txtiddv.Text);
                        dv.IDDAT = long.Parse(txtidhd.Text);
                        dv.Soluong = int.Parse(txtsl.Text);
                        HttpResponseMessage response = client.PostAsJsonAsync<CTDDV>("api/CTHDDV", dv).Result;
                        if (response.IsSuccessStatusCode == true)
                        {
                            MessageBox.Show("Thêm thành công", "", MessageBoxButtons.OK);
                            ThanhTien(long.Parse(txtidhddv.Text));
                            btnthemdv.Enabled = btnxoadv.Enabled = btnsuadv.Enabled = btnreloaddv.Enabled = true;
                            btnquaylaidv.Enabled = btnxacnhandv.Enabled = txtdv.Enabled = txtsl.Enabled = false;
                            y1 = 0;
                            txtsl.Text = txtiddv.Text = txtdv.Text = "";
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại", "", MessageBoxButtons.OK);
                            btnthemdv.Enabled = btnxoadv.Enabled = btnsuadv.Enabled = btnreloaddv.Enabled = true;
                            btnquaylaidv.Enabled = btnxacnhandv.Enabled = txtdv.Enabled = txtsl.Enabled = false;
                            y1 = 0;
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm thất bại", "", MessageBoxButtons.OK);
                    return;
                }

            }
            if (y2 == 1)
            {
                HttpClient clienta = new HttpClient();
                clienta.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage responsea = clienta.GetAsync("api/kiemtrahd").Result;
                var kt = responsea.Content.ReadAsAsync<IEnumerable<LuuHD>>().Result;
                var kh = from t in kt where t.IDDAT == long.Parse(txtidhddv.Text) select t;
                var d = kh.ToList();
                foreach (var pi in d)
                {
                    if (pi.IDDAT.Equals(long.Parse(txtidhd.Text)))
                    {
                        MessageBox.Show("Phiếu đặt đã xuất hóa đơn.Không thể xóa", "", MessageBoxButtons.OK);
                        return;
                    }
                }
                if (txtdv.Text == "" || txtidhddv.Text == "")
                {
                    MessageBox.Show("Thông tin rỗng.Không thể xóa", "", MessageBoxButtons.OK);
                    return;
                }
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage response = client.DeleteAsync("api/CTHDDV?iddv=" + long.Parse(txtiddv.Text) + "&idhd=" + long.Parse(txtidhddv.Text) + "").Result;
                if (response.IsSuccessStatusCode == true)
                {
                    MessageBox.Show("Xóa thành công", "", MessageBoxButtons.OK);
                    ThanhTien(long.Parse(txtidhddv.Text));
                    btnthemdv.Enabled = btnxoadv.Enabled = btnsuadv.Enabled = btnreloaddv.Enabled = true;
                    btnquaylaidv.Enabled = btnxacnhandv.Enabled = txtdv.Enabled = txtsl.Enabled = false;
                    y2 = 0;
                    txtsl.Text = txtiddv.Text = txtdv.Text = "";
                    return;
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "", MessageBoxButtons.OK);
                    btnthemdv.Enabled = btnxoadv.Enabled = btnsuadv.Enabled = btnreloaddv.Enabled = true;
                    btnquaylaidv.Enabled = btnxacnhandv.Enabled = txtdv.Enabled = txtsl.Enabled = false;
                    y2 = 0;
                    return;
                }
            }
            if (y3 == 1)
            {
                if (txtdv.Text == "" || txtsl.Text == "")
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin", "", MessageBoxButtons.OK);
                    return;
                }
                HttpClient clienta = new HttpClient();
                clienta.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage responsea = clienta.GetAsync("api/kiemtrahd").Result;
                var kt = responsea.Content.ReadAsAsync<IEnumerable<LuuHD>>().Result;
                var kh = from t in kt where t.IDDAT == long.Parse(txtidhddv.Text) select t;
                var d = kh.ToList();
                foreach (var pi in d)
                {
                    if (pi.IDDAT.Equals(long.Parse(txtidhd.Text)))
                    {
                        MessageBox.Show("Phiếu đặt đã xuất hóa đơn.Không thể sửa", "", MessageBoxButtons.OK);
                        return;
                    }
                }
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44326/");
                CTDDV dv = new CTDDV();
                dv.IDDV = long.Parse(txtiddv.Text);
                dv.IDDAT = long.Parse(txtidhddv.Text);
                dv.Soluong = int.Parse(txtsl.Text);
                HttpResponseMessage response = client.PutAsJsonAsync<CTDDV>("api/CTHDDV?idhd=" + long.Parse(txtidhddv.Text) + "&iddv=" + long.Parse(txtiddv.Text) + "", dv).Result;
                if (response.IsSuccessStatusCode == true)
                {
                    MessageBox.Show("Sửa thành công", "", MessageBoxButtons.OK);
                    ThanhTien(long.Parse(txtidhddv.Text));
                    btnthemdv.Enabled = btnxoadv.Enabled = btnsuadv.Enabled = btnreloaddv.Enabled = true;
                    btnquaylaidv.Enabled = btnxacnhandv.Enabled = txtdv.Enabled = txtsl.Enabled = false;
                    y3 = 0;
                    txtsl.Text = txtiddv.Text = txtdv.Text = "";
                    return;
                }
                else
                {
                    MessageBox.Show("Sửa thất bại", "", MessageBoxButtons.OK);
                    btnthemdv.Enabled = btnxoadv.Enabled = btnsuadv.Enabled = btnreloaddv.Enabled = true;
                    btnquaylaidv.Enabled = btnxacnhandv.Enabled = txtdv.Enabled = txtsl.Enabled = false;
                    y3 = 0;
                    return;
                }
            }
        }

        private void btnquaylaidv_Click(object sender, EventArgs e)
        {
            y1 = y2 = y3 = 0;
            txtsl.Text = txtiddv.Text = txtdv.Text = "";
            ThanhTien(long.Parse(txtidhddv.Text));
            //HttpClient client2 = new HttpClient();
            //client2.BaseAddress = new Uri("https://localhost:44326/");
            //HttpResponseMessage response2 = client2.GetAsync("api/CTHDDV?idhd=" + txtidhddv.Text + "").Result;
            //var cthddv = response2.Content.ReadAsAsync<IEnumerable<CTDDV>>().Result;
            //gvcthddv.DataSource = cthddv;
            txtidhddv.Text = txtidhd.Text;
            btnthemdv.Enabled = btnxoadv.Enabled = btnsuadv.Enabled = btnreloaddv.Enabled = true;
            btnquaylaidv.Enabled = btnxacnhandv.Enabled = txtdv.Enabled = txtsl.Enabled = false;
        }

        private void btnreloaddv_Click(object sender, EventArgs e)
        {
            y1 = y2 = y3 = 0;
            txtsl.Text = txtiddv.Text = txtdv.Text = "";
            ThanhTien(long.Parse(txtidhddv.Text));
            //HttpClient client2 = new HttpClient();
            //client2.BaseAddress = new Uri("https://localhost:44326/");
            //HttpResponseMessage response2 = client2.GetAsync("api/CTHDDV?idhd=" + txtidhddv.Text + "").Result;
            //var cthddv = response2.Content.ReadAsAsync<IEnumerable<CTDDV>>().Result;
            //gvcthddv.DataSource = cthddv;
            txtidhddv.Text = txtidhd.Text;
            btnthemdv.Enabled = btnxoadv.Enabled = btnsuadv.Enabled = btnreloaddv.Enabled = true;
            btnquaylaidv.Enabled = btnxacnhandv.Enabled = txtdv.Enabled = txtsl.Enabled = false;
        }

        private void cmbloaip_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbsophong.Text = "";
            HttpClient client3 = new HttpClient();
            client3.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response3 = client3.GetAsync("api/RoomR?loaip=" + cmbloaip.Text + "").Result;
            var roomr = response3.Content.ReadAsAsync<IEnumerable<Room>>().Result;
            cmbsophong.DataSource = roomr;
            cmbsophong.DisplayMember = "Sophong";
        }

        private void gvctphong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = gvctphong.CurrentRow.Index;
            cmbsophong.Text = gvctphong.Rows[i].Cells[1].Value.ToString();
            // txtidhdp.Text = gvctphong.Rows[i].Cells[1].Value.ToString();
            //cmbloaip.= gvctphong.Rows[i].Cells[2].Value.ToString();
            dtngayden.Text = gvctphong.Rows[i].Cells[3].Value.ToString();
            dtngaydi.Text = gvctphong.Rows[i].Cells[4].Value.ToString();
        }

        private void btnxuathd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtidhd.Text == "")
            {
                MessageBox.Show("Chưa chọn phiếu xuất hóa đơn", "", MessageBoxButtons.OK);
                return;
            }
            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response1 = client1.GetAsync("api/ChitietHDPhong?iddat=" + long.Parse(txtidhd.Text) + "").Result;
            var ctbillphong = response1.Content.ReadAsAsync<IEnumerable<CTDP>>().Result;
            var kt = ctbillphong.ToList();
            for(int i=0;i<kt.Count;i++)
            {
                //TimeSpan ngay = kt[i].Ngaydi - DateTime.Now;
                if(kt[i].Ngaydi.CompareTo(DateTime.Now)>0)
                {
                    MessageBox.Show("Thiết lập lại ngày đi cho khách hàng", "", MessageBoxButtons.OK);
                    return;
                }
            }
            Program.hoten = txttenkh.Text;
            if(Program.giaphong==0 && Program.giadv==0)
            {
                MessageBox.Show("Hóa đơn xuất không hợp lệ", "", MessageBoxButtons.OK);
                return;
            }
            Program.idhd = long.Parse(txtidhd.Text);
            Program.cmt = txtkh.Text;
            FormHoaDon fhd = new FormHoaDon();
            fhd.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormKhachHang fkh = new FormKhachHang();
            fkh.Show();
        }

        private void btntim_Click(object sender, EventArgs e)
        {
            txtidhd.Text = txtsdt.Text = txtkh.Text = txttenkh.Text = txtghichu.Text = txttongtien.Text 
               = txtidhdp.Text = cmbsophong.Text  = txttienphong.Text
               = txtidhddv.Text = txtiddv.Text = txtdv.Text = txtsl.Text = txttiendv.Text = "";
            dtngayden.Value = dtngaydi.Value = dtngaylap.Value = DateTime.Now;
            gvctphong.DataSource = gvcthddv.DataSource = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/Bill").Result;
            var bill = response.Content.ReadAsAsync<IEnumerable<Datphong>>().Result;
            var t = from a in bill where a.CMT == txttimkiem.Text select a;
            gvbill.DataSource = t.ToList();
        }

        // Hàm bắt sự kiện thay đổi dữ liệu
        void assistant_Idled(object sender, EventArgs e)
        {
            this.Invoke(
            new MethodInvoker(() =>
            {

                txtkh.Text = cmt;
                txtsdt.Text = sdt;
                txttenkh.Text = hoten;

            }));
        }

        public class TypeAssistant
        {
            public event EventHandler Idled = delegate { };
            public int WaitingMilliSeconds { get; set; }
            System.Threading.Timer waitingTimer;

            public TypeAssistant(int waitingMilliSeconds = 300)
            {
                WaitingMilliSeconds = waitingMilliSeconds;
                waitingTimer = new System.Threading.Timer(p =>
                {
                    Idled(this, EventArgs.Empty);
                });
            }
            public void TextChanged()
            {
                waitingTimer.Change(WaitingMilliSeconds, System.Threading.Timeout.Infinite);
            }
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtdv_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/Service").Result;
            var service = response.Content.ReadAsAsync<IEnumerable<Service>>().Result;
            var c = service.ToList();
            for(int i=0;i<c.Count;i++)
            {
                if(c[i].TenDV.Equals(txtdv.Text))
                {
                    txtiddv.Text = c[i].IDDV.ToString();
                }
            }
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void hyperLinkEdit1_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FormKhachHang kh = new FormKhachHang();
            Program.flagkh = 1;
            //txtkh.Text = Program.cmtkh.ToString();
            kh.Show();
            //if (Program.cmtkh != null)
            //{
            //    txtkh.Text = Program.cmtkh.ToString();
            //}
        }

        private void FormDatphong_Load(object sender, EventArgs e)
        {
            //if(Program.cmtkh!=null)
            {
                txtkh.Text = Program.cmtkh;
            }
           
        }

        private void txtkh_TextChanged_1(object sender, EventArgs e)
        {
            //if (Program.cmtkh != null)
            //{
            //    txtkh.Text = Program.cmtkh.ToString();
            //}
            int delay = 2000; //int.Parse();
            assistant = new TypeAssistant(delay);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/Customer").Result;
            var customer = response.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
            var t = customer.ToList();
            foreach (var pi in t)
            {
                if (pi.CMT.Equals(txtkh.Text))
                {
                    cmt = pi.CMT;
                    sdt = pi.SDT;
                    hoten = pi.Hoten;
                    assistant.Idled += assistant_Idled;
                    assistant.TextChanged();
                }
            }
        }

        private void txtkh_Click(object sender, EventArgs e)
        {
            txtkh.Text = Program.cmtkh;
        }
    }
}
