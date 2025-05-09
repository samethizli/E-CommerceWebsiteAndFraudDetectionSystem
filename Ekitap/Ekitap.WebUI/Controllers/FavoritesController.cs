using Microsoft.AspNetCore.Mvc;

namespace Ekitap.WebUI.Controllers
{
    public class FavoritesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
