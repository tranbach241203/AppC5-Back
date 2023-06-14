using BanGiayTheThao.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppC5View.Controllers.QuanLi
{
    public class MauController : Controller
    {
        // GET: GiamGiaController
        [HttpGet]

        public async Task<ActionResult> listMau()
        {
            try
            {

                string requesURL = $"https://localhost:7021/api/Mau/get-all-Mau";
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(requesURL);
                string apiData = await response.Content.ReadAsStringAsync();
                var lst = JsonConvert.DeserializeObject<List<Mau>>(apiData);

                return View(lst);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {

            var url = $"https://localhost:7021/api/Mau/get-by-Id/{id}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            var dataApi = await response.Content.ReadAsStringAsync();
            var lst = JsonConvert.DeserializeObject<Mau>(dataApi);
            return View(lst);
        }

        // GET: GiamGiaController1/Create
        public async Task<ActionResult> Create()
        {
            if (ModelState.IsValid)
            {
                return View();
            }

            return BadRequest();
        }

        // POST: QlGiamGiacontroller1/Create
        [HttpPost]
        public async Task<ActionResult> Create(Mau mau)
        {
            try
            {
                var url = $"https://localhost:7021/api/Mau/create-Mau?mamau={mau.MaMau}&tenmau={mau.TenMau}";
                var httpClient = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(mau), Encoding.UTF8, "application/json");
                var respose = await httpClient.PostAsync(url, content);
                if (respose.IsSuccessStatusCode)
                {
                    return RedirectToAction("listMau");
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
                var url = $"https://localhost:7021/api/Mau/get-by-Id/{id}";
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);
                var dataApi = await response.Content.ReadAsStringAsync();
                var lst = JsonConvert.DeserializeObject<Mau>(dataApi);
                return View(lst);
            }

            return BadRequest();

        }
        // POST: GiamGiaController/Edit/5
        [HttpPost]
        public async Task<IActionResult> Sua(Mau mau)
        {
            try
            {
                var url = $"https://localhost:7021/api/Mau/update-Mau{mau.IdMau}?mamau={mau.MaMau}&tenmau={mau.TenMau}";
                var httpClient = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(mau), Encoding.UTF8, "application/json");
                var respose = await httpClient.PostAsync(url, content);
                if (respose.IsSuccessStatusCode)
                {
                    return RedirectToAction("listMau");
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
            var url = $"https://localhost:7021/api/Mau/delete-Mau/{id}";
            var httpClient = new HttpClient();
            var respose = await httpClient.DeleteAsync(url);
            if (respose.IsSuccessStatusCode)
            {
                return RedirectToAction("listMau");
            }
            return BadRequest();
        }
    }
}
