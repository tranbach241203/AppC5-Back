using AppData.IRepositories;
using AppData.Repositories;
using BanGiayTheThao.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppC5API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MauController : ControllerBase
    {
        private readonly IAllRepositories<Mau> irepos;
        GiayDBcontext context =
            new GiayDBcontext();
        public MauController()
        {
            irepos = new AllRepositories<Mau>(context, context.Maus);
        }

        // GET: api/<MauController>
        [HttpGet("get-all-Mau")]
        public IEnumerable<Mau> GetAllMau()
        {
            return irepos.GetAll();
        }
        [HttpGet("get-by-Id/{id}")]
        public Mau GetByMau(Guid id)
        {
            return irepos.GetAll().FirstOrDefault(c => c.IdMau == id);
        }

        // GET api/<MauController>/5
        [HttpPost("create-Mau")]
        public bool CreateMau(string mamau, string tenmau)
        {
            Mau Mau = new Mau();
            Mau.IdMau = Guid.NewGuid();
            Mau.MaMau = mamau; 
            Mau.TenMau = tenmau;
            return irepos.CreateItem(Mau);
        }
        // PUT api/<MauController>/5
        [HttpPost("update-Mau{id}")]
        public bool UpdateMau(Guid id, string mamau, string tenmau)
        {
            Mau Mau = new Mau()
            {
                IdMau = id,
                MaMau = mamau,
                TenMau = tenmau,

            };
            return irepos.UpdateItem(Mau);
        }

        // DELETE api/<MauController>/5
        [HttpDelete("delete-Mau/{id}")]
        public bool DeleteMau(Guid id)
        {
            Mau Mau = new Mau()
            {
                IdMau = id,
            };
            return irepos.DeleteItem(Mau);
        }
    }
}

