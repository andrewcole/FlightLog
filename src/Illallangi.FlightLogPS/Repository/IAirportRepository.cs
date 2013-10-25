// <copyright file="IAirportRepository.cs" company="Illallangi Enterprises">Copyright Illallangi Enterprises 2013</copyright>
// <summary>A repository of Airport objects.</summary>

using Illallangi.T4Database.Repository;
using Illallangi.FlightLogPS.Model;

namespace Illallangi.FlightLogPS.Repository
{
    /// <summary>A repository of Airport objects.</summary>
    public interface IAirportRepository : IRepository<Airport>
    {
        /// <summary>Creates a <see cref="Airport"/> object and persists it in the repository.</summary>
        /// <param name="name">The Name of the <see cref="Airport"/> under construction.</param>
        /// <param name="city">The City of the <see cref="Airport"/> under construction.</param>
        /// <param name="country">The Country of the <see cref="Airport"/> under construction.</param>
        /// <param name="iata">The Iata of the <see cref="Airport"/> under construction.</param>
        /// <param name="icao">The Icao of the <see cref="Airport"/> under construction.</param>
        /// <param name="latitude">The Latitude of the <see cref="Airport"/> under construction.</param>
        /// <param name="longitude">The Longitude of the <see cref="Airport"/> under construction.</param>
        /// <param name="altitude">The Altitude of the <see cref="Airport"/> under construction.</param>
        /// <param name="timezone">The Timezone of the <see cref="Airport"/> under construction.</param>
        /// <param name="DST">The DST of the <see cref="Airport"/> under construction.</param>
        /// <returns>The created <see cref="Airport"/> object.</returns>
        Airport Create(string name, string city, string country, string iata, string icao, float latitude, float longitude, float altitude, float timezone, string DST, bool recurse = false);
    }
}