using System;
using NodaTime;

namespace Illallangi.FlightLog.Model
{
    public interface IFlight
    {
        int? Id { get; set; }

        string Year { get; set; }

        string Trip { get; set; }

        string Origin { get; set; }

        string OriginTimezone { get; set; }

        string Destination { get; set; }

        string DestinationTimezone { get; set; }

        DateTime Departure { get; set; }

        DateTime Arrival { get; set; }

        string Airline { get; set; }

        string Number { get; set; }

        string Aircraft { get; set; }

        string Seat { get; set; }

        string Note { get; set; }

        ZonedDateTime DepartureZoned { get; }

        ZonedDateTime ArrivalZoned { get; }
    }

    public class Flight : IFlight
    {
        #region Fields

        private ZonedDateTime? currentDepartureZoned;

        private ZonedDateTime? currentArrivalZoned;

        private TimeSpan? currentDuration;

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

        public float OriginLatitude { get; set; }

        public float OriginLongitude { get; set; }

        public string Destination { get; set; }

        public string DestinationTimezone { get; set; }

        public float DestinationLatitude { get; set; }

        public float DestinationLongitude { get; set; }

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

        public TimeSpan Duration
        {
            get
            {
                return
                    (this.currentDuration.HasValue
                         ? this.currentDuration
                         : this.currentDuration =
                           (this.ArrivalZoned.ToInstant() - this.DepartureZoned.ToInstant()).ToTimeSpan()).Value;
            }
        }

        public double DurationMinutes
        {
            get
            {
                return this.Duration.TotalMinutes;
            }
        }

        #endregion

        #endregion
    }
}