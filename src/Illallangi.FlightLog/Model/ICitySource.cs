using System.Collections.Generic;
using Illallangi.FlightLog.Repository;

namespace Illallangi.FlightLog.Model
{
    public interface ICitySource : IDebugHooks
    {
        City CreateCity(string name, string countryName);
        IEnumerable<City> RetrieveCity(int? id = null, string name = null, string countryName = null);
        void DeleteCity(City city);
    }
}