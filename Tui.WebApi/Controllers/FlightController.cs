using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Tui.Business;
using Tui.Services.Flight;

namespace Tui.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class FlightController : Controller
    {
        private ILogger<FlightController> _logger;
        public FlightController(ILogger<FlightController> logger)
        {           
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IFlightService service)
        {
            try
            {
                var result = await service.GetAllAsync();
                return new  OkObjectResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task Post([FromServices] IFlightBusiness business, [FromBody]FlightDto flight)
        {
            try
            {
                 await business.AddSync(flight);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async void Put([FromServices] IFlightBusiness business, int id, [FromBody]UpdateFlightDto flight)
        {
            try
            {
                await business.UpdateAsync(flight);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromServices] IFlightService service,int id)
        {
            try
            {
                var result = await service.GetAsync(id);
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
