using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using AppC5API.ViewModels;
using AppData.IRepositories;
using AppData.Repositories;
using BanGiayTheThao.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace AppC5API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        GiayDBcontext context;
           
        public LoginController()
        {   context= new GiayDBcontext();

        }
        [HttpPost("api/Checknd")]
         public IActionResult Checknd(LoginViewModel loginViewModel)
        {
            var user = context.NguoiDungs.Where(x => x.TenDangNhap == loginViewModel.TenDangNhap && x.MatKhau == loginViewModel.MatKhau).FirstOrDefault();
            return Ok(user);
        }
        [HttpPost("api/Checknv")]
        public IActionResult Checkcv(LoginViewModel loginViewModel)
        {
            var user = context.NguoiDungs.Where(x => x.TenDangNhap == loginViewModel.TenDangNhap && x.MatKhau == loginViewModel.MatKhau).FirstOrDefault();

            var role = context.ChucVus.Where(x => x.IdChucVu ==user.IdChucVu).FirstOrDefault();
            return Ok(role);
        }
		[HttpPost("SignUp")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> SignUp( SignUpViewModel users)
		{
			
                NguoiDung nd = new NguoiDung() {
                    IdNguoiDung = Guid.NewGuid(),
                    Ho = users.Ho,
                    Ten = users.Ten,
                    TenDangNhap = users.TenDangNhap,
                    MatKhau = users.MatKhau,
                    IdChucVu = Guid.Parse("9245fe4a-d402-451c-b9ed-9c1a05247482"),
                    GioiTinh = users.GioiTinh,
                    Email = users.Email,
                    SDT = users.SDT,
                    DiaChi = users.DiaChi,
                    TrangThai = 1
					};
					context.Add(nd);
					await context.SaveChangesAsync();
            return Ok(users);
			}
		}
}
