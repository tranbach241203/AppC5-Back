using AppC5API.ViewModels;
using BanGiayTheThao.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AppC5View.Controllers.QuanLi
{
    public class SaleController : Controller
    {
        // GET: SaleController
        public async Task<ActionResult> XemSaleAsync()
        {
            string requesURL = $"https://localhost:7021/api/SanPham/get-all-SanPham";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(requesURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var lst = JsonConvert.DeserializeObject<List<SanPham>>(apiData);

            string requesURL1 = $"https://localhost:7021/api/KmSanPham/get-all-KmSanPham";
            var httpClient1 = new HttpClient();
            var response1 = await httpClient.GetAsync(requesURL1);
            string apiData1 = await response.Content.ReadAsStringAsync();
            var lst1 = JsonConvert.DeserializeObject<List<KmSanPham>>(apiData);

            string requestUrl2 = $"https://localhost:7021/api/KhuyenMai/get-all-KhuyenMai";
            var httpClient2 = new HttpClient();
            var response2 = await httpClient.GetAsync(requestUrl2);
            string apiData2 = await response.Content.ReadAsStringAsync();
            var lst2 = JsonConvert.DeserializeObject<List<KhuyenMai>>(apiData);

            var v = new SaleView() { sanPhams = lst, KmSanPhams = lst1, khuyenMai = lst2 };
            return View(v);
        }

        // GET: SaleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SaleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SaleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SaleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SaleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SaleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SaleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
