using AppData.IRepositories;
using AppData.Repositories;
using BanGiayTheThao.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppC5API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonChiTietController : ControllerBase
    {
        private readonly IAllRepositories<HoaDonChiTiet> irepos;

        private PhanLoaiSPController PLSanPhams;
        GiayDBcontext context =
            new GiayDBcontext();

        public HoaDonChiTietController()
        {
            irepos = new AllRepositories<HoaDonChiTiet>(context, context.HoaDonChiTiets);
            PLSanPhams = new PhanLoaiSPController();

        }

        [HttpGet("Get-all-HoaDonChiTiet")]
        public IEnumerable<HoaDonChiTiet> GetAllHoaDonCT()
        {
            return irepos.GetAll();
        }

        [HttpGet("Search{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var hanghoa = context.HoaDonChiTiets.SingleOrDefault(a => a.IdHoaDonChiTiet == id);
                if (hanghoa == null)
                {
                    return NotFound();
                }

                return Ok(hanghoa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create-SanPham")]
        public IActionResult CreateCTHoaDon(Guid HoaDon, Guid Idphanloaisp, int soluong)
        {
            try
            {
                //HoaDonChiTiet hd = new HoaDonChiTiet();
                //hd.IdHoaDonChiTiet = Guid.NewGuid();
                //hd.IDhoaDon = HoaDon;
                //hd.IdPhanLoaiSP = Idphanloaisp;
                //hd.SoLuong = soluong;
                //hd.GiaTien = 0;
                //irepos.CreateItem(hd);
                //return Ok();
                var a = PLSanPhams.GetAllPLSP().FirstOrDefault(c=>c.IdPhanLoaiSP==Idphanloaisp);
                if (a.Soluong <1||a.Soluong<soluong)
                {
                  return NotFound();
                }


                var CTGiohangn = GetAllHoaDonCT().FirstOrDefault(c => c.IdPhanLoaiSP == Idphanloaisp);
                if (CTGiohangn == null)
                {
                    var b = new HoaDonChiTiet()
                    {
                        IdPhanLoaiSP = Idphanloaisp,
                        IDhoaDon = HoaDon,
                        SoLuong = soluong,
                        GiaTien = 0
                    };
                    if (irepos.CreateItem(b))
                    {
                        return Ok();
                    }
                }
                else
                {
                    var SP = GetAllHoaDonCT().FirstOrDefault(c => c.IDhoaDon == HoaDon);
                    if (SP == null)
                    {
                        var hoaDonChiTiet = new HoaDonChiTiet()
                        {
                            IdPhanLoaiSP = Idphanloaisp,
                            IDhoaDon = HoaDon,
                            SoLuong = soluong,
                            GiaTien = 0
                        };
                        if (irepos.CreateItem(hoaDonChiTiet))
                        {
                            return Ok();
                        }
                    }
                    else
                    {
                        SP.SoLuong += soluong;
                        if (irepos.UpdateItem(SP))
                        {
                            return Ok();
                        }
                    }
                }
            }
            catch (Exception)
            {

                return NotFound();
            }
            return NotFound();

        }

        [HttpPut("Update{id}")]
        public IActionResult Updadate( Guid id,Guid Hoadon,Guid Idphanloaisp, int soluong, int giatien)
        {
            try
            {
                HoaDonChiTiet hd = new HoaDonChiTiet();
                hd.IdHoaDonChiTiet = id;
                hd.IDhoaDon =Hoadon;

                hd.IdPhanLoaiSP = Idphanloaisp;
                hd.SoLuong = soluong;
                hd.GiaTien = giatien;
                irepos.UpdateItem(hd);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest ( e.Message);
            }
          
        }
        [HttpDelete("Delete{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var check = context.HoaDonChiTiets.FirstOrDefault(c => c.IdHoaDonChiTiet == id);
                if (check != null)
                {
                    HoaDonChiTiet hoaDonChiTiet = new HoaDonChiTiet()
                    {
                        IdHoaDonChiTiet = id
                    };
                    irepos.DeleteItem(hoaDonChiTiet);
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
           
        }
    }
}
