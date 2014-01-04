using System.Collections.Generic;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.Context
{
    public interface ICountrySource : IDebugHooks
    {
        Country Create(string name);
        IEnumerable<Country> Retrieve(int? id = null, string name = null);
        void Delete(Country country);
    }
}