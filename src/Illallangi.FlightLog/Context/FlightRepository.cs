using System;
using System.Collections.Generic;
using System.Linq;
using Illallangi.FlightLog.Model;
using Illallangi.LiteOrm;
using Ninject.Extensions.Logging;

namespace Illallangi.FlightLog.Context
{
    public class FlightRepository : SourceBase<Flight>
    {
        #region Fields

        private readonly ISource<Trip> currentTripSource;
        
        private readonly ISource<Airport> currentAirportSource;

        #endregion

        #region Constructor

        public FlightRepository(ILogger logger, IConnectionSource connectionSource, ISource<Trip> tripSource, ISource<Airport> airportSource) : base(logger, connectionSource)
        {
            this.currentTripSource = tripSource;
            this.currentAirportSource = airportSource;
        }

        #endregion

        #region Properties

        private ISource<Trip> TripSource
        {
            get { return this.currentTripSource; }
        }

        private ISource<Airport> AirportSource
        {
            get { return this.currentAirportSource; }
        }

        #endregion

        #region Methods

        public override Flight Create(Flight obj)
        {
            var trip = this.TripSource.Retrieve(new Trip { Year = obj.Year, Name = obj.Trip }).Single();
            var origin = this.AirportSource.Retrieve(new Airport { Icao = obj.Origin }).Single();
            var destination = this.AirportSource.Retrieve(new Airport { Icao = obj.Destination }).Single();

            var id = this.GetConnection()
                .InsertInto("Flight")
                .Values("TripId", trip.Id)
                .Values("OriginId", origin.Id)
                .Values("DestinationId", destination.Id)
                .Values("Airline", obj.Airline)
                .Values("Number", obj.Number)
                .Values("Note", obj.Note)
                .Values("Departure", obj.Departure)
                .Values("Arrival", obj.Arrival)
                .Values("Aircraft", obj.Aircraft)
                .Values("Seat", obj.Seat)
                .Go();

            return this.Retrieve(new Flight { Id = id }).Single();
        }

        public override IEnumerable<Flight> Retrieve(Flight obj = null)
        {
            return this.GetConnection()
                .Select<Flight>("Flights")
                .Column("FlightId", (flight, i) => flight.Id = i, null == obj ? null : obj.Id)
                .Column("YearName", (flight, s) => flight.Year = s, null == obj ? null : obj.Year)
                .Column("TripName", (flight, s) => flight.Trip = s, null == obj ? null : obj.Trip)
                .Column("OriginIcao", (flight, s) => flight.Origin = s, null == obj ? null : obj.Origin)
                .Column("OriginTimezone", (flight, s) => flight.OriginTimezone = s)
                .Column("DestinationIcao", (flight, s) => flight.Destination = s, null == obj ? null : obj.Destination)
                .Column("DestinationTimezone", (flight, s) => flight.DestinationTimezone = s)
                .Column("Airline", (flight, s) => flight.Airline = s, null == obj ? null : obj.Airline)
                .Column("Number", (flight, s) => flight.Number = s, null == obj ? null : obj.Number)
                .Column("Note", (flight, s) => flight.Note = s)
                .Column("Departure", (flight, s) => flight.Departure = s)
                .Column("Arrival", (flight, s) => flight.Arrival = s)
                .Column("Aircraft", (flight, s) => flight.Aircraft = s)
                .Column("Seat", (flight, s) => flight.Seat = s)
                .Go();
        }

        public override Flight Update(Flight obj)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Flight obj)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}