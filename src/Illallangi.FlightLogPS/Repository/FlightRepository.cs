// <copyright file="FlightRepository.cs" company="Illallangi Enterprises">Copyright Illallangi Enterprises 2013</copyright>
// <summary>A repository of Flight objects.</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using Illallangi.FlightLog.Model;
using Illallangi.T4Database.Repository;

namespace Illallangi.FlightLog.Repository
{
    /// <summary>A repository of Flight objects.</summary>
    public sealed class FlightRepository : BaseRepository<Flight, SqlResources>, IFlightRepository
    {
        /// <summary>Creates a <see cref="Flight"/> object and persists it in the repository.</summary>
        /// <param name="airportId">The id of the <see cref="Airport"/> of the <see cref="Flight"/> under construction.</param>
        /// <param name="airportId">The id of the <see cref="Airport"/> of the <see cref="Flight"/> under construction.</param>
        /// <param name="departure">The Departure of the <see cref="Flight"/> under construction.</param>
        /// <param name="arrival">The Arrival of the <see cref="Flight"/> under construction.</param>
        /// <param name="recurse">An optional value indicating whether to create parent objects if not found.</param>
        /// <returns>The created <see cref="Flight"/> object.</returns>
        public Flight Create(int airportId, int airportId, string departure, string arrival, bool recurse = false)
        {
            var airport = this.RetrieveById<Airport>(airportId);
            var airport = this.RetrieveById<Airport>(airportId);

            return this.Create<Flight>(new Flight
                {
                    AirportId = (int)airport.Id,
                    AirportName = (string)airport.Name,
                    AirportId = (int)airport.Id,
                    AirportName = (string)airport.Name,
                    Departure = (string)departure,
                    Arrival = (string)arrival,
                });
        }

        public override IEnumerable<Flight> Retrieve()
        {
            return this.Retrieve<Flight>().Select(o => new Flight()
            {
                Id = (int)o.Id,
                Departure = (string)o.Departure,
                Arrival = (string)o.Arrival,
                OriginId = (int)o.OriginId,
                OriginName = (string)o.OriginName,
                DestinationId = (int)o.DestinationId,
                DestinationName = (string)o.DestinationName,
            });
        }

        public override IEnumerable<Flight> Search(string search)
        {
            return this.Search<Flight>(search).Select(o => new Flight()
            {
                Id = (int)o.Id,
                Departure = (string)o.Departure,
                Arrival = (string)o.Arrival,
                OriginId = (int)o.OriginId,
                OriginName = (string)o.OriginName,
                DestinationId = (int)o.DestinationId,
                DestinationName = (string)o.DestinationName,
            });
        }
    }
}