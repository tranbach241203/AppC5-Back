using AppData.IRepositories;
using AppData.Repositories;
using BanGiayTheThao.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppC5API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatLieuController : ControllerBase
    {
        private readonly IAllRepositories<ChatLieu> irepos;
        GiayDBcontext context =
            new GiayDBcontext();
        public ChatLieuController()
        {
            irepos = new AllRepositories<ChatLieu>(context, context.ChatLieus);
        }

        // GET: api/<DongSPController>
        [HttpGet("get-all-chatlieu")]
        public IEnumerable<ChatLieu> GetAllChatLieu()
        {
	        return irepos.GetAll();
        }
        [HttpGet("get-by-chatlieu")]
        public ChatLieu GetAllChatLieubyID(Guid id)
        {
            return irepos.GetAll().FirstOrDefault(c=>c.IdChatLieu==id);
        }


        [HttpPost("create-chatlieu")]
        public IActionResult CreateChatLieu(string ma, string ten)
        {
            var matrung = GetAllChatLieu().FirstOrDefault(c => c.MaChatLieu == ma);
            var tens = GetAllChatLieu().FirstOrDefault(c => c.TenChatLieu == ten);
            if (matrung == null || tens == null)
            {
                ChatLieu chatLieu = new ChatLieu();
                chatLieu.IdChatLieu = Guid.NewGuid();
                chatLieu.MaChatLieu = ma; chatLieu.TenChatLieu = ten;
                irepos.CreateItem(chatLieu);
                return Ok();
            }
            return NotFound();
        }
        // PUT api/<PaymentMenthodController>/5
        [HttpPost("update-chatlieu/{id}")]
        public bool UpdateChatLieu(Guid id, string ma, string ten)
        {
            ChatLieu chatLieu = new ChatLieu()
            {
                IdChatLieu = id,
                MaChatLieu = ma,
                TenChatLieu = ten
            };
            return irepos.UpdateItem(chatLieu);
        }

        // DELETE api/<PaymentMenthodController>/5
        [HttpDelete("delete-chatlieu/{id}")]
        public bool DeleteChatLieu(Guid id)
        {
            var a = GetAllChatLieubyID(id);
            return irepos.DeleteItem(a);
        }
    }
}
