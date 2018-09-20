using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Tui.Domain;

namespace Tui.Infrastructure.Flight
{
    public class FlightRepository : RepositoryBase<Domain.Flight>, IFlightRepository
    {
        public FlightRepository(TuiContext context) : base(context)
        {

        }
    }
}
