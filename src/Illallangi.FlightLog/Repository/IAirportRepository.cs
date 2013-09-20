// <copyright file="IAirportRepository.cs" company="Illallangi Enterprises">Copyright Illallangi Enterprises 2013</copyright>
// <summary>A repository of Airport objects.</summary>

using Illallangi.T4Database.Repository;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.Repository
{
    /// <summary>A repository of Airport objects.</summary>
    public interface IAirportRepository : IRepository<Airport>
    {
        /// <summary>Creates a <see cref="Airport"/> object and persists it in the repository.</summary>
        /// <param name="cityId">The id of the <see cref="City"/> of the <see cref="Airport"/> under construction.</param>
        /// <param name="name">The Name of the <see cref="Airport"/> under construction.</param>
        /// <param name="icao">The Icao of the <see cref="Airport"/> under construction.</param>
        /// <param name="iata">The Iata of the <see cref="Airport"/> under construction.</param>
        /// <param name="latitude">The Latitude of the <see cref="Airport"/> under construction.</param>
        /// <param name="longitude">The Longitude of the <see cref="Airport"/> under construction.</param>
        /// <param name="altitude">The Altitude of the <see cref="Airport"/> under construction.</param>
        /// <param name="timezone">The Timezone of the <see cref="Airport"/> under construction.</param>
        /// <param name="DST">The DST of the <see cref="Airport"/> under construction.</param>
        /// <param name="openFlightsId">The OpenFlightsId of the <see cref="Airport"/> under construction.</param>
        /// <param name="recurse">An optional value indicating whether to create parent objects if not found.</param>
        /// <returns>The created <see cref="Airport"/> object.</returns>
        Airport Create(int cityId, string name, string icao, string iata, float latitude, float longitude, float altitude, float timezone, string DST, int openFlightsId, bool recurse = false);
    }
}