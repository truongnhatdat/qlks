using API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace API.Controllers
{
    public class ChitietHDPhongController : ApiController
    {
        public double tien;
        [HttpGet]
        public IEnumerable<SP_CTDATPHONG_Result> GetCTHDP(long iddat)
        {
            using(QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                return entity.SP_CTDATPHONG(iddat).ToList();
            }
        }
        // lay ra cac phong chua thue
        [HttpGet]
        [Route("api/RoomR")]
        public IEnumerable<LOADROOMRANH_Result>GetRR(string loaip)
        {
            using(QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                return entity.LOADROOMRANH(loaip).ToList();
            }
        }
       [HttpPost]
        public void PostCTHDP(Chitietdatphong ctdp)
        {
            using(QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                entity.Chitietdatphongs.Add(ctdp);
                entity.SaveChanges();
            }
        }
        
        [HttpPut]
        public void PutCTHDP(long sophong,long iddat,Chitietdatphong ctdp)
        {
            using(QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                var cth = entity.Chitietdatphongs.FirstOrDefault(e =>e.Sophong.Equals(sophong) && e.IDDAT.Equals(iddat));
          
               // cth.Sophong = cthdp.Sophong;
               // cth.IDHD = cthdp.IDHD;
                cth.Ngayden = ctdp.Ngayden;
                cth.Ngaydi = ctdp.Ngaydi;
                entity.SaveChanges();
            }
        }
        [HttpPut]
        [Route("api/update1")]
        public void updateroom1(long sophong,Phong room)
        {
            using(QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                var em = entity.Phongs.FirstOrDefault(e => e.Sophong.Equals(sophong));
                em.Tinhtrang = room.Tinhtrang;
                entity.SaveChanges();
            }
        }
        [HttpDelete]
        public void DeleteCTHDP(long sophong,long iddat)
        {
            using(QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                entity.Chitietdatphongs.Remove(entity.Chitietdatphongs.FirstOrDefault(e => e.IDDAT.Equals(iddat) && e.Sophong.Equals(sophong)));
                entity.SaveChanges();
            }
        }
    }
}
