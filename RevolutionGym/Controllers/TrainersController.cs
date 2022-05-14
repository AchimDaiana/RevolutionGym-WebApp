using Microsoft.AspNetCore.Mvc;
using RevolutionGym.Data.Services;
using RevolutionGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevolutionGym.Controllers
{
    public class TrainersController : Controller
    {
        private readonly ITrainersServices _service;

        public TrainersController(ITrainersServices service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allTrainers = await _service.GetAllAsync();
            return View(allTrainers);
        }

        //get:trainer/create
        public IActionResult Create()
        {
            return View();
        }

        //pentru a trimite datele in bd
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FirstName, LastName, Biography, ProfilePicture")] Trainer trainer)
        {
            if (!ModelState.IsValid)
            {
                return View(trainer);
            }

            await _service.AddAsync(trainer);
            return RedirectToAction(nameof(Index));
        }

        //get:trainer/details
        public async Task<IActionResult> Details(int id)
        {
            var trainerDetails = await _service.GetByIdAsync(id);

            if (trainerDetails == null) return View("NotFound");
            return View(trainerDetails);
        }

        //get:editare antrenor
        public async Task<IActionResult> Edit(int id)
        {
            var trainerDetails = await _service.GetByIdAsync(id);
            if (trainerDetails == null) return View("NotFound");
            return View(trainerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Biography,ProfilePictureUrl")] Trainer trainer)
        {
            if (!ModelState.IsValid)
            {
                return View(trainer);
            }

            await _service.UpdateAsync(id, trainer);
            return RedirectToAction(nameof(Index));
        }

        //get:stergere antrenor
        public async Task<IActionResult> Delete(int id)
        {
            var trainerDetails = await _service.GetByIdAsync(id);
            if (trainerDetails == null) return View("NotFound");
            return View(trainerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteValidation(int id)
        {
            var trainerDetails = await _service.GetByIdAsync(id);
            if (trainerDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
