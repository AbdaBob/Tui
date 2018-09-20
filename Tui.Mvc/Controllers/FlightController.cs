using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Tui.Mvc.Services;

namespace Tui.Mvc.Controllers
{
    public class FlightController : Controller
    {
        private readonly IFlightService _service;
        private readonly ILogger<FlightController> _logger;
        public FlightController(IFlightService service, ILogger<FlightController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index() => View();
        [HttpGet]
        public IActionResult Detail(int id) => View(model: id);

        [HttpPost]
        public async Task<IActionResult> Add( Models.PostFlightModel addFlight)
        {
            try
            {
                await _service.AddFlight(addFlight);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Add {ex.Message}");
            }
            return RedirectToAction("Index", "Flight");
        }

        [HttpPost]
        public async Task<IActionResult> Put(Models.PostFlightModel addFlight)
        {
            try
            {
                await _service.UpdateFlight(addFlight);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Put {ex.Message}");
            }
            return RedirectToAction("Index", "Flight");
        }
    }
}