using AppData.IRepositories;
using AppData.Repositories;
using BanGiayTheThao.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppC5API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangChiTietController : ControllerBase
    {
        private readonly IAllRepositories<GioHangChiTiet> irepos;
        GiayDBcontext context =
            new GiayDBcontext();
        public GioHangChiTietController()
        {
            irepos = new AllRepositories<GioHangChiTiet>(context, context.GioHangChiTiets);
        }

        // GET: api/<GioHangChiTietController>
        [HttpGet("get-all-ghCT")]
        public IEnumerable<GioHangChiTiet> GetAllGioHangChiTiet()
        {
            return irepos.GetAll();
        }

        // GET api/<GioHangChiTietController>/5
        [HttpPost("create-GioHangChiTiet")]
        public bool CreateGioHangChiTiet(Guid idGioHang, Guid idphanloaisp, int soluong, int trangthai)
        {
        //   public Guid IdGioHangCT { get; set; }
        //public Guid? IdGioHang { get; set; }
        //public Guid? IdPhanLoaiSP { get; set; }
        //public int? SoLuong { get; set; }
        //public int? TrangThai { get; set; }

        GioHangChiTiet GioHangChiTiet = new GioHangChiTiet();
            GioHangChiTiet.IdGioHangCT = Guid.NewGuid();
            GioHangChiTiet.IdGioHang = idGioHang;
            GioHangChiTiet.IdPhanLoaiSP = idphanloaisp;
            GioHangChiTiet.SoLuong = soluong;
            GioHangChiTiet.TrangThai = trangthai;
            return irepos.CreateItem(GioHangChiTiet);
        }
        // PUT api/<GioHangChiTietController>/5
        [HttpPost("update-GioHangChiTiet{id}")]
        public bool UpdateGioHangChiTiet(Guid id, Guid idGioHang, Guid idphanloaisp, int soluong, int trangthai)
        {
            GioHangChiTiet GioHangChiTiet = new GioHangChiTiet()
            {
                IdGioHangCT = id,
                IdGioHang = idGioHang,
                IdPhanLoaiSP = idphanloaisp,
                SoLuong = soluong,
                TrangThai = trangthai
            };
            return irepos.UpdateItem(GioHangChiTiet);
        }

        // DELETE api/<GioHangChiTietController>/5
        [HttpDelete("delete-GioHangChiTiet{id}")]
        public bool DeleteGioHangChiTiet(Guid id)
        {
            GioHangChiTiet GioHangChiTiet = new GioHangChiTiet()
            {
                IdGioHangCT = id,
            };
            return irepos.DeleteItem(GioHangChiTiet);
        }

		internal bool CreateGioHangChiTiet(Guid? idGioHang, Guid? idPhanLoaiSP, int? soLuong, int? trangThai)
		{
			GioHangChiTiet GioHangChiTiet = new GioHangChiTiet();
			GioHangChiTiet.IdGioHangCT = Guid.NewGuid();
			GioHangChiTiet.IdGioHang = idGioHang;
			GioHangChiTiet.IdPhanLoaiSP = idPhanLoaiSP;
			GioHangChiTiet.SoLuong = soLuong;
			GioHangChiTiet.TrangThai = trangThai;
			return irepos.CreateItem(GioHangChiTiet);
		}

		internal bool UpdateGioHangChiTiet(Guid idGioHangCT, Guid? idGioHang, Guid? idPhanLoaiSP, int? soLuong, int? trangThai)
		{
			GioHangChiTiet GioHangChiTiet = new GioHangChiTiet()
			{
				IdGioHangCT = idGioHangCT,
				IdGioHang = idGioHang,
				IdPhanLoaiSP = idPhanLoaiSP,
				SoLuong = soLuong,
				TrangThai = trangThai
			};
			return irepos.UpdateItem(GioHangChiTiet);
		}
	}
}

