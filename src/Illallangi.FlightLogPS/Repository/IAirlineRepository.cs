// <copyright file="IAirlineRepository.cs" company="Illallangi Enterprises">Copyright Illallangi Enterprises 2013</copyright>
// <summary>A repository of Airline objects.</summary>

using Illallangi.T4Database.Repository;
using Illallangi.FlightLogPS.Model;

namespace Illallangi.FlightLogPS.Repository
{
    /// <summary>A repository of Airline objects.</summary>
    public interface IAirlineRepository : IRepository<Airline>
    {
        /// <summary>Creates a <see cref="Airline"/> object and persists it in the repository.</summary>
        /// <param name="name">The Name of the <see cref="Airline"/> under construction.</param>
        /// <param name="alias">The Alias of the <see cref="Airline"/> under construction.</param>
        /// <param name="iata">The Iata of the <see cref="Airline"/> under construction.</param>
        /// <param name="icao">The Icao of the <see cref="Airline"/> under construction.</param>
        /// <param name="callsign">The Callsign of the <see cref="Airline"/> under construction.</param>
        /// <param name="country">The Country of the <see cref="Airline"/> under construction.</param>
        /// <param name="active">The Active of the <see cref="Airline"/> under construction.</param>
        /// <returns>The created <see cref="Airline"/> object.</returns>
        Airline Create(string name, string alias, string iata, string icao, string callsign, string country, string active, bool recurse = false);
    }
}