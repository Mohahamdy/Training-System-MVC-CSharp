using Microsoft.AspNetCore.Mvc;

namespace TrainingSystem.Controllers
{
    public class StateController : Controller
    {
        public IActionResult SetSessionAndCookie()
        {
            HttpContext.Session.SetString("Name", "Session");
            HttpContext.Response.Cookies.Append("Name", "cookie");

            return Content("Saved Session and Cookies");
        }

        public IActionResult GetSessionAndCookie()
        {
            string? session = HttpContext.Session.GetString("Name");
            string? cookie = HttpContext.Request.Cookies["Name"];

            return Content($"this Data come from {session} \n this Data come from {cookie}");
        }
    }
}
