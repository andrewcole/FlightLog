// <copyright file="AirlineRepository.cs" company="Illallangi Enterprises">Copyright Illallangi Enterprises 2013</copyright>
// <summary>A repository of Airline objects.</summary>

namespace Illallangi.FlightLog.Model
{
    /// <summary>Represents a Airline entity.</summary>
    public sealed class Airline
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public string Iata { get; set; }

        public string Icao { get; set; }

        public string Callsign { get; set; }

        public int OpenFlightsId { get; set; }

        public int CountryId { get; set; }

        public string CountryName { get; set; }
    }
}