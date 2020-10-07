using API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    public class EmployeesController : ApiController
    {
        [HttpGet]
        public IEnumerable<Nhanvien>GetEmployees()
        {
            using(QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                 entity.Configuration.ProxyCreationEnabled = false;
                return entity.Nhanviens.ToList();
            }
        }
        [HttpGet]
        public IEnumerable<SEARCHUSER_Result>SearchUser(string name)
        {
            using(QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                entity.Configuration.ProxyCreationEnabled = false;
                return entity.SEARCHUSER(name).ToList();
            }
        }
        [HttpGet]
        public IEnumerable<KTMANV_Result> KTNV(string manv)
        {
            using (QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                entity.Configuration.ProxyCreationEnabled = false;
                return entity.KTMANV(manv).ToList();
            }
        }
        [HttpPost]
        public void PostEmployee(Nhanvien employee)
        {
            QLKhachsanEntities entity = new QLKhachsanEntities();
            entity.Nhanviens.Add(employee);
            entity.SaveChanges();
        }
        [HttpPut]
        public void PutEmployees(string manv,Nhanvien employee)
        {
            using(QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                var en = entity.Nhanviens.FirstOrDefault(e => e.MaNV==manv);
                en.MaNV = employee.MaNV;
              
                en.Hoten = employee.Hoten;
                en.Gioitinh = employee.Gioitinh;
                en.SDT = employee.SDT;
                en.Hinh = employee.Hinh;
                en.Ghichu = employee.Ghichu;
  
                entity.SaveChanges();
            }
        }
        [HttpDelete]
        public void DeleteEmployees(string manv)
        {
            using(QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                entity.Nhanviens.Remove(entity.Nhanviens.FirstOrDefault(e => e.MaNV==manv));
                entity.SaveChanges();
            }
        }
    }
}
