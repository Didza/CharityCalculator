using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CharityCalculator.UI.Contracts;
using CharityCalculator.UI.Models;
using CharityCalculator.UI.Services.Base;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CharityCalculator.UI.Controllers
{
    public class RateController : Controller
    {
        private readonly IRateService _rateService;
        private readonly IEventTypeService _eventTypeService;

        public RateController(IRateService rateService, IEventTypeService eventTypeService)
        {
            _rateService = rateService;
            _eventTypeService = eventTypeService;
        }
        // GET: RateController
        public async Task<ActionResult> Index()
        {
            var model = await _rateService.GetRates();
            return PartialView("_RateIndex", model);
        }

        // GET: RateController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var model = await _rateService.GetRate(id);
            return PartialView("_RateDetails", model);
        }
        private IEnumerable<SelectListItem> GetRateTypes()
        {

            var rateTypeList = Enum.GetValues(typeof(RateType)).Cast<RateType>();
            var rateTypes = rateTypeList.Select((item, index) =>
                new SelectListItem
                {
                    Text = item.ToString(),
                    Value = (index + 1).ToString()
                });

            return new SelectList(rateTypes, "Value", "Text");
        }
        // GET: RateController/Create
        public ActionResult Create()
        {
            var model = new RateVM
            {
                RateTypes = GetRateTypes()
            };
            return PartialView("_RateCreate", model);
        }

        // POST: RateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RateVM rate)
        {
            try
            {
                var response = await _rateService.CreateRate(rate);
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

            return PartialView("_RateCreate", rate);
        }

        // GET: RateController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var model = await _rateService.GetRate(id);
            return PartialView("_RateEdit", model);
        }

        // POST: RateController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RateVM rate)
        {
            try
            {
                var response = await _rateService.UpdateRate(rate);
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

            return PartialView("_RateEdit", rate);
        }


        // POST: RateController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var response = await _rateService.DeleteRate(id);
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

            return BadRequest();
        }

        private async Task<IEnumerable<SelectListItem>> GetEventTypes()
        {

            var model = await _eventTypeService.GetEventTypes();
            var eventTypes = model.Select(x =>
                new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });

            return new SelectList(eventTypes, "Value", "Text");
        }

        public async Task<ActionResult> GetDeductibleAmount()
        {
            var model = new DeductibleAmountVM
            {
                EventTypes = await GetEventTypes(),
                RateTypes = GetRateTypes()
            };
            return PartialView("_GetDeductibleAmount", model);
        }

        [HttpPost]
        public async Task<ActionResult<decimal>> GetDeductibleAmount(DeductibleAmountVM deductibleAmount)
        {
            try
            {
                var response = await _rateService.GetDeductibleAmount(deductibleAmount);

                deductibleAmount.DeductibleAmountResult = response;
                deductibleAmount.RateTypes = GetRateTypes();
                deductibleAmount.EventTypes = await GetEventTypes();
                deductibleAmount.RateTypes
                    .First(x => x.Value == ((int)deductibleAmount.RateType).ToString()).Selected = true;
                deductibleAmount.EventTypes.First(x => x.Value == deductibleAmount.EventTypeDtoId.ToString()).Selected = true;

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return Json(deductibleAmount);
        }
    }
}
