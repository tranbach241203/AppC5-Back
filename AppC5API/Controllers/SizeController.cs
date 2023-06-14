using AppData.IRepositories;
using AppData.Repositories;
using BanGiayTheThao.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppC5API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private readonly IAllRepositories<Size> irepos;
        GiayDBcontext context =
            new GiayDBcontext();
        public SizeController()
        {
            irepos = new AllRepositories<Size>(context, context.Sizess);
        }

        // GET: api/<SizeController>
        [HttpGet("get-all-Size")]
        public IEnumerable<Size> GetAllSize()
        {
            return irepos.GetAll();
        }
        [HttpGet("get-by-Size/{id}")]
        public Size GetbyidSize(Guid id)
        {
            return GetAllSize().FirstOrDefault(c=>c.IdSize==id);
        }
        [HttpGet("get-by-SoSize/")]
        public Size GetbyidSizeSo(int Sosize)
        {
	        return GetAllSize().FirstOrDefault(c => c.SoSize == Sosize);
        }



		// GET api/<SizeController>/5
		[HttpPost("create-Size")]
        public bool CreateSize(int trangthai,  int sosize)
        {
        //          public Guid IdSize { get; set; }
        //public int? SoSize { get; set; }
        //public int? TrangThai { get; set; }

        Size size = new Size();
            size.IdSize = Guid.NewGuid();
            size.SoSize = sosize; 
            size.TrangThai = trangthai;
            return irepos.CreateItem(size);
        }
        // PUT api/<SizeController>/5
        [HttpPost("update-Size{id}")]
        public bool UpdateSize(Guid id, int trangthai, int sosize)
        {
            Size size = new Size()
            {
                IdSize = id,
                SoSize = sosize,
                TrangThai = trangthai
            };
            return irepos.UpdateItem(size);
        }

        // DELETE api/<SizeController>/5
        [HttpDelete("delete-Size{id}")]
        public bool DeleteSize(Guid id)
        {
            Size Size = new Size()
            {
                IdSize = id,
            };
            return irepos.DeleteItem(Size);
        }
    }
}
