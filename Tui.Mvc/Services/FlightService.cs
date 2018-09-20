using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Tui.Mvc.Models;
using Tui.Mvc.Extensions;
using Microsoft.Extensions.Configuration;

namespace Tui.Mvc.Services
{
    public class FlightService : IFlightService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public FlightService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task AddFlight(PostFlightModel model)
        {
            using (var client = _httpClientFactory.CreateClient("flight"))
            {
                await client.PostAsync(client.BaseAddress, model.GetStringContent());
            }

        }

        public async Task<List<AircraftModel>> GetAircrafts()
        {
            using (var client = _httpClientFactory.CreateClient("aircraft"))
            {
                var response = await client.GetAsync(client.BaseAddress);
                var products = await response.Content.ReadAsJsonAsync<List<AircraftModel>>();
                return products;
            }

        }

        public async Task<List<AirportModel>> GetAirports()
        {
            using (var client = _httpClientFactory.CreateClient("airport"))
            {
                var response = await client.GetAsync(client.BaseAddress);
                var products = await response.Content.ReadAsJsonAsync<List<AirportModel>>();
                return products;
            }
        }

        public async Task<FlightDetailModel> GetFlight(int id)
        {
            using (var client = _httpClientFactory.CreateClient("flight"))
            {
                var uri = $"{client.BaseAddress}/{id}";
                var response = await client.GetAsync(uri);
                var result = await response.Content.ReadAsJsonAsync<FlightDetailModel>();
                return result;
            }
        }

        public async Task<List<FlightResultDetailModel>> GetFlights()
        {
            using (var client = _httpClientFactory.CreateClient("flight"))
            {
                var response = await client.GetAsync(client.BaseAddress);
                var products = await response.Content.ReadAsJsonAsync<List<FlightResultDetailModel>>();
                return products;
            }

        }

        public async Task UpdateFlight(PostFlightModel model)
        {
            using (var client = _httpClientFactory.CreateClient("flight"))
            {
                var uri = $"{client.BaseAddress}/{model.Id}";
                try
                {
                    await client.PutAsync(uri, model.GetStringContent());
                }
                catch (System.Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
