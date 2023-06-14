using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AppC5API.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "TenDangNhap")]
        public string? TenDangNhap { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? MatKhau { get; set; }
        public bool RememberLogin { get; set; }
    
    }
}
