using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppC5View.Controllers
{
    public class ShopController : Controller
    {
        [Authorize(Roles ="ADMIN")]
        public IActionResult Shop()
        {
            return View();
        }
    }
}
