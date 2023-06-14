using System.Text;
using BanGiayTheThao.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace AppC5View.Controllers.QuanLi
{
	public class KhuyenMaiController : Controller
	{
		// GET: QlKhuyeMaiController
		[HttpGet]
		public async Task<ActionResult> GetAllKM()
		{
			try
			{
				string requestUrl = $"https://localhost:7021/api/KhuyenMai/get-all-KhuyenMai";
				var httpClient = new HttpClient();
				var response = await httpClient.GetAsync(requestUrl);
				string apiData = await response.Content.ReadAsStringAsync();
				var lst = JsonConvert.DeserializeObject<List<KhuyenMai>>(apiData);
				return View(lst);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}
        public async Task<IActionResult> Details(Guid id)
        {
            var url = $"https://localhost:7021/api/KhuyenMai/get-by-id?id={id}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            var dataApi = await response.Content.ReadAsStringAsync();
            var lst = JsonConvert.DeserializeObject<KhuyenMai>(dataApi);
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
        // POST: Create
        [HttpPost]
        public async Task<ActionResult> Create(KhuyenMai km)
        {
            try
            {
                var url = $"https://localhost:7021/api/KhuyenMai/create-KhuyenMai";
                var httpClient = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(km), Encoding.UTF8, "application/json");
                var respose = await httpClient.PostAsync(url, content);
                if (respose.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetAllKM");
                }

                return View();
            }
            catch (Exception e)
            {
                return View();
            }
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            if (ModelState.IsValid)
            {
                var url = $"https://localhost:7021/api/KhuyenMai/get-by-id?id={id}";
                var httpClient = new HttpClient();
                var respose = await httpClient.GetAsync(url);
                var apidata = await respose.Content.ReadAsStringAsync();
                var lst = JsonConvert.DeserializeObject<KhuyenMai>(apidata);
                if (respose.IsSuccessStatusCode)
                {
                    return View(lst);
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(KhuyenMai km)
        {
            try
            {
                var url =
                    $"https://localhost:7021/api/KhuyenMai/update-KhuyenMai?id=36095748-9151-40d2-b5b8-e8fbf1554d9b&ma=km20&NgayBatdau=2023-05-27T00%3A00%3A00&NgayKetThuc=2023-06-27T00%3A00%3A00&SoTienGiam=20000";
                var httpClient = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(km), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetAllKM");
                }

                return View();
            }
            catch (Exception e)
            {
                return View();
            }
        }

        public async Task<IActionResult> Delete(Guid id)
		{
			var url = $"https://localhost:7021/api/KhuyenMai/delete-KhuyenMai?id={id}";
			var httpClient = new HttpClient();
			var respose = await httpClient.DeleteAsync(url);
			if (respose.IsSuccessStatusCode)
			{
				return RedirectToAction("GetAllKM");
			}
			return BadRequest();
		}
	}
}
