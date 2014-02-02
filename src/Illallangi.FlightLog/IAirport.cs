namespace Illallangi.FlightLog
{
    public interface IAirport
    {
        int? Id { get; }

        string Country { get; }

        string City { get; }

        /// <summary>
        /// IANA Time Zone Database designation for the local time zone of the airport.
        /// </summary>
        string Timezone { get; }
        
        /// <summary>
        /// Name of airport. May or may not contain the City name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 3-letter FAA code, for airports located in Country 'United States of America'. 3-letter IATA code, for all other airports. Blank if not assigned.
        /// </summary>
        string Iata { get; }

        /// <summary>
        /// 4-letter ICAO code. Blank if not assigned.
        /// </summary>
        string Icao { get; }

        /// <summary>
        /// Decimal degrees, usually to six significant digits. Negative is South, positive is North.
        /// </summary>
        float Latitude { get; }

        /// <summary>
        /// Decimal degrees, usually to six significant digits. Negative is West, positive is East.
        /// </summary>
        float Longitude { get; }

        /// <summary>
        /// In feet.
        /// </summary>
        float Altitude { get; }

        int FlightCount { get; set; }
    }
}