using AppData.IRepositories;
using AppData.Repositories;
using BanGiayTheThao.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppC5API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private readonly IAllRepositories<HoaDon> irepos;
        GiayDBcontext context =
            new GiayDBcontext();
        public HoaDonController()
        {
            irepos = new AllRepositories<HoaDon>(context, context.HoaDons);
        }
        [HttpGet("Get-all-HoaDon")]
        public IEnumerable<HoaDon> Getall()
        {
            try
            {
                return irepos.GetAll();
                
            }
            catch (Exception)
            {

                return null;
            }

        }
        [HttpGet("Search{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var hanghoa = context.HoaDons.SingleOrDefault(a => a.IdHoaDon == id);
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
        [HttpPost("Create-HoaDon")]
        public IActionResult Create(Guid IdGiamGia, DateTime NgayTao, Guid IdNguoiDung,string Diachi,DateTime NgayDat,DateTime NgayGiao,double TongTien)
        {
            try
            {
                HoaDon hd = new HoaDon();
                hd.IdHoaDon = Guid.NewGuid();
                hd.IDGiamGia = IdGiamGia;
                hd.NgayTao = NgayTao;
                hd.IDNguoiDung = IdNguoiDung;
                hd.DiaChi = Diachi;
                hd.NgayDat = NgayDat;
                hd.NgayGiao = NgayGiao;
                hd.TongTien = TongTien;
                irepos.CreateItem(hd);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }



        }
        [HttpPut("Update{id}")]
        public IActionResult Updadate(Guid id,Guid IdGiamGia, DateTime NgayTao, Guid IdNguoiDung, string Diachi, DateTime NgayDat, DateTime NgayGiao, double TongTien)
        {
            try
            {
                HoaDon hd = new HoaDon();
                hd.IdHoaDon = id;
                hd.IDGiamGia = IdGiamGia;
                hd.NgayTao = NgayTao;
                hd.IDNguoiDung = IdNguoiDung;
                hd.DiaChi = Diachi;
                hd.NgayDat = NgayDat;
                hd.NgayGiao = NgayGiao;
                hd.TongTien = TongTien;
                irepos.UpdateItem(hd);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
        [HttpDelete("Delete{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var check = context.HoaDons.FirstOrDefault(c => c.IdHoaDon == id);
                if (check != null)
                {
                    HoaDon hd= new HoaDon()
                    {
                        IdHoaDon = id
                    };
                    irepos.DeleteItem(hd);
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

