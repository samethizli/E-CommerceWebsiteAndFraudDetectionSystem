using System.Diagnostics;
using Ekitap.Data;
using Ekitap.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ekitap.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context; //sonradan ekledik
        public HomeController(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomePageViewModel()
            {
                Sliders = await _context.Sliders.ToListAsync(),
                News = await _context.News.ToListAsync(),
                Products = await _context.Products.Where(p => p.isActive && p.isHome).ToListAsync()
            };
            return View(model);
        }


        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ContactUs()
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
