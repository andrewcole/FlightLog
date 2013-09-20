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
        public Airport Create(int cityId, string name, string icao, string iata, float latitude, float longitude, float altitude, float timezone, string DST, int openFlightsId, bool recurse = false)
        {
            var city = this.RetrieveById<City>(cityId);

            return this.Create<Airport>(new Airport
                {
                    CityId = (int)city.Id,
                    CityName = (string)city.Name,
                    Name = (string)name,
                    Icao = (string)icao,
                    Iata = (string)iata,
                    Latitude = (float)latitude,
                    Longitude = (float)longitude,
                    Altitude = (float)altitude,
                    Timezone = (float)timezone,
                    DST = (string)DST,
                    OpenFlightsId = (int)openFlightsId,
                });
        }

        public override IEnumerable<Airport> Retrieve()
        {
            return this.Retrieve<Airport>().Select(o => new Airport()
            {
                Id = (int)o.Id,
                Name = (string)o.Name,
                Icao = (string)o.Icao,
                Iata = (string)o.Iata,
                Latitude = (float)o.Latitude,
                Longitude = (float)o.Longitude,
                Altitude = (float)o.Altitude,
                Timezone = (float)o.Timezone,
                DST = (string)o.DST,
                OpenFlightsId = (int)o.OpenFlightsId,
                CityId = (int)o.CityId,
                CityName = (string)o.CityName,
            });
        }

        public override IEnumerable<Airport> Search(string search)
        {
            return this.Search<Airport>(search).Select(o => new Airport()
            {
                Id = (int)o.Id,
                Name = (string)o.Name,
                Icao = (string)o.Icao,
                Iata = (string)o.Iata,
                Latitude = (float)o.Latitude,
                Longitude = (float)o.Longitude,
                Altitude = (float)o.Altitude,
                Timezone = (float)o.Timezone,
                DST = (string)o.DST,
                OpenFlightsId = (int)o.OpenFlightsId,
                CityId = (int)o.CityId,
                CityName = (string)o.CityName,
            });
        }
    }
}