using BanGiayTheThao.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppC5View.Controllers.QuanLi
{
	public class KmSanPhamController : Controller
	{
		// GET: KmSanPhamController
		public async Task<IActionResult> GetAllKmSP()
		{
			try
			{
				string requesURL = $"https://localhost:7021/api/KmSanPham/get-all-KmSanPham";
				var httpClient = new HttpClient();
				var response = await httpClient.GetAsync(requesURL);
				string apiData = await response.Content.ReadAsStringAsync();
				var lst = JsonConvert.DeserializeObject<List<KmSanPham>>(apiData);

				return View(lst);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		// GET: KmSanPhamController/Details/5
		public async Task<IActionResult> Details(Guid id)
		{
			var url = $"https://localhost:7021/api/KmSanPham/get-kmsp-by-id?id={id}";
			var httpClient = new HttpClient();
			var response = await httpClient.GetAsync(url);
			var dataApi = await response.Content.ReadAsStringAsync();
			var lst = JsonConvert.DeserializeObject<KmSanPham>(dataApi);
			return View(lst);
		}

		// GET: KmSanPhamController/Create
		public async Task<IActionResult> Create()
		{
			 if (ModelState.IsValid)
            {
                return View();
	}

            return BadRequest();
		}

		// POST: KmSanPhamController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(KmSanPham kmsp)
		{
			try
			{
				var url = $"https://localhost:7021/api/KmSanPham/create-KmSanPham?idSanPham={kmsp.idSanPham}&idKhuyenMai={kmsp.idKhuyenMai}";
				var httpClient = new HttpClient();
				var content = new StringContent(JsonConvert.SerializeObject(kmsp), Encoding.UTF8, "application/json");
				var respose = await httpClient.PostAsync(url, content);
				if (respose.IsSuccessStatusCode)
				{
					return RedirectToAction("GetAllKmSP");
				}
				return View();
			}
			catch
			{
				return View();
			}
		}

		// GET: KmSanPhamController/Edit/5
		public async Task<IActionResult> Edit(Guid id)
		{
			if (ModelState.IsValid)
			{
				var url = $"https://localhost:7021/api/KmSanPham/get-kmsp-by-id?id={id}";
				var httpClient = new HttpClient();
				var response = await httpClient.GetAsync(url);
				var dataApi = await response.Content.ReadAsStringAsync();
				var lst = JsonConvert.DeserializeObject<KmSanPham>(dataApi);
				return View(lst);
			}

			return BadRequest();
		}

		// POST: KmSanPhamController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(KmSanPham kmsp)
		{
			try
			{
				var url = $"https://localhost:7021/api/KmSanPham/update-KmSanPham{kmsp.IDKMSP}?idSanPham={kmsp.idSanPham}&idKhuyenMai={kmsp.idKhuyenMai}";
				var httpClient = new HttpClient();
				var content = new StringContent(JsonConvert.SerializeObject(kmsp), Encoding.UTF8, "application/json");
				var respose = await httpClient.PostAsync(url, content);
				if (respose.IsSuccessStatusCode)
				{
					return RedirectToAction("GetAllKmSP");
				}
				return View();
			}
			catch (Exception e)
			{
				return View();
			}
		}

		// GET: KmSanPhamController/Delete/5
		public async Task<IActionResult> Delete(KmSanPham kmsp)
		{
			var url = $"https://localhost:7021/api/KmSanPham/delete-KmSanPham "+$"{kmsp.IDKMSP}";
			var httpClient = new HttpClient();
			var respose = await httpClient.DeleteAsync(url);
			if (respose.IsSuccessStatusCode)
			{
				return RedirectToAction("GetAllKmSP");
			}
			return BadRequest();
		}
	}
}
