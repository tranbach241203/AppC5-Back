using BanGiayTheThao.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppC5View.Controllers.QuanLi
{
    public class ChatLieuController : Controller
    {
        // GET: QlChatLieuController1
        [HttpGet]
        public async Task<ActionResult> lisChatLieu()
        {
            try
            {
                string requesURL = $"https://localhost:7021/api/ChatLieu/get-all-chatlieu";
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(requesURL);
                string apiData = await response.Content.ReadAsStringAsync();
                var lst = JsonConvert.DeserializeObject<List<ChatLieu>>(apiData);

                return View(lst);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        // GET: QlChatLieuController1/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {

            var url = $"https://localhost:7021/api/ChatLieu/get-by-chatlieu?id={id}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            var dataApi = await response.Content.ReadAsStringAsync();
            var lst = JsonConvert.DeserializeObject<ChatLieu>(dataApi);
            return View(lst);
        }

        // GET: QlChatLieuController1/Create
        public async Task<ActionResult> Create()
        {
            if (ModelState.IsValid)
            {
                return View();
            }

            return BadRequest();
        }

        // POST: QlChatLieuController1/Create
        [HttpPost]
        public async Task<ActionResult> Create(ChatLieu cl)
        {
            try
            {
                var url = $"https://localhost:7021/api/ChatLieu/create-chatlieu?ma={cl.MaChatLieu}&ten={cl.TenChatLieu}";
                var httpClient = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(cl), Encoding.UTF8, "application/json");
                var respose = await httpClient.PostAsync(url, content);
                if (respose.IsSuccessStatusCode)
                {
                    return RedirectToAction("lisChatLieu");
                }
                return View();

            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Sua(Guid id)
        {
            if (ModelState.IsValid)
            {
                var url = $"https://localhost:7021/api/ChatLieu/get-by-chatlieu?id={id}";
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);
                var dataApi = await response.Content.ReadAsStringAsync();
                var lst = JsonConvert.DeserializeObject<ChatLieu>(dataApi);
                return View(lst);
            }

            return BadRequest();

        }
        [HttpPost]
        public async Task<IActionResult> Sua(ChatLieu cl)
        {
            try
            {
                var url = $"https://localhost:7021/api/ChatLieu/update-chatlieu/{cl.IdChatLieu}?ma={cl.MaChatLieu}&ten={cl.TenChatLieu}";
                var httpClient = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(cl), Encoding.UTF8, "application/json");
                var respose = await httpClient.PostAsync(url, content);
                if (respose.IsSuccessStatusCode)
                {
                    return RedirectToAction("lisChatLieu");
                }
                return View();
            }
            catch (Exception e)
            {
                return View();
            }

        }


        public async Task<ActionResult> Delete(Guid id)
        {
            var url = $"https://localhost:7021/api/ChatLieu/delete-chatlieu/{id}";
            var httpClient = new HttpClient();
            var respose = await httpClient.DeleteAsync(url);
            if (respose.IsSuccessStatusCode)
            {
                return RedirectToAction("lisChatLieu");
            }
            return BadRequest();
        }
    }
}
