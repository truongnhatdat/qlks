using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using QLKS.INHOADON;

namespace QLKS
{
    public partial class Formdn : Form
    {

        public Formdn()
        {
            InitializeComponent();
        }

        private void btndn_Click(object sender, EventArgs e)
        {
            if (txtac.Text.Length < 6 || string.IsNullOrWhiteSpace(txtac.Text) || string.IsNullOrWhiteSpace(txtpass.Text))
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không hợp lệ", "", MessageBoxButtons.OK);
                return;
            }
            if (Program.co==1)
            {
                MessageBox.Show("Bạn chưa đăng xuất", "", MessageBoxButtons.OK);
                return;
            }
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44326/");
            HttpResponseMessage response = client.GetAsync("api/dangnhap?ac=" + txtac.Text + "&pass=" + txtpass.Text + "").Result;
            var login = response.Content.ReadAsAsync<IEnumerable<Login>>().Result;
            var login1 = login.ToList();
            if (login.ToList().Count == 0)
            {
                MessageBox.Show("Sai thông tin đăng nhập mời bạn xem lại", "", MessageBoxButtons.OK);
                return;
            }
            else
            {
                MessageBox.Show("Đăng nhập thành công", "", MessageBoxButtons.OK);
                var log = login1[0];
                Program.nhom = log.Nhom;
                Program.FormChinh.sttmanv.Text = "Mã nhân viên :" + log.MaNV;
                Program.FormChinh.stthoten.Text = "Họ tên :" + log.Hoten;
                Program.FormChinh.sttnhom.Text = "Nhóm quyền :" +log.Nhom;
                //if (log.Nhom.CompareTo("Quản Lý") == 0)
                //{
                //    Program.cox = 1;
                //}
                Program.hotennv = log.Hoten;
                Program.manv= log.MaNV;
                Program.taikhoan = txtac.Text;
                Program.co = 1;
                this.Close();
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
