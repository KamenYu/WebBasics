using Microsoft.AspNetCore.Mvc;

namespace WebAppTest.Controllers
{
    public class DateController : Controller
    {
        public IActionResult Now()
        {
            var storedDate = this.HttpContext.Session.GetString("CurrentDate");
            if (storedDate == null)
            {
                storedDate = DateTime.Now.ToString();
                this.HttpContext.Session.SetString("CurrentDate", storedDate);
            }
            return Ok(storedDate);
        }
    }
}
