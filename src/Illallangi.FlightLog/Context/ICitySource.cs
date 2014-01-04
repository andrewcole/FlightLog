using System.Collections.Generic;
using Illallangi.FlightLog.Model;
using Illallangi.FlightLog.Repository;

namespace Illallangi.FlightLog.Context
{
    public interface ICitySource : IDebugHooks
    {
        City CreateCity(string name, string countryName);
        IEnumerable<City> RetrieveCity(int? id = null, string name = null, string countryName = null);
        void DeleteCity(City city);
    }
}