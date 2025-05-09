using Ekitap.Data;
using Ekitap.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ekitap.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DatabaseContext _context;

        public ProductsController(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string arama = "")
        {
            var databaseContext = _context.Products.Where(p => p.isActive && p.Name.Contains(arama) || p.Description.Contains(arama) || p.YayinEvi.Name.Contains(arama) || p.Yazar.Name.Contains(arama)).Include(p => p.Category).Include(p => p.YayinEvi).Include(p => p.Yazar);
            return View(await databaseContext.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.YayinEvi)
                .Include(p => p.Yazar)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            var model = new ProductDetailViewModel() { Product= product,
            RelatedProducts = _context.Products.Where(p => p.isActive && p.CategoryId == product.CategoryId
            &&p.Id != product.Id)
            };
            return View(model);
        }
    }
}
