// <copyright file="AirportRepository.cs" company="Illallangi Enterprises">Copyright Illallangi Enterprises 2013</copyright>
// <summary>A repository of Airport objects.</summary>

namespace Illallangi.FlightLog.Model
{
    /// <summary>Represents a Airport entity.</summary>
    public sealed class Airport
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Icao { get; set; }

        public string Iata { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public float Altitude { get; set; }

        public float Timezone { get; set; }

        public string DST { get; set; }

        public int OpenFlightsId { get; set; }

        public int CityId { get; set; }

        public string CityName { get; set; }
    }
}