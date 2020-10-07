using API.Models;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class RoomController : ApiController
    {
        [HttpGet]
        public IEnumerable<Phong> GetRooms()
        {
            QLKhachsanEntities entity = new QLKhachsanEntities();
            entity.Configuration.ProxyCreationEnabled = false;
            return entity.Phongs.ToList();
        }
        [HttpGet]
        public IEnumerable<LOADROOMID_Result> GetRoomID(int number)
        {
            QLKhachsanEntities entity = new QLKhachsanEntities();
            return entity.LOADROOMID(number).ToList();
        }
        [HttpPost]
        public void PostRoom2(Phong room)
        {
            QLKhachsanEntities entity = new QLKhachsanEntities();
            entity.Phongs.Add(room);
            entity.SaveChanges();
        }
        [HttpPut]
        public void PutRoom2(int numberroom,Phong room)
        {
            QLKhachsanEntities entity = new QLKhachsanEntities();
            var en = entity.Phongs.FirstOrDefault(e => e.Sophong == numberroom);
            en.Sophong = room.Sophong;
            en.Tinhtrang = room.Tinhtrang;
        
            en.Loaiphong = room.Loaiphong;
            en.Ghichu = room.Ghichu;
         
            entity.SaveChanges();
        }
        [HttpDelete]
        public void DeleteRoom2(int numberroom)
        {
            QLKhachsanEntities entity = new QLKhachsanEntities();
            entity.Phongs.Remove(entity.Phongs.FirstOrDefault(e => e.Sophong == numberroom));
            entity.SaveChanges();
        }
    }
}
