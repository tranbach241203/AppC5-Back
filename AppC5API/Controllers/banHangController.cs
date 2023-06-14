using AppData.IRepositories;
using AppData.Repositories;
using BanGiayTheThao.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppC5API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class banHangController : ControllerBase
    {
        public readonly IAllRepositories<SanPham> _sanPham;
        public readonly IAllRepositories<HoaDon> _hoaDon;
        public readonly IAllRepositories<HoaDonChiTiet> _hoaDonChiTiet;
        public readonly IAllRepositories<GioHang> _gioHang;
        public readonly IAllRepositories<GioHangChiTiet> _giohangChiTiet;
        public readonly IAllRepositories<PhanLoaiSP> _phanLoaiSP;
        GiayDBcontext context = new GiayDBcontext();
        public banHangController()
        {
            _sanPham = new AllRepositories<SanPham>(context, context.SanPhams);
            _hoaDon= new AllRepositories<HoaDon>(context, context.HoaDons);
            _hoaDonChiTiet = new AllRepositories<HoaDonChiTiet>(context, context.HoaDonChiTiets);
            _gioHang = new AllRepositories<GioHang>(context, context.GioHangs);
            _giohangChiTiet = new AllRepositories<GioHangChiTiet>(context, context.GioHangChiTiets);
            _phanLoaiSP=new AllRepositories<PhanLoaiSP>(context, context.PhanLoaiSps);
        }
        // GET: api/<banHangController>
        [HttpGet]
        public IEnumerable<SanPham> GetAllSanPham()
        {
            return _sanPham.GetAll().ToList();
        }

        // GET api/<banHangController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<banHangController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<banHangController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<banHangController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
