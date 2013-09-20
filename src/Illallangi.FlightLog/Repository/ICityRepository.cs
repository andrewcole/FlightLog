// <copyright file="ICityRepository.cs" company="Illallangi Enterprises">Copyright Illallangi Enterprises 2013</copyright>
// <summary>A repository of City objects.</summary>

using Illallangi.T4Database.Repository;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.Repository
{
    /// <summary>A repository of City objects.</summary>
    public interface ICityRepository : IRepository<City>
    {
        /// <summary>Creates a <see cref="City"/> object and persists it in the repository.</summary>
        /// <param name="countryId">The id of the <see cref="Country"/> of the <see cref="City"/> under construction.</param>
        /// <param name="name">The Name of the <see cref="City"/> under construction.</param>
        /// <param name="recurse">An optional value indicating whether to create parent objects if not found.</param>
        /// <returns>The created <see cref="City"/> object.</returns>
        City Create(int countryId, string name, bool recurse = false);
    }
}