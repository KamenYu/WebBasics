using Microsoft.AspNetCore.Mvc;

namespace WebAppTest.Controllers
{
    public class CatsController : Controller
    {
       
        public IActionResult List()  // /cats/list
        {
            //return View(); // returns html

            return Redirect("/cats/search");
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
