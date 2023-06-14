using BanGiayTheThao.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppC5View.Controllers.QuanLi
{
    public class SizeController : Controller
    {
        // GET: SizeController
        [HttpGet]
        public async Task<ActionResult> lisSize()
        {
            try
            {
                string requesURL = $"https://localhost:7021/api/Size/get-all-Size";
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(requesURL);
                string apiData = await response.Content.ReadAsStringAsync();
                var lst = JsonConvert.DeserializeObject<List<Size>>(apiData);

                return View(lst);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        // GET: SizeController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {
            
                var url = $"https://localhost:7021/api/Size/get-by-Size/{id}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            var dataApi = await response.Content.ReadAsStringAsync();
            var lst = JsonConvert.DeserializeObject<Size>(dataApi);
            return View(lst);
        }

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
        public async Task<ActionResult> Create(Size s)
        {
            try
            {
                var url = $"https://localhost:7021/api/Size/create-Size?trangthai={s.TrangThai}&sosize={s.SoSize}";
                var httpClient = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(s), Encoding.UTF8, "application/json");
                var respose = await httpClient.PostAsync(url, content);
                if (respose.IsSuccessStatusCode)
                {
                    return RedirectToAction("lisSize");
                }
                return View();

            }
            catch
            {
                return View();
            }
        }

        // GET: SizeController/Edit/5
        public async Task<IActionResult> Sua(Guid id)
        {
            if (ModelState.IsValid)
            {
                var url = $"https://localhost:7021/api/Size/get-by-Size/{id}";
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);
                var dataApi = await response.Content.ReadAsStringAsync();
                var lst = JsonConvert.DeserializeObject<NSX>(dataApi);
                return View(lst);
            }

            return BadRequest();

        }
        [HttpPost]
        public async Task<IActionResult> Sua(Size s)
        {
            try
            {
                var url = $"https://localhost:7021/api/Size/update-Size{s.IdSize}?trangthai={s.TrangThai}&sosize={s.SoSize}";
                var httpClient = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(s), Encoding.UTF8, "application/json");
                var respose = await httpClient.PostAsync(url, content);
                if (respose.IsSuccessStatusCode)
                {
                    return RedirectToAction("lisSize");
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
            var url = $"https://localhost:7021/api/Size/delete-Size{id}";
            var httpClient = new HttpClient();
            var respose = await httpClient.DeleteAsync(url);
            if (respose.IsSuccessStatusCode)
            {
                return RedirectToAction("lisSize");
            }
            return BadRequest();
        }
    }
}
