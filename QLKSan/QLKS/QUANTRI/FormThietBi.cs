
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
    public partial class FormThietBi : Form
    {
        private static int flag1 = 0;
        private static int flag2 = 0;
        private static int flag3 = 0;

        public FormThietBi()
        {
            InitializeComponent();
            cmbtinhtrang.Text = "Tốt";
            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response1 = client1.GetAsync("api/Room").Result;
            var room = response1.Content.ReadAsAsync<IEnumerable<Room>>().Result;
            cmbsophong.DataSource = room;
            cmbsophong.DisplayMember = "Sophong";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/Device").Result;
            var device = response.Content.ReadAsAsync<IEnumerable<Device>>().Result;
            gvdevice.DataSource = device;
            gvdevice.Columns["TenTB"].HeaderText = "Tên thiết bị";
            gvdevice.Columns["Sophong"].HeaderText = "Số phòng";
            gvdevice.Columns["Soluong"].HeaderText = "Số lượng";
            gvdevice.Columns["Tinhtrang"].HeaderText = "Tình trạng";
            gvdevice.Columns["Ghichu"].HeaderText = "Ghi chú";

            btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = btnreload.Enabled = true;
            txtthietbi.Enabled = cmbsophong.Enabled = txtsoluong.Enabled = cmbtinhtrang.Enabled =
            btnquaylai.Enabled = btnxacnhan.Enabled = false;
        }

        private void gvdevice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = gvdevice.CurrentRow.Index;
            txtthietbi.Text = gvdevice.Rows[i].Cells[0].Value.ToString();
            cmbsophong.Text = gvdevice.Rows[i].Cells[1].Value.ToString();
            txtsoluong.Text = gvdevice.Rows[i].Cells[2].Value.ToString();
            if (Boolean.Parse(gvdevice.Rows[i].Cells[3].Value.ToString()) == true)
            {
                cmbtinhtrang.Text = "Tốt";
            }
            else
            {
                cmbtinhtrang.Text = "Không tốt";
            }
            if (gvdevice.Rows[i].Cells[4].Value == null)
            {
                txtghichu.Text = "";
            }
            else
            {
                txtghichu.Text = gvdevice.Rows[i].Cells[4].Value.ToString();
            }
        }

        private void btnthem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = btnreload.Enabled = false;
            txtthietbi.Enabled = cmbsophong.Enabled = txtsoluong.Enabled = cmbtinhtrang.Enabled =
            btnquaylai.Enabled = btnxacnhan.Enabled = true;
            flag1 = 1;
        }

        private void btnxoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("Bạn có chắc xóa ?", "", MessageBoxButtons.OK);
            btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = btnreload.Enabled = false;
            btnquaylai.Enabled = btnxacnhan.Enabled = true;
            flag2 = 1;
        }

        private void btnsua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = btnreload.Enabled = false;
            txtsoluong.Enabled = cmbtinhtrang.Enabled =
            btnquaylai.Enabled = btnxacnhan.Enabled = true;
            flag3 = 1;
        }

        private void btnxacnhan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (flag1 == 1)
            {
                if (txtsoluong.Text == "" || txtthietbi.Text == "" || cmbsophong.Text == "" || cmbtinhtrang.Text == "")
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm", "", MessageBoxButtons.OK);
                    return;
                }
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44326/");
                Device device = new Device();
                device.TenTB = txtthietbi.Text;
                device.Sophong = long.Parse(cmbsophong.Text);
                device.Soluong = int.Parse(txtsoluong.Text);

                if (cmbtinhtrang.SelectedItem.ToString().Equals("Tốt"))
                {
                    device.Tinhtrang = true;
                }
                else
                {
                    device.Tinhtrang = false;
                }
                device.Ghichu = txtghichu.Text;
                HttpClient clienta = new HttpClient();
                clienta.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage responsea = clienta.GetAsync("api/Device").Result;
                var devicea = responsea.Content.ReadAsAsync<IEnumerable<Device>>().Result;
                var de = devicea.ToList();
                foreach (var pi in de)
                {
                    if (pi.TenTB.Equals(txtthietbi.Text) && pi.Sophong == long.Parse(cmbsophong.Text))
                    {
                        MessageBox.Show("Thiết bị phòng này đã có.Vui lòng thay đổi thông tin", "", MessageBoxButtons.OK);
                        return;
                    }
                }

                HttpResponseMessage response = client.PostAsJsonAsync<Device>("api/Device", device).Result;
                if (response.IsSuccessStatusCode == true)
                {
                    MessageBox.Show("Thêm thành công", "", MessageBoxButtons.OK);
                    txtsoluong.Text = txtthietbi.Text = cmbsophong.Text = cmbtinhtrang.Text = txtghichu.Text = "";
                    HttpClient clientt = new HttpClient();
                    clientt.BaseAddress = new Uri("https://localhost:44326/");
                    HttpResponseMessage responset = clientt.GetAsync("api/Device").Result;
                    var devicet = response.Content.ReadAsAsync<IEnumerable<Device>>().Result;
                    gvdevice.DataSource = devicet;
                    btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = btnreload.Enabled = true;
                    txtthietbi.Enabled = cmbsophong.Enabled = txtsoluong.Enabled = cmbtinhtrang.Enabled =
                    btnquaylai.Enabled = btnxacnhan.Enabled = false;
                    flag1 = 0;
                    return;
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "", MessageBoxButtons.OK);
                    btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = btnreload.Enabled = true;
                    txtthietbi.Enabled = cmbsophong.Enabled = txtsoluong.Enabled = cmbtinhtrang.Enabled =
                    btnquaylai.Enabled = btnxacnhan.Enabled = false;
                    flag1 = 0;
                    return;
                }
            }
            if (flag2 == 1)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage response = client.DeleteAsync("api/Device?sophong=" + long.Parse(cmbsophong.Text) + "&tentb=" + txtthietbi.Text + "").Result;
                if (response.IsSuccessStatusCode == true)
                {
                    MessageBox.Show("Xóa thành công", "", MessageBoxButtons.OK);
                    HttpClient clientt = new HttpClient();
                    clientt.BaseAddress = new Uri("https://localhost:44326/");
                    HttpResponseMessage responset = clientt.GetAsync("api/Device").Result;
                    var devicet = response.Content.ReadAsAsync<IEnumerable<Device>>().Result;
                    gvdevice.DataSource = devicet;
                    txtsoluong.Text = txtthietbi.Text = cmbsophong.Text = cmbtinhtrang.Text = txtghichu.Text = "";
                    btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = btnreload.Enabled = true;
                    txtthietbi.Enabled = cmbsophong.Enabled = txtsoluong.Enabled = cmbtinhtrang.Enabled =
                    btnquaylai.Enabled = btnxacnhan.Enabled = false;
                    flag2 = 0;
                    return;
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "", MessageBoxButtons.OK);
                    btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = btnreload.Enabled = true;
                    txtthietbi.Enabled = cmbsophong.Enabled = txtsoluong.Enabled = cmbtinhtrang.Enabled =
                    btnquaylai.Enabled = btnxacnhan.Enabled = false;
                    flag2 = 0;
                    return;
                }
            }
            if (flag3 == 1)
            {
                if (txtsoluong.Text == "" || txtthietbi.Text == "" || cmbsophong.Text == "" || cmbtinhtrang.Text == "")
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi sửa", "", MessageBoxButtons.OK);
                    return;
                }
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44326/");
                Device device = new Device();
                device.TenTB = txtthietbi.Text;
                device.Sophong = long.Parse(cmbsophong.Text);
                device.Soluong = int.Parse(txtsoluong.Text);

                if (cmbtinhtrang.SelectedItem.ToString().Equals("Tốt"))

                {
                    device.Tinhtrang = true;
                }
                else
                {
                    device.Tinhtrang = false;
                }
                device.Ghichu = txtghichu.Text;

                HttpResponseMessage response = client.PutAsJsonAsync<Device>("api/Device?sophong=" + long.Parse(cmbsophong.Text) + "&tentb=" + txtthietbi.Text + "", device).Result;
                if (response.IsSuccessStatusCode == true)
                {
                    MessageBox.Show("Sửa thành công", "", MessageBoxButtons.OK);
                    HttpClient clientt = new HttpClient();
                    clientt.BaseAddress = new Uri("https://localhost:44326/");
                    HttpResponseMessage responset = clientt.GetAsync("api/Device").Result;
                    var devicet = response.Content.ReadAsAsync<IEnumerable<Device>>().Result;
                    gvdevice.DataSource = devicet;
                    txtsoluong.Text = txtthietbi.Text = cmbsophong.Text = cmbtinhtrang.Text = txtghichu.Text = "";
                    btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = btnreload.Enabled = true;
                    txtthietbi.Enabled = cmbsophong.Enabled = txtsoluong.Enabled = cmbtinhtrang.Enabled =
                    btnquaylai.Enabled = btnxacnhan.Enabled = false;
                    flag3 = 0;
                    return;
                }
                else
                {
                    MessageBox.Show("Sửa thất bại", "", MessageBoxButtons.OK);
                    btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = btnreload.Enabled = true;
                    txtthietbi.Enabled = cmbsophong.Enabled = txtsoluong.Enabled = cmbtinhtrang.Enabled =
                    btnquaylai.Enabled = btnxacnhan.Enabled = false;
                    flag3 = 0;
                    return;
                }
            }
        }

        private void btnquaylai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/Device").Result;
            var device = response.Content.ReadAsAsync<IEnumerable<Device>>().Result;
            gvdevice.DataSource = device;
            txtsoluong.Text = txtthietbi.Text = cmbsophong.Text = cmbtinhtrang.Text = txtghichu.Text = "";
            btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = btnreload.Enabled = true;
            txtthietbi.Enabled = cmbsophong.Enabled = txtsoluong.Enabled = cmbtinhtrang.Enabled =
            btnquaylai.Enabled = btnxacnhan.Enabled = false;
            flag1 = flag2 = flag3 = 0;
        }

        private void btnthoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnreload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/Device").Result;
            var device = response.Content.ReadAsAsync<IEnumerable<Device>>().Result;
            gvdevice.DataSource = device;
            txtsoluong.Text = txtthietbi.Text = cmbsophong.Text = cmbtinhtrang.Text = txtghichu.Text = "";
            btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = btnreload.Enabled = true;
            txtthietbi.Enabled = cmbsophong.Enabled = txtsoluong.Enabled = cmbtinhtrang.Enabled =
            btnquaylai.Enabled = btnxacnhan.Enabled = false;
        }

        private void btntim_Click(object sender, EventArgs e)
        {
            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response1 = client1.GetAsync("api/Device?sophong=" + txttim.Text + "").Result;
            var device = response1.Content.ReadAsAsync<IEnumerable<Device>>().Result;
            gvdevice.DataSource = device;
        }
    }
}
