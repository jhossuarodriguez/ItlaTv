using System.Diagnostics;
using ItlaTv.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItlaTv.Controllers
{
    public class HomeController : Controller
    {
        private readonly StreamingContext _context;
        private readonly MovieService _movieService;

        public HomeController(StreamingContext context, MovieService movieService)
        {
            _context = context;
            _movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            var seriesLocales = await _context.Series
                .Include(s => s.Productora)
                .Include(s => s.GeneroPrimario)
                .Include(s => s.GeneroSecundario)
                .ToListAsync();

            var peliculasPopulares = await _movieService.GetPopularMoviesAsync();

            ViewBag.Peliculas = peliculasPopulares["results"];
            return View(seriesLocales);
        }

        public async Task<IActionResult> Productoras()
        {
            var productoras = await _context.Productoras.ToListAsync();
            return View(productoras);
        }

        public async Task<IActionResult> Details(int id)
        {
            var serie = await _context.Series
                .Include(s => s.Productora)
                .Include(s => s.GeneroPrimario)
                .Include(s => s.GeneroSecundario)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (serie == null)
            {
                return NotFound();
            }

            return View(serie);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productora = await _context.Productoras
                .FirstOrDefaultAsync(m => m.Id == id);

            if (productora == null)
            {
                return NotFound();
            }

            return View(productora);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productora = await _context.Productoras.FindAsync(id);

            if (productora != null)
            {
                _context.Productoras.Remove(productora);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
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
