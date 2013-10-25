// <copyright file="AirportRepository.cs" company="Illallangi Enterprises">Copyright Illallangi Enterprises 2013</copyright>
// <summary>A repository of Airport objects.</summary>

namespace Illallangi.FlightLog.Model
{
    /// <summary>Represents a Airport entity.</summary>
    public sealed class Airport
    {
        public int Id { get; set; }

        /// <summary>
        /// Name of airport. May or may not contain the City name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Main city served by airport. May be spelled differently from Name.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Country or territory where airport is located.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 3-letter FAA code, for airports located in Country 'United States of America'. 3-letter IATA code, for all other airports. Blank if not assigned.
        /// </summary>
        public string Iata { get; set; }

        /// <summary>
        /// 4-letter ICAO code. Blank if not assigned.
        /// </summary>
        public string Icao { get; set; }

        /// <summary>
        /// Decimal degrees, usually to six significant digits. Negative is South, positive is North.
        /// </summary>
        public float Latitude { get; set; }

        /// <summary>
        /// Decimal degrees, usually to six significant digits. Negative is West, positive is East.
        /// </summary>
        public float Longitude { get; set; }

        /// <summary>
        /// In feet.
        /// </summary>
        public float Altitude { get; set; }

        /// <summary>
        /// Hours offset from UTC. Fractional hours are expressed as decimals, eg. India is 5.5.
        /// </summary>
        public float Timezone { get; set; }

        /// <summary>
        /// Daylight savings time. One of E (Europe), A (US/Canada), S (South America), O (Australia), Z (New Zealand), N (None) or U (Unknown) (http://openflights.org/help/time.html)
        /// </summary>
        public string DST { get; set; }

        public int Departures { get; set; }

        public int Arrivals { get; set; }
    }
}