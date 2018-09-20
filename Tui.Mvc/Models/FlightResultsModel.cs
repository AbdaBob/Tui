using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tui.Mvc.Services;

namespace Tui.Mvc.Models
{
    [ViewComponent(Name = "FlightResults")]
    public class FlightResultsModel : ViewComponent
    {
        private readonly IFlightService _service;
        public FlightResultsModel(IFlightService service)
        {
            _service = service;
        }
        public List<FlightResultDetailModel> Results { get; set; }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var results = await _service.GetFlights();
            Results = results;
            return View(this);
        }
    }
}
