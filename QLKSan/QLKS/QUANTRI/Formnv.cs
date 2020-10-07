
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
    public partial class Formnv : Form
    {
         
        private static int flag1 = 0;
        private static int flag2 = 0;
        private static int flag3 = 0;
        List<Employee> eml = new List<Employee>();
       
        public Formnv()
        {
            InitializeComponent();
          
            cmbgt.Text = "Nam";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/Employees").Result;
            var employee = response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
            gvnv.DataSource = employee;
            gvnv.Columns["MaNV"].HeaderText = "Mã nhân viên";
           
            gvnv.Columns["Hoten"].HeaderText = "Họ tên";
            gvnv.Columns["Gioitinh"].HeaderText = "Giới tính";
            gvnv.Columns["SDT"].HeaderText = "Số điện thoại";
            gvnv.Columns["Hinh"].HeaderText = "Hình ảnh";
            gvnv.Columns["Ghichu"].HeaderText = "Ghi chú";
            eml = employee.ToList();
            txtmanv.Enabled  = txthoten.Enabled = txtghichu.Enabled
         = btnquaylai.Enabled = btnxacnhan.Enabled = txtdt.Enabled = btnbrowse.Enabled = cmbgt.Enabled = false;
        }

        private void gvnv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = gvnv.CurrentRow.Index;
            txtmanv.Text = gvnv.Rows[i].Cells[0].Value.ToString();
           
            txthoten.Text = gvnv.Rows[i].Cells[1].Value.ToString();
            if (Boolean.Parse(gvnv.Rows[i].Cells[2].Value.ToString()) == true)
            {
                cmbgt.Text = "Nam";
            }
            else
            {
                cmbgt.Text = "Nữ";
            }
            txtdt.Text = gvnv.Rows[i].Cells[3].Value.ToString();
            picturenv.Image = Base64StringIntoImage(gvnv.Rows[i].Cells[4].Value.ToString());
            if (gvnv.Rows[i].Cells[5].Value == null)
            {
                txtghichu.Text = "";
            }
            else
            {
                txtghichu.Text = gvnv.Rows[i].Cells[5].Value.ToString();
            }

        }
        public static Image Base64StringIntoImage(string str64)
        {
            byte[] img = Convert.FromBase64String(str64);
            MemoryStream ms = new MemoryStream(img);
            return Image.FromStream(ms);
        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
          
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "Image files(*.jpg, *.jpeg, *.bmp, *.png) | *.jpg; *.jpeg; *.bmp; *.png|All files (*.*)|*.*";
            if (od.ShowDialog() == DialogResult.OK)
            {
                picturenv.Load(od.FileName);
            }
        }

        private void btnthem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtmanv.Text = txthoten.Text
                  = txtdt.Text = cmbgt.Text = "";
            picturenv.Image = null;
            btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = false;
            txtmanv.Enabled= txthoten.Enabled
            = btnquaylai.Enabled = btnxacnhan.Enabled = txtdt.Enabled = btnbrowse.Enabled = cmbgt.Enabled = txtghichu.Enabled = true;
            flag1 = 1;
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
            btnthem.Enabled = btnsua.Enabled = btnxoa.Enabled = btnthoat.Enabled = btnreload.Enabled = false;
            btnquaylai.Enabled = btnxacnhan.Enabled = true;
            flag2 = 1;
        }

        private void btnsua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = false;
             txthoten.Enabled
            = btnquaylai.Enabled = btnxacnhan.Enabled = txtdt.Enabled = btnbrowse.Enabled = cmbgt.Enabled = txtghichu.Enabled = true;
            flag3 = 1;
        }

        private void btnxacnhan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (flag1 == 1)
            {
                if (txtmanv.Text == "" || txthoten.Text
                 == "" || txtdt.Text == "" || cmbgt.Text == "" || picturenv.Image == null)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm","",MessageBoxButtons.OK);
                    
                    return;
                }
                if(txtdt.Text.ToString().Length!=10 || txtdt.Text.ToString().StartsWith("0")!=true)
                {
                    MessageBox.Show("Số điện thoại không hợp lệ","",MessageBoxButtons.OK);
                    return;
                }
                HttpClient clienta = new HttpClient();
                clienta.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage responsea = clienta.GetAsync("api/Employees?manv="+txtmanv.Text+"").Result;
                var employee1 = responsea.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
                
                if(employee1.ToList().Count!=0)
                {
                    MessageBox.Show("Nhân viên này đã có", "", MessageBoxButtons.OK);
                    return;
                }
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44326/");
                Employee em = new Employee();
                em.MaNV = txtmanv.Text;
               
                em.Hoten = txthoten.Text;
                if (cmbgt.SelectedItem.ToString().Equals("Nam"))
                {
                    em.Gioitinh = true;
                }
                else
                {
                    em.Gioitinh = false;
                }
                em.SDT = txtdt.Text;
                em.Hinh = ImageIntoBase64String(picturenv);
          
                HttpResponseMessage response = client.PostAsJsonAsync<Employee>("api/Employees", em).Result;
                if (response.IsSuccessStatusCode == true)
                {
                    
                    MessageBox.Show("Thêm thành công", "", MessageBoxButtons.OK);
                    cmbgt.Text = "Nam";
                    HttpClient clientt = new HttpClient();
                    clientt.BaseAddress = new Uri("https://localhost:44326/");
                    HttpResponseMessage responset = clientt.GetAsync("api/Employees").Result;
                    var employee = responset.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
                    gvnv.DataSource = employee;
                    txtmanv.Text = txthoten.Text
                    = txtdt.Text = cmbgt.Text = "";
                    picturenv.Image = null;
                    btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = true;
                    txtmanv.Enabled = txthoten.Enabled
                    = btnquaylai.Enabled = btnxacnhan.Enabled = txtdt.Enabled = cmbgt.Enabled = btnbrowse.Enabled = txtghichu.Enabled = false;
                    flag1 = 0;
                    
                    return;
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "", MessageBoxButtons.OK);
                    btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = true;
                    txtmanv.Enabled  = txthoten.Enabled
                    = btnquaylai.Enabled = btnxacnhan.Enabled = txtdt.Enabled = btnbrowse.Enabled = txtghichu.Enabled = false;
                    flag1 = 0;
                    return;
                }
            }
            if (flag2 == 1)
            {
                HttpClient client1 = new HttpClient();
                client1.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage response1 = client1.GetAsync("api/Bill").Result;
                var bill = response1.Content.ReadAsAsync<IEnumerable<Datphong>>().Result;
                var hd = bill.ToList();
                foreach (var pi in hd)
                {
                    if (pi.MaNV.Equals(txtmanv.Text))
                    {
                        MessageBox.Show("Nhân viên này đã lập hóa đơn.Không thể xóa", "", MessageBoxButtons.OK);
                       // flag2 = 0;
                        return;
                    }
                }
                HttpClient client2 = new HttpClient();
                client2.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage response2 = client2.GetAsync("api/login").Result;
                var dn = response2.Content.ReadAsAsync<IEnumerable<taikhoan>>().Result;
                var tk = from a in dn where a.MaNV == txtmanv.Text select a;
                if(tk.ToList().Count!=0)
                {
                    HttpClient clienta = new HttpClient();
                    clienta.BaseAddress = new Uri("https://localhost:44326/");
                    HttpResponseMessage responsea = clienta.DeleteAsync("api/xoatk?manv=" + txtmanv.Text + "").Result;
                }
             
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri("https://localhost:44326/");
                HttpResponseMessage response = client.DeleteAsync("api/Employees?manv=" + txtmanv.Text + "").Result;
                //client1.Delete("Employees/" + txtmanv.Text);
                if (response.IsSuccessStatusCode == true)
                {
                    MessageBox.Show("Xóa thành công", "", MessageBoxButtons.OK);
                    HttpClient clientt = new HttpClient();
                    clientt.BaseAddress = new Uri("https://localhost:44326/");
                    HttpResponseMessage responset = clientt.GetAsync("api/Employees").Result;
                    var employee = responset.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
                    gvnv.DataSource = employee;
                    txtmanv.Text = txthoten.Text
                  = txtdt.Text = cmbgt.Text = "";
                    picturenv.Image = null;
                    btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = btnreload.Enabled = true;
                    txtmanv.Enabled = txthoten.Enabled
                    = btnquaylai.Enabled = btnxacnhan.Enabled = txtdt.Enabled = btnbrowse.Enabled = txtghichu.Enabled = false;
                    flag2 = 0;
                    return;
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "", MessageBoxButtons.OK);
                    btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = btnreload.Enabled = true;
                    txtmanv.Enabled  = txthoten.Enabled
                    = btnquaylai.Enabled = btnxacnhan.Enabled = txtdt.Enabled = cmbgt.Enabled = txtghichu.Enabled = btnbrowse.Enabled = false;
                    flag2 = 0;
                    return;
                }
            }
            if (flag3 == 1)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44326/");
                Employee em = new Employee();
                em.MaNV = txtmanv.Text;
             
                em.Hoten = txthoten.Text;
                if (cmbgt.SelectedItem.ToString().Equals("Nam"))
                {
                    em.Gioitinh = true;
                }
                else
                {
                    em.Gioitinh = false;
                }
                em.SDT = txtdt.Text;
              
                em.Hinh = ImageIntoBase64String(picturenv);
                em.Ghichu = txtghichu.Text;
                if (txtmanv.Text == "" || txthoten.Text
                     == "" || txtdt.Text == "" || cmbgt.Text == "" || picturenv.Image==null)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi sửa");
                   // flag3 = 0;
                    return;
                }
                if (txtdt.Text.ToString().Length != 10 || txtdt.Text.ToString().StartsWith("0") != true)
                {
                    MessageBox.Show("Số điện thoại không hợp lệ", "", MessageBoxButtons.OK);
                    return;
                }
                HttpResponseMessage response = client.PutAsJsonAsync<Employee>("api/Employees?manv=" + txtmanv.Text + "", em).Result;
                if (response.IsSuccessStatusCode == true)
                {
                    MessageBox.Show("Sửa thành công", "", MessageBoxButtons.OK);
                    HttpClient clientt = new HttpClient();
                    clientt.BaseAddress = new Uri("https://localhost:44326/");
                    HttpResponseMessage responset = clientt.GetAsync("api/Employees").Result;
                    var employee = responset.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
                    gvnv.DataSource = employee;
                    txtmanv.Text = txthoten.Text
                  = txtdt.Text = cmbgt.Text = "";
                    picturenv.Image = null;
                    btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = btnreload.Enabled = true;
                    txtmanv.Enabled= txthoten.Enabled
                    = btnquaylai.Enabled = btnxacnhan.Enabled = txtdt.Enabled = cmbgt.Enabled = txtghichu.Enabled = btnbrowse.Enabled = false;
                    flag3 = 0;
                    return;
                }
                else
                {
                    MessageBox.Show("Sửa thất bại", "", MessageBoxButtons.OK);
                    btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = btnreload.Enabled = true;
                    txtmanv.Enabled  = txthoten.Enabled
                    = btnquaylai.Enabled = btnxacnhan.Enabled = txtdt.Enabled = cmbgt.Enabled = txtghichu.Enabled = btnbrowse.Enabled = false;
                    flag3 = 0;
                    return;
                }
            }
        }

        private void btnquaylai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            flag1 = flag2 = flag3 = 0;
            txtmanv.Text = txthoten.Text
                  = txtdt.Text = cmbgt.Text = "";
            picturenv.Image = null;
            btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = btnreload.Enabled = true;
            txtmanv.Enabled  = txthoten.Enabled
            = btnquaylai.Enabled = btnxacnhan.Enabled = txtdt.Enabled = cmbgt.Enabled = btnbrowse.Enabled = txtghichu.Enabled = false;
            flag1 = flag2 = flag3 = 0;
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/Employees").Result;
            var employee = response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
            gvnv.DataSource = employee;
            txtmanv.Text = txthoten.Text
                  = txtdt.Text = cmbgt.Text = "";
            picturenv.Image = null;
            btnthem.Enabled = btnxoa.Enabled = btnsua.Enabled = btnthoat.Enabled = btnreload.Enabled = true;
            txtmanv.Enabled = txthoten.Enabled
            = btnquaylai.Enabled = btnxacnhan.Enabled = txtdt.Enabled = cmbgt.Enabled = btnbrowse.Enabled = txtghichu.Enabled = false;
        }

        private void btntim_Click(object sender, EventArgs e)
        {
            txtmanv.Text = txthoten.Text
                = txtdt.Text = cmbgt.Text = "";
            picturenv.Image = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/Employees?name=" + txttim.Text + "").Result;
            var employee = response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
            gvnv.DataSource = employee;
        }
    }
}
