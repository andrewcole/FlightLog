using System;
using System.Collections.Generic;
using System.Linq;
using Illallangi.FlightLog.Model;
using Illallangi.LiteOrm;
using Ninject.Extensions.Logging;

namespace Illallangi.FlightLog.Context
{
    public class TripRepository : RepositoryBase<Trip>
    {
        #region Fields

        private readonly IRepository<Year> currentYearRepository;

        #endregion

        #region Constructors

        public TripRepository(ILogger logger, IConnectionSource connectionSource, IRepository<Year> yearRepository) 
            : base(logger, connectionSource)
        {
            this.Logger.Debug(@"TripRepository(""{0}"",""{1}"",""{2}"")", logger, connectionSource, yearRepository);
            this.currentYearRepository = yearRepository;
        }

        #endregion

        #region Properties

        private IRepository<Year> YearRepository
        {
            get { return this.currentYearRepository; }
        }

        #endregion
        
        #region Methods

        public override Trip Create(Trip obj)
        {
            this.Logger.Debug(@"TripRepository.Create(""{0}"")", obj);

            var year = this.YearRepository.Retrieve(new Year { Name = obj.Year }).Single();

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
            this.Logger.Debug(@"TripRepository.Retrieve(""{0}"")", obj); 
            
            return this.GetConnection()
                .Select<Trip>("Trips")
                .Column("TripId", (trip, i) => trip.Id = i, null == obj ? null : obj.Id)
                .Column("YearName", (trip, s) => trip.Year = s, null == obj ? null : obj.Year)
                .Column("TripName", (trip, s) => trip.Name = s, null == obj ? null : obj.Name)
                .Column("Description", (trip, s) => trip.Description = s, null == obj ? null : obj.Description)
                .Column("FlightCount", (trip, i) => trip.FlightCount = i)
                .Go();
        }

        public override Trip Update(Trip obj)
        {
            this.Logger.Debug(@"TripRepository.Update(""{0}"")", obj);

            throw new NotImplementedException();
        }

        public override void Delete(Trip obj)
        {
            this.Logger.Debug(@"TripRepository.Delete(""{0}"")", obj);

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