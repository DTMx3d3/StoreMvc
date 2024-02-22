using Microsoft.AspNetCore.Mvc;
using StoreMvc.Data;
using StoreMvc.Models;
using System.Diagnostics;

namespace StoreMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToAction("AllWatches", "AllWatches");
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

        public IActionResult AllWatches()
        {
            List<Watch> watches = _context.Watches.ToList(); // oobtinere ceasuri
            return PartialView("~/Views/AllWatches.cshtml", watches);
        }
    }
}