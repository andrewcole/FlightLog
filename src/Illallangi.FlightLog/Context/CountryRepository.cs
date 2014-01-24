using System.Collections.Generic;
using System.Linq;
using Illallangi.FlightLog.Model;
using Illallangi.LiteOrm;

namespace Illallangi.FlightLog.Context
{
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

        public override ICountry Create(ICountry obj)
        {
            this.Log.DebugFormat(@"CountryRepository.Create(""{0}"")", obj);
            
            var id = this.GetConnection()
                .InsertInto("Country")
                .Values("CountryName", obj.Name)
                .Go();

            return this.Retrieve(new Country { Id = id }).Single();
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

        public override void Delete(ICountry obj)
        {
            this.Log.DebugFormat(@"CountryRepository.Delete(""{0}"")", obj);

            this.GetConnection()
                .DeleteFrom("Country")
                .Where("CountryId", obj.Id)
                .Where("Country", obj.Name)
                .CreateCommand()
                .ExecuteNonQuery();
        }

        #endregion
    }
}