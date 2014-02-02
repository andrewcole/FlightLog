namespace Illallangi.FlightLog.Sqlite
{
    public class Airport : IAirport
    {
        #region Primary Key Property

        public int? Id { get; set; }

        #endregion

        #region Parent Properties

        public string Country { get; set; }
        
        public string City { get; set; }

        /// <summary>
        /// IANA Time Zone Database designation for the local time zone of the airport.
        /// </summary>
        public string Timezone { get; set; }

        #endregion

        #region Instance Properties

        /// <summary>
        /// Name of airport. May or may not contain the City name.
        /// </summary>
        public string Name { get; set; }

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

        #endregion

        #region Child Properties

        #endregion

        #region Child Properties

        public int FlightCount { get; set; }

        #endregion

        public override string ToString()
        {
            return string.Format(@"{0} ({1}, {2})", this.Name, this.City, this.Country);
        }
    }
}