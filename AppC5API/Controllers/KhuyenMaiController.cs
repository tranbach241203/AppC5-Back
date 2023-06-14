using AppData.IRepositories;
using AppData.Repositories;
using BanGiayTheThao.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppC5API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhuyenMaiController : ControllerBase
    {
        private readonly IAllRepositories<KhuyenMai> irepos;
        GiayDBcontext context =
            new GiayDBcontext();
        public KhuyenMaiController()
        {
            irepos = new AllRepositories<KhuyenMai>(context, context.KhuyenMais);
        }

        // GET: api/<KhuyenMaiController>
        [HttpGet("get-all-KhuyenMai")]
        public IEnumerable<KhuyenMai> GetAllKhuyenMai()
        {
            return irepos.GetAll();
        }

        [HttpGet("get-by-id")]
        public KhuyenMai GetKhuyenMaiById(Guid id)
        {
	        return irepos.GetAll().FirstOrDefault(c => c.IdKhuyenMai == id);
        }
        // GET api/<KhuyenMaiController>/5
        [HttpPost("create-KhuyenMai")]
        public bool CreateKhuyenMai(KhuyenMai k)
        {
            return irepos.CreateItem(k);
        }
        // PUT api/<KhuyenMaiController>/5
        [HttpPost("update-KhuyenMai")]
        public bool UpdateMau(Guid id,string ma,DateTime NgayBatdau, DateTime NgayKetThuc,int SoTienGiam)
        {
            KhuyenMai KhuyenMai = new KhuyenMai()
            {
                IdKhuyenMai = id,
                MaKhuyenMai = ma,
                NgayBatDau = NgayBatdau,
                NgayKetThuc = NgayKetThuc,
                SoTienGiam = SoTienGiam
            };
            return irepos.UpdateItem(KhuyenMai);
        }

        // DELETE api/<KhuyenMaiController>/5
        [HttpDelete("delete-KhuyenMai")]
        public bool DeleteMau(Guid id)
        {
            KhuyenMai KhuyenMai = new KhuyenMai()
            {
                IdKhuyenMai = id,
            };
            return irepos.DeleteItem(KhuyenMai);
        }
    }
}
