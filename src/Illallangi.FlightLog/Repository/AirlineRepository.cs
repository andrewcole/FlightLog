// <copyright file="AirlineRepository.cs" company="Illallangi Enterprises">Copyright Illallangi Enterprises 2013</copyright>
// <summary>A repository of Airline objects.</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using Illallangi.FlightLog.Model;
using Illallangi.T4Database.Repository;

namespace Illallangi.FlightLog.Repository
{
    /// <summary>A repository of Airline objects.</summary>
    public sealed class AirlineRepository : BaseRepository<Airline, SqlResources>, IAirlineRepository
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
        public Airline Create(string name, string alias, string iata, string icao, string callsign, string country, string active, bool recurse = false)
        {

            return this.Create<Airline>(new Airline
                {
                    Name = (string)name,
                    Alias = (string)alias,
                    Iata = (string)iata,
                    Icao = (string)icao,
                    Callsign = (string)callsign,
                    Country = (string)country,
                    Active = (string)active,
                });
        }

        public override IEnumerable<Airline> Retrieve()
        {
            return this.Retrieve<Airline>().Select(o => new Airline()
            {
                Id = (int)o.Id,
                Name = (string)o.Name,
                Alias = (string)o.Alias,
                Iata = (string)o.Iata,
                Icao = (string)o.Icao,
                Callsign = (string)o.Callsign,
                Country = (string)o.Country,
                Active = (string)o.Active,
            });
        }

        public override IEnumerable<Airline> Search(string search)
        {
            return this.Search<Airline>(search).Select(o => new Airline()
            {
                Id = (int)o.Id,
                Name = (string)o.Name,
                Alias = (string)o.Alias,
                Iata = (string)o.Iata,
                Icao = (string)o.Icao,
                Callsign = (string)o.Callsign,
                Country = (string)o.Country,
                Active = (string)o.Active,
            });
        }
    }
}