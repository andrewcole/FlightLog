using System.Collections.Generic;
using System.Linq;
using Illallangi.FlightLog.Model;
using Illallangi.LiteOrm;

namespace Illallangi.FlightLog.Context
{
    using System;
    using System.Data.SQLite;

    using Common.Logging;

    using Illallangi.FlightLog.Config;

    public sealed class TimezoneRepository : FlightLogRepositoryBase<ITimezone>
    {
        #region Constructor

        public TimezoneRepository(
                IFlightLogConfig flightLogConfig,
                ILog log)
            : base(
                flightLogConfig,
                log)
        {
            this.Log.DebugFormat(
                @"TimezoneRepository(""{0}"", ""{1}"")",
                flightLogConfig,
                log);
        }

        #endregion

        #region Methods

        protected override int Import(SQLiteConnection cx, SQLiteTransaction tx, params ITimezone[] objs)
        {
            foreach (var obj in objs)
            {
                this.Log.DebugFormat(@"TimezoneRepository.Create(""{0}"")", obj);
                try
                {
                    cx.InsertInto("Timezone").Values("TimezoneName", obj.Name).Go(tx);
                }
                catch (SQLiteException sqe)
                {
                    throw new RepositoryException<ITimezone>(obj, sqe);
                }
            }

            return objs.Count();
        }

        public override IEnumerable<ITimezone> Retrieve(ITimezone obj = null)
        {
            this.Log.DebugFormat(@"TimezoneRepository.Retrieve(""{0}"")", obj);

            return this.GetConnection()
                .Select<Timezone>("Timezones")
                .Column("TimezoneId", (country, value) => country.Id = value, null == obj ? null : obj.Id)
                .Column("TimezoneName", (country, value) => country.Name = value, null == obj ? null : obj.Name)
                .Column("AirportCount", (country, value) => country.AirportCount = value)
                .Go();
        }

        public override ITimezone Update(ITimezone obj)
        {
            this.Log.DebugFormat(@"TimezoneRepository.Update(""{0}"")", obj);

            throw new System.NotImplementedException();
        }

        public override void Delete(params ITimezone[] objs)
        {
            foreach (var obj in objs)
            {
                this.Log.DebugFormat(@"TimezoneRepository.Delete(""{0}"")", obj);

                this.GetConnection()
                    .DeleteFrom("Timezone")
                    .Where("TimezoneId", obj.Id)
                    .Where("TimezoneName", obj.Name)
                    .CreateCommand()
                    .ExecuteNonQuery();
            }
        }

        #endregion
    }
}