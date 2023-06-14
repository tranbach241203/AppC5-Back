using BanGiayTheThao.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using AppC5API.ViewModel;

namespace AppC5View.Controllers.QuanLi
{
    public class AnhController : Controller
    {
    
        public AppC5API.Controllers.SanPhamController SanPhamController;
        public AnhController()
        {

            SanPhamController = new AppC5API.Controllers.SanPhamController();
        }
        // GET: AnhController
        public async Task<ActionResult> LstAnh()
        {
            try
            {
                string requesURL = $"https://localhost:7021/api/Anh/get-all-anh";
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(requesURL);
                string apiData = await response.Content.ReadAsStringAsync();
                var lst = JsonConvert.DeserializeObject<List<Anh>>(apiData);

                return View(lst);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // GET: AnhController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var url = $"https://localhost:7021/api/Anh/get-by-anh?id={id}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            var dataApi = await response.Content.ReadAsStringAsync();
            var lst = JsonConvert.DeserializeObject<Anh>(dataApi);
            return View(lst);
        }

        // GET: AnhController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: QlChatLieuController1/Create
        [HttpPost]
        public async Task<ActionResult> Create(Anh a, IFormFile imageFile)
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
                    a.DuongDanAnh = imageFile.FileName;

                }
                var url = $"https://localhost:7021/api/Anh?idSP={a.IdSanPham}&ma={a.MaAnh}&ten={a.TenAnh}&DuongDan={a.DuongDanAnh}&trangThai={a.TrangThai}";
                var httpClient = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(a), Encoding.UTF8, "application/json");
                var respose = await httpClient.PostAsync(url, content);
                if (respose.IsSuccessStatusCode)
                {
                    return RedirectToAction("LstAnh");
                }
                return View();

            }
            catch
            {
                return View();
            }
        }

    

        public async Task<ActionResult> Edit2(Guid id)
        {
            if (ModelState.IsValid)
            {
                var url = $"https://localhost:7021/api/Anh/get-by-anh?id={id}";
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);
                var dataApi = await response.Content.ReadAsStringAsync();
                var lst = JsonConvert.DeserializeObject<Anh>(dataApi);
                return View(lst);
            }

            return BadRequest();
        }
        [HttpPost]
        public async Task<ActionResult> Edit2(Anh a, IFormFile imageFile)
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
                    a.DuongDanAnh = imageFile.FileName;

                }
                var url = $"https://localhost:7021/api/Anh/edit-anh{a.IdAnh}?idSP={a.IdSanPham}&ma={a.MaAnh}&ten=a&DuongDan={a.DuongDanAnh}&trangThai={a.TrangThai}";
                var httpClient = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(a), Encoding.UTF8, "application/json");
                var respose = await httpClient.PostAsync(url, content);
                if (respose.IsSuccessStatusCode)
                {
                    return RedirectToAction("LstAnh");
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
            var url = $"https://localhost:7021/api/Anh/delete-Anh{id}";
            var httpClient = new HttpClient();
            var respose = await httpClient.DeleteAsync(url);
            if (respose.IsSuccessStatusCode)
            {
                return RedirectToAction("LstAnh");
            }
            return BadRequest();
        }
    }
}
