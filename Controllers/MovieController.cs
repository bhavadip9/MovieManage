using Microsoft.AspNetCore.Mvc;
using MovieManage.Middleware;
using MovieManage.Service.Interfaces;
using MovieManage.ViewModel;

namespace MovieManage.Controllers
{
    [ServiceFilter(typeof(LoginCheckFilter))]
    public class MovieController : Controller
    {

        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            var movies = _movieService.GetAllMovies();
            return View(movies);
        }

        [HttpPost]
        public IActionResult Create(MovieViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _movieService.AddMovie(model);
            TempData["success"] = "Movie added successfully!";
            return RedirectToAction("Index");
        }

        // Show edit form
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }

        // Handle edit form POST
        [HttpPost]
        public IActionResult Edit(MovieViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _movieService.UpdateMovie(model);
            TempData["success"] = "Movie updated successfully!";
            return RedirectToAction("Index");
        }

        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }

        
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var success = _movieService.DeleteMovie(id);
            if (success)
                TempData["success"] = "Movie deleted.";
            else
                TempData["error"] = "Movie not found.";

            return RedirectToAction("Index");
        }

        // Show create form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
