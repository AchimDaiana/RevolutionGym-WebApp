using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RevolutionGym.Data.Services;
using RevolutionGym.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevolutionGym.Controllers
{
    public class TrainingsController : Controller
    {
        private readonly ITrainingsServices _service;

        public TrainingsController(ITrainingsServices service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allTrainings = await _service.GetAllAsync(m => m.Trainer);
            return View(allTrainings);
        }

        //get/training/details
        public async Task<IActionResult> Details(int id)
        {
            var trainingDetails = await _service.GetTrainingByIdAsync(id);
            return View(trainingDetails);

        }

        public async Task<IActionResult> Create()
        {
            var trainingDropDownValue = await _service.GetTrainingDropDownsData();
            ViewBag.Trainers = new SelectList(trainingDropDownValue.Trainers, "Id", "FirstName");
            ViewBag.Subscriptions = new SelectList(trainingDropDownValue.Subscriptions, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TrainingVM training)
        {
            if (!ModelState.IsValid)
            {
                var trainingDropDownValue = await _service.GetTrainingDropDownsData();
                ViewBag.Trainers = new SelectList(trainingDropDownValue.Trainers, "Id", "FirstName");
                ViewBag.Subscriptions = new SelectList(trainingDropDownValue.Subscriptions, "Id", "Name");
                return View(training);
            }
            await _service.AddTrainingAsync(training);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var trainingDetails = await _service.GetTrainingByIdAsync(id);
            if (trainingDetails == null) return View("NotFound");

            var outcome = new TrainingVM();
            outcome.Id = trainingDetails.Id;
            outcome.Name = trainingDetails.Name;
            outcome.Description = trainingDetails.Description;
            outcome.Picture = trainingDetails.Picture;
            outcome.StartHour = trainingDetails.StartHour;
            outcome.FinishHour = trainingDetails.FinishHour;
            outcome.Category = trainingDetails.Category;
            outcome.TrainerId = trainingDetails.TrainerId;
            outcome.SubscriptionId = trainingDetails.SubscriptionId;


            var trainingDropDownValue = await _service.GetTrainingDropDownsData();
            ViewBag.Trainers = new SelectList(trainingDropDownValue.Trainers, "Id", "FirstName");
            ViewBag.Subscriptions = new SelectList(trainingDropDownValue.Subscriptions, "Id", "Name");

            return View(outcome);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TrainingVM training)
        {
            if (id != training.Id) return View("NotFound");


            if (!ModelState.IsValid)
            {
                var trainingDropDownValue = await _service.GetTrainingDropDownsData();
                ViewBag.Trainers = new SelectList(trainingDropDownValue.Trainers, "Id", "FirstName");
                ViewBag.Subscriptions = new SelectList(trainingDropDownValue.Subscriptions, "Id", "Name");
                return View(training);
            }
            await _service.UpdateTrainingAsync(training);
            return RedirectToAction(nameof(Index));
        }
    }
}
