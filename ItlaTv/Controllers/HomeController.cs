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

        private static List<Serie> GetSeriesFromDatabase()
        {
            return new List<Serie>();
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
