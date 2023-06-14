using AppData.IRepositories;
using AppData.Repositories;
using BanGiayTheThao.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppC5API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KmSanPhamController : ControllerBase
    {
        private readonly IAllRepositories<KmSanPham> irepos;
        GiayDBcontext context =
            new GiayDBcontext();
        public KmSanPhamController()
        {
            irepos = new AllRepositories<KmSanPham>(context, context.KhSanPhams);
        }

        // GET: api/<KmNguoiDungController>
        [HttpGet("get-all-KmSanPham")]
        public IEnumerable<KmSanPham> GetAllKmSanPham()
        {
            return irepos.GetAll();
        }

        [HttpGet("get-kmsp-by-id")]
        public KmSanPham GetKmSanPhamById(Guid id)
        {
	        return irepos.GetAll().FirstOrDefault(c => c.IDKMSP == id);
        }

        // GET api/<KmNguoiDungController>/5
        [HttpPost("create-KmSanPham")]
        public bool CreateKmSanPham(Guid idSanPham, Guid idKhuyenMai)
        {
            KmSanPham KmSanPham = new KmSanPham();
            KmSanPham.IDKMSP = Guid.NewGuid();
            KmSanPham.idSanPham = idSanPham; 
            KmSanPham.idKhuyenMai = idKhuyenMai;
            
            return irepos.CreateItem(KmSanPham);
        }
        // PUT api/<KmNguoiDungController>/5
        [HttpPost("update-KmSanPham{id}")]
        public bool UpdateKmSanPham(Guid id,Guid idSanPham, Guid idKhuyenMai)
        {
            KmSanPham KmSanPham = new KmSanPham()
            {
                IDKMSP = id,
                idSanPham = idSanPham,
                idKhuyenMai = idKhuyenMai,
            };
            return irepos.UpdateItem(KmSanPham);
        }

        // DELETE api/<KmNguoiDungController>/5
        [HttpDelete("delete-KmSanPham{id}")]
        public bool DeleteKmSanPham(Guid id)
        {
            KmSanPham KmSanPham = new KmSanPham()
            {
                idSanPham = id,
            };
            return irepos.DeleteItem(KmSanPham);
        }
    }
}
