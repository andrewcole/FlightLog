using System;
using System.Collections.Generic;
using System.Linq;

using Common.Logging;

using Illallangi.FlightLog.Config;
using Illallangi.FlightLog.Model;
using Illallangi.LiteOrm;

namespace Illallangi.FlightLog.Context
{
    using System.Data.SQLite;

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

        protected override int Import(SQLiteConnection cx, SQLiteTransaction tx, params IYear[] objs)
        {
            foreach (var obj in objs)
            {
                this.Log.DebugFormat(@"YearRepository.Import(""{0}"")", obj);
                try
                {
                    cx.InsertInto("Year")
                      .Values("YearName", obj.Name)
                      .Go(tx);
                }
                catch (SQLiteException sqe)
                {
                    throw new RepositoryException<IYear>(obj, sqe);
                }
            }

            return objs.Count();
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

        public override void Delete(params IYear[] objs)
        {
            foreach (var obj in objs)
            {
                this.Log.DebugFormat(@"YearRepository.Delete(""{0}"")", obj);

                this.GetConnection()
                    .DeleteFrom("Year")
                    .Where("YearId", obj.Id)
                    .Where("YearName", obj.Name)
                    .CreateCommand()
                    .ExecuteNonQuery();
            }
        }

        #endregion
    }
}