// <copyright file="AirportRepository.cs" company="Illallangi Enterprises">Copyright Illallangi Enterprises 2013</copyright>
// <summary>A repository of Airport objects.</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using Illallangi.FlightLog.Model;
using Illallangi.T4Database.Repository;

namespace Illallangi.FlightLog.Repository
{
    /// <summary>A repository of Airport objects.</summary>
    public sealed class AirportRepository : BaseRepository<Airport, SqlResources>, IAirportRepository
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
        public Airport Create(string name, string city, string country, string iata, string icao, float latitude, float longitude, float altitude, float timezone, string DST, bool recurse = false)
        {

            return this.Create<Airport>(new Airport
                {
                    Name = (string)name,
                    City = (string)city,
                    Country = (string)country,
                    Iata = (string)iata,
                    Icao = (string)icao,
                    Latitude = (float)latitude,
                    Longitude = (float)longitude,
                    Altitude = (float)altitude,
                    Timezone = (float)timezone,
                    DST = (string)DST,
                });
        }

        public override IEnumerable<Airport> Retrieve()
        {
            return this.Retrieve<Airport>().Select(o => new Airport()
            {
                Id = (int)o.Id,
                Name = (string)o.Name,
                City = (string)o.City,
                Country = (string)o.Country,
                Iata = (string)o.Iata,
                Icao = (string)o.Icao,
                Latitude = (float)o.Latitude,
                Longitude = (float)o.Longitude,
                Altitude = (float)o.Altitude,
                Timezone = (float)o.Timezone,
                DST = (string)o.DST,
            });
        }

        public override IEnumerable<Airport> Search(string search)
        {
            return this.Search<Airport>(search).Select(o => new Airport()
            {
                Id = (int)o.Id,
                Name = (string)o.Name,
                City = (string)o.City,
                Country = (string)o.Country,
                Iata = (string)o.Iata,
                Icao = (string)o.Icao,
                Latitude = (float)o.Latitude,
                Longitude = (float)o.Longitude,
                Altitude = (float)o.Altitude,
                Timezone = (float)o.Timezone,
                DST = (string)o.DST,
            });
        }
    }
}