// <copyright file="AirlineRepository.cs" company="Illallangi Enterprises">Copyright Illallangi Enterprises 2013</copyright>
// <summary>A repository of Airline objects.</summary>

namespace Illallangi.FlightLog.Model
{
    /// <summary>Represents a Airline entity.</summary>
    public sealed class Airline
    {
        public int Id { get; set; }

        /// <summary>
        /// Name of the airline.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Alias of the airline. For example, All Nippon Airways is commonly known as ANA.
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// 2-letter IATA code, if available.
        /// </summary>
        public string Iata { get; set; }

        /// <summary>
        /// 3-letter ICAO code, if available.
        /// </summary>
        public string Icao { get; set; }

        /// <summary>
        /// Airline callsign.
        /// </summary>
        public string Callsign { get; set; }

        /// <summary>
        /// Country or territory where airline is incorporated.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Y if the airline is or has until recently been operational, N if it is defunct. This field is not reliable: in particular, major airlines that stopped flying long ago, but have not had their IATA code reassigned (eg. Ansett/AN), will incorrectly show as Y.
        /// </summary>
        public string Active { get; set; }
    }
}