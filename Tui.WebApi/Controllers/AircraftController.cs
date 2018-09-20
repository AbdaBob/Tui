using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tui.Services.Aircraft;

namespace Tui.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AircraftController :  Controller
    {
        private IAircraftService _aircraftService;
        private ILogger<AircraftController> _logger;
        public AircraftController(IAircraftService service, ILogger<AircraftController> logger)
        {
            _logger = logger;
            _aircraftService = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _aircraftService.GetAllAsync();
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
