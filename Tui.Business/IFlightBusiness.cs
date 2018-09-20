using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tui.Services.Flight;

namespace Tui.Business
{
    public interface IFlightBusiness
    {
        Task AddSync(FlightDto flight);
        Task UpdateAsync(UpdateFlightDto flight);
    }
}
