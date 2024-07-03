using Core_Bookcase.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Core_Bookcase.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var bk = new List<Book>()
            {
                new Book(){Id=1,Name="Book1",Writer="Jesus1"},
                new Book(){Id=2,Name="Book2",Writer="Jesus2"},
                new Book(){Id=3,Name="Book3",Writer="Jesus3"}
            };
            return View(bk);
        }

        public IActionResult StaticView()
        {
            return View();
        }
        public IActionResult Privacy()
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
