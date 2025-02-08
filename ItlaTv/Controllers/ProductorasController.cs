using ItlaTv.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ItlaTv.Controllers
{
    public class ProductorasController : Controller
    {
        private readonly StreamingContext _context;

        public ProductorasController(StreamingContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Productoras.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Productora productora)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productora);
        }
    }
}
