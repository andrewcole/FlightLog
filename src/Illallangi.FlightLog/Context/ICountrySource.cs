using System.Collections.Generic;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.Context
{
    public interface ICountrySource : IDebugHooks
    {
        Country Create(Country obj);
        IEnumerable<Country> Retrieve(Country obj);
        void Delete(Country obj);
    }
}