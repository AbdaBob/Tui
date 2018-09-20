using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tui.Domain;

namespace Tui.Services.Flight
{
    public interface IFlightService
    {
        Task<bool> AddAsync(FlightDto flight);
        Task<bool> UpdateAsync(UpdateFlightDto flight);
        Task<List<RequestFlightDto>> GetAllAsync();
        Task<RequestFlightDto> GetAsync(int id);
    }
}
