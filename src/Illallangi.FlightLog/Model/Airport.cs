namespace Illallangi.FlightLog.Model
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

        string ToString();
    }

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

        #region Calculated Properties

        #endregion

        public override string ToString()
        {
            return string.Format(@"{0} ({1}, {2})", this.Name, this.City, this.Country);
        }
    }
}