
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
    public partial class FormDoiMK : Form
    {
        private static string manv = "";
      
        public FormDoiMK()
        {
            InitializeComponent();
          
        }
      
        private void btndoi_Click(object sender, EventArgs e)
        {

            foreach(var pi in txtmkmoi.Text)
            {
                if (pi.Equals(' '))
                {
                    MessageBox.Show("Mật khẩu mới không hợp lệ", "", MessageBoxButtons.OK);
                    return;
                }
            }
        
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/login").Result;
            var tk1= response.Content.ReadAsAsync<IEnumerable<taikhoan>>().Result;
            var nv = tk1.FirstOrDefault(a => a.Taikhoan1.Equals(Program.taikhoan) && a.Matkhau.Equals(txtmkcu.Text));
            try
            {
             
                if (nv == null)
                {
                    MessageBox.Show("Bạn nhập sai thông tin tài khoản cũ.Vui lòng nhập lại", "", MessageBoxButtons.OK);
                    return;
                }
              
                else if (txtxnmkmoi.Text.Equals(txtmkmoi.Text)!=true)
                {
                    MessageBox.Show("Mật khẩu xác nhận bị sai.Vui lòng kiểm tra lại", "", MessageBoxButtons.OK);
                    return;
                    
                }
                else
                {
                    manv = nv.MaNV;
                    taikhoan tk = new taikhoan();
                   // em.Taikhoan = txttkmoi.Text;
                    tk.Matkhau = txtmkmoi.Text.Trim();

                    HttpClient client1 = new HttpClient();
                    client1.BaseAddress = new Uri("https://localhost:44326/");
                    HttpResponseMessage response1 = client1.PutAsJsonAsync<taikhoan>("api/doimk?manv=" + nv.MaNV +"", tk).Result;
                    if (response1.IsSuccessStatusCode == true)
                    {
                        MessageBox.Show("Đổi thành công", "", MessageBoxButtons.OK);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Đổi thất bại", "", MessageBoxButtons.OK);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi", "", MessageBoxButtons.OK);
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
