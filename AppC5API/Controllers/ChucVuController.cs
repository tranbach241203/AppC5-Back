using AppC5API.ViewModels;
using AppData.IRepositories;
using AppData.Repositories;
using BanGiayTheThao.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppC5API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucVuController : ControllerBase
    {
        private readonly IAllRepositories<ChucVu> irepos;
        GiayDBcontext context =
            new GiayDBcontext();
        public ChucVuController()
        {
            irepos = new AllRepositories<ChucVu>(context, context.ChucVus);
        }

        // GET: api/<ChucVuController>
        [HttpGet("get-all-ChucVu")]
        public IEnumerable<ChucVu> GetAllChucVu()
        {
            return irepos.GetAll();
        }
        [HttpGet("get-by-Id/{id}")]
        public ChucVu GetByChucVu(Guid id)
        {
            return irepos.GetAll().FirstOrDefault(c => c.IdChucVu == id);
        }

        // GET api/<ChucVuController>/5
        [HttpPost("create-ChucVu")]
        public bool CreateChucVu( string ten, int trangthai)
        {
            ChucVu ChucVu = new ChucVu();
            ChucVu.IdChucVu = Guid.Parse("9245fe4a-d402-451c-b9ed-9c1a05247482");
            ChucVu.TenCV = ten;
            ChucVu.TrangThai = trangthai;
            return irepos.CreateItem(ChucVu);
        }
        // PUT api/<ChucVuController>/5
        [HttpPost("update-ChucVu{id}")]
        public bool UpdateChucVu(Guid id,  string tencv, int trangthai)
        {
            ChucVu ChucVu = new ChucVu()
            {
                IdChucVu = id,
                TenCV = tencv,
                TrangThai = trangthai
            };
            return irepos.UpdateItem(ChucVu);
        }

        // DELETE api/<ChucVuController>/5
        [HttpDelete("delete-ChucVu{id}")]
        public bool DeleteChucVu(Guid id)
        {
            ChucVu ChucVu = new ChucVu()
            {
                IdChucVu = id,
            };
            return irepos.DeleteItem(ChucVu);
        }
    
    }
}
