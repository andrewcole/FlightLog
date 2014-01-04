using System.Collections.Generic;
using Illallangi.FlightLog.Repository;

namespace Illallangi.FlightLog.Model
{
    public interface ICountrySource : IDebugHooks
    {
        Country CreateCountry(string name);
        IEnumerable<Country> RetrieveCountry(int? id = null, string name = null);
        void DeleteCountry(Country country);
    }
}