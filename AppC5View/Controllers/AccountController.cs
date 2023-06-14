using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using AppC5API.ViewModels;
using Newtonsoft.Json;
using System.Text;
using BanGiayTheThao.Models;

namespace AppC5View.Controllers
{
	public class AccountController : Controller
	{
		HttpClient client;
		public AccountController()
		{
			client = new HttpClient();
		}
		[HttpGet]
		public IActionResult Login()
		{
			LoginViewModel objLoginModel = new LoginViewModel();

			return View(objLoginModel);
			//ClaimsPrincipal claimUser = HttpContext.User;

			//if (claimUser.Identity.IsAuthenticated)
			//	return RedirectToAction("Index", "Home");
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel objLoginModel)
		{

			var json = JsonConvert.SerializeObject(objLoginModel);
			HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
			var reponse = await client.PostAsync("https://localhost:7021/api/Login/api/Checknd", content);
			if (reponse.IsSuccessStatusCode)
			{
				var contentrespone = await reponse.Content.ReadAsStringAsync();
				var user = JsonConvert.DeserializeObject<LoginViewModel>(contentrespone);
				if (user != null)
				{
					var reponses = await client.PostAsync("https://localhost:7021/api/Login/api/Checknv", content);
					if (reponses.IsSuccessStatusCode)
					{
						var contentrespones = await reponses.Content.ReadAsStringAsync();
						var role = JsonConvert.DeserializeObject<ChucVu>(contentrespones);
						if (role != null)
						{
							// 
							if (ModelState.IsValid)
							{

								if (user.MatKhau != null && objLoginModel.MatKhau.Length <= 2)
								{

								}
								if (user == null)
								{
									//Add logic here to display some message to user

									return View(objLoginModel);
								}
								else
								{

									if (role != null)
									{

										//A claim is a statement about a subject by an issuer and
										//represent attributes of the subject that are useful in the context of authentication and authorization operations.
										// cái thằng này chứa các thông tin, quyền của người dùng sau khi đã xác thực xong
										var claims = new List<Claim>() {
						new Claim(ClaimTypes.Name,user.TenDangNhap),
						new Claim(ClaimTypes.Role,role.TenCV),

						};
										//Initialize a new instance of the ClaimsIdentity with the claims and authentication scheme
										// tạo ra 1 đối tượng xác thực với các thông tin được cung cấp trong danh sach Claim
										// với 2 tham số là 1 list claims
										// CookieAuthenticationDefaults.AuthenticationScheme là phương thức xác thực sử dụng Cookie Authentication Scheme
										// nói cách khác CookieAuthenticationDefaults.AuthenticationScheme cung cấp cookie mặc đinh cho Scheme
										// cho phép xác thực người dùng bằng cách sử dụng cookie 
										ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
										Console.WriteLine(CookieAuthenticationDefaults.AuthenticationScheme);


										//Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity
										// Đối tượng ClaimsPrincipal chứa thông tin về người dùng, bao gồm cả đối tượng ClaimsIdentity
										// và các thông tin khác như tên đăng nhập, mật khẩu, v.v.

										// => Đối tượng đại diện cho User là ClaimsPricipal,
										// một ClaimsPrincipal có thể có nhiều ClaimsIdentity chứa các đối tượng Identity cho Authetication Scheme.
										// Nếu ứng dụng có 1 Scheme thì ClaimsPrincipal sẽ có 1 đối tượng ClaimsIdentity 

										ClaimsPrincipal principal = new ClaimsPrincipal(identity);
										//SignInAsync is a Extension method for Sign in a principal for the specified scheme.

										//Nếu IsPersistent được thiết lập là true, cookie xác thực sẽ được lưu trữ trên máy khách (client-side cookie)
										//để cho phép người dùng giữ phiên đăng nhập (persistent session) sau khi đóng trình duyệt hoặc tắt máy tính. Nếu IsPersistent là false,
										//cookie xác thực sẽ được lưu trữ trong bộ nhớ tạm thời (session cookie), và sẽ bị xóa khi trình duyệt đóng hoặc khi người dùng đăng xuất.
										await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
											principal, new AuthenticationProperties() { IsPersistent = false });


									}

								}

							}
							await Console.Out.WriteLineAsync(User.Identity.IsAuthenticated.ToString());
						}
						return RedirectToAction("Index", "Home");
					}

				}

				return NotFound();
			}
			//if (objLoginModel.TenDangNhap == "user@example.com" &&
			//	objLoginModel.MatKhau == "123"
			//	)
			//{
			//	List<Claim> claims = new List<Claim>() {
			//		new Claim(ClaimTypes.NameIdentifier, objLoginModel.TenDangNhap),
			//		new Claim("OtherProperties","Example Role")

			//	};

			//	ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
			//		CookieAuthenticationDefaults.AuthenticationScheme);

			//	AuthenticationProperties properties = new AuthenticationProperties()
			//	{

			//		AllowRefresh = true,
			//		IsPersistent = objLoginModel.RememberLogin
			//	};

			//	await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
			//		new ClaimsPrincipal(claimsIdentity), properties);

			//	return RedirectToAction("Index", "Home");

			//}
			return NotFound();
		}
		public async Task<IActionResult> LogOut()
		{
			//SignOutAsync is Extension method for SignOut    
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			//Redirect to home page    

			return LocalRedirect("/");
		}
		[HttpGet]
		public IActionResult SignUp()
		{
            if (User.IsInRole("ADMIN"))
            {

            }
            SignUpViewModel objLoginModels = new SignUpViewModel();

			return View(objLoginModels);
			//ClaimsPrincipal claimUser = HttpContext.User;

			//if (claimUser.Identity.IsAuthenticated)
			//	return RedirectToAction("Index", "Home");
		}
		[HttpPost]
		public async Task<IActionResult> SignUp(SignUpViewModel sign)
		{
			var json = JsonConvert.SerializeObject(sign);
			HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7021/api/Login/SignUp",content);
			if (response.IsSuccessStatusCode)
			{
				// Đăng ký thành công, có thể thực hiện các xử lý bổ sung nếu cần
				return RedirectToAction("Login");
			}
			else
			{
				// Xử lý khi đăng ký thất bại, ví dụ: hiển thị thông báo lỗi
				ModelState.AddModelError("", "Đăng ký thất bại. Vui lòng thử lại.");
				return View(sign);
			}
			//	//	var json = JsonConvert.SerializeObject(objLoginModel);
			//	//HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
			//	//var reponse = await client.PostAsync("https://localhost:7021/api/Login/api/Checknd", content);
		}

	}
}
