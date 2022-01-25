using Microsoft.AspNetCore.Mvc;

namespace WebAppTest.Controllers
{
    public class CatsController : Controller
    {
       
        public IActionResult List()  // /cats/list
        {
            var requestCookies = this.Request.Cookies;

            if (requestCookies.ContainsKey("Authentication") == false)
            {
                return Unauthorized();
            }
            return View(); // returns html
            //return Redirect("/cats/search");
        }

        public IActionResult Details() // /cats/details
        {
            return View();
        }

        public IActionResult Search() // /cats/details
        {
            return View();
        }
    }
}
