using BanGiayTheThao.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppC5View.Controllers.QuanLi
{
    public class NSXController : Controller
    {
        // GET: NSXController
        [HttpGet]
        public async Task<ActionResult> lisNSX()
        {
            try
            {
                string requesURL = $"https://localhost:7021/api/NSX/get-all-nsx";
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(requesURL);
                string apiData = await response.Content.ReadAsStringAsync();
                var lst = JsonConvert.DeserializeObject<List<NSX>>(apiData);

                return View(lst);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

     
        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {

            var url = $"https://localhost:7021/api/NSX/get-by-Id/{id}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            var dataApi = await response.Content.ReadAsStringAsync();
            var lst = JsonConvert.DeserializeObject<NSX>(dataApi);
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
        public async Task<ActionResult> Create(NSX nsx)
        {
            try
            {
                var url = $"https://localhost:7021/api/NSX/create-nsx?ma={nsx.MaNSX}&ten={nsx.TenNSX}&trangthai={nsx.TrangThai}";
                var httpClient = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(nsx), Encoding.UTF8, "application/json");
                var respose = await httpClient.PostAsync(url, content);
                if (respose.IsSuccessStatusCode)
                {
                    return RedirectToAction("lisNSX");
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
                var url = $"https://localhost:7021/api/NSX/get-by-Id/{id}";
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);
                var dataApi = await response.Content.ReadAsStringAsync();
                var lst = JsonConvert.DeserializeObject<NSX>(dataApi);
                return View(lst);
            }

            return BadRequest();

        }
        [HttpPost]
        public async Task<IActionResult> Sua(NSX nsx)
        {
            try
            {
                var url = $"https://localhost:7021/api/NSX/update-nsx{nsx.IdNSX}?ma={nsx.MaNSX}&ten={nsx.TenNSX}&trangthai={nsx.TrangThai}";
                var httpClient = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(nsx), Encoding.UTF8, "application/json");
                var respose = await httpClient.PostAsync(url, content);
                if (respose.IsSuccessStatusCode)
                {
                    return RedirectToAction("lisNSX");
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
            var url = $"https://localhost:7021/api/NSX/delete-nsx{id}";
            var httpClient = new HttpClient();
            var respose = await httpClient.DeleteAsync(url);
            if (respose.IsSuccessStatusCode)
            {
                return RedirectToAction("lisNSX");
            }
            return BadRequest();
        }
    }
}
