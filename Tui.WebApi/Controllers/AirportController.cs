using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tui.Services.Airport;

namespace Tui.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AirportController : Controller
    {
        private IAirportService _airportService;
        private ILogger<AirportController> _logger;
        public AirportController(IAirportService service, ILogger<AirportController> logger)
        {
            _logger = logger;
            _airportService = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _airportService.GetAllAsync();
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }
    }
}
