using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tui.Services.Flight;

namespace Tui.Business
{
    public interface IFlightBusiness
    {
        Task<bool> AddSync(FlightDto flight);
        Task<bool> UpdateAsync(UpdateFlightDto flight);
    }
}
