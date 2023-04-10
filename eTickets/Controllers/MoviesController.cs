using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _movieService;
        public MoviesController(IMoviesService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            var allMovies = await _movieService.GetAllAsync(n => n.Cinema);
            return View(allMovies);
        }
    }
}
