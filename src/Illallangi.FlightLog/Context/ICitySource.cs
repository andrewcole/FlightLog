using System.Collections.Generic;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.Context
{
    public interface ICitySource : IDebugHooks
    {
        City Create(string name, string countryName);
        IEnumerable<City> Retrieve(int? id = null, string name = null, string countryName = null);
        void Delete(City city);
    }
}