using BanGiayTheThao.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppC5View.Controllers.QuanLi
{
    public class GiamGiaController : Controller
    {
        // GET: GiamGiaController
        [HttpGet]

        public async Task<ActionResult> listGiamGia()
        {
            try
            {

                string requesURL = $"https://localhost:7021/api/GiamGia/get-all-GiamGia";
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(requesURL);
                string apiData = await response.Content.ReadAsStringAsync();
                var lst = JsonConvert.DeserializeObject<List<GiamGia>>(apiData);

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

            var url = $"https://localhost:7021/api/GiamGia/get-by-Id/{id}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            var dataApi = await response.Content.ReadAsStringAsync();
            var lst = JsonConvert.DeserializeObject<GiamGia>(dataApi);
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
        public async Task<ActionResult> Create(GiamGia gg)
        {
            try
            {
                var url = $"https://localhost:7021/api/GiamGia/create-GiamGia?magiamgia={gg.MaGiamGia}&tengiamgia={gg.TenGiamGia}&sotiendagiam={gg.SoTienDaGiam}";
                var httpClient = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(gg), Encoding.UTF8, "application/json");
                var respose = await httpClient.PostAsync(url, content);
                if (respose.IsSuccessStatusCode)
                {
                    return RedirectToAction("listGiamGia");
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
                var url = $"https://localhost:7021/api/GiamGia/get-by-Id/{id}";
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);
                var dataApi = await response.Content.ReadAsStringAsync();
                var lst = JsonConvert.DeserializeObject<GiamGia>(dataApi);
                return View(lst);
            }

            return BadRequest();

        }
        // POST: GiamGiaController/Edit/5
        [HttpPost]
        public async Task<IActionResult> Sua(GiamGia gg)
        {
            try
            {
                var url = $"https://localhost:7021/api/GiamGia/update-GiamGia{gg.IdGiamGia}?magiamgia={gg.MaGiamGia}&tengiamgia={gg.TenGiamGia}&sotiendagiam={gg.SoTienDaGiam}";
                var httpClient = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(gg), Encoding.UTF8, "application/json");
                var respose = await httpClient.PostAsync(url, content);
                if (respose.IsSuccessStatusCode)
                {
                    return RedirectToAction("listGiamGia");
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
            var url = $"https://localhost:7021/api/GiamGia/delete-GiamGia/{id}";
            var httpClient = new HttpClient();
            var respose = await httpClient.DeleteAsync(url);
            if (respose.IsSuccessStatusCode)
            {
                return RedirectToAction("listGiamGia");
            }
            return BadRequest();
        }
    }
}
