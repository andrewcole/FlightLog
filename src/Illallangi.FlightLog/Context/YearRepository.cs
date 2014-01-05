using System;
using System.Collections.Generic;
using System.Linq;
using Illallangi.FlightLog.Model;
using Illallangi.LiteOrm;
using Ninject.Extensions.Logging;

namespace Illallangi.FlightLog.Context
{
    public class YearRepository : RepositoryBase<Year>
    {
        #region Constructor

        public YearRepository(ILogger logger, IConnectionSource connectionSource)
            : base(logger, connectionSource)
        {
            this.Logger.Debug(@"YearRepository(""{0}"",""{1}"")", logger, connectionSource);
        }

        #endregion

        #region Methods

        public override Year Create(Year obj)
        {
            this.Logger.Debug(@"YearRepository.Create(""{0}"")", obj);

            var id = this.GetConnection()
                .InsertInto("Year")
                .Values("YearName", obj.Name)
                .Go();

            return this.Retrieve(new Year { Id = id }).Single();
        }

        public override IEnumerable<Year> Retrieve(Year obj = null)
        {
            this.Logger.Debug(@"YearRepository.Retrieve(""{0}"")", obj);

            return this.GetConnection()
                       .Select<Year>("Years")
                       .Column("YearID", (year, value) => year.Id = value, null == obj ? null : obj.Id)
                       .Column("YearName", (year, value) => year.Name = value, null == obj ? null : obj.Name)
                       .Column("TripCount", (year, value) => year.TripCount = value)
                       .Go();
        }

        public override Year Update(Year obj)
        {
            this.Logger.Debug(@"YearRepository.Update(""{0}"")", obj);

            throw new NotImplementedException();
        }

        public override void Delete(Year obj)
        {
            this.Logger.Debug(@"YearRepository.Delete(""{0}"")", obj);

            this.GetConnection()
                .DeleteFrom("Year")
                .Where("YearId", obj.Id)
                .Where("YearName", obj.Name)
                .CreateCommand()
                .ExecuteNonQuery();
        }

        #endregion
    }
}