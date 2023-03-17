using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _cinemasService;

        public CinemasController(ICinemasService service)
        {
            _cinemasService = service;
        }
        public async Task<IActionResult> Index()
        {
            var allCinemas = await _cinemasService.GetAllAsync();
            return View(allCinemas);
        }

        //Get: Cinema/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetail = await _cinemasService.GetByIdAsync(id); 
            if(cinemaDetail == null) { return View("NoFound"); }
            return View(cinemaDetail);
        }
    }
}
