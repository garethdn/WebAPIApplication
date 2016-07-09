using Microsoft.AspNetCore.Mvc;

namespace WebAPIApplication.Controllers
{
    public class ViewController : Controller
    {

        [Route("/")]
        [HttpGet]
        public IActionResult Index()
        {
            return View("~/Views/index.cshtml");
        }


        [Route("/about")]
        [HttpGet]
        public string About()
        {
            return "This is the About action method...";
        }
    }
}