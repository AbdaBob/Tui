using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tui.Mvc.Services;

namespace Tui.Mvc.Models
{
    [ViewComponent(Name ="AddFlight")]
    public class AddFlightModel : ViewComponent
    {

        private readonly IFlightService _service;
        public AddFlightModel([FromServices]IFlightService service)
        {
            _service = service;
        }



        [Display(ResourceType = typeof(FlightResources), Name = "DepartureAirport")]
        [Required]
        public int DestinationAirportId { get; set; }

        [Display(ResourceType = typeof(FlightResources), Name = "DepartureAirport")]
        [Required]
        public int DepartureAirportId { get; set; }

        [Display(ResourceType = typeof(FlightResources), Name = "Aircraft")]
        [Required]
        public int AircraftId { get; set; }

        public List<AirportModel> Airports { get; set; }
        public List<AircraftModel> Aircrafts { get; set; }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var airports = await _service.GetAirports();
            var aircrafts = await _service.GetAircrafts();
            Aircrafts = aircrafts;
            Airports = airports;
            return View(this);
        }
    }
}
