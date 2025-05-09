using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ekitap.Core.Entities;
using Ekitap.Data;
using Ekitap.WebUI.Utils;
using Microsoft.AspNetCore.Authorization;

namespace Ekitap.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class WritersController : Controller
    {
        private readonly DatabaseContext _context;

        public WritersController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Admin/Writers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Writers.ToListAsync());
        }

        // GET: Admin/Writers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var writer = await _context.Writers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (writer == null)
            {
                return NotFound();
            }

            return View(writer);
        }

        // GET: Admin/Writers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Writers/Create
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Writer writer, IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                writer.Image = await FileHelper.FileLoaderAsync(Image, "/Img/Writers/");
                _context.Add(writer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(writer);
        }

        // GET: Admin/Writers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var writer = await _context.Writers.FindAsync(id);
            if (writer == null)
            {
                return NotFound();
            }
            return View(writer);
        }

        // POST: Admin/Writers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Writer writer,IFormFile? Image, bool ResmiSil = false)
        {
            if (id != writer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (ResmiSil)
                        writer.Image = string.Empty;
                    if (Image is not null)
                        writer.Image = await FileHelper.FileLoaderAsync(Image, "/Img/Writers/");
                    _context.Update(writer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WriterExists(writer.Id))
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
            return View(writer);
        }

        // GET: Admin/Writers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var writer = await _context.Writers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (writer == null)
            {
                return NotFound();
            }

            return View(writer);
        }

        // POST: Admin/Writers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var writer = await _context.Writers.FindAsync(id);
            if (writer != null)
            {
                if (!string.IsNullOrEmpty(writer.Image))
                {
                    FileHelper.FileRemover(writer.Image, "/Img/Writers/");
                }
                _context.Writers.Remove(writer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WriterExists(int id)
        {
            return _context.Writers.Any(e => e.Id == id);
        }
    }
}
