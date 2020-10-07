using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class CustomerController : ApiController
    {
        [HttpGet]
        public IEnumerable<Khachhang>GetCustomer()
        {
            using(QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                entity.Configuration.ProxyCreationEnabled = false;
                return entity.Khachhangs.ToList();
            }
        }
        [HttpGet]
        public IEnumerable<TIMKH_Result>GetTim(string cmt)
        {
            using(QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                return entity.TIMKH(cmt).ToList();
            }
        }
        [HttpPost]
        public void PostCustomer(Khachhang customer)
        {
            using(QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                entity.Khachhangs.Add(customer);
                entity.SaveChanges();
            }
        }
        [HttpPut]
        public void PutCustomer(string CMT,Khachhang customer)
        {
            using(QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                var cus = entity.Khachhangs.FirstOrDefault(e => e.CMT.Equals(CMT));
                cus.CMT = customer.CMT;
            
                cus.Hoten = customer.Hoten;
                cus.Ngaysinh = customer.Ngaysinh;
                cus.Gioitinh = customer.Gioitinh;
                cus.Diachi = customer.Diachi;
                cus.SDT = customer.SDT;
                entity.SaveChanges();
            }
        }
        [HttpDelete]
        public void DeleteCustomer(string CMT)
        {
            using(QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                entity.Khachhangs.Remove(entity.Khachhangs.FirstOrDefault(e => e.CMT.Equals(CMT)));
                entity.SaveChanges();
            }
        }
    }
}
