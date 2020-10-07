
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
    public partial class FormKhachHang : Form
    {
        private static int flag1 = 0;
        private static int flag2 = 0;
        private static int flag3 = 0;
 
        public FormKhachHang()
        {
            InitializeComponent();
            cmbgt.Text = "Nam";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/Customer").Result;
            var customer = response.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
            gvkhachhang.DataSource = customer;
            gvkhachhang.Columns["CMT"].HeaderText = "Chứng Minh Thư";
            gvkhachhang.Columns["Hoten"].HeaderText = "Họ tên";
            gvkhachhang.Columns["Ngaysinh"].HeaderText = "Ngày sinh";
            gvkhachhang.Columns["Gioitinh"].HeaderText = "Giới tính";
            gvkhachhang.Columns["Diachi"].HeaderText = "Địa chỉ";
            gvkhachhang.Columns["SDT"].HeaderText = "Số điện thoại";
            btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = btnreload.Enabled = true;
            txtcmt.Enabled  = txthoten.Enabled = cmbgt.Enabled = txtdc.Enabled = txtdt.Enabled = dtns.Enabled
            = btnquaylai.Enabled = btnxacnhan.Enabled = false;
        }

        private void gvkhachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = gvkhachhang.CurrentRow.Index;
            txtcmt.Text = gvkhachhang.Rows[i].Cells[0].Value.ToString();
         
            txthoten.Text = gvkhachhang.Rows[i].Cells[1].Value.ToString();
            dtns.Text = gvkhachhang.Rows[i].Cells[2].Value.ToString();
            if (Boolean.Parse(gvkhachhang.Rows[i].Cells[3].Value.ToString()) == true)
            {
                cmbgt.Text = "Nam";
            }
            else
            {
                cmbgt.Text = "Nữ";
            }
            txtdc.Text = gvkhachhang.Rows[i].Cells[4].Value.ToString();
            txtdt.Text = gvkhachhang.Rows[i].Cells[5].Value.ToString();
            if(Program.flagkh == 1)
            {
                Program.cmtkh = gvkhachhang.Rows[i].Cells[0].Value.ToString();
                Program.flagkh = 0;
             
                Form frm = Program.FormChinh.CheckExists(typeof(FormDatphong));
                if (frm != null)
                {
                    frm.Activate();
                }
                else
                {
                    FormDatphong f = new FormDatphong();
                    f.txtkh.Text = gvkhachhang.Rows[i].Cells[0].Value.ToString();
                    f.MdiParent = this;
                    f.Show();
                }
                this.Close();
            }
        }

     
        private void btnthem_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtcmt.Text = txtdc.Text = txthoten.Text = txtdc.Text = txtdt.Text = cmbgt.Text = dtns.Text = "";
            btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = btnreload.Enabled = false;
            txtcmt.Enabled  = txthoten.Enabled = cmbgt.Enabled = txtdc.Enabled = txtdt.Enabled =
            btnquaylai.Enabled = btnxacnhan.Enabled = dtns.Enabled = true;
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
             txthoten.Enabled = cmbgt.Enabled = txtdc.Enabled = txtdt.Enabled =
            btnquaylai.Enabled = btnxacnhan.Enabled = dtns.Enabled = true;
            flag3 = 1;
        }

        private void btnxacnhan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (flag1 == 1)
            {
                if(txtcmt.Text == "" || txtdc.Text=="" || txthoten.Text=="" || txtdc.Text=="" || txtdt.Text=="" || cmbgt.Text=="")
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm");
                    return;
                }
                if (txtdt.Text.ToString().Length != 10 || txtdt.Text.ToString().StartsWith("0") != true)
                {
                    MessageBox.Show("Số điện thoại không hợp lệ", "", MessageBoxButtons.OK);
                    return;
                }
                if (txtcmt.Text.ToString().Length!=9)
                {
                    MessageBox.Show("Chứng minh thư không hợp lệ", "", MessageBoxButtons.OK);
                    return;
                }
                HttpClient clienta = new HttpClient();
                clienta.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage responsea = clienta.GetAsync("api/Customer").Result;
                var customera = responsea.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
                var c = from t in customera where txtcmt.Text == t.CMT select t;
                if(c.ToList().Count!=0)
                {
                    MessageBox.Show("Đã có khách hàng này.Vui lòng thêm khách hàng khác");
                    return;
                }

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44326/");
                Customer customer = new Customer();
                customer.CMT = txtcmt.Text;
                customer.Hoten = txthoten.Text;
                customer.Ngaysinh = dtns.Value;
                if (cmbgt.SelectedItem.ToString().Equals("Nam"))
                {
                    customer.Gioitinh = true;
                }
                else
                {
                    customer.Gioitinh = false;
                }
                customer.Diachi = txtdc.Text;
                customer.SDT = txtdt.Text;
     
                HttpResponseMessage response = client.PostAsJsonAsync<Customer>("api/Customer", customer).Result;
                if (response.IsSuccessStatusCode == true)
                {
                    MessageBox.Show("Thêm thành công", "", MessageBoxButtons.OK);
                    HttpClient clientt = new HttpClient();
                    clientt.BaseAddress = new Uri("https://localhost:44326/");
                    HttpResponseMessage responset = clientt.GetAsync("api/Customer").Result;
                    var customert = responset.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
                    gvkhachhang.DataSource = customert;
                    txtcmt.Text = txtdc.Text = txthoten.Text = txtdc.Text = txtdt.Text = cmbgt.Text = dtns.Text = "";
                    btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = btnreload.Enabled = true;
                    txtcmt.Enabled  = txthoten.Enabled = cmbgt.Enabled = txtdc.Enabled = txtdt.Enabled = dtns.Enabled
                    = btnquaylai.Enabled = btnxacnhan.Enabled = false;
                    flag1 = 0;
                    return;
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "", MessageBoxButtons.OK);
                    btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = btnreload.Enabled = true;
                    txtcmt.Enabled  = txthoten.Enabled = cmbgt.Enabled = txtdc.Enabled = txtdt.Enabled = dtns.Enabled
                    = btnquaylai.Enabled = btnxacnhan.Enabled = false;
                    flag1 = 0;
                    return;
                }
            }
            if (flag3 == 1)
            {
                if (txtcmt.Text == "" || txtdc.Text == "" || txthoten.Text == "" || txtdc.Text == "" || txtdt.Text == "" || cmbgt.Text == "")
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi sửa");
                    return;
                }
                if (txtdt.Text.ToString().Length != 10 || txtdt.Text.ToString().StartsWith("0") != true)
                {
                    MessageBox.Show("Số điện thoại không hợp lệ", "", MessageBoxButtons.OK);
                    return;
                }
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44326/");
                Customer customer = new Customer();
                customer.CMT = txtcmt.Text;
                
                customer.Hoten = txthoten.Text;
                customer.Ngaysinh = dtns.Value;
                if (cmbgt.SelectedItem.ToString().Equals("Nam"))
                {
                    customer.Gioitinh = true;
                }
                else
                {
                    customer.Gioitinh = false;
                }
                customer.Diachi = txtdc.Text;
                customer.SDT = txtdt.Text;
             
                HttpResponseMessage response = client.PutAsJsonAsync<Customer>("api/Customer?CMT=" + txtcmt.Text + "", customer).Result;
                if (response.IsSuccessStatusCode == true)
                {
                    MessageBox.Show("Sửa thành công", "", MessageBoxButtons.OK);
                    HttpClient clientt = new HttpClient();
                    clientt.BaseAddress = new Uri("https://localhost:44326/");
                    HttpResponseMessage responset = clientt.GetAsync("api/Customer").Result;
                    var customert = responset.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
                    gvkhachhang.DataSource = customert;
                    txtcmt.Text = txtdc.Text = txthoten.Text = txtdc.Text = txtdt.Text = cmbgt.Text = dtns.Text = "";
                    btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = btnreload.Enabled = true;
                    txtcmt.Enabled  = txthoten.Enabled = cmbgt.Enabled = txtdc.Enabled = txtdt.Enabled = dtns.Enabled
                    = btnquaylai.Enabled = btnxacnhan.Enabled = false;
                    flag3 = 0;
                    return;
                }
                else
                {
                    if (txtcmt.Text == "" || txtdc.Text == "" || txthoten.Text == "" || txtdc.Text == "" || txtdt.Text == "" || cmbgt.Text == "")
                    {
                        MessageBox.Show("Sửa không hợp lệ");
                        return;
                    }

                   
                    MessageBox.Show("Sửa thất bại", "", MessageBoxButtons.OK);
                    btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = btnreload.Enabled = true;
                    txtcmt.Enabled  = txthoten.Enabled = cmbgt.Enabled = txtdc.Enabled = txtdt.Enabled = dtns.Enabled
                    = btnquaylai.Enabled = btnxacnhan.Enabled = false;
                    flag3 = 0;
                    return;
                }
            }
            if (flag2 == 1)
            {
                HttpClient clienta = new HttpClient();
                clienta.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage responsea = clienta.GetAsync("api/Bill").Result;
                var bill = responsea.Content.ReadAsAsync<IEnumerable<Datphong>>().Result;
                HttpClient clientb = new HttpClient();
                clientb.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage responseb = clientb.GetAsync("api/kiemtrahd").Result;
                var kt = responseb.Content.ReadAsAsync<IEnumerable<LuuHD>>().Result;
                var t = from c in bill from d in kt where c.CMT == txtcmt.Text && c.IDDAT == d.IDDAT select c;
                if (t.ToList().Count != 0)
                {
                    MessageBox.Show("Khách hang này đã có hóa đơn.Không thể xóa");
                    return;
                }

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage response = client.DeleteAsync("api/Customer?CMT=" + txtcmt.Text + "").Result;
                if (response.IsSuccessStatusCode == true)
                {
                    MessageBox.Show("Xóa thành công", "", MessageBoxButtons.OK);
                    HttpClient clientt = new HttpClient();
                    clientt.BaseAddress = new Uri("https://localhost:44326/");
                    HttpResponseMessage responset = clientt.GetAsync("api/Customer").Result;
                    var customert = responset.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
                    gvkhachhang.DataSource = customert;
                    txtcmt.Text = txtdc.Text = txthoten.Text = txtdc.Text = txtdt.Text = cmbgt.Text = dtns.Text = "";
                    btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = btnreload.Enabled = true;
                    txtcmt.Enabled  = txthoten.Enabled = cmbgt.Enabled = txtdc.Enabled = txtdt.Enabled = dtns.Enabled
                    = btnquaylai.Enabled = btnxacnhan.Enabled = false;
                    flag2 = 0;
                    return;
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "", MessageBoxButtons.OK);
                    btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = btnreload.Enabled = true;
                    txtcmt.Enabled = txthoten.Enabled = cmbgt.Enabled = txtdc.Enabled = txtdt.Enabled = dtns.Enabled
                    = btnquaylai.Enabled = btnxacnhan.Enabled = false;
                    flag2 = 0;
                    return;
                }
            }
        }

        private void btnquaylai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtcmt.Text = txtdc.Text = txthoten.Text = txtdc.Text = txtdt.Text = cmbgt.Text = dtns.Text = "";
            flag1 = flag2 = flag3 = 0;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/Customer").Result;
            var customer = response.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
            gvkhachhang.DataSource = customer;
            btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = btnreload.Enabled = true;
            txtcmt.Enabled  = txthoten.Enabled = cmbgt.Enabled = txtdc.Enabled = txtdt.Enabled = dtns.Enabled =
            btnquaylai.Enabled = btnxacnhan.Enabled = false;
        }

        private void btnreload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtcmt.Text = txtdc.Text = txthoten.Text = txtdc.Text = txtdt.Text = cmbgt.Text = dtns.Text = "";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/Customer").Result;
            var customer = response.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
            gvkhachhang.DataSource = customer;
            btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = btnreload.Enabled = true;
            txtcmt.Enabled  = txthoten.Enabled = cmbgt.Enabled = txtdc.Enabled = txtdt.Enabled = dtns.Enabled =
            btnquaylai.Enabled = btnxacnhan.Enabled = false;
        }

        private void btnthoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btntim_Click(object sender, EventArgs e)
        {
            txtcmt.Text = txtdc.Text = txthoten.Text = txtdc.Text = txtdt.Text = cmbgt.Text = dtns.Text = "";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/Customer?cmt=" + txttim.Text + "").Result;
            var customer = response.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
            gvkhachhang.DataSource = customer;
        }
    }
}
