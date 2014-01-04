using System.Collections.Generic;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.Context
{
    public interface IAirportSource
    {
        Airport Create(Airport obj);

        IEnumerable<Airport> Retrieve(Airport obj);

        void Delete(Airport obj);
    }
}