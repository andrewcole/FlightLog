using System;
using NodaTime;

namespace Illallangi.FlightLog.Model
{
    public class Flight
    {
        #region Fields

        private ZonedDateTime? currentDepartureZoned;

        private ZonedDateTime? currentArrivalZoned;

        #endregion

        #region Properties

        #region Primary Key Property

        public int? Id { get; set; }

        #endregion

        #region Parent Properties

        public string Year { get; set; }

        public string Trip { get; set; }

        public string Origin { get; set; }

        public string OriginTimezone { get; set; }

        public string Destination { get; set; }

        public string DestinationTimezone { get; set; }
        
        #endregion

        #region Instance Properties

        public DateTime Departure { get; set; }

        public DateTime Arrival { get; set; }

        public string Airline { get; set; }

        public string Number { get; set; }

        public string Aircraft { get; set; }

        public string Seat { get; set; }

        public string Note { get; set; }

        #endregion

        #region Child Properties

        #endregion

        #region Calculated Properties

        public ZonedDateTime DepartureZoned
        {
            get
            {
                return (this.currentDepartureZoned.HasValue ?
                            this.currentDepartureZoned :
                            this.currentDepartureZoned =
                                DateTimeZoneProviders.Tzdb[this.OriginTimezone].ResolveLocal(
                                    LocalDateTime.FromDateTime(this.Departure),
                                NodaTime.TimeZones.Resolvers.LenientResolver)).Value;
            }
        }

        public ZonedDateTime ArrivalZoned
        {
            get
            {
                return (this.currentArrivalZoned.HasValue ?
                            this.currentArrivalZoned :
                            this.currentArrivalZoned =
                                DateTimeZoneProviders.Tzdb[this.DestinationTimezone].ResolveLocal(
                                    LocalDateTime.FromDateTime(this.Arrival),
                                    NodaTime.TimeZones.Resolvers.LenientResolver)).Value;
            }
        }

        #endregion

        #endregion
    }
}