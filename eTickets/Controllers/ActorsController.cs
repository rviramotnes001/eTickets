﻿using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        //Database context
        private readonly IActorsService _actorsService;

        //Injected into constructor
        public ActorsController(IActorsService service)
        {
            _actorsService = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _actorsService.GetAllAsync();
            return View(data);
        }

        //Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Fullname,ProfilePictureUrl,Bio")]Actor actor)
        {
            if(!ModelState.IsValid)
            {
                return View(actor);
            }
            await _actorsService.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Detail/1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _actorsService.GetByIdAsync(id);
            if (actorDetails == null) return View("NoFound");
            return View(actorDetails);
        }

        //Get: Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _actorsService.GetByIdAsync(id);
            if (actorDetails == null) return View("NoFound");
            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fullname,ProfilePictureUrl,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _actorsService.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _actorsService.GetByIdAsync(id);
            if (actorDetails == null) return View("NoFound");
            return View(actorDetails);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _actorsService.GetByIdAsync(id);
            if (actorDetails == null) return View("NoFound");

            await _actorsService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
