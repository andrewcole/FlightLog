// <copyright file="ICountryRepository.cs" company="Illallangi Enterprises">Copyright Illallangi Enterprises 2013</copyright>
// <summary>A repository of Country objects.</summary>

using Illallangi.T4Database.Repository;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.Repository
{
    /// <summary>A repository of Country objects.</summary>
    public interface ICountryRepository : IRepository<Country>
    {
        /// <summary>Creates a <see cref="Country"/> object and persists it in the repository.</summary>
        /// <param name="name">The Name of the <see cref="Country"/> under construction.</param>
        /// <returns>The created <see cref="Country"/> object.</returns>
        Country Create(string name, bool recurse = false);
    }
}