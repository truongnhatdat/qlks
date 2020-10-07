
using QLKS.INHOADON;
using QLKS.LOGIN;
using QLKS.REPORT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace QLKS
{
    public partial class FormMain : DevExpress.XtraBars.TabForm
    {
        
        public FormMain()
        {
            InitializeComponent();
        }
      
        public Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(Program.co == 1)
            {
                FormDoiMK formdoi = new FormDoiMK();
                formdoi.Show();
            }
            else
            {
                MessageBox.Show("Bạn chưa đăng nhập.Vui lòng đăng nhập", "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnlogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formdn fdn = new Formdn();
            fdn.Show();
        }

        private void btnnv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            if (Program.co == 1)
            {
                if (Program.nhom.CompareTo("Nhân Viên ") == 0)
                {
                    MessageBox.Show("Bạn không đủ quyền vào mục này", "", MessageBoxButtons.OK);
                    return;
                }

                Form frm = this.CheckExists(typeof(Formnv));

                if (frm != null)
                {
                    frm.Activate();

                }
                else
                {
                    //MessageBox.Show("Bạn chưa đăng nhập.Vui lòng đăng nhập "+Program.nhom+"", "", MessageBoxButtons.OK);
                    Formnv f = new Formnv();
                    f.MdiParent = this;
                    f.Show();
                }
            }
            
            else
            {
                MessageBox.Show("Bạn chưa đăng nhập.Vui lòng đăng nhập", "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnphong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(Program.co == 1)
            {
                Form frm = this.CheckExists(typeof(FormRoom));
                if (frm != null)
                {
                    frm.Activate();
                }
                else
                {
                    FormRoom f = new FormRoom();
                    f.MdiParent = this;
                    f.Show();
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa đăng nhập.Vui lòng đăng nhập", "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnloaiphong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(Program.co == 1)
            {
                Form frm = this.CheckExists(typeof(FormLoaiPhong));
                if (frm != null)
                {
                    frm.Activate();
                }
                else
                {
                    FormLoaiPhong f = new FormLoaiPhong();
                    f.MdiParent = this;
                    f.Show();
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa đăng nhập.Vui lòng đăng nhập", "", MessageBoxButtons.OK);
                return;
            }
        }

       

        private void btndv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           if(Program.co == 1)
            {
                Form frm = this.CheckExists(typeof(Formdv));
                if (frm != null)
                {
                    frm.Activate();
                }
                else
                {
                    Formdv f = new Formdv();
                    f.MdiParent = this;
                    f.Show();
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa đăng nhập.Vui lòng đăng nhập", "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnkhachhang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(Program.co == 1)
            {
                Form frm = this.CheckExists(typeof(FormKhachHang));
                if (frm != null)
                {
                    frm.Activate();
                }
                else
                {
                    FormKhachHang f = new FormKhachHang();
                    f.MdiParent = this;
                    f.Show();
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa đăng nhập.Vui lòng đăng nhập", "", MessageBoxButtons.OK);
                return;
            }
        }


        private void btnthongke_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            if (Program.co == 1)
            {
                //if (Program.nhom=="User")
                //{
                //    MessageBox.Show("Bạn không đủ quyền để xem!", "", MessageBoxButtons.OK);
                //    return;
                //}
                if (Program.nhom.CompareTo("Nhân Viên ") == 0)
                {
                    MessageBox.Show("Bạn không đủ quyền vào mục này", "", MessageBoxButtons.OK);
                    return;
                }
                Form frm = this.CheckExists(typeof(FormThongKe));
                if (frm != null)
                {
                    frm.Activate();
                }
                else
                {
                    FormThongKe f = new FormThongKe();
                    f.MdiParent = this;
                    f.Show();
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa đăng nhập.Vui lòng đăng nhập", "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btninbaocao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(Program.co == 1)
            {
                if(Program.ngaytruoc==null)
                {
                    MessageBox.Show("Bạn chưa thống kê", "", MessageBoxButtons.OK);
                    return;
                }
                FormInBaoCao ftk = new FormInBaoCao();
                ftk.Show();
            }
            else
            {
               MessageBox.Show("Bạn chưa đăng nhập.Vui lòng đăng nhập", "", MessageBoxButtons.OK);
                return;
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(Program.co==1)
            {
                Program.co = 0;
                MessageBox.Show("Bạn Đã đăng xuất thành công", "", MessageBoxButtons.OK);
                try
                {
                    Form frm1 = this.CheckExists(typeof(FormRoom));

                    if (frm1 !=null)
                    {
                        frm1.Close();
                       // return;
                    }
                    Form frm2 = this.CheckExists(typeof(Formnv));
                    if (frm2 !=null)
                    {
                        frm2.Close();
                       // return;
                    }
                    Form frm3 = this.CheckExists(typeof(FormLoaiPhong));
                    if (frm3 !=null)
                    {
                        frm3.Close();
                       // return;
                    }
                    Form frm4 = this.CheckExists(typeof(FormThietBi));
                    if (frm4 != null)
                    {
                        frm4.Close();
                        //return;
                    }
                    Form frm5 = this.CheckExists(typeof(Formdv));
                    if (frm5 != null)
                    {
                        frm5.Close();
                        //return;
                    }
                    Form frm6 = this.CheckExists(typeof(FormKhachHang));
                    if (frm6 !=null )
                    {
                        frm6.Close();
                        //return;
                    }
                    Form frm7 = this.CheckExists(typeof(FormDatphong));
                    if (frm7 !=null)
                    {
                        frm7.Close();
                        //return;
                    }
                    Form frm8 = this.CheckExists(typeof(FormThongKe));
                    if (frm8 != null)
                    {
                        frm8.Close();
                        //return;
                    }
                    Program.FormChinh.sttmanv.Text = "";
                    Program.FormChinh.stthoten.Text = "";
                    Program.FormChinh.sttnhom.Text = "";
                }
                catch(Exception ex)
                {
                    
                }
               
               
            }
            else
            {
                MessageBox.Show("Bạn chưa đăng nhập.Vui lòng đăng nhập", "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btndatphong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.co == 1)
            {
                Form frm = this.CheckExists(typeof(FormDatphong));
                if (frm != null)
                {
                    frm.Activate();
                }
                else
                {
                    FormDatphong f = new FormDatphong();
                    f.MdiParent = this;
                    f.Show();
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa đăng nhập.Vui lòng đăng nhập", "", MessageBoxButtons.OK);
                return;
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.nhom.CompareTo("Nhân Viên ") == 0)
            {
                MessageBox.Show("Bạn không đủ quyền vào mục này", "", MessageBoxButtons.OK);
                return;
            }
            if (Program.co == 1)
            {
                TaoTK ftk = new TaoTK();
                ftk.Show();
            }
            else
            {
                MessageBox.Show("Bạn chưa đăng nhập.Vui lòng đăng nhập", "", MessageBoxButtons.OK);
                return;
            }
        }
    }
}
