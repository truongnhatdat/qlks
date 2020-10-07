
using QLKS.INHOADON;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS
{
    public partial class FormLoaiPhong : Form
    {
        private static int flag1 = 0;
        private static int flag2 = 0;
        private static int flag3 = 0;
        public FormLoaiPhong()
        {
            InitializeComponent();
            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/TypeRoom").Result;
            var loai = response.Content.ReadAsAsync<IEnumerable<LoaiPhong>>().Result;
            gvtyperoom.DataSource = loai;
            gvtyperoom.Columns["Loaiphong1"].HeaderText = "Loại phòng";
            gvtyperoom.Columns["Gia"].HeaderText = "Giá phòng";
            gvtyperoom.Columns["Hinhanh"].HeaderText = "Hình ảnh";
            gvtyperoom.Columns["Mota"].HeaderText = "Mô tả";
            txtloai.Enabled = txtgia.Enabled =
            btnquaylai.Enabled = btnxacnhan.Enabled = btnbrowse.Enabled = false;
        }

        private void gvtyperoom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = gvtyperoom.CurrentRow.Index;
            txtloai.Text = gvtyperoom.Rows[i].Cells[0].Value.ToString();
            txtgia.Text = gvtyperoom.Rows[i].Cells[1].Value.ToString();
            pictureloai.Image = Base64StringIntoImage(gvtyperoom.Rows[i].Cells[2].Value.ToString());
            txtnd.BodyHTML = gvtyperoom.Rows[i].Cells[3].Value.ToString();
     
        }
        public static Image Base64StringIntoImage(string str64)
        {
            byte[] img = Convert.FromBase64String(str64);
            MemoryStream ms = new MemoryStream(img);
            return Image.FromStream(ms);
        }
        public static string ImageIntoBase64String(PictureBox pbox)
        {
            MemoryStream ms = new MemoryStream();
            pbox.Image.Save(ms, pbox.Image.RawFormat);
            return Convert.ToBase64String(ms.ToArray());
        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "Image files(*.jpg, *.jpeg, *.bmp, *.png) | *.jpg; *.jpeg; *.bmp; *.png|All files (*.*)|*.*";
            if (od.ShowDialog() == DialogResult.OK)
            {
                pictureloai.Load(od.FileName);
            }
        }

        private void btnthem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtgia.Text = txtloai.Text = txtnd.BodyHTML = "";
            pictureloai.Image = null;
            btnthem.Enabled = btnxoalp.Enabled = btnsua.Enabled = btnthoat.Enabled = false;
            txtloai.Enabled = txtgia.Enabled =
            btnquaylai.Enabled = btnxacnhan.Enabled = btnbrowse.Enabled = true;
            flag1 = 1;
        }

        private void btnxoalp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("bạn có chắc muốn xóa", "", MessageBoxButtons.OK);
            btnthem.Enabled = btnxoalp.Enabled = btnsua.Enabled = btnthoat.Enabled = false;
            btnquaylai.Enabled = btnxacnhan.Enabled = true;
            flag2 = 1;
        }

        private void btnsua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnthem.Enabled = btnxoalp.Enabled = btnsua.Enabled = btnthoat.Enabled = false;
            txtgia.Enabled =
           txtgia.Enabled = txtnd.Enabled= btnquaylai.Enabled = btnxacnhan.Enabled = btnbrowse.Enabled = true;
            flag3 = 1;
        }

        private void btnxacnhan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (flag1 == 1)
            {
                if(txtgia.Text == "" || txtloai.Text=="" || txtnd.BodyHTML=="" || pictureloai.Image==null)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm", "", MessageBoxButtons.OK);
                    return;
                }
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44326/");
                LoaiPhong loai = new LoaiPhong();
                loai.Loaiphong1 = txtloai.Text;
                loai.Gia = float.Parse(txtgia.Text);
                loai.Hinhanh = ImageIntoBase64String(pictureloai);
                loai.Mota = txtnd.BodyHTML;

                HttpClient client1 = new HttpClient();
                client1.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage response1 = client1.GetAsync("api/TypeRoom").Result;
                var loai1 = response1.Content.ReadAsAsync<IEnumerable<LoaiPhong>>().Result;
                var t = loai1.ToList();
                foreach(var pi in t)
                {
                    if (pi.Loaiphong1.Equals(txtloai.Text))
                    {
                        MessageBox.Show("Loại phòng nay đã có.Vui lòng thêm loai phòng khác", "", MessageBoxButtons.OK);
                        return;
                    }
                }
              

                HttpResponseMessage response = client.PostAsJsonAsync<LoaiPhong>("api/TypeRoom", loai).Result;
                if (response.IsSuccessStatusCode == true)
                {
                    MessageBox.Show("Thêm thành công", "", MessageBoxButtons.OK);
                    HttpClient clientt = new HttpClient();
                    clientt.BaseAddress = new Uri("https://localhost:44326/");
                    HttpResponseMessage responset = clientt.GetAsync("api/TypeRoom").Result;
                    var loait = responset.Content.ReadAsAsync<IEnumerable<LoaiPhong>>().Result;
                    gvtyperoom.DataSource = loait;
                    txtgia.Text = txtloai.Text = txtnd.BodyHTML = "";
                    pictureloai.Image = null;
                    btnthem.Enabled = btnxoalp.Enabled = btnsua.Enabled = btnthoat.Enabled = true;
                    txtloai.Enabled = txtgia.Enabled =
                    btnquaylai.Enabled = btnxacnhan.Enabled = btnbrowse.Enabled = false;
                    flag1 = 0;
                    return;
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "", MessageBoxButtons.OK);
                    btnthem.Enabled = btnxoalp.Enabled = btnsua.Enabled = btnthoat.Enabled = true;
                    txtloai.Enabled = txtgia.Enabled =
                    btnquaylai.Enabled = btnxacnhan.Enabled = btnbrowse.Enabled = false;
                    flag1 = 0;
                    return;
                }
            }
            if (flag2 == 1)
            {
                HttpClient client1 = new HttpClient();
                client1.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage response1 = client1.GetAsync("api/Room").Result;
                var room = response1.Content.ReadAsAsync<IEnumerable<Room>>().Result;
                var ro = room.ToList();
                foreach (var pi in ro)
                {
                    if (pi.Loaiphong.Equals(txtloai.Text))
                    {
                        MessageBox.Show("Không thể xóa loại phòng vì có các phòng thuộc loại này", "", MessageBoxButtons.OK);
                        return;
                    }
                }
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage response = client.DeleteAsync("api/TypeRoom?loai=" + txtloai.Text + "").Result;
                if (response.IsSuccessStatusCode == true)
                {
                    MessageBox.Show("Xóa thành công", "", MessageBoxButtons.OK);
                    txtgia.Text = txtloai.Text = txtnd.BodyHTML = "";
                    pictureloai.Image = null;
                    HttpClient clientt = new HttpClient();
                    clientt.BaseAddress = new Uri("https://localhost:44326/");
                    HttpResponseMessage responset = clientt.GetAsync("api/TypeRoom").Result;
                    var loait = responset.Content.ReadAsAsync<IEnumerable<LoaiPhong>>().Result;
                    gvtyperoom.DataSource = loait;

                    btnthem.Enabled = btnxoalp.Enabled = btnsua.Enabled = btnthoat.Enabled = true;
                    txtloai.Enabled = txtgia.Enabled =
                    btnquaylai.Enabled = btnxacnhan.Enabled = btnbrowse.Enabled = false;
                    flag2 = 0;
                    return;
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "", MessageBoxButtons.OK);
                    btnthem.Enabled = btnxoalp.Enabled = btnsua.Enabled = btnthoat.Enabled = true;
                    txtloai.Enabled = txtgia.Enabled =
                    btnquaylai.Enabled = btnxacnhan.Enabled = btnbrowse.Enabled = false;
                    flag2 = 0;
                    return;
                }
            }
            if(flag3==1)
            {
                if (txtgia.Text == "" || txtloai.Text == "" || txtnd.BodyHTML == "" || pictureloai.Image == null)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm", "", MessageBoxButtons.OK);
                    return;
                }
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44326/");
                LoaiPhong loai = new LoaiPhong();
               
                loai.Gia = float.Parse(txtgia.Text);
                loai.Hinhanh = ImageIntoBase64String(pictureloai);
                loai.Mota = txtnd.BodyHTML;
              
                HttpResponseMessage response = client.PutAsJsonAsync<LoaiPhong>("api/TypeRoom?loai=" + txtloai.Text + "", loai).Result;
                if (response.IsSuccessStatusCode == true)
                {
                    MessageBox.Show("Sửa thành công", "", MessageBoxButtons.OK);
                    HttpClient clientt = new HttpClient();
                    clientt.BaseAddress = new Uri("https://localhost:44326/");
                    HttpResponseMessage responset = clientt.GetAsync("api/TypeRoom").Result;
                    var loait = responset.Content.ReadAsAsync<IEnumerable<LoaiPhong>>().Result;
                    gvtyperoom.DataSource = loait;
                    txtgia.Text = txtloai.Text = txtnd.BodyHTML = "";
                    pictureloai.Image = null;
                    btnthem.Enabled = btnxoalp.Enabled = btnsua.Enabled = btnthoat.Enabled = true;
                    txtloai.Enabled = txtgia.Enabled =
                    btnquaylai.Enabled = btnxacnhan.Enabled = btnbrowse.Enabled = false;
                    flag3 = 0;
                    return;
                }
                else
                {
                    MessageBox.Show("Sửa thất bại", "", MessageBoxButtons.OK);
                    btnthem.Enabled = btnxoalp.Enabled = btnsua.Enabled = btnthoat.Enabled = true;
                    txtloai.Enabled = txtgia.Enabled =
                    btnquaylai.Enabled = btnxacnhan.Enabled = btnbrowse.Enabled = false;
                    flag3 = 0;
                    return;
                }
            }
        }

        private void btnquaylai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            flag1 = flag2 = flag3 = 0;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/TypeRoom").Result;
            var loai = response.Content.ReadAsAsync<IEnumerable<LoaiPhong>>().Result;
            gvtyperoom.DataSource = loai;
            txtgia.Text = txtloai.Text = txtnd.BodyHTML = "";
            pictureloai.Image = null;
            btnthem.Enabled = btnxoalp.Enabled = btnsua.Enabled = btnthoat.Enabled = true;
            txtloai.Enabled = txtgia.Enabled =
            btnquaylai.Enabled = btnxacnhan.Enabled = btnbrowse.Enabled = false;
        }

        private void btnthoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnreload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/TypeRoom").Result;
            var loai = response.Content.ReadAsAsync<IEnumerable<LoaiPhong>>().Result;
            gvtyperoom.DataSource = loai;
            txtgia.Text = txtloai.Text = txtnd.BodyHTML = "";
            pictureloai.Image = null;
            btnthem.Enabled = btnxoalp.Enabled = btnsua.Enabled = btnthoat.Enabled = true;
            txtloai.Enabled = txtgia.Enabled =
            btnquaylai.Enabled = btnxacnhan.Enabled = btnbrowse.Enabled = false;
        }
    }
}
