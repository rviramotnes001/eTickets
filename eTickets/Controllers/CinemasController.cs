﻿using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eTickets.Models;

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

        //Get: Cinema/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Logo,Description")]Cinema cinema)
        {
            if(!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _cinemasService.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cinema/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetail = await _cinemasService.GetByIdAsync(id); 
            if(cinemaDetail == null) { return View("NoFound"); }
            return View(cinemaDetail);
        }
        //Get: Cinema/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetail = await _cinemasService.GetByIdAsync(id);
            if(cinemaDetail == null) { return View("NoFound"); }
            return View(cinemaDetail);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")]Cinema cinema)
        {
            if(!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _cinemasService.UpdateAsync(id,cinema);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cinemas/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetail = await _cinemasService.GetByIdAsync(id);
            if(cinemaDetail == null) { return View("NoFound"); }
            return View(cinemaDetail);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var cinemaDetail = await _cinemasService.GetByIdAsync(id);
            if(cinemaDetail == null) { return View("NoFound"); }
            await _cinemasService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
