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

        public async Task<IActionResult> Index(string selectedProductora, string selectedGenero)
        {
            var productoras = await _context.Productoras.ToListAsync();
            var generos = await _context.Generos.ToListAsync();

            var seriesLocales = _context.Series
                .Include(s => s.Productora)
                .Include(s => s.GeneroPrimario)
                .Include(s => s.GeneroSecundario)
                .AsQueryable();

            if (!string.IsNullOrEmpty(selectedProductora))
            {
                seriesLocales = seriesLocales.Where(s => s.Productora.Nombre == selectedProductora);
            }

            if (!string.IsNullOrEmpty(selectedGenero))
            {
                seriesLocales = seriesLocales.Where(s => s.GeneroPrimario.Nombre == selectedGenero || s.GeneroSecundario.Nombre == selectedGenero);
            }

            var seriesFiltradas = await seriesLocales.ToListAsync();

            var peliculasPopulares = await _movieService.GetPopularMoviesAsync();
            var peliculas = peliculasPopulares?["results"]?.ToObject<List<object>>() ?? new List<object>();

            ViewBag.Peliculas = peliculas;
            ViewBag.Productoras = productoras;
            ViewBag.Generos = generos;

            return View(seriesFiltradas);
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

        public async Task<IActionResult> Productoras()
        {
            var productoras = await _context.Productoras.ToListAsync();
            return View(productoras);
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
