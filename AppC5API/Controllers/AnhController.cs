using AppData.IRepositories;
using AppData.Repositories;
using BanGiayTheThao.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppC5API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnhController : ControllerBase
    {
        private readonly IAllRepositories<Anh> anhRepo;
        GiayDBcontext context = new GiayDBcontext();
        public AnhController()
        {
            anhRepo = new AllRepositories<Anh>(context, context.Anhs);
        }
        // GET: api/<AnhController>
        [HttpGet("get-all-anh")]
        public IEnumerable<Anh> GetAllAnh()
        {
            return anhRepo.GetAll().ToList();
        }

        [HttpGet("get-by-anh")]
        public Anh GetByID(Guid id)
        {
            return GetAllAnh().FirstOrDefault(c=>c.IdAnh==id);
        }

        //// GET api/<AnhController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<AnhController>
        [HttpPost]
        public bool CreateAnh(Guid idSP,string ma, string ten, string DuongDan, int trangThai)
        {
            Anh anh = new Anh();
            anh.IdAnh = Guid.NewGuid();
            anh.IdSanPham = idSP;
            anh.MaAnh = ma;
            anh.TenAnh = ten;
            anh.DuongDanAnh = DuongDan;
            anh.TrangThai = trangThai;
            return anhRepo.CreateItem(anh);
        }

        // PUT api/<AnhController>/5
        [HttpPost("edit-anh{id}")]
        public bool EditAnh(Guid id,Guid idSP, string ma, string ten, string DuongDan, int trangThai)
        {
            Anh anhs = new Anh()
            {
                IdAnh = id,
                //IdSanPham = idSP,
                MaAnh = ma,
                TenAnh = ten,
                DuongDanAnh = DuongDan,
                TrangThai = trangThai
            };
           
            return anhRepo.UpdateItem(anhs);
        }

        // DELETE api/<AnhController>/5
        [HttpDelete("delete-Anh{id}")]
        public bool DeleteAnh(Guid id)
        {
            Anh anhs = new Anh()
            {
                IdAnh = id
               
            };
            return anhRepo.DeleteItem(anhs);
        }
    }
}
