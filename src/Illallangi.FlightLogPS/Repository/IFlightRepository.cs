// <copyright file="IFlightRepository.cs" company="Illallangi Enterprises">Copyright Illallangi Enterprises 2013</copyright>
// <summary>A repository of Flight objects.</summary>

using Illallangi.T4Database.Repository;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.Repository
{
    /// <summary>A repository of Flight objects.</summary>
    public interface IFlightRepository : IRepository<Flight>
    {
        /// <summary>Creates a <see cref="Flight"/> object and persists it in the repository.</summary>
        /// <param name="airportId">The id of the <see cref="Airport"/> of the <see cref="Flight"/> under construction.</param>
        /// <param name="airportId">The id of the <see cref="Airport"/> of the <see cref="Flight"/> under construction.</param>
        /// <param name="departure">The Departure of the <see cref="Flight"/> under construction.</param>
        /// <param name="arrival">The Arrival of the <see cref="Flight"/> under construction.</param>
        /// <param name="recurse">An optional value indicating whether to create parent objects if not found.</param>
        /// <returns>The created <see cref="Flight"/> object.</returns>
        Flight Create(int airportId, int airportId, string departure, string arrival, bool recurse = false);
    }
}