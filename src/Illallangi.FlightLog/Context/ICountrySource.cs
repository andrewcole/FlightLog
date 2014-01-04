using System.Collections.Generic;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.Context
{
    public interface ICountrySource : IDebugHooks
    {
        Country CreateCountry(string name);
        IEnumerable<Country> RetrieveCountry(int? id = null, string name = null);
        void DeleteCountry(Country country);
    }
}