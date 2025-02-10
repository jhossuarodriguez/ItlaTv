using ItlaTv.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ItlaTv.Controllers
{
    public class SeriesController : Controller
    {
        private readonly StreamingContext _context;

        public SeriesController(StreamingContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var series = await _context.Series
                .Include(s => s.Productora)
                .Include(s => s.GeneroPrimario)
                .Include(s => s.GeneroSecundario)
                .ToListAsync();
            return View(series);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serie = await _context.Series
                .Include(s => s.Productora)
                .Include(s => s.GeneroPrimario)
                .Include(s => s.GeneroSecundario)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (serie == null)
            {
                return NotFound();
            }

            return View(serie);
        }

        public IActionResult Create()
        {
            ViewBag.Productoras = new SelectList(_context.Productoras, "Id", "Nombre");
            ViewBag.Generos = new SelectList(_context.Generos, "Id", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Serie serie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Productoras = new SelectList(_context.Productoras, "Id", "Nombre");
            ViewBag.Generos = new SelectList(_context.Generos, "Id", "Nombre");

            return View(serie);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serie = await _context.Series.FindAsync(id);
            if (serie == null)
            {
                return NotFound();
            }

            ViewBag.Productoras = new SelectList(_context.Productoras, "Id", "Nombre", serie.ProductoraId);
            ViewBag.Generos = new SelectList(_context.Generos, "Id", "Nombre", serie.GeneroPrimarioId);
            return View(serie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Serie serie)
        {
            if (id != serie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SerieExists(serie.Id))
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

            ViewBag.Productoras = new SelectList(_context.Productoras, "Id", "Nombre", serie.ProductoraId);
            ViewBag.Generos = new SelectList(_context.Generos, "Id", "Nombre", serie.GeneroPrimarioId);
            return View(serie);
        }

        // GET: Series/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serie = await _context.Series
                .Include(s => s.Productora)
                .Include(s => s.GeneroPrimario)
                .Include(s => s.GeneroSecundario)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (serie == null)
            {
                return NotFound();
            }

            return View(serie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serie = await _context.Series.FindAsync(id);
            if (serie != null)
            {
                _context.Series.Remove(serie);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool SerieExists(int id)
        {
            return _context.Series.Any(e => e.Id == id);
        }
    }
}
