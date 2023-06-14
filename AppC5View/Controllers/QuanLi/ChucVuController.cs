using BanGiayTheThao.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppC5View.Controllers.QuanLi
{
    public class ChucVuController : Controller
    {
        // GET: ChucVuController
        [HttpGet]
        public async Task<ActionResult> lisChucVu()
        {
            try
            {
                string requesURL = $"https://localhost:7021/api/ChucVu/get-all-ChucVu";
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(requesURL);
                string apiData = await response.Content.ReadAsStringAsync();
                var lst = JsonConvert.DeserializeObject<List<ChucVu>>(apiData);

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

            var url = $"https://localhost:7021/api/ChucVu/get-by-Id/{id}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            var dataApi = await response.Content.ReadAsStringAsync();
            var lst = JsonConvert.DeserializeObject<ChucVu>(dataApi);
            return View(lst);
        }


        public async Task<ActionResult> ThemChucVu()
        {
            if (ModelState.IsValid)
            {
                return View();
            }

            return BadRequest();
        }

      //POST: QlChucVuController1/Create
       [HttpPost]
        public async Task<ActionResult> ThemChucVu(ChucVu ChucVu)
        {
            try
            {
                var url = $"https://localhost:7021/api/ChucVu/create-ChucVu?ten={ChucVu.TenCV}&trangthai={ChucVu.TrangThai}";
                var httpClient = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(ChucVu), Encoding.UTF8, "application/json");
                var respose = await httpClient.PostAsync(url, content);
                if (respose.IsSuccessStatusCode)
                {
                    return RedirectToAction("lisChucVu");
                }
                return View();

            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Sua(Guid id)
        {
            if (ModelState.IsValid)
            {
                var url = $"https://localhost:7021/api/ChucVu/get-by-Id/{id}";
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);
                var dataApi = await response.Content.ReadAsStringAsync();
                var lst = JsonConvert.DeserializeObject<ChucVu>(dataApi);
                return View(lst);
            }

            return BadRequest();

        }
        [HttpPost]
        public async Task<IActionResult> Sua(ChucVu ChucVu)
        {
            try
            {
                var url = $"https://localhost:7021/api/ChucVu/update-ChucVu{ChucVu.IdChucVu}?&ten={ChucVu.TenCV}&trangthai={ChucVu.TrangThai}";
                var httpClient = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(ChucVu), Encoding.UTF8, "application/json");
                var respose = await httpClient.PostAsync(url, content);
                if (respose.IsSuccessStatusCode)
                {
                    return RedirectToAction("lisChucVu");
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
            var url = $"https://localhost:7021/api/ChucVu/delete-ChucVu{id}";
            var httpClient = new HttpClient();
            var respose = await httpClient.DeleteAsync(url);
            if (respose.IsSuccessStatusCode)
            {
                return RedirectToAction("lisChucVu");
            }
            return BadRequest();
        }
    }
}

