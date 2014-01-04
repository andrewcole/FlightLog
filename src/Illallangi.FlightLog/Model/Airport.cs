namespace Illallangi.FlightLog.Model
{
    public class Airport
    {
        public int? Id { get; set; }

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

        /// <summary>
        /// Hours offset from UTC. Fractional hours are expressed as decimals, eg. India is 5.5.
        /// </summary>
        public float Timezone { get; set; }

        /// <summary>
        /// Daylight savings time. One of E (Europe), A (US/Canada), S (South America), O (Australia), Z (New Zealand), N (None) or U (Unknown) (http://openflights.org/help/time.html)
        /// </summary>
        public string Dst { get; set; }

        public int CityId { get; set; }

        public string CityName { get; set; }

        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public override string ToString()
        {
            return string.Format(@"{0} ({1}, {2})", this.Name, this.CityName, this.CountryName);
        }
    }
}