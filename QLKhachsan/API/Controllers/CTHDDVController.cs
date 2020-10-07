using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class CTHDDVController : ApiController
    {
      
        [HttpGet]
        public IEnumerable<SP_CTDATDV_Result>GetCTHDDV(long idhd)
        {
            using(QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                return entity.SP_CTDATDV(idhd).ToList();
            }
        }
        [HttpGet]
        [Route("api/kiemtradv")]
        public IEnumerable<Chitietdatdichvu>Get()
        {
            using (QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                entity.Configuration.ProxyCreationEnabled = false;
                return entity.Chitietdatdichvus.ToList();
            }
        }
    
        [HttpPost]
        public void PostCTHDDV(Chitietdatdichvu cthddv)
        {
            using(QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                entity.Chitietdatdichvus.Add(cthddv);
                entity.SaveChanges();
            }
        }
        [HttpPut]
        public void PutCTHDDV(long idhd,long iddv,Chitietdatdichvu cthddv)
        {
            using(QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                var em = entity.Chitietdatdichvus.FirstOrDefault(e => e.IDDAT.Equals(idhd) && e.IDDV == iddv);
                em.IDDAT = cthddv.IDDAT;
                em.IDDV = cthddv.IDDV;
                em.Soluong = cthddv.Soluong;
                entity.SaveChanges();
            }
        }
        [HttpDelete]
        public void DeleteCTHDDV(long iddv,long idhd)
        {
            using(QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                entity.Chitietdatdichvus.Remove(entity.Chitietdatdichvus.FirstOrDefault(e => e.IDDAT.Equals(idhd) && e.IDDV == iddv));
                entity.SaveChanges();
            }
        }
    }
}
