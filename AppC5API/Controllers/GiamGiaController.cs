using AppData.IRepositories;
using AppData.Repositories;
using BanGiayTheThao.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppC5API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiamGiaController : ControllerBase
    {
        private readonly IAllRepositories<GiamGia> irepos;
        GiayDBcontext context =
            new GiayDBcontext();
        public GiamGiaController()
        {
            irepos = new AllRepositories<GiamGia>(context, context.GiamGias);
        }

        // GET: api/<GiamGiaController>
        [HttpGet("get-all-GiamGia")]
        public IEnumerable<GiamGia> GetAllGiamGia()
        {
            return irepos.GetAll();
        }
        [HttpGet("get-by-Id/{id}")]
        public GiamGia GetByGiamGia(Guid id)
        {
            return irepos.GetAll().FirstOrDefault(c => c.IdGiamGia == id);
        }

        // GET api/<GiamGiaController>/5
        [HttpPost("create-GiamGia")]
        public bool CreateGiamGia(string magiamgia, string tengiamgia, double sotiendagiam)
        {
            GiamGia GiamGia = new GiamGia();
            GiamGia.IdGiamGia = Guid.NewGuid();
            GiamGia.MaGiamGia = magiamgia; 
            GiamGia.TenGiamGia = tengiamgia;
            GiamGia.SoTienDaGiam = sotiendagiam;
            return irepos.CreateItem(GiamGia);
        }
        // PUT api/<GiamGiaController>/5
        [HttpPost("update-GiamGia{id}")]
        public bool UpdateGiamGia(Guid id, string magiamgia, string tengiamgia, double sotiendagiam)
        {
            GiamGia GiamGia = new GiamGia()
            {
                IdGiamGia = id,
                MaGiamGia = magiamgia,
            TenGiamGia = tengiamgia,
            SoTienDaGiam = sotiendagiam,
        };
            return irepos.UpdateItem(GiamGia);
        }

        // DELETE api/<GiamGiaController>/5
        [HttpDelete("delete-GiamGia/{id}")]
        public bool DeleteGiamGia(Guid id)
        {
         var a = GetByGiamGia(id);
            return irepos.DeleteItem(a);
        }
    }
}
