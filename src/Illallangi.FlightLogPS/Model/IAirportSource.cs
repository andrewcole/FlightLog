using System.Collections.Generic;
using Illallangi.FlightLogPS.Repository;

namespace Illallangi.FlightLogPS.Model
{
    public interface IAirportSource : IDebugHooks
    {
        Airport CreateAirport(string name, string cityName, string countryName, string iata, string icao, float latitude,
            float longitude, float altitude, float timezone, string dst);

        IEnumerable<Airport> RetrieveAirport(int? id, string name = null, string cityName = null, string countryName = null,
            string iata = null, string icao = null, float? latitude = null,
            float? longitude = null, float? altitude = null, float? timezone = null, string dst = null);

        void DeleteAirport(Airport airport);
    }
}