using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mission06_Hales.Models;
using System.Diagnostics;
using System.Linq;

namespace Mission06_Hales.Controllers
{
    public class HomeController : Controller
    {
        private readonly JoelHiltonMovieCollectionContext _context;

        public HomeController(JoelHiltonMovieCollectionContext context)
        {
            _context = context;
        }
         
        public IActionResult Index()
        {
            // Fetch and return the list of all movies
            var movies = _context.Movies.Include(m => m.Category).ToList();
            return View(movies);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Movie(int? id)
        {
            // Example of fetching categories from the database
            // Ensure you have a _context variable available in your controller that represents your database context
            var categories = _context.Categories.Select(c => new { c.CategoryId, c.CategoryName }).ToList();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");

            ViewBag.Rating = new SelectList(new List<string>() { "G", "PG", "PG-13", "R" }); // Keep your existing Ratings dropdown preparation

            if (id.HasValue)
            {
                var movie = _context.Movies.Find(id.Value);
                if (movie == null)
                {
                    return NotFound();
                }
                return View(movie);
            }

            return View(new Movie());
        }


        [HttpPost]
        public IActionResult Movie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (movie.MovieId == 0)
                {
                    _context.Movies.Add(movie);
                }
                else
                {
                    _context.Movies.Update(movie);
                }

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            var categories = _context.Categories.Select(c => new { c.CategoryId, c.CategoryName }).ToList();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");

            ViewBag.Rating = new SelectList(new List<string>() { "G", "PG", "PG-13", "R" });
            return View(movie);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = _context.Movies
                .FirstOrDefault(m => m.MovieId == id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
