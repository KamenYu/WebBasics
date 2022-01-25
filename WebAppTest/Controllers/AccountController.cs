using Microsoft.AspNetCore.Mvc;

namespace WebAppTest.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            this.Response.Cookies.Append("Authentication", "User");
            return View();
        }
    }
}
