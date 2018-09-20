using System;
using System.Collections.Generic;
using System.Text;
using Tui.Domain;

namespace Tui.Infrastructure.Aircraft
{
    public class AircraftRepository : RepositoryBase<Domain.Aircraft>, IAircraftRepository
    {
        public AircraftRepository(TuiContext context) : base(context)
        {

        }
    }
}
