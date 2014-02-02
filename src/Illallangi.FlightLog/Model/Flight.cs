using System;
using NodaTime;

namespace Illallangi.FlightLog.Model
{
    public class Flight : IFlight
    {
        #region Fields

        private ZonedDateTime? currentDepartureZoned;

        private ZonedDateTime? currentArrivalZoned;

        private TimeSpan? currentDuration;

        private double? currentDistance;

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

        public double Distance
        {
            get
            {
                return
                    (this.currentDistance.HasValue ? this.currentDistance : this.currentDistance = this.GetDistance())
                        .Value;
            }
        }

        #endregion

        #endregion

        #region Methods

        //http://www.geodatasource.com/developers/c-sharp
        private double GetDistance()
        {
            double theta = this.OriginLongitude - this.DestinationLongitude;
            var dist = Math.Sin(DegreesToRadians(this.OriginLatitude)) * Math.Sin(DegreesToRadians(this.DestinationLatitude)) + 
                       Math.Cos(DegreesToRadians(this.OriginLatitude)) * Math.Cos(DegreesToRadians(this.DestinationLatitude)) * Math.Cos(DegreesToRadians(theta));
            dist = Math.Acos(dist);
            dist = RadiansToDegrees(dist);
            dist = dist * 60 * 1.1515;
            dist = dist * 1.609344;
            return dist;
        }

        private static double DegreesToRadians(double deg)
        {
            return deg * Math.PI / 180.0;
        }

        private static double RadiansToDegrees(double rad)
        {
            return rad / Math.PI * 180.0;
        } 

        #endregion

        #region Methods

        public override string ToString()
        {
            return string.Format(
                "Flight from {0} to {1}, departing at {2}, arriving at {3}, part of trip {4} ({5}), on {6}{7} (ID {8})",
                Origin,
                Destination,
                Departure,
                Arrival,
                Trip,
                Year,
                Airline,
                Number,
                Id);
        }

        #endregion
    }
}