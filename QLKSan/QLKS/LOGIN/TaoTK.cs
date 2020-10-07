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

namespace QLKS.LOGIN
{
    public partial class TaoTK : Form
    {
        public TaoTK()
        {
            InitializeComponent();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/Employees").Result;
            var employee = response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
            cmbmanv.DataSource = employee;
            cmbmanv.DisplayMember = "MaNV";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var pi in txtmk.Text)
            {
                if (pi.Equals(' '))
                {
                    MessageBox.Show("Mật khẩu mới không hợp lệ", "", MessageBoxButtons.OK);
                    return;
                }
            }
            if (txttk.Text.Length < 6)
            {
                MessageBox.Show("Tài khoản không hợp lệ", "", MessageBoxButtons.OK);
                return;
            }
            if (txttk.Text == "" || txtmk.Text =="" || cmbnhom.Text == "" || cmbmanv.Text =="")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "", MessageBoxButtons.OK);
                return;
            }
            HttpClient clienta = new HttpClient();
            clienta.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage responsea = clienta.GetAsync("api/login").Result;
            var kt = responsea.Content.ReadAsAsync<IEnumerable<taikhoan>>().Result;
            var kiemtra = from t in kt where t.Taikhoan1 == txttk.Text || t.MaNV==cmbmanv.Text select t;
            if(kiemtra.ToList().Count!=0)
            {
                MessageBox.Show("Tài khoản đã có sẵn.Vui lòng thay đổi tài khoản", "", MessageBoxButtons.OK);
                return;
            }
            taikhoan tk = new taikhoan();
            tk.MaNV = cmbmanv.Text;
            tk.Taikhoan1 = txttk.Text;
            tk.Matkhau = txtmk.Text;
            tk.Nhom = cmbnhom.Text;
            tk.Ngaylap = DateTime.Now;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.PostAsJsonAsync<taikhoan>("api/Taotk", tk).Result;
            if (response.IsSuccessStatusCode == true)
            {
                MessageBox.Show("Tạo thành công", "", MessageBoxButtons.OK);
             
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show("Tạo thất bại", "", MessageBoxButtons.OK);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
