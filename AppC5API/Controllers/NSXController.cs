using AppData.IRepositories;
using AppData.Repositories;
using BanGiayTheThao.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppC5API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NSXController : ControllerBase
    {
        private readonly IAllRepositories<NSX> irepos;
        GiayDBcontext context =
            new GiayDBcontext();
        public NSXController()
        {
            irepos = new AllRepositories<NSX>(context, context.NSXs);
        }

        // GET: api/<NSXController>
        [HttpGet("get-all-nsx")]
        public IEnumerable<NSX> GetAllNSX()
        {
            return irepos.GetAll();
        }
        [HttpGet("get-by-Id/{id}")]
        public NSX GetByNSX(Guid id)
        {
            return irepos.GetAll().FirstOrDefault(c=>c.IdNSX == id);
        }

        // GET api/<NSXController>/5
        [HttpPost("create-nsx")]
        public bool CreateNSX(string ma, string ten,int trangthai)
        {
            NSX nsx = new NSX();
            nsx.IdNSX = Guid.NewGuid();
            nsx.MaNSX = ma; nsx.TenNSX = ten;
            nsx.TrangThai = trangthai;
            return irepos.CreateItem(nsx);
        }
        // PUT api/<NSXController>/5
        [HttpPost("update-nsx{id}")]
        public bool UpdateNSX(Guid id, string ma, string ten,int trangthai)
        {
            NSX nsx = new NSX()
            {
                IdNSX = id,
                MaNSX = ma,
                TenNSX = ten,
                TrangThai = trangthai
            };
            return irepos.UpdateItem(nsx);
        }

        // DELETE api/<NSXController>/5
        [HttpDelete("delete-nsx{id}")]
        public bool DeleteNSX(Guid id)
        {
            NSX nsx = new NSX()
            {
                IdNSX = id,
            };
            return irepos.DeleteItem(nsx);
        }
    }
}
