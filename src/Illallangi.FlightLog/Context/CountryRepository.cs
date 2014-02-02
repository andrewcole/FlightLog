using System.Collections.Generic;
using System.Linq;
using Illallangi.FlightLog.Model;
using Illallangi.LiteOrm;

namespace Illallangi.FlightLog.Context
{
    using System.Data.SQLite;

    using Common.Logging;

    using Illallangi.FlightLog.Config;

    public sealed class CountryRepository : FlightLogRepositoryBase<ICountry>
    {
        #region Constructor

        public CountryRepository(
            IFlightLogConfig flightLogConfig,
            ILog log)
        : base(
            flightLogConfig,
            log)
        {
            this.Log.DebugFormat(
                @"CountryRepository(""{0}"", ""{1}"")",
                flightLogConfig,
                log);
        }

        #endregion

        #region Methods

        protected override int Import(SQLiteConnection cx, SQLiteTransaction tx, params ICountry[] objs)
        {
            foreach (var obj in objs)
            {
                this.Log.DebugFormat(@"CountryRepository.Import(""{0}"")", obj);
                try
                {
                    cx.InsertInto("Country").Values("CountryName", obj.Name).Go(tx);
                }
                catch (SQLiteException sqe)
                {
                    throw new RepositoryException<ICountry>(obj, sqe);
                }
            }

            return objs.Count();
        }

        public override IEnumerable<ICountry> Retrieve(ICountry obj = null)
        {
            this.Log.DebugFormat(@"CountryRepository.Retrieve(""{0}"")", obj);

            return this.GetConnection()
                .Select<Country>("Countries")
                .Column("CountryId", (country, value) => country.Id = value, null == obj ? null : obj.Id)
                .Column("CountryName", (country, value) => country.Name = value, null == obj ? null : obj.Name)
                .Column("CityCount", (country, value) => country.CityCount = value)
                .Go();
        }

        public override ICountry Update(ICountry obj)
        {
            this.Log.DebugFormat(@"CountryRepository.Update(""{0}"")", obj);

            throw new System.NotImplementedException();
        }

        public override void Delete(params ICountry[] objs)
        {
            foreach (var obj in objs)
            {
                this.Log.DebugFormat(@"CountryRepository.Delete(""{0}"")", obj);

                this.GetConnection()
                    .DeleteFrom("Country")
                    .Where("CountryId", obj.Id)
                    .Where("CountryName", obj.Name)
                    .CreateCommand()
                    .ExecuteNonQuery();
            }
        }

        #endregion
    }
}