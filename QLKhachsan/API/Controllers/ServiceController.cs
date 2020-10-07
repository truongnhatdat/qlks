using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ServiceController : ApiController
    {
        [HttpGet]
        public IEnumerable<Dichvu>GetService()
        {
            using(QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                entity.Configuration.ProxyCreationEnabled = false;
                return entity.Dichvus.ToList();
            }
        }
        [HttpPost]
        public void PostService(Dichvu Service)
        {
            using(QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                entity.THEMDV(Service.TenDV, Service.GiaDV, Service.DVT, Service.Hinh, Service.Mota);
            }
        }
        [HttpPut]
        public void PutService(long iddv,Dichvu service)
        {
            using (QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                var en = entity.Dichvus.FirstOrDefault(e => e.IDDV == iddv);
                en.TenDV = service.TenDV;
                en.GiaDV = service.GiaDV;
                en.DVT = service.DVT;
                en.Hinh = service.Hinh;
                en.Mota = service.Mota;
                entity.SaveChanges();
            }

        }
        [HttpDelete]
        public void DeleteService(long iddv)
        {
            using(QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                entity.Dichvus.Remove(entity.Dichvus.FirstOrDefault(e => e.IDDV == iddv));
                entity.SaveChanges();
            }
        }
    }
}
