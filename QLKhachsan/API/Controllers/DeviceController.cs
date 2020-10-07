using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class DeviceController : ApiController
    {
       // [HttpGet]
       // public IEnumerable<Thietbi>GetDevice()
       // {
       //     QLKhachsanEntities entity = new QLKhachsanEntities();
       //     entity.Configuration.ProxyCreationEnabled = false;
       //     return entity.Thietbis.ToList();

       // }
       // [HttpGet]
       // public IEnumerable<LOADDEVICEROOM_Result>GetDeviceRoom(int sophong)
       // {
       //     QLKhachsanEntities entity = new QLKhachsanEntities();
       //     return entity.LOADDEVICEROOM(sophong).ToList();
       // }
       // [HttpPost]
       // public void PostDevice(Thietbi device)
       // {
       //     QLKhachsanEntities entity = new QLKhachsanEntities();
       //     entity.Thietbis.Add(device);
       //     entity.SaveChanges();
       // }
       // [HttpPut]
       // public void PutDevice(long sophong,string tentb,Thietbi device)
       // {
       //     using(QLKhachsanEntities entity = new QLKhachsanEntities())
       //     {
       //         var de = entity.Thietbis.FirstOrDefault(e => e.Sophong.Equals(sophong) && e.TenTB.Equals(tentb));
       //         de.Sophong = device.Sophong;
       //         de.TenTB = device.TenTB;
       //         de.Soluong = device.Soluong;
       //         de.Tinhtrang = device.Tinhtrang;
       //         de.Ghichu = device.Ghichu;
          
       //         entity.SaveChanges();
       //     }
       // }
       // [HttpDelete]
       // public void DeleteDevcie(long sophong,string tentb)
       // {
       //    using(QLKhachsanEntities entity = new QLKhachsanEntities())
       //     {
       //         entity.Thietbis.Remove(entity.Thietbis.FirstOrDefault(e => e.Sophong.Equals(sophong) && e.TenTB.Equals(tentb)));
       //         entity.SaveChanges();
       //     }
       // }
       ///* [HttpDelete]
       // public void DeleteDeviceRoom(int numberroom)
       // {
       //     QLKhachsanEntities entity = new QLKhachsanEntities();
       //     entity.DELETEDEVICEROOM(numberroom);
       // }*/
    }
}
