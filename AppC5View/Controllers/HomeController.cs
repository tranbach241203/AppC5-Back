using AppC5View.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AppC5API.Controllers;
using AppC5API.ViewModel;
using BanGiayTheThao.Models;
using Newtonsoft.Json;
using ErrorViewModel = AppC5View.Models.ErrorViewModel;
using System.Text;

namespace AppC5View.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		public SanPhamController _SanPham;
        public LisController _lst;

		public HomeController(ILogger<HomeController> logger)
		{
			_SanPham = new SanPhamController();
			_logger = logger;
            _lst = new LisController();
        }

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		public async Task<IActionResult> ShopCategory()
		{
            string requesURL = $"https://localhost:7021/api/SanPham/get-all-SanPham";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(requesURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var lst = JsonConvert.DeserializeObject<List<SanPham>>(apiData);
            //var a = _SanPham.GetAllSanPham();
			return View(lst);
		}

		public IActionResult ProductDetails()
		{
			return View();
		}

		public IActionResult ProductCheckout()
		{
            return RedirectToAction("FormThanhToan");
        }

		public IActionResult Cart()
		{
            return RedirectToAction("XemGiohang");
        }

		public IActionResult Confirmation()
		{
			return View();
		}

		public IActionResult Blog()
		{
			return View();
		}

		public IActionResult SingleBlog()
		{
			return View();
		}

		public IActionResult Login()
		{
			return View();
		}

		public IActionResult Tracking()
		{
			return View();
		}

		public IActionResult Element()
		{
			return View();
		}

		public IActionResult Contact()
		{
			return View();
		}

		public IActionResult QL()
		{
			return View();
		}

		public async Task<IActionResult> ChiTietSP(Guid id)
		{
			string requesURL1 = $"https://localhost:7021/api/Anh/get-all-anh";
			var httpClient1 = new HttpClient();
			var response1 = await httpClient1.GetAsync(requesURL1);
			string apiData1 = await response1.Content.ReadAsStringAsync();
			var lstanh = (JsonConvert.DeserializeObject<List<Anh>>(apiData1)).Where(c => c.IdSanPham == id);

			string requesURL2 = $"https://localhost:7021/api/PhanLoaiSP/get-all-SP";
			var httpClient2 = new HttpClient();
			var response2 = await httpClient2.GetAsync(requesURL2);
			string apiData2 = await response2.Content.ReadAsStringAsync();
			var lstPhanLoaiSps =
				(JsonConvert.DeserializeObject<List<PhanLoaiSP>>(apiData2)).Where(c => c.IdSanPham == id);

			string requesURL3 = $"https://localhost:7021/api/NSX/get-all-nsx";
			var httpClient3 = new HttpClient();
			var response3 = await httpClient3.GetAsync(requesURL3);
			string apiData3 = await response3.Content.ReadAsStringAsync();
			var lstNsxes =
				(JsonConvert.DeserializeObject<List<NSX>>(apiData3)).Where(c =>
					c.IdNSX == lstPhanLoaiSps.GetEnumerator().Current.IDNSX);

			string requesURL4 = $"https://localhost:7021/api/Mau/get-all-Mau";
			var httpClient4 = new HttpClient();
			var response4 = await httpClient4.GetAsync(requesURL4);
			string apiData4 = await response4.Content.ReadAsStringAsync();
			var lstmau =
				(JsonConvert.DeserializeObject<List<Mau>>(apiData4)).Where(c =>
					c.IdMau == lstPhanLoaiSps.GetEnumerator().Current.IDmau);

			string requesURL5 = $"https://localhost:7021/api/ChatLieu/get-all-chatlieu";
			var httpClient5 = new HttpClient();
			var response5 = await httpClient5.GetAsync(requesURL5);
			string apiData5 = await response5.Content.ReadAsStringAsync();
			var lstChatLieu = (JsonConvert.DeserializeObject<List<ChatLieu>>(apiData5)).Where(c =>
				c.IdChatLieu == lstPhanLoaiSps.GetEnumerator().Current.IDChatLieu);

			string requesURL6 = $"https://localhost:7021/api/Size/get-all-Size";
			var httpClient6 = new HttpClient();
			var response6 = await httpClient6.GetAsync(requesURL6);
			string apiData6 = await response6.Content.ReadAsStringAsync();
			var lstSize = (JsonConvert.DeserializeObject<List<Size>>(apiData6));

			var url = $"https://localhost:7021/api/SanPham/get-byId-SanPham/{id}";
			var httpClient = new HttpClient();
			var response = await httpClient.GetAsync(url);
			var dataApi = await response.Content.ReadAsStringAsync();
			var lstsanpham = JsonConvert.DeserializeObject<SanPham>(dataApi);

			var b = new XemView()
			{
				sanPhams = lstsanpham, Nsxes = lstNsxes, ChatLieus = lstChatLieu, mau = lstmau,
				PhanLoaiSps = lstPhanLoaiSps, Sizes = lstSize, Anhs = lstanh
			};
			return View(b);
		}
		public async Task<IActionResult> XemGiohang()
        {

            var lstGioHangChiTiets = _lst.GetAllChiTietGioHang();
            var lis = lstGioHangChiTiets;
            var tong = 0;
            foreach (var x in lstGioHangChiTiets)
            {
                tong += Int32.Parse(x.PhanLoaiSp.SanPham.GiaBan.Value.ToString()) * x.SoLuong.Value;

            }
            var b = new XemGiohangView2()
			{
				GioHangChiTiets = lis,
				tong = tong
				
			};
			return View(b);
		}
        public async Task<IActionResult> thanhToan()
        {
            var a = new GioHangView() { };
            var url = $"https://localhost:7021/api/Lis/create-sauthanhtoan";
            var httpClient = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(a), Encoding.UTF8, "application/json");
            var respose = await httpClient.PostAsync(url, content);
            if (respose.IsSuccessStatusCode)
            {
                return RedirectToAction("LstHoaDon");
            }
            return View();
        }
        public async Task<IActionResult> LstHoaDon()
        {
            
            string requesURL = $"https://localhost:7021/api/HoaDon/Get-all-HoaDon";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(requesURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var lst = JsonConvert.DeserializeObject<List<HoaDon>>(apiData);
            return View(lst);
        }
        public async Task<IActionResult> LstCTHoaDon(Guid id)
        {

            string requesURL = $"https://localhost:7021/api/Lis/get-all-CTHD22?id={id}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(requesURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var lst = JsonConvert.DeserializeObject<List<HoaDonChiTiet>>(apiData);
            return View(lst);
        }


        public async Task<IActionResult> AddTOCard(Guid idSP,int SoSize,int soluong)
		{
			var a = new GioHangView() {idSP = idSP,SoSize = SoSize,soluong = soluong};
			var url = $"https://localhost:7021/api/PhanLoaiSP/Add-GioHang?idsp={idSP}&SoSize={SoSize}&soluong={soluong}";
			var httpClient = new HttpClient();
			var content = new StringContent(JsonConvert.SerializeObject(a), Encoding.UTF8, "application/json");
			var respose = await httpClient.PostAsync(url, content);

			if (respose.IsSuccessStatusCode)
			{
				return RedirectToAction("XemGiohang");
			}
			return RedirectToAction("ChiTietSP",  idSP);
		}
        public IActionResult loatlaisanpham()
        {
            return RedirectToAction("ShopCategory");
        }
        public IActionResult FormThanhToan()
        {
            var lstGioHangChiTiets = _lst.GetAllChiTietGioHang();
            var lis = lstGioHangChiTiets;
            var tong = 0;
            foreach (var x in lstGioHangChiTiets)
            {
                tong += Int32.Parse(x.PhanLoaiSp.SanPham.GiaBan.Value.ToString()) * x.SoLuong.Value;

            }
            var b = new XemGiohangView2()
            {
                GioHangChiTiets = lis,
                tong = tong
            };
            return View(b);
        }
        public async Task<IActionResult> XoaGH(Guid id)
        {
            var url = $"https://localhost:7021/api/GioHangChiTiet/delete-GioHangChiTiet{id}";
            var httpClient = new HttpClient();
            var respose = await httpClient.DeleteAsync(url);
            if (respose.IsSuccessStatusCode)
            {
                return RedirectToAction("XemGiohang");
            }
            return BadRequest();
           
        }

    }
}