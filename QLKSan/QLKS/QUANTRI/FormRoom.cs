
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
    public partial class FormRoom : Form
    {
        private static int flag1 = 0;
        private static int flag2 = 0;
        private static int flag3 = 0;
        
        public FormRoom()
        {
            InitializeComponent();
    
            cmbtinhtrang.Text = "Chưa thuê";
            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response1 = client1.GetAsync("api/TypeRoom").Result;
            var loai = response1.Content.ReadAsAsync<IEnumerable<LoaiPhong>>().Result;
            // var em = from loaip in loai select loaip.Loaiphong;
            cmbloaiphong.DataSource = loai;
            cmbloaiphong.DisplayMember = "Loaiphong1";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/Room").Result;
            var room = response.Content.ReadAsAsync<IEnumerable<Room>>().Result;
            gvroom.DataSource = room;
            gvroom.Columns["Sophong"].HeaderText = "Số phòng";
            gvroom.Columns["Tinhtrang"].HeaderText = "Tình trạng";
    
            gvroom.Columns["Loaiphong"].HeaderText = "Loại phòng";
            gvroom.Columns["Ghichu"].HeaderText = "Ghi chú";
        
            cmbtinhtrang.Enabled = txtsophong.Enabled = cmbloaiphong.Enabled  = btnconfirm.Enabled = txtghichu.Enabled = btnback.Enabled = false;
        }

        private void gvroom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = gvroom.CurrentRow.Index;
            txtsophong.Text = gvroom.Rows[i].Cells[0].Value.ToString();
            cmbtinhtrang.Text = gvroom.Rows[i].Cells[1].Value.ToString();
            cmbloaiphong.Text = gvroom.Rows[i].Cells[2].Value.ToString();
            if (gvroom.Rows[i].Cells[3].Value == null)
            {
                txtghichu.Text = "";
            }
            else
            {
                txtghichu.Text = gvroom.Rows[i].Cells[3].Value.ToString();
            }

        }

        private void btninsertroom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtsophong.Text = cmbloaiphong.Text = cmbtinhtrang.Text = txtghichu.Text = "";
            btninsertroom.Enabled = btnxoaroom.Enabled = btnsuaroom.Enabled = btnexit.Enabled = btnreload.Enabled = false;
            btnback.Enabled = btnconfirm.Enabled = cmbtinhtrang.Enabled  = txtghichu.Enabled = txtsophong.Enabled = cmbloaiphong.Enabled = true;
            flag1 = 1;
        }

        private void btnxoaroom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("bạn có chắc muốn xóa", "", MessageBoxButtons.OK);
            btnxoaroom.Enabled = btninsertroom.Enabled = btnsuaroom.Enabled = btnexit.Enabled = btnreload.Enabled = false;
            btnback.Enabled = btnconfirm.Enabled = true;
            //btnback.Enabled = btnconfirm.Enabled= cmbtinhtrang.Enabled = cmbth.Enabled = txtsophong.Enabled = txtloaiphong.Enabled = true;
            flag2 = 1;
        }

        private void btnsuaroom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtsophong.Enabled = btnsuaroom.Enabled = btninsertroom.Enabled = btnxoaroom.Enabled = btnexit.Enabled = btnreload.Enabled = false;
            btnback.Enabled = btnconfirm.Enabled = cmbtinhtrang.Enabled = txtghichu.Enabled  = cmbloaiphong.Enabled = true;
            flag3 = 1;
        }

        private void btnconfirm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (flag1 == 1)
            {
                if (txtsophong.Text == ""  || cmbloaiphong.Text == "" || cmbtinhtrang.Text == "")
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm", "", MessageBoxButtons.OK);
                    return;
                }
                HttpClient clienta = new HttpClient();
                clienta.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage responsea = clienta.GetAsync("api/Room").Result;
                var room1 = responsea.Content.ReadAsAsync<IEnumerable<Room>>().Result;
                var ro = room1.ToList();
                foreach (var pi in ro)
                {
                    if(pi.Sophong==long.Parse(txtsophong.Text))
                    {
                        MessageBox.Show("Phòng đã có sẵn.Vui lòng thêm tên phòng khác", "", MessageBoxButtons.OK);
                        return;
                    }
                }
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44326/");
                Room room = new Room();
                room.Sophong = long.Parse(txtsophong.Text);
                room.Tinhtrang = cmbtinhtrang.Text;
                room.Loaiphong = cmbloaiphong.Text;
                room.Ghichu = txtghichu.Text;
               
                HttpResponseMessage response = client.PostAsJsonAsync<Room>("api/Room", room).Result;
                if (response.IsSuccessStatusCode == true)
                {
                    MessageBox.Show("Thêm thành công", "", MessageBoxButtons.OK);
                    HttpClient clientt = new HttpClient();
                    clientt.BaseAddress = new Uri("https://localhost:44326/");
                    HttpResponseMessage responset = clientt.GetAsync("api/Room").Result;
                    var roomt = responset.Content.ReadAsAsync<IEnumerable<Room>>().Result;
                    gvroom.DataSource = roomt;
                    txtsophong.Text = cmbloaiphong.Text = cmbtinhtrang.Text = txtghichu.Text= "";
                    btninsertroom.Enabled = btnxoaroom.Enabled = btnsuaroom.Enabled = btnexit.Enabled = btnreload.Enabled = true;
                    btnback.Enabled = btnconfirm.Enabled = cmbtinhtrang.Enabled = txtghichu.Enabled  = txtsophong.Enabled = cmbloaiphong.Enabled = false;
                    flag1 = 0;
                    return;

                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "", MessageBoxButtons.OK);
                    btninsertroom.Enabled = btnxoaroom.Enabled = btnsuaroom.Enabled = btnexit.Enabled = btnreload.Enabled = true;
                    btnback.Enabled = btnconfirm.Enabled = cmbtinhtrang.Enabled = txtghichu.Enabled = txtsophong.Enabled = cmbloaiphong.Enabled = false;
                    flag1 = 0;
                    return;
                }
            }
            if (flag2 == 1)
            {
                //HttpClient client1 = new HttpClient();
                //client1.BaseAddress = new Uri("https://localhost:44326/");
                //HttpResponseMessage response1 = client1.GetAsync("api/Device").Result;
                //var device = response1.Content.ReadAsAsync<IEnumerable<Device>>().Result;
           
                //var t = device.ToList();
                //foreach(var pi in t)
                //{
                //    if(pi.Sophong.Equals(txtsophong.Text))
                //    {
                //        MessageBox.Show("Phòng này có các thiết bị.Vui lòng xóa hoặc update thông tin thiết bị", "", MessageBoxButtons.OK);
                //        return;
                //    }
                //}
                HttpClient client2 = new HttpClient();
                client2.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage response2 = client2.GetAsync("api/Room").Result;
                var room = response2.Content.ReadAsAsync<IEnumerable<Room>>().Result;
                var kt = from c in room
                         where c.Sophong == long.Parse(txtsophong.Text)
                         select c;
                var xetpmuon = kt.ToList();
                if(xetpmuon[0].Tinhtrang.Equals("Đã thuê"))
                {
                    MessageBox.Show("Phòng đã thuê.Không thể xóa", "", MessageBoxButtons.OK);
                    return;
                }
                if (txtsophong.Text == ""  || cmbloaiphong.Text == "" || cmbtinhtrang.Text == "")
                {
                    MessageBox.Show("Vui lòng điền thông tin đầy đủ", "", MessageBoxButtons.OK);
                    return;
                }
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage response = client.DeleteAsync("api/Room?numberroom=" + long.Parse(txtsophong.Text) + "").Result;
                if (response.IsSuccessStatusCode == true)
                {
                    MessageBox.Show("Xóa thành công", "", MessageBoxButtons.OK);
                    txtsophong.Text = cmbloaiphong.Text = cmbtinhtrang.Text = txtghichu.Text = "";
                    HttpClient clientt = new HttpClient();
                    clientt.BaseAddress = new Uri("https://localhost:44326/");
                    HttpResponseMessage responset = clientt.GetAsync("api/Room").Result;
                    var roomt = responset.Content.ReadAsAsync<IEnumerable<Room>>().Result;
                    gvroom.DataSource = roomt;
                    btninsertroom.Enabled = btnxoaroom.Enabled = btnsuaroom.Enabled = btnexit.Enabled = btnreload.Enabled = true;
                    btnback.Enabled = btnconfirm.Enabled = cmbtinhtrang.Enabled = txtghichu.Enabled  = txtsophong.Enabled = cmbloaiphong.Enabled = false;
                    flag2 = 0;
                    return;
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "", MessageBoxButtons.OK);
                    btninsertroom.Enabled = btnxoaroom.Enabled = btnsuaroom.Enabled = btnexit.Enabled = btnreload.Enabled = true;
                    flag2 = 0;
                    btnback.Enabled = btnconfirm.Enabled = cmbtinhtrang.Enabled = txtghichu.Enabled  = txtsophong.Enabled = cmbloaiphong.Enabled = false;
                    return;
                }
            }
            if (flag3 == 1)
            {

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44326/");
                Room room = new Room();
                room.Sophong = long.Parse(txtsophong.Text);
                room.Tinhtrang = cmbtinhtrang.Text;
                room.Loaiphong = cmbloaiphong.Text;
                room.Ghichu = txtghichu.Text;
                if (txtsophong.Text == "" || cmbloaiphong.Text == "" || cmbtinhtrang.Text == "")
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi sửa", "", MessageBoxButtons.OK);
                    return;
                }
                HttpClient client2 = new HttpClient();
                client2.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage response2 = client2.GetAsync("api/Room").Result;
                var room1 = response2.Content.ReadAsAsync<IEnumerable<Room>>().Result;
                var kt = from c in room1
                         where c.Sophong == long.Parse(txtsophong.Text)
                         select c;
                var xetpmuon = kt.ToList();
                if (xetpmuon[0].Tinhtrang== "Đã thuê")
                {
                    MessageBox.Show("Phòng đã thuê.Không thể sửa", "", MessageBoxButtons.OK);
                    return;
                }
                if (txtsophong.Text == "")
                {
                    MessageBox.Show("Số phòng rỗng.Không thể sửa", "", MessageBoxButtons.OK);
                    return;
                }
                HttpResponseMessage response = client.PutAsJsonAsync<Room>("api/Room?numberroom=" + long.Parse(txtsophong.Text) + "", room).Result;
                if (response.IsSuccessStatusCode == true)
                {
                    MessageBox.Show("Sửa thành công", "", MessageBoxButtons.OK);
                    HttpClient clientt = new HttpClient();
                    clientt.BaseAddress = new Uri("https://localhost:44326/");
                    HttpResponseMessage responset = clientt.GetAsync("api/Room").Result;
                    var roomt = responset.Content.ReadAsAsync<IEnumerable<Room>>().Result;
                    gvroom.DataSource = roomt;
                    txtsophong.Text = cmbloaiphong.Text = cmbtinhtrang.Text = txtghichu.Text = "";
                    btninsertroom.Enabled = btnxoaroom.Enabled = btnsuaroom.Enabled = btnexit.Enabled = btnreload.Enabled = true;
                    btnback.Enabled = btnconfirm.Enabled = txtghichu.Enabled = cmbtinhtrang.Enabled  = txtsophong.Enabled = cmbloaiphong.Enabled = false;
                    flag3 = 0;
                    return;
                }
                else
                {
                    MessageBox.Show("Sửa thất bại", "", MessageBoxButtons.OK);
                    btninsertroom.Enabled = btnxoaroom.Enabled = btnsuaroom.Enabled = btnexit.Enabled = btnreload.Enabled = true;
                    btnback.Enabled = btnconfirm.Enabled = txtghichu.Enabled = cmbtinhtrang.Enabled = txtsophong.Enabled = cmbloaiphong.Enabled = false;
                    flag3 = 0;
                    return;
                }
            }

        }

        private void btnback_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            flag1 = flag2 = flag3 = 0;
            txtsophong.Text = cmbloaiphong.Text = cmbtinhtrang.Text = txtghichu.Text = "";
            btninsertroom.Enabled = btnxoaroom.Enabled = btnsuaroom.Enabled = btnexit.Enabled = btnreload.Enabled = true;
            btnback.Enabled = btnconfirm.Enabled = cmbtinhtrang.Enabled  = txtghichu.Enabled = txtsophong.Enabled = cmbloaiphong.Enabled = false;
        }

        private void btnexit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnreload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtsophong.Text = cmbloaiphong.Text = cmbtinhtrang.Text = txtghichu.Text = "";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/Room").Result;
            var room = response.Content.ReadAsAsync<IEnumerable<Room>>().Result;
            gvroom.DataSource = room;
          //  flag1 = flag2 = flag3 = 0;
        }

        private void btntim_Click(object sender, EventArgs e)
        {
            txtsophong.Text = cmbloaiphong.Text = cmbtinhtrang.Text = txtghichu.Text = "";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/Room?number=" + txttim.Text + "").Result;
            var room = response.Content.ReadAsAsync<IEnumerable<Room>>().Result;
            gvroom.DataSource = room;
        }

        private void gvroom_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //gvroom.DefaultCellStyle.BackColor = Color.Blue;
            //gvroom.DefaultCellStyle.ForeColor = Color.White;
            foreach (DataGridViewRow pi in gvroom.Rows)
            {

                if (pi.Cells[1].Value.Equals("Đã thuê") || pi.Cells[1].Value.Equals("Đang bảo trì") || pi.Cells[1].Value.Equals("Đang dọn"))
                {
                    pi.DefaultCellStyle.BackColor = Color.Red;
                    
                }
                else
                {
                    pi.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }
    }
}
