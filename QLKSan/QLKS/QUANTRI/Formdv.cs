
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
    public partial class Formdv : Form
    {
        private static int flag1 = 0;
        private static int flag2 = 0;
        private static int flag3 = 0;
        public Formdv()
        {
            InitializeComponent();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/Service").Result;
            var service = response.Content.ReadAsAsync<IEnumerable<Service>>().Result;
            gvdv.DataSource = service;

            gvdv.Columns["IDDV"].HeaderText = "ID Dịch vụ";
            gvdv.Columns["TenDV"].HeaderText = "Tên dịch vụ";
            gvdv.Columns["GiaDV"].HeaderText = "Giá dịch vụ";
            gvdv.Columns["DVT"].HeaderText = "Đơn vị tính";
            gvdv.Columns["Hinh"].HeaderText = "Hình ảnh";
            gvdv.Columns["Mota"].HeaderText = "Mô tả";
           
            btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = true;
            txttendv.Enabled = txtgia.Enabled =
            btnquaylai.Enabled = btnxacnhan.Enabled = btnbrowse.Enabled = txtdvt.Enabled  = false;
        }

        private void btnthem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtdvt.Text = txtgia.Text = txtnd.BodyHTML = txttendv.Text = "";
            picturedv.Image = null;
            btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = false;
            txttendv.Enabled = txtgia.Enabled = 
            btnquaylai.Enabled = btnxacnhan.Enabled = btnbrowse.Enabled = txtdvt.Enabled  = true;
            flag1 = 1;
        }

        private void gvdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = gvdv.CurrentRow.Index;

            txtiddv.Text = gvdv.Rows[i].Cells[0].Value.ToString();
            txttendv.Text = gvdv.Rows[i].Cells[1].Value.ToString();
            txtgia.Text = gvdv.Rows[i].Cells[2].Value.ToString();
            txtdvt.Text = gvdv.Rows[i].Cells[3].Value.ToString();
            picturedv.Image = Base64StringIntoImage(gvdv.Rows[i].Cells[4].Value.ToString());
            txtnd.BodyHTML = gvdv.Rows[i].Cells[5].Value.ToString();
       
  
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

        private void btnxoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("bạn có chắc muốn xóa", "", MessageBoxButtons.OK);
            btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = false;
            btnquaylai.Enabled = btnxacnhan.Enabled = true;
            flag2 = 1;
        }

        private void btnsua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = false;
            txtgia.Enabled = 
            txttendv.Enabled = btnquaylai.Enabled = btnxacnhan.Enabled = btnbrowse.Enabled = txtdvt.Enabled = true;
            flag3 = 1;
        }

        private void btnxacnhan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (flag1 == 1)
            {
                if(txtdvt.Text == "" || txtgia.Text == "" || txtnd.BodyHTML=="" || txttendv.Text=="" || picturedv.Image==null)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm", "", MessageBoxButtons.OK);
                    return;
                }
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44326/");
                Service service = new Service();
                service.TenDV = txttendv.Text;
                service.DVT = txtdvt.Text;
                service.GiaDV = float.Parse(txtgia.Text);
                service.Hinh = ImageIntoBase64String(picturedv);
                service.Mota = txtnd.BodyHTML;
          

                HttpClient client1 = new HttpClient();
                client1.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage response1 = client1.GetAsync("api/Service").Result;
                var service1 = response1.Content.ReadAsAsync<IEnumerable<Service>>().Result;
                var t = service1.ToList();
                foreach(var pi in t)
                {
                    if(pi.TenDV.Equals(txttendv.Text))
                    {
                        MessageBox.Show("Dịch vụ này đã có.Vui lòng thêm dịch vụ khác", "", MessageBoxButtons.OK);
                        return;
                    }
                }
             

                HttpResponseMessage response = client.PostAsJsonAsync<Service>("api/Service", service).Result;
                if (response.IsSuccessStatusCode == true)
                {
                    MessageBox.Show("Thêm thành công", "", MessageBoxButtons.OK);
                    HttpClient clientt = new HttpClient();
                    clientt.BaseAddress = new Uri("https://localhost:44326/");
                    HttpResponseMessage responset = clientt.GetAsync("api/Service").Result;
                    var servicet = responset.Content.ReadAsAsync<IEnumerable<Service>>().Result;
                    gvdv.DataSource = servicet;
                    txtdvt.Text = txtgia.Text = txtnd.BodyHTML = txttendv.Text = "";
                    picturedv.Image = null;
                    btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = true;
                    txttendv.Enabled = txtgia.Enabled = 
                    btnquaylai.Enabled = btnxacnhan.Enabled = btnbrowse.Enabled = txtdvt.Enabled = false;
                    flag1 = 0;
                    return;

                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "", MessageBoxButtons.OK);
                    btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = true;
                    txttendv.Enabled = txtgia.Enabled = 
                    btnquaylai.Enabled = btnxacnhan.Enabled = btnbrowse.Enabled = txtdvt.Enabled = false;
                    flag1 = 0;
                    return;
                }
            }
            if (flag3 == 1)
            {
                if (txtdvt.Text == "" || txtgia.Text == "" || txtnd.BodyHTML == "" || txttendv.Text == "" ||  picturedv.Image == null)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi sửa", "", MessageBoxButtons.OK);
                    return;
                }
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44326/");
                Service service = new Service();
                service.TenDV = txttendv.Text;
                service.GiaDV = float.Parse(txtgia.Text);
                service.DVT = txtdvt.Text;
                service.Hinh = ImageIntoBase64String(picturedv);
                service.Mota = txtnd.BodyHTML;
            

                HttpResponseMessage response = client.PutAsJsonAsync("api/Service?iddv=" + long.Parse(txtiddv.Text) + "", service).Result;
                if (response.IsSuccessStatusCode == true)
                {
                    MessageBox.Show("Sửa thành công", "", MessageBoxButtons.OK);
                    HttpClient clientt = new HttpClient();
                    clientt.BaseAddress = new Uri("https://localhost:44326/");
                    HttpResponseMessage responset = clientt.GetAsync("api/Service").Result;
                    var servicet = responset.Content.ReadAsAsync<IEnumerable<Service>>().Result;
                    gvdv.DataSource = servicet;
                    txtdvt.Text = txtgia.Text = txtnd.BodyHTML = txttendv.Text = "";
                    picturedv.Image = null;
                    btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = true;
                    txttendv.Enabled = txtgia.Enabled =
                    btnquaylai.Enabled = btnxacnhan.Enabled = btnbrowse.Enabled = txtdvt.Enabled = false;
                    flag3 = 0;
                    return;
                }
                else
                {
                    MessageBox.Show("Sửa thất bại", "", MessageBoxButtons.OK);
                    btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = true;
                    txttendv.Enabled = txtgia.Enabled = 
                    btnquaylai.Enabled = btnxacnhan.Enabled = btnbrowse.Enabled = txtdvt.Enabled = false;
                    flag3 = 0;
                    return;
                }
            }
            if(flag2==1)
            {
                HttpClient client2 = new HttpClient();
                client2.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage response2 = client2.GetAsync("api/kiemtradv").Result;
                var cthddv = response2.Content.ReadAsAsync<IEnumerable<CTDDV>>().Result;
                var x = from c in cthddv where c.IDDV == long.Parse(txtiddv.Text) select c;
                if (x.ToList().Count!=0)
                {
                    MessageBox.Show("Dịch vụ này đã thuê.Không thể xóa", "", MessageBoxButtons.OK);
                    return;
                }

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage response = client.DeleteAsync("api/Service?iddv=" + long.Parse(txtiddv.Text) + "").Result;
                if (response.IsSuccessStatusCode == true)
                {
                    MessageBox.Show("Xóa thành công", "", MessageBoxButtons.OK);
                    HttpClient clientt = new HttpClient();
                    clientt.BaseAddress = new Uri("https://localhost:44326/");
                    HttpResponseMessage responset = clientt.GetAsync("api/Service").Result;
                    var servicet = responset.Content.ReadAsAsync<IEnumerable<Service>>().Result;
                    gvdv.DataSource = servicet;
                    txtdvt.Text = txtgia.Text = txtnd.BodyHTML = txttendv.Text = "";
                    picturedv.Image = null;
                    btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = true;
                    txttendv.Enabled = txtgia.Enabled = 
                    btnquaylai.Enabled = btnxacnhan.Enabled = btnbrowse.Enabled = txtdvt.Enabled = false;
                    flag2 = 0;
                    return;
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "", MessageBoxButtons.OK);
                    btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = true;
                    txttendv.Enabled = txtgia.Enabled = 
                    btnquaylai.Enabled = btnxacnhan.Enabled = btnbrowse.Enabled = txtdvt.Enabled = false;
                    flag2 = 0;
                    return;
                }
            }
        }

        private void btnquaylai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/Service").Result;
            var service = response.Content.ReadAsAsync<IEnumerable<Service>>().Result;
            gvdv.DataSource = service;
            txtdvt.Text = txtgia.Text = txtnd.BodyHTML = txttendv.Text = "";
            picturedv.Image = null;
            btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = true;
            txttendv.Enabled = txtgia.Enabled = 
            btnquaylai.Enabled = btnxacnhan.Enabled = btnbrowse.Enabled = txtdvt.Enabled = false;
            flag1 = flag2 = flag3 = 0;
        }

        private void btnthoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnreload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtdvt.Text = txtgia.Text = txtnd.BodyHTML = txttendv.Text = "";
            picturedv.Image = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/Service").Result;
            var service = response.Content.ReadAsAsync<IEnumerable<Service>>().Result;
            gvdv.DataSource = service;
        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
       
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "Image files(*.jpg, *.jpeg, *.bmp, *.png) | *.jpg; *.jpeg; *.bmp; *.png|All files (*.*)|*.*";
            if (od.ShowDialog() == DialogResult.OK)
            {
                picturedv.Load(od.FileName);
            }
        }
    }
}
