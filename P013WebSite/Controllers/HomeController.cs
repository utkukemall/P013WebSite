using Microsoft.AspNetCore.Mvc;
using P013WebSite.Data;
using P013WebSite.Models;
using System.Diagnostics;

namespace P013WebSite.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}   // Bunları normalde sildik. Bunun yerine private readonly DatabaseContext _context; satırını yazdık.

        private readonly DatabaseContext _context;  // Sağ tık genarete constructor yaptık

        public HomeController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.Sliders.ToList();
            return View(model);
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