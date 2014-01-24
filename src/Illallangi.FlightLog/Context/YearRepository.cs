using System;
using System.Collections.Generic;
using System.Linq;

using Common.Logging;

using Illallangi.FlightLog.Config;
using Illallangi.FlightLog.Model;
using Illallangi.LiteOrm;

namespace Illallangi.FlightLog.Context
{
    public class YearRepository : FlightLogRepositoryBase<IYear>
    {
        #region Constructor

        public YearRepository(
            IFlightLogConfig flightLogConfig, 
            ILog log)
        : base(
            flightLogConfig,
            log)
        {
            this.Log.DebugFormat(
                @"YearRepository(""{0}"", ""{1}"")",
                flightLogConfig,
                log);
        }

        #endregion

        #region Methods

        public override IYear Create(IYear obj)
        {
            this.Log.DebugFormat(@"YearRepository.Create(""{0}"")", obj);

            var id = this.GetConnection()
                .InsertInto("Year")
                .Values("YearName", obj.Name)
                .Go();

            return this.Retrieve(new Year { Id = id }).Single();
        }

        public override IEnumerable<IYear> Retrieve(IYear obj = null)
        {
            this.Log.DebugFormat(@"YearRepository.Retrieve(""{0}"")", obj);

            return this.GetConnection()
                       .Select<Year>("Years")
                       .Column("YearID", (year, value) => year.Id = value, null == obj ? null : obj.Id)
                       .Column("YearName", (year, value) => year.Name = value, null == obj ? null : obj.Name)
                       .Column("TripCount", (year, value) => year.TripCount = value)
                       .Go();
        }

        public override IYear Update(IYear obj)
        {
            this.Log.DebugFormat(@"YearRepository.Update(""{0}"")", obj);

            throw new NotImplementedException();
        }

        public override void Delete(IYear obj)
        {
            this.Log.DebugFormat(@"YearRepository.Delete(""{0}"")", obj);

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