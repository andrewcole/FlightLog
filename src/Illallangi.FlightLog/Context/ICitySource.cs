using System.Collections.Generic;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.Context
{
    public interface ICitySource
    {
        City Create(City obj);
        IEnumerable<City> Retrieve(City obj);
        void Delete(City obj);
    }
}