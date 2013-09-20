// <copyright file="IAirlineRepository.cs" company="Illallangi Enterprises">Copyright Illallangi Enterprises 2013</copyright>
// <summary>A repository of Airline objects.</summary>

using Illallangi.T4Database.Repository;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.Repository
{
    /// <summary>A repository of Airline objects.</summary>
    public interface IAirlineRepository : IRepository<Airline>
    {
        /// <summary>Creates a <see cref="Airline"/> object and persists it in the repository.</summary>
        /// <param name="countryId">The id of the <see cref="Country"/> of the <see cref="Airline"/> under construction.</param>
        /// <param name="name">The Name of the <see cref="Airline"/> under construction.</param>
        /// <param name="alias">The Alias of the <see cref="Airline"/> under construction.</param>
        /// <param name="iata">The Iata of the <see cref="Airline"/> under construction.</param>
        /// <param name="icao">The Icao of the <see cref="Airline"/> under construction.</param>
        /// <param name="callsign">The Callsign of the <see cref="Airline"/> under construction.</param>
        /// <param name="openFlightsId">The OpenFlightsId of the <see cref="Airline"/> under construction.</param>
        /// <param name="recurse">An optional value indicating whether to create parent objects if not found.</param>
        /// <returns>The created <see cref="Airline"/> object.</returns>
        Airline Create(int countryId, string name, string alias, string iata, string icao, string callsign, int openFlightsId, bool recurse = false);
    }
}