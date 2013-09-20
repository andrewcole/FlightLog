// <copyright file="CityRepository.cs" company="Illallangi Enterprises">Copyright Illallangi Enterprises 2013</copyright>
// <summary>A repository of City objects.</summary>

namespace Illallangi.FlightLog.Model
{
    /// <summary>Represents a City entity.</summary>
    public sealed class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public int Airports { get; set; }
    }
}