using BanGiayTheThao.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppC5View.Controllers.QuanLi
{
    public class SanPhamController : Controller
    {
        // GET: SanPhamController
        public async Task<ActionResult> listSp()
        {
            try
            {
                string requesURL = $"https://localhost:7021/api/SanPham/get-all-SanPham";
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(requesURL);
                string apiData = await response.Content.ReadAsStringAsync();
                var lst = JsonConvert.DeserializeObject<List<SanPham>>(apiData);

                return View(lst);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        // GET: SanPhamController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {

            var url = $"https://localhost:7021/api/SanPham/get-byId-SanPham/{id}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            var dataApi = await response.Content.ReadAsStringAsync();
            var lst = JsonConvert.DeserializeObject<SanPham>(dataApi);
            return View(lst);
        }

        // GET: SanPhamController/Create
        public async Task<ActionResult> CreateSp()
        {
            if (ModelState.IsValid)
            {
                return View();
            }

            return BadRequest();
        }

        // POST: SanPhamController/Create
        [HttpPost]
        public async Task<ActionResult> CreateSp(SanPham s, IFormFile imageFile)
        {
            try
            {
                if (imageFile != null && imageFile.Length > 0) // Không null và không trống
                {
                    //Trỏ tới thư mục wwwroot để lát nữa thực hiện việc Copy sang
                    var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot", "anhluutru", imageFile.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        // Thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
                        imageFile.CopyTo(stream);
                    }
                    // Gán lại giá trị cho Description của đối tượng bằng tên file ảnh đã được sao chép
                    s.AnhDaidien = imageFile.FileName;

                }
                var url = $"https://localhost:7021/api/SanPham/create-SanPham?ma={s.MaSanPham}&TenSanPham={s.TenSanPham}&GiaBan={s.GiaBan}&GiaNhap={s.GiaNhap}&ChieuCaoDeGiay={s.ChieuCaoDeGiay}&MoTa={s.MoTa}&anhdaidien={s.AnhDaidien}&TrangThai={s.TrangThai}";
                var httpClient = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(s), Encoding.UTF8, "application/json");
                var respose = await httpClient.PostAsync(url, content);
                if (respose.IsSuccessStatusCode)
                {
                    return RedirectToAction("listSp");
                }
                return View();

            }
            catch
            {
                return View();
            }
        }


        // GET: SanPhamController/Edit/5
        public async Task<IActionResult> Sua(Guid id)
        {
            if (ModelState.IsValid)
            {
                var url = $"https://localhost:7021/api/SanPham/get-byId-SanPham/{id}";
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);
                var dataApi = await response.Content.ReadAsStringAsync();
                var lst = JsonConvert.DeserializeObject<SanPham>(dataApi);
                return View(lst);
            }

            return BadRequest();

        }
        // POST: SanPhamController/Edit/5
        [HttpPost]
        public async Task<IActionResult> Sua(SanPham s, IFormFile imageFile)
        {
            try
            {
	            if (imageFile != null && imageFile.Length > 0) // Không null và không trống
	            {
		            //Trỏ tới thư mục wwwroot để lát nữa thực hiện việc Copy sang
		            var path = Path.Combine(
			            Directory.GetCurrentDirectory(), "wwwroot", "anhluutru", imageFile.FileName);
		            using (var stream = new FileStream(path, FileMode.Create))
		            {
			            // Thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
			            imageFile.CopyTo(stream);
		            }
		            // Gán lại giá trị cho Description của đối tượng bằng tên file ảnh đã được sao chép
		            s.AnhDaidien = imageFile.FileName;

	            }
				var url = $"https://localhost:7021/api/SanPham/update-SanPham{s.IdSanPham}?ma={s.MaSanPham}&TenSanPham={s.TenSanPham}&GiaBan={s.GiaBan}&GiaNhap={s.GiaNhap}&ChieuCaoDeGiay={s.ChieuCaoDeGiay}&MoTa={s.MoTa}&TrangThai={s.TrangThai}&anhdaidien={s.AnhDaidien}";
                var httpClient = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(s), Encoding.UTF8, "application/json");
                var respose = await httpClient.PostAsync(url, content);
                if (respose.IsSuccessStatusCode)
                {
                    return RedirectToAction("listSp");
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
            var url = $"https://localhost:7021/api/SanPham/delete-SanPham/{id}";
            var httpClient = new HttpClient();
            var respose = await httpClient.DeleteAsync(url);
            if (respose.IsSuccessStatusCode)
            {
                return RedirectToAction("listSp");
            }
            return BadRequest();
        }
    }
}
