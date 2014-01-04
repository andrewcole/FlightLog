using System;
using System.Collections.Generic;
using System.Linq;
using Illallangi.FlightLog.Model;
using Illallangi.LiteOrm;
using Ninject.Extensions.Logging;

namespace Illallangi.FlightLog.Context
{
    public class YearRepository : SourceBase<Year>
    {
        #region Constructor

        public YearRepository(ILogger logger, IConnectionSource connectionSource)
            : base(logger, connectionSource)
        {
        }

        #endregion

        #region Methods

        public override Year Create(Year obj)
        {
            var id = this.GetConnection()
                .InsertInto("Year")
                .Values("YearName", obj.Name)
                .Go();

            return this.Retrieve(new Year { Id = id }).Single();
        }

        public override IEnumerable<Year> Retrieve(Year obj = null)
        {
            return this.GetConnection()
                       .Select<Year>("Years")
                       .Column("YearID", (year, value) => year.Id = value, null == obj ? null : obj.Id)
                       .Column("YearName", (year, value) => year.Name = value, null == obj ? null : obj.Name)
                       .Column("TripCount", (year, value) => year.TripCount = value)
                       .Go();
        }

        public override Year Update(Year obj)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Year obj)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}