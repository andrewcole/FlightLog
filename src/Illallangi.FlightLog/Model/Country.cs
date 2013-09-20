// <copyright file="CountryRepository.cs" company="Illallangi Enterprises">Copyright Illallangi Enterprises 2013</copyright>
// <summary>A repository of Country objects.</summary>

namespace Illallangi.FlightLog.Model
{
    /// <summary>Represents a Country entity.</summary>
    public sealed class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Cities { get; set; }

        public int Airlines { get; set; }
    }
}