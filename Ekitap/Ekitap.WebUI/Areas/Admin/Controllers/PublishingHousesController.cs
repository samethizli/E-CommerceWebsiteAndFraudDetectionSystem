using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ekitap.Core.Entities;
using Ekitap.Data;
using Ekitap.WebUI.Utils;
using Microsoft.AspNetCore.Authorization;

namespace Ekitap.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class PublishingHousesController : Controller
    {
        private readonly DatabaseContext _context;

        public PublishingHousesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Admin/PublishingHouses
        public async Task<IActionResult> Index()
        {
            return View(await _context.PublishingHouses.ToListAsync());
        }

        // GET: Admin/PublishingHouses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publishingHouse = await _context.PublishingHouses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (publishingHouse == null)
            {
                return NotFound();
            }

            return View(publishingHouse);
        }

        // GET: Admin/PublishingHouses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/PublishingHouses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PublishingHouse publishingHouse, IFormFile? Logo)
        {
            if (ModelState.IsValid)
            {
                publishingHouse.Logo = await FileHelper.FileLoaderAsync(Logo,"/Img/PublishingHouses/");
                _context.Add(publishingHouse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(publishingHouse);
        }

        // GET: Admin/PublishingHouses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publishingHouse = await _context.PublishingHouses.FindAsync(id);
            if (publishingHouse == null)
            {
                return NotFound();
            }
            return View(publishingHouse);
        }

        // POST: Admin/PublishingHouses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PublishingHouse publishingHouse,IFormFile? Logo,bool ResmiSil=false)
        {
            if (id != publishingHouse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (ResmiSil)
                        publishingHouse.Logo = string.Empty;
                    if (Logo is not null)
                    publishingHouse.Logo = await FileHelper.FileLoaderAsync(Logo, "/Img/PublishingHouses/");
                    _context.Update(publishingHouse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublishingHouseExists(publishingHouse.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(publishingHouse);
        }

        // GET: Admin/PublishingHouses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publishingHouse = await _context.PublishingHouses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (publishingHouse == null)
            {
                return NotFound();
            }

            return View(publishingHouse);
        }

        // POST: Admin/PublishingHouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publishingHouse = await _context.PublishingHouses.FindAsync(id);
            if (publishingHouse != null)
            {
                if (publishingHouse != null)
                {
                    if (!string.IsNullOrEmpty(publishingHouse.Logo))
                    {
                        FileHelper.FileRemover(publishingHouse.Logo);
                    }
                }
                _context.PublishingHouses.Remove(publishingHouse);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublishingHouseExists(int id)
        {
            return _context.PublishingHouses.Any(e => e.Id == id);
        }
    }
}
