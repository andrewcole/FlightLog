using System;
using System.Collections.Generic;
using System.Linq;
using Illallangi.FlightLog.Model;
using Illallangi.LiteOrm;

namespace Illallangi.FlightLog.Context
{
    using Common.Logging;

    using Illallangi.FlightLog.Config;

    public class TripRepository : FlightLogRepositoryBase<ITrip>
    {
        #region Fields

        private readonly IRepository<IYear> currentYearRepository;

        #endregion

        #region Constructors

        public TripRepository(
            IFlightLogConfig flightLogConfig,
            IRepository<IYear> yearRepository,
            ILog log)
        : base(
            flightLogConfig,
            log)
        {
            this.Log.DebugFormat(
                @"TimezoneRepository(""{0}"", ""{1}"")",
                flightLogConfig,
                log);
            this.currentYearRepository = yearRepository;
        }

        #endregion

        #region Properties

        private IRepository<IYear> YearRepository
        {
            get { return this.currentYearRepository; }
        }

        #endregion
        
        #region Methods

        public override ITrip Create(ITrip obj)
        {
            this.Log.DebugFormat(@"TripRepository.Create(""{0}"")", obj);

            var year = this.YearRepository.Retrieve(new Year { Name = obj.Year }).Single();

            var id = this.GetConnection()
                .InsertInto("Trip")
                .Values("YearId", year.Id)
                .Values("TripName", obj.Name)
                .Values("Description", obj.Description)
                .Go();

            return this.Retrieve(new Trip { Id = id }).Single();
        }

        public override IEnumerable<ITrip> Retrieve(ITrip obj = null)
        {
            this.Log.DebugFormat(@"TripRepository.Retrieve(""{0}"")", obj); 
            
            return this.GetConnection()
                .Select<Trip>("Trips")
                .Column("TripId", (trip, i) => trip.Id = i, null == obj ? null : obj.Id)
                .Column("YearName", (trip, s) => trip.Year = s, null == obj ? null : obj.Year)
                .Column("TripName", (trip, s) => trip.Name = s, null == obj ? null : obj.Name)
                .Column("Description", (trip, s) => trip.Description = s, null == obj ? null : obj.Description)
                .Column("FlightCount", (trip, i) => trip.FlightCount = i)
                .Go();
        }

        public override ITrip Update(ITrip obj)
        {
            this.Log.DebugFormat(@"TripRepository.Update(""{0}"")", obj);

            throw new NotImplementedException();
        }

        public override void Delete(ITrip obj)
        {
            this.Log.DebugFormat(@"TripRepository.Delete(""{0}"")", obj);

            this.GetConnection()
                .DeleteFrom("Trip")
                .Where("TripId", obj.Id)
                .Where("TripName", obj.Name)
                .Where("Description", obj.Description)
                .CreateCommand()
                .ExecuteNonQuery();
        }

        #endregion
    }
}