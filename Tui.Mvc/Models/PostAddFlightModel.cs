using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tui.Mvc.Models
{
    public class PostFlightModel
    {
        public int Id { get; set; }
        [Required]
        public int DestinationAirportId { get; set; }

        [Required]
        public int DepartureAirportId { get; set; }


        [Required]
        public int AircraftId { get; set; }
    }
}
