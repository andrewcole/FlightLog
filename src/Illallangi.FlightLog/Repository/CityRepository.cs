// <copyright file="CityRepository.cs" company="Illallangi Enterprises">Copyright Illallangi Enterprises 2013</copyright>
// <summary>A repository of City objects.</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using Illallangi.FlightLog.Model;
using Illallangi.T4Database.Repository;

namespace Illallangi.FlightLog.Repository
{
    /// <summary>A repository of City objects.</summary>
    public sealed class CityRepository : BaseRepository<City, SqlResources>, ICityRepository
    {
        /// <summary>Creates a <see cref="City"/> object and persists it in the repository.</summary>
        /// <param name="countryId">The id of the <see cref="Country"/> of the <see cref="City"/> under construction.</param>
        /// <param name="name">The Name of the <see cref="City"/> under construction.</param>
        /// <param name="recurse">An optional value indicating whether to create parent objects if not found.</param>
        /// <returns>The created <see cref="City"/> object.</returns>
        public City Create(int countryId, string name, bool recurse = false)
        {
            var country = this.RetrieveById<Country>(countryId);

            return this.Create<City>(new City
                {
                    CountryId = (int)country.Id,
                    CountryName = (string)country.Name,
                    Name = (string)name,
                });
        }

        public override IEnumerable<City> Retrieve()
        {
            return this.Retrieve<City>().Select(o => new City()
            {
                Id = (int)o.Id,
                Name = (string)o.Name,
                CountryId = (int)o.CountryId,
                CountryName = (string)o.CountryName,
                Airports = (int)(o.Airports ?? 0),
            });
        }

        public override IEnumerable<City> Search(string search)
        {
            return this.Search<City>(search).Select(o => new City()
            {
                Id = (int)o.Id,
                Name = (string)o.Name,
                CountryId = (int)o.CountryId,
                CountryName = (string)o.CountryName,
                Airports = (int)(o.Airports ?? 0),
            });
        }
    }
}