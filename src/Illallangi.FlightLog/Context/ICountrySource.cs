using System.Collections.Generic;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.Context
{
    public interface ICountrySource
    {
        Country Create(Country obj);
        IEnumerable<Country> Retrieve(Country obj);
        void Delete(Country obj);
    }
}