namespace Illallangi.FlightLog
{
    public interface IAirport
    {
        int? Id { get; set; }

        string Country { get; set; }

        string City { get; set; }

        /// <summary>
        /// IANA Time Zone Database designation for the local time zone of the airport.
        /// </summary>
        string Timezone { get; set; }
        
        /// <summary>
        /// Name of airport. May or may not contain the City name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 3-letter FAA code, for airports located in Country 'United States of America'. 3-letter IATA code, for all other airports. Blank if not assigned.
        /// </summary>
        string Iata { get; set; }

        /// <summary>
        /// 4-letter ICAO code. Blank if not assigned.
        /// </summary>
        string Icao { get; set; }

        /// <summary>
        /// Decimal degrees, usually to six significant digits. Negative is South, positive is North.
        /// </summary>
        float Latitude { get; set; }

        /// <summary>
        /// Decimal degrees, usually to six significant digits. Negative is West, positive is East.
        /// </summary>
        float Longitude { get; set; }

        /// <summary>
        /// In feet.
        /// </summary>
        float Altitude { get; set; }

        int FlightCount { get; set; }
    }
}