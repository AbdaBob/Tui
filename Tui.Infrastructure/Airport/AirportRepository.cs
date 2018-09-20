using System;
using System.Collections.Generic;
using System.Text;
using Tui.Domain;

namespace Tui.Infrastructure.Airport
{
    public class AirportRepository : RepositoryBase<Domain.Airport>, IAirportRepository
    {
        public AirportRepository(TuiContext context): base(context)
        {

        }
    }
}
