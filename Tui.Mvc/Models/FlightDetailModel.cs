using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tui.Mvc.Services;

namespace Tui.Mvc.Models
{
    [ViewComponent(Name = "FlightDetail")]
    public class FlightDetailModel : ViewComponent
    {
        private readonly IFlightService _service;
        public FlightDetailModel(IFlightService service)
        {
            _service = service;
        }
        public int Id { get; set; }
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
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var flight = await _service.GetFlight(id);
            var airports = await _service.GetAirports();
            var aircrafts = await _service.GetAircrafts();
            flight.Aircrafts = aircrafts;
            flight.Airports = airports;
            return View(flight);
        }
    }
}
