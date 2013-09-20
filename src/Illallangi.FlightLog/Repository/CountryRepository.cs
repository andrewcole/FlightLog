// <copyright file="CountryRepository.cs" company="Illallangi Enterprises">Copyright Illallangi Enterprises 2013</copyright>
// <summary>A repository of Country objects.</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using Illallangi.FlightLog.Model;
using Illallangi.T4Database.Repository;

namespace Illallangi.FlightLog.Repository
{
    /// <summary>A repository of Country objects.</summary>
    public sealed class CountryRepository : BaseRepository<Country, SqlResources>, ICountryRepository
    {
        /// <summary>Creates a <see cref="Country"/> object and persists it in the repository.</summary>
        /// <param name="name">The Name of the <see cref="Country"/> under construction.</param>
        /// <returns>The created <see cref="Country"/> object.</returns>
        public Country Create(string name, bool recurse = false)
        {

            return this.Create<Country>(new Country
                {
                    Name = (string)name,
                });
        }

        public override IEnumerable<Country> Retrieve()
        {
            return this.Retrieve<Country>().Select(o => new Country()
            {
                Id = (int)o.Id,
                Name = (string)o.Name,
                Cities = (int)(o.Cities ?? 0),
                Airlines = (int)(o.Airlines ?? 0),
            });
        }

        public override IEnumerable<Country> Search(string search)
        {
            return this.Search<Country>(search).Select(o => new Country()
            {
                Id = (int)o.Id,
                Name = (string)o.Name,
                Cities = (int)(o.Cities ?? 0),
                Airlines = (int)(o.Airlines ?? 0),
            });
        }
    }
}