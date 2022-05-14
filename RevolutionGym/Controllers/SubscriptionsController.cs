using Microsoft.AspNetCore.Mvc;
using RevolutionGym.Data.Services;
using RevolutionGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevolutionGym.Controllers
{
    public class SubscriptionsController : Controller
    {
        private readonly ISubscriptionsServices _service;

        public SubscriptionsController(ISubscriptionsServices service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allSubscriptions = await _service.GetAllAsync();
            return View(allSubscriptions);
        }

        //get/details
        public async Task<IActionResult> Details(int id)
        {
            var subscriptiondetails = await _service.GetByIdAsync(id);
            if (subscriptiondetails == null) return View("NotFound");
            return View(subscriptiondetails);
        }

        //get/create
        public IActionResult Create()
        {
            return View();
        }

        //pt bd
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Validity,Picture,Price,Description")] Subscription subscription)
        {
            if (!ModelState.IsValid)
            {
                return View(subscription);
            }

            await _service.AddAsync(subscription);
            return RedirectToAction(nameof(Index));
        }

        //get:editare 
        public async Task<IActionResult> Edit(int id)
        {
            var subscriptionDetails = await _service.GetByIdAsync(id);
            if (subscriptionDetails == null) return View("NotFound");
            return View(subscriptionDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Validity,Picture,Price,Description")] Subscription subscription)
        {
            if (!ModelState.IsValid)
            {
                return View(subscription);
            }

            if (id == subscription.Id)
            {
                await _service.UpdateAsync(id, subscription);
                return RedirectToAction(nameof(Index));
            }
            return View(subscription);
        }

        //get:stergere 
        public async Task<IActionResult> Delete(int id)
        {
            var subscriptionDetails = await _service.GetByIdAsync(id);
            if (subscriptionDetails == null) return View("NotFound");
            return View(subscriptionDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteValidation(int id)
        {
            var subscriptionDetails = await _service.GetByIdAsync(id);
            if (subscriptionDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
