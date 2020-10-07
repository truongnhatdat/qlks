using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("api/dangnhap")]
        public IEnumerable<SP_LOGIN_Result> GetLogin(string ac, string pass)
        {
            using (QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                return entity.SP_LOGIN(ac, pass).ToList();
            }

        }
        [HttpGet]
        [Route("api/login")]
        public IEnumerable<TaiKhoan> GetTK()
        {
            using (QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                entity.Configuration.ProxyCreationEnabled = false;
                return entity.TaiKhoans.ToList();
            }

        }
        [HttpPut]
        [Route("api/doimk")]
        public void Thaydoi(string manv,TaiKhoan login)
        {
            using(QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                var tk = entity.TaiKhoans.FirstOrDefault(e => e.MaNV.Equals(manv));
                tk.Matkhau = login.Matkhau;
                entity.SaveChanges();
            }
        }
        [HttpPost]
        [Route("api/Taotk")]
        public void Taotk(TaiKhoan dangnhap)
        {
            using (QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                entity.TaiKhoans.Add(dangnhap);
                entity.SaveChanges();
            }
        }
        [HttpDelete]
        [Route("api/xoatk")]
        public void deletetk(string manv)
        {
            using (QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                var tk = entity.TaiKhoans.FirstOrDefault(e => e.MaNV.Equals(manv));
                entity.TaiKhoans.Remove(tk);
                entity.SaveChanges();
            }
        }
    }
}
