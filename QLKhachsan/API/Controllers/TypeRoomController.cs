using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class TypeRoomController : ApiController
    {
        [HttpGet]
        public IEnumerable<Loaiphong>GetTypeRoom()
        {
            using(QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                entity.Configuration.ProxyCreationEnabled = false;
                return entity.Loaiphongs.ToList();
            }
        }
        [HttpPost]
        public void PostTypeRoom(Loaiphong loai)
        {
            using(QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                entity.Loaiphongs.Add(loai);
                entity.SaveChanges();
            }
        }
        [HttpPut]
        public void PutTypeRoom(string loai,Loaiphong loaiphong)
        {
            using(QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                var room = entity.Loaiphongs.FirstOrDefault(e => e.Loaiphong1.Equals(loai));
                //room.Loaiphong1 = loaiphong.Loaiphong1;
                room.Gia = loaiphong.Gia;
                room.Mota = loaiphong.Mota;
                room.Hinhanh = loaiphong.Hinhanh;
               
                entity.SaveChanges();
            }
        }
        [HttpDelete]
        public void DeleteTypeRoom(string loai)
        {
            using(QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                entity.Loaiphongs.Remove(entity.Loaiphongs.FirstOrDefault(e=>e.Loaiphong1.Equals(loai)));
                entity.SaveChanges();
            }
        }
    }
}
