using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class BillController : ApiController
    {
        [HttpGet]
        public IEnumerable<Datphong>GetBill()
        {
            using(QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                entity.Configuration.ProxyCreationEnabled = false;
                return entity.Datphongs.ToList();
            }
        }
        [HttpPost]
        public void PostBill(Datphong datphong)
        {
            using(QLKhachsanEntities entity = new QLKhachsanEntities())
            {
               
                entity.SP_THEMDAT(datphong.Ngaydat.ToString(),datphong.MaNV,datphong.CMT,datphong.Ghichu);
            }
        }
        [HttpPut]
        public void PutBill(long iddat,Datphong bill)
        {
            using(QLKhachsanEntities  entity = new QLKhachsanEntities())
            {
                var bi = entity.Datphongs.FirstOrDefault(e => e.IDDAT.Equals(iddat));
                bi.IDDAT = bill.IDDAT;
                bi.Ngaydat = bill.Ngaydat;
                bi.MaNV = bill.MaNV;
                bi.CMT = bill.CMT;
                bi.Ghichu = bill.Ghichu;
               
                entity.SaveChanges();
            }
        }
        [HttpDelete]
        public void DeleteBill(long iddat)
        {
            using(QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                entity.Datphongs.Remove(entity.Datphongs.FirstOrDefault(e => e.IDDAT.Equals(iddat)));
                entity.SaveChanges();
            }
        }
    }
}
