using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        //DB access
        private readonly IProducersService _producersService;
        //Injected to constructor
        public ProducersController(IProducersService service)
        {
            _producersService = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _producersService.GetAllAsync();
            return View(data);
        }

        //Get: Producers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Fullname,ProfilePictureUrl,Bio")]Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _producersService.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

    }
}
