using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models;

namespace API.Controllers
{
    public class HoaDonVaThongKeController : ApiController
    {
        [HttpPost]
        [Route("api/luuhoadon")]
        public void LuuHD(Hoadon hoadon)
        {
            using (QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                entity.LuuHoaDon(hoadon.Tienphong,hoadon.Tiendichvu,hoadon.VAT,hoadon.Khuyenmai,hoadon.Ngaylap,hoadon.IDDAT);
            }
        }
        [HttpGet]
        [Route("api/thongke")]
        public IEnumerable<THONGKETHANG_Result>Get(string ngay)
        {
            using (QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                return entity.THONGKETHANG(ngay).ToList();
            }
        }
        [HttpGet]
        [Route("api/kiemtrahd")]
        public IEnumerable<Hoadon>Get()
        {
            using (QLKhachsanEntities entity = new QLKhachsanEntities())
            {
                entity.Configuration.ProxyCreationEnabled = false;
                return entity.Hoadons.ToList();
            }
        }
    
    }
}
