using IT_ELEC1C_3ITE__GRP6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IT_ELEC1C_3ITE__GRP6.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {

            return View();
        }

        public IActionResult Clubs()
        {

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
