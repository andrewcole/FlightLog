using System;
using System.Collections.Generic;
using System.Linq;
using Illallangi.FlightLog.Model;
using Illallangi.LiteOrm;
using Ninject.Extensions.Logging;

namespace Illallangi.FlightLog.Context
{
    public class FlightRepository : RepositoryBase<Flight>
    {
        #region Fields

        private readonly IRepository<Trip> currentTripRepository;
        
        private readonly IRepository<Airport> currentAirportRepository;

        #endregion

        #region Constructor

        public FlightRepository(ILogger logger, IConnectionSource connectionSource, IRepository<Trip> tripRepository, IRepository<Airport> airportRepository) 
            : base(logger, connectionSource)
        {
            this.Logger.Debug(@"FlightRepository(""{0}"",""{1}"",""{2}"",""{3}"")", logger, connectionSource, tripRepository, airportRepository);
            this.currentTripRepository = tripRepository;
            this.currentAirportRepository = airportRepository;
        }

        #endregion

        #region Properties

        private IRepository<Trip> TripRepository
        {
            get { return this.currentTripRepository; }
        }

        private IRepository<Airport> AirportRepository
        {
            get { return this.currentAirportRepository; }
        }

        #endregion

        #region Methods

        public override Flight Create(Flight obj)
        {
            this.Logger.Debug(@"FlightRepository.Create(""{0}"")", obj);

            var trip = this.TripRepository.Retrieve(new Trip { Year = obj.Year, Name = obj.Trip }).Single();
            var origin = this.AirportRepository.Retrieve(new Airport { Icao = obj.Origin }).Single();
            var destination = this.AirportRepository.Retrieve(new Airport { Icao = obj.Destination }).Single();

            var id = this.GetConnection()
                .InsertInto("Flight")
                .Values("TripId", trip.Id)
                .Values("OriginId", origin.Id)
                .Values("DestinationId", destination.Id)
                .Values("Departure", obj.Departure)
                .Values("Arrival", obj.Arrival)
                .Values("Airline", obj.Airline)
                .Values("Number", obj.Number)
                .Values("Aircraft", obj.Aircraft)
                .Values("Seat", obj.Seat)
                .Values("Note", obj.Note)
                .Go();

            return this.Retrieve(new Flight { Id = id }).Single();
        }

        public override IEnumerable<Flight> Retrieve(Flight obj = null)
        {
            this.Logger.Debug(@"FlightRepository.Retrieve(""{0}"")", obj);

            return this.GetConnection()
                .Select<Flight>("Flights")
                .Column("FlightId", (flight, i) => flight.Id = i, null == obj ? null : obj.Id)
                .Column("YearName", (flight, s) => flight.Year = s, null == obj ? null : obj.Year)
                .Column("TripName", (flight, s) => flight.Trip = s, null == obj ? null : obj.Trip)
                .Column("OriginIcao", (flight, s) => flight.Origin = s, null == obj ? null : obj.Origin)
                .Column("OriginTimezone", (flight, s) => flight.OriginTimezone = s)
                .Column("DestinationIcao", (flight, s) => flight.Destination = s, null == obj ? null : obj.Destination)
                .Column("DestinationTimezone", (flight, s) => flight.DestinationTimezone = s)
                .Column("Departure", (flight, s) => flight.Departure = s)
                .Column("Arrival", (flight, s) => flight.Arrival = s)
                .Column("Airline", (flight, s) => flight.Airline = s, null == obj ? null : obj.Airline)
                .Column("Number", (flight, s) => flight.Number = s, null == obj ? null : obj.Number)
                .Column("Aircraft", (flight, s) => flight.Aircraft = s)
                .Column("Seat", (flight, s) => flight.Seat = s)
                .Column("Note", (flight, s) => flight.Note = s)
                .Go();
        }

        public override Flight Update(Flight obj)
        {
            this.Logger.Debug(@"FlightRepository.Update(""{0}"")", obj);

            throw new NotImplementedException();
        }

        public override void Delete(Flight obj)
        {
            this.Logger.Debug(@"CountryRepository.Delete(""{0}"")", obj);

            this.GetConnection()
                .DeleteFrom("Flight")
                .Where("FlightId", obj.Id)
                .Where("Departure", obj.Departure)
                .Where("Arrival", obj.Arrival)
                .Where("Airline", obj.Airline)
                .Where("Number", obj.Number)
                .Where("Aircraft", obj.Aircraft)
                .Where("Seat", obj.Seat)
                .Where("Note", obj.Note)
                .CreateCommand()
                .ExecuteNonQuery();
        }

        #endregion
    }
}