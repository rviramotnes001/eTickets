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

        //Get: Producer/Detail/1
        public async Task<IActionResult> Details(int id)
        {
            var producerDetail = await _producersService.GetByIdAsync(id);
            if(producerDetail == null) { return View("NoFound"); }
            return View(producerDetail);
        }

        //Get: Producer/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetail = await _producersService.GetByIdAsync(id);
            if(producerDetail == null) { return View("NoFound"); }
            return View(producerDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fullname,ProfilePictureUrl,Bio")]Producer producer)
        {
            if(!ModelState.IsValid)
            {
                return View(producer);
            }
            await _producersService.UpdateAsync(id, producer);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _producersService.GetByIdAsync(id);
            if (actorDetails == null) return View("NoFound");
            return View(actorDetails);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetail = await _producersService.GetByIdAsync(id);
            if(producerDetail == null) { return View("NoFound"); }

            await _producersService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
