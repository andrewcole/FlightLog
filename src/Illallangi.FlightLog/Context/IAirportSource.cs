using System.Collections.Generic;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.Context
{
    public interface IAirportSource : IDebugHooks
    {
        Airport Create(string name, string cityName, string countryName, string iata, string icao, float latitude,
            float longitude, float altitude, float timezone, string dst);

        IEnumerable<Airport> Retrieve(int? id, string name = null, string cityName = null, string countryName = null,
            string iata = null, string icao = null, float? latitude = null,
            float? longitude = null, float? altitude = null, float? timezone = null, string dst = null);

        void Delete(Airport airport);
    }
}