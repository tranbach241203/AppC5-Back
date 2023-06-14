using AppData.IRepositories;
using AppData.Repositories;
using BanGiayTheThao.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppC5API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiDungController : ControllerBase
    {
       private readonly IAllRepositories<NguoiDung> irepos;
        GiayDBcontext context =
            new GiayDBcontext();
        public NguoiDungController()
        {
            irepos = new AllRepositories<NguoiDung>(context, context.NguoiDungs);
        }

        // GET: api/<NguoiDungController>
        [HttpGet("get-all-NguoiDung")]
        public IEnumerable<NguoiDung> GetAllNguoiDung()
        {
            return irepos.GetAll();
        }

        // GET api/<NguoiDungController>/5
        [HttpPost("create-NguoiDung")]
        public bool CreateNguoiDung(string Ho, string Ten, string TenDangNhap, string MatKhau,int GioiTinh,string Email, string SDT,string DiaChi,int TrangThai)
        {
            NguoiDung NguoiDung = new NguoiDung();
            NguoiDung.IdNguoiDung = Guid.NewGuid();
            NguoiDung.Ho = Ho ;
            NguoiDung.Ten = Ten;
            NguoiDung.TenDangNhap = TenDangNhap;
            NguoiDung.MatKhau = MatKhau;
            NguoiDung.IdChucVu = Guid.Parse("9245fe4a-d402-451c-b9ed-9c1a05247482");
            NguoiDung.GioiTinh = GioiTinh;
            NguoiDung.Email = Email;
            NguoiDung.SDT = SDT;
            NguoiDung.DiaChi = DiaChi;
            NguoiDung.TrangThai = TrangThai;
            return irepos.CreateItem(NguoiDung);
        }
        // PUT api/<NguoiDungController>/5
        [HttpPost("update-NguoiDung{id}")]
        public bool UpdateNguoiDung(Guid id, string Ho, string Ten, string TenDangNhap, string MatKhau,int GioiTinh,string Email, string SDT,string DiaChi,int TrangThai)
        {
            NguoiDung NguoiDung = new NguoiDung()
            {
                IdNguoiDung = id,
                Ho = Ho,
                Ten = Ten,
                TenDangNhap = TenDangNhap,
                MatKhau = MatKhau,
                IdChucVu = Guid.Parse("9245fe4a-d402-451c-b9ed-9c1a05247482"),
			GioiTinh = GioiTinh,
                Email = Email,
                SDT = Email,
                DiaChi = DiaChi,
                TrangThai = TrangThai,
            };
            return irepos.UpdateItem(NguoiDung);
        }

        // DELETE api/<NguoiDungController>/5
        [HttpDelete("delete-NguoiDung{id}")]
        public bool DeleteNguoiDung(Guid id)
        {
            NguoiDung NguoiDung = new NguoiDung()
            {
                IdNguoiDung = id,
            };
            return irepos.DeleteItem(NguoiDung);
        }
    }
}
