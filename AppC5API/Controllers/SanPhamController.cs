using AppData.IRepositories;
using AppData.Repositories;
using BanGiayTheThao.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppC5API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly IAllRepositories<SanPham> irepos;
        GiayDBcontext context =
            new GiayDBcontext();
        public SanPhamController()
        {
            irepos = new AllRepositories<SanPham>(context, context.SanPhams);
        }

        // GET: api/<SanPhamController>
        [HttpGet("get-all-SanPham")]
        public IEnumerable<SanPham> GetAllSanPham()
        {
            return irepos.GetAll();
        }
        [HttpGet("get-byId-SanPham/{id}")]
        public SanPham GetByIdSanPham(Guid id)
        {
            return irepos.GetAll().FirstOrDefault(c=>c.IdSanPham==id);
        }

        // GET api/<SanPhamController>/5
        [HttpPost("create-SanPham")]
        public bool CreateSanPham(string ma, string TenSanPham, double GiaBan, double GiaNhap, double ChieuCaoDeGiay, string MoTa,string anhdaidien, int TrangThai)
        {
            SanPham SanPham = new SanPham();
            SanPham.IdSanPham = Guid.NewGuid();
            SanPham.MaSanPham = ma;
            SanPham.TenSanPham = TenSanPham;
            SanPham.GiaBan = GiaBan;
            SanPham.GiaNhap = GiaNhap;
            SanPham.ChieuCaoDeGiay = ChieuCaoDeGiay;
            SanPham.AnhDaidien = anhdaidien;
            SanPham.MoTa = MoTa;
            SanPham.TrangThai = TrangThai;


            return irepos.CreateItem(SanPham);
        }
        // PUT api/<SanPhamController>/5
        [HttpPost("update-SanPham{id}")]
        public bool UpdateSanPham(Guid id, string ma, string TenSanPham, double GiaBan, double GiaNhap, double ChieuCaoDeGiay, string MoTa, int TrangThai, string anhdaidien)
        {
            SanPham SanPham = new SanPham()
            {
                IdSanPham = id,
                MaSanPham = ma,
                TenSanPham = TenSanPham,
                GiaBan = GiaBan,
                GiaNhap = GiaNhap,
                ChieuCaoDeGiay = ChieuCaoDeGiay,
                AnhDaidien = anhdaidien,
                MoTa = MoTa,
                TrangThai = TrangThai,
            };
            return irepos.UpdateItem(SanPham);
        }

        // DELETE api/<SanPhamController>/5
        [HttpDelete("delete-SanPham/{id}")]
        public bool DeleteSanPham(Guid id)
        {
	        var a = GetAllSanPham().FirstOrDefault(c => c.IdSanPham == id);
            return irepos.DeleteItem(a);
        }
    }
}
