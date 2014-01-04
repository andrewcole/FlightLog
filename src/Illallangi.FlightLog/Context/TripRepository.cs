using System;
using System.Collections.Generic;
using System.Linq;
using Illallangi.FlightLog.Model;
using Illallangi.LiteOrm;
using Ninject.Extensions.Logging;

namespace Illallangi.FlightLog.Context
{
    public class TripRepository : SourceBase<Trip>
    {
        #region Fields

        private readonly ISource<Year> currentYearSource;

        #endregion

        #region Constructors

        public TripRepository(ILogger logger, IConnectionSource connectionSource, ISource<Year> yearSource) : base(logger, connectionSource)
        {
            this.Logger.Debug(@"TripRepository(""{0}"",""{1}"",""{2}"")", logger, connectionSource, yearSource);
            this.currentYearSource = yearSource;
        }

        #endregion

        #region Properties

        private ISource<Year> YearSource
        {
            get { return this.currentYearSource; }
        }

        #endregion
        
        #region Methods

        public override Trip Create(Trip obj)
        {
            this.Logger.Debug(@"TripRepository.Create(""{0}"")", obj);
            var year = this.YearSource.Retrieve(new Year { Name = obj.Year }).Single();

            var id = this.GetConnection()
                .InsertInto("Trip")
                .Values("YearId", year.Id)
                .Values("TripName", obj.Name)
                .Values("Description", obj.Description)
                .Go();

            return this.Retrieve(new Trip { Id = id }).Single();
        }

        public override IEnumerable<Trip> Retrieve(Trip obj = null)
        {
            return this.GetConnection()
                       .Select<Trip>("Trips")
                       .Column("TripId", (trip, i) => trip.Id = i, null == obj ? null : obj.Id)
                       .Column("TripName", (trip, s) => trip.Name = s, null == obj ? null : obj.Name)
                       .Column("YearName", (trip, s) => trip.Year = s, null == obj ? null : obj.Year)
                       .Column("Description", (trip, s) => trip.Description = s, null == obj ? null : obj.Description)
                       .Column("FlightCount", (trip, i) => trip.FlightCount = i)
                       .Go();
        }

        public override Trip Update(Trip obj)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Trip obj)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}