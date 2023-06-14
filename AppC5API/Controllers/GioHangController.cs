using AppC5API.ViewModel;
using AppData.IRepositories;
using AppData.Repositories;
using BanGiayTheThao.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppC5API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangController : ControllerBase
    {
        private readonly IAllRepositories<GioHang> irepos;
        private readonly IAllRepositories<GioHangChiTiet> _giohangchitiet;
        private readonly IAllRepositories<PhanLoaiSP> _phanloaSp;
        private readonly IAllRepositories<Size> _size;
        private readonly IAllRepositories<NSX> _nsx;
        private readonly IAllRepositories<Mau> _mau;
        private readonly IAllRepositories<ChatLieu> _chatlaiu;
        private readonly IAllRepositories<SanPham> _sanpham;
        private readonly IAllRepositories<Anh> _anh;

        GiayDBcontext context =
            new GiayDBcontext();

        public GioHangController()
        {
            irepos = new AllRepositories<GioHang>(context, context.GioHangs);
            _sanpham = new AllRepositories<SanPham>(context, context.SanPhams);
            _giohangchitiet = new AllRepositories<GioHangChiTiet>(context, context.GioHangChiTiets);
            _phanloaSp = new AllRepositories<PhanLoaiSP>(context, context.PhanLoaiSps);

        }

        // GET: api/<GioHangController>
        [HttpGet("get-all-GioHang")]
        public IEnumerable<GioHang> GetAllGioHang()
        {
            return irepos.GetAll();
        }
        [HttpGet("get-all-phanloi")]
        public List<XemGiohangView> GetAllphanloai()
        {
            List<XemGiohangView> lstSanPhamViews = new List<XemGiohangView>();
            lstSanPhamViews = (from a in _giohangchitiet.GetAll()
                               join b in _phanloaSp.GetAll() on a.IdPhanLoaiSP equals b.IdPhanLoaiSP
                               join c in _nsx.GetAll() on b.IDNSX equals c.IdNSX
                               join d in _mau.GetAll() on b.IDmau equals d.IdMau
                               join e in _size.GetAll() on b.IdSize equals e.IdSize
                               join f in _chatlaiu.GetAll() on b.IDChatLieu equals f.IdChatLieu
                               join g in _sanpham.GetAll() on b.IdSanPham equals g.IdSanPham
                               select new XemGiohangView()
                               {
                                   GioHangChiTiet = a,
                                    PhanLoaiSp= b,
                                   Nsx = c,
                                   mau = d,
                                   Size = e,
                                   ChatLieu = f,
                                   SanPham = g
                               }).ToList();
            return lstSanPhamViews;
        }

        // GET api/<GioHangController>/5
        [HttpPost("create-GioHang")]
        public bool CreateGioHang(Guid idNguoiIDung, string mota)
        {
            GioHang GioHang = new GioHang();
            GioHang.IdGioHang = Guid.NewGuid();
            GioHang.IdNguoiDung = idNguoiIDung;
            GioHang.MoTa = mota;
            return irepos.CreateItem(GioHang);
        }

        // PUT api/<GioHangController>/5
        [HttpPost("update-GioHang{id}")]
        public bool UpdateGioHang(Guid id, Guid idNguoiDung, string mota)
        {
            GioHang GioHang = new GioHang()
            {
                IdGioHang = id,
                IdNguoiDung = idNguoiDung,
                MoTa = mota,
            };
            return irepos.UpdateItem(GioHang);
        }

        // DELETE api/<GioHangController>/5
        [HttpDelete("delete-GioHang{id}")]
        public bool DeleteGioHang(Guid id)
        {
            GioHang GioHang = new GioHang()
            {
                IdGioHang = id,
            };
            return irepos.DeleteItem(GioHang);
        }

    }
}