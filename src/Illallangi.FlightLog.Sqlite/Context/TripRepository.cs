using System;
using System.Collections.Generic;
using System.Linq;
using Illallangi.LiteOrm;

namespace Illallangi.FlightLog.Sqlite.Context
{
    using System.Data.SQLite;

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

        protected override int Import(SQLiteConnection cx, SQLiteTransaction tx, params ITrip[] objs)
        {
            var years = objs.Select(c => c.Year)
                                .Distinct()
                                .ToDictionary(year => year, year => this.YearRepository.Retrieve(new { Name = year }).Single().Id.Value);

            foreach (var obj in objs)
            { 
                this.Log.DebugFormat(@"TripRepository.Import(""{0}"")", obj);
                try
                {
                    cx.InsertInto("Trip")
                        .Values("YearId", years[obj.Year])
                        .Values("TripName", obj.Name)
                        .Values("Description", obj.Description)
                        .Go(tx);
                }
                catch (SQLiteException sqe)
                {
                    throw new RepositoryException<ITrip>(obj, sqe.Message, sqe.ErrorCode, sqe);
                }
            }

            return objs.Count();
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
                .Column("Departure", (trip, s) => trip.Departure = s)
                .Column("Arrival", (trip, s) => trip.Arrival = s)
                .Go();
        }

        public override ITrip Update(ITrip obj)
        {
            this.Log.DebugFormat(@"TripRepository.Update(""{0}"")", obj);

            throw new NotImplementedException();
        }

        public override void Delete(params ITrip[] objs)
        {
            foreach (var obj in objs)
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
        }

        #endregion
    }
}