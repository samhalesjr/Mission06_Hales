using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mission06_Hales.Models;
using System.Diagnostics;

namespace Mission06_Hales.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Movie()
        {
            // Populate the Ratings dropdown list
            ViewBag.Rating = new SelectList(new List<string>() { "G", "PG", "PG-13", "R" });

            return View();
        }

        [HttpPost]
        public IActionResult Movie(MovieCollection movie)
        {
            if (ModelState.IsValid)
            {
                // Save the movie to the database
                // Assuming you have a method to save the movie

                return RedirectToAction("Index"); // Or wherever you want to redirect
            }

            // If we got this far, something failed, redisplay form
            ViewBag.Rating = new SelectList(new List<string>() { "G", "PG", "PG-13", "R" });
            return View(movie);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
