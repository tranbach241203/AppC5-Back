using AppData.IRepositories;
using AppData.Repositories;
using BanGiayTheThao.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppC5API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhanLoaiSPController : ControllerBase
    {
        // GET: api/<PhanLoaiSPController>
        private readonly IAllRepositories<PhanLoaiSP> iRepos;
        public GioHangController GioHang;
        public GioHangChiTietController GioHangChiTiet;
        public SizeController Size;
        GiayDBcontext context = new GiayDBcontext();
        private readonly IAllRepositories<GioHangChiTiet> irepos2;
		public PhanLoaiSPController()
        {
	        GioHangChiTiet = new GioHangChiTietController();
            iRepos = new AllRepositories<PhanLoaiSP>(context, 
context.PhanLoaiSps);
            irepos2 = new AllRepositories<GioHangChiTiet>(context,
	            context.GioHangChiTiets);
            GioHang=new GioHangController();
            Size=new SizeController();
        }
        // GET: api/<AnhController>
        [HttpGet("get-all-SP")]
        public IEnumerable<PhanLoaiSP> GetAllPLSP()
        {
            return iRepos.GetAll();
        }
        [HttpGet("get-by-id{id}")]
        public PhanLoaiSP GetAllPLSP(Guid id)
        {
            return GetAllPLSP().FirstOrDefault(c=>c.IdSanPham==id);
        }

        //// GET api/<AnhController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<AnhController>
        [HttpPost("crate-sp")]
        public bool CreatePLSP(/*Guid idSP*/int soLuong, int trangThai, Guid idsanpham, Guid idsize, Guid idchatlieu, Guid idmau, Guid idnsx)
        {
    
            PhanLoaiSP plSP = new PhanLoaiSP();
            plSP.IdPhanLoaiSP = Guid.NewGuid();
            plSP.IdSize = idsize;
            plSP.IdSanPham = idsanpham;
            plSP.IDChatLieu = idchatlieu;
            plSP.IDmau = idmau;
            plSP.IDNSX = idnsx;
            plSP.Soluong = soLuong;
            plSP.TrangThai = trangThai;
            return iRepos.CreateItem(plSP);
        }

        // PUT api/<AnhController>/5
        [HttpPut("edit-sp{id}")]
        public bool EditPLSP(Guid idplsp, int soLuong, int trangThai, Guid idsanpham, Guid idsize, Guid idchatlieu, Guid idmau, Guid idnsx)
        {
            PhanLoaiSP plsp = new PhanLoaiSP()
            {
                //"idPhanLoaiSP": "bc7d51d1-54f9-4ef6-bec6-be906561f405",
                //"idSize": "27fcf828-9cc4-4a6a-9663-190a0a4699ef",
                //"idSanPham": "80b3a552-a231-47cd-b8c1-2e862a0c8bda",
                //"idChatLieu": "8addf8f5-dd53-4fb8-bdcf-34a7c6f99778",
                //"iDmau": "f4721a9a-f04b-4252-9d52-1dd9be729552",
                //"idnsx": "f8afd585-c929-4280-9065-153f29280d79",
                IdPhanLoaiSP = idplsp,
                IdSize = idsize,
                IdSanPham = idsanpham,
                IDChatLieu = idchatlieu,
                IDmau = idmau,
                IDNSX = idnsx,
                Soluong = soLuong,
                TrangThai = trangThai,

            };

            return iRepos.UpdateItem(plsp);
        }

        // DELETE api/<AnhController>/5
        [HttpDelete("delete-sp{id}")]
        public bool DeletePLSP(Guid idplsp)
        {
            PhanLoaiSP plsps = new PhanLoaiSP()
            {
                IdPhanLoaiSP = idplsp

            };
            return iRepos.DeleteItem(plsps);
        }
		[HttpGet("get-all-SPMax")]
		public IEnumerable<PhanLoaiSP> GetAllHienCo(Guid idSp)
		{
			return iRepos.GetAll().Where(c => c.IdSanPham == idSp);
		}

		[HttpPost("Add-GioHang")]
		public bool ADDGioHang(Guid idsp, int SoSize, int soluong)
        {
            var gioHang = GioHang.GetAllGioHang();
            if (gioHang.Count() == 0)
            {
                var a = new GioHang()
                {
                    IdNguoiDung = Guid.Parse("3012ac7b-c1de-4381-9813-ef76609f9f3c"),
                    MoTa = "",
                };
                GioHang.CreateGioHang(a.IdNguoiDung, a.MoTa);
            }

            var amoi = Size.GetbyidSizeSo(SoSize);
            var pl = iRepos.GetAll().Where(c => c.IdSanPham == idsp).FirstOrDefault(c => c.IdSize == amoi.IdSize);
			var CTGiohangn = GioHangChiTiet.GetAllGioHangChiTiet().FirstOrDefault(c => c.IdPhanLoaiSP == pl.IdPhanLoaiSP);
            if (CTGiohangn == null)
            {
	            var b = new GioHangChiTiet()
	            {
		            IdPhanLoaiSP = pl.IdPhanLoaiSP,
		            IdGioHang = Guid.Parse("ce5aa05a-97d1-4dca-889c-80f537152ffc"),
		            SoLuong = soluong,
		            TrangThai= 0,
	            };
	            return GioHangChiTiet.CreateGioHangChiTiet(b.IdGioHang, b.IdPhanLoaiSP, b.SoLuong, b.TrangThai);
            }
            else
            {
				var amoi2 = Size.GetbyidSizeSo(SoSize);
				var pl2 = iRepos.GetAll().Where(c => c.IdSanPham == idsp).FirstOrDefault(c => c.IdSize == amoi2.IdSize);
				var CTGiohangn2 = GioHangChiTiet.GetAllGioHangChiTiet().FirstOrDefault(c => c.IdPhanLoaiSP == pl2.IdPhanLoaiSP);
				if (CTGiohangn2 == null)
	            {
		            var b = new GioHangChiTiet()
		            {
			            IdPhanLoaiSP = pl2.IdPhanLoaiSP,
			            IdGioHang = Guid.Parse("ce5aa05a-97d1-4dca-889c-80f537152ffc"),
			            SoLuong = soluong,
			            TrangThai = 0,
		            };
		            return GioHangChiTiet.CreateGioHangChiTiet(b.IdGioHang, b.IdPhanLoaiSP, b.SoLuong, b.TrangThai);
	            }
	            else
	            {
		           
					CTGiohangn2.SoLuong += soluong;
		            if ( irepos2.UpdateItem(CTGiohangn2))
		            {
			            return true;
		            }
	            }
            }

            return false;
        }

    }
}


