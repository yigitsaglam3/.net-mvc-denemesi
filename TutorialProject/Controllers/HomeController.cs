using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TutorialProject.Data; // Veritaban? ba?lam? için
using TutorialProject.Models;

namespace TutorialProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context; // Veritaban? ba?lam?

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // Ana sayfada ürünleri göstermek için
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync(); // Veritaban?ndan ürünleri çekiyoruz
            return View(products); // Ürünleri view'a gönderiyoruz
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
