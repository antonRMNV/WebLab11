using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using WebApplication16.Filters;
using WebApplication16.Models;

namespace WebApplication16.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [UserLoggerFilter]
        public IActionResult Index()
        {
            return View("Index", "Nothing to see here so far...");
        }

        [HttpPost]
        public IActionResult ViewMethods()
        {
            string[] info = System.IO.File.ReadAllLines(@"log.txt");
            StringBuilder sb = new StringBuilder();
            foreach (string line in info)
                sb.Append(line + "\n");
            return View("Index", sb.ToString());
        }

        [HttpPost]
        public IActionResult ViewUsers()
        {
            string[] info = System.IO.File.ReadAllLines(@"userlog.txt");
            StringBuilder sb = new StringBuilder();
            foreach (string line in info)
                sb.Append(line + "\n");
            return View("Index", sb.ToString());
        }

        [HttpGet]
        public IActionResult Info()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
