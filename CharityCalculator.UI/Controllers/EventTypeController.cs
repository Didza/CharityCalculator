using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CharityCalculator.UI.Contracts;
using CharityCalculator.UI.Models;

namespace CharityCalculator.UI.Controllers
{
    public class EventTypeController : Controller
    {
        private readonly IEventTypeService _eventTypeService;

        public EventTypeController(IEventTypeService eventTypeService)
        {
            _eventTypeService = eventTypeService;
        }
        // GET: EventTypeController
        public async Task<ActionResult> Index()
        {
            var model = await _eventTypeService.GetEventTypes();
            return View(model);
        }

        // GET: EventTypeController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var model = await _eventTypeService.GetEventType(id);
            return View(model);
        }

        // GET: EventTypeController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: EventTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EventTypeVM eventType)
        {
            try
            {
                var response = await _eventTypeService.CreateEventType(eventType);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(eventType);
        }

        // GET: EventTypeController/Edit/<Guid>
        public async Task<ActionResult> Edit(Guid id)
        {
            var model = await _eventTypeService.GetEventType(id);
            return View(model);
        }

        // POST: EventTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EventTypeVM eventType)
        {
            try
            {
                var response = await _eventTypeService.UpdateEventType(eventType);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(eventType);
        }

        // GET: EventTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EventTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
