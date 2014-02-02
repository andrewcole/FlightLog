using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

using Common.Logging;

using Illallangi.FlightLog.Config;
using Illallangi.LiteOrm;

namespace Illallangi.FlightLog.Sqlite.Context
{
    public sealed class CityRepository : FlightLogRepositoryBase<ICity>
    {
        #region Fields

        private readonly IRepository<ICountry> currentCountryRepository;

        #endregion

        #region Constructor

        public CityRepository(
            IFlightLogConfig flightLogConfig,
            IRepository<ICountry> countryRepository,
            ILog log)
            : base(
                flightLogConfig,
                log)
        {
            this.Log.DebugFormat(
                @"CityRepository(""{0}"", ""{1}"", ""{2}"")",
                flightLogConfig,
                countryRepository,
                log);
            this.currentCountryRepository = countryRepository;
        }

        #endregion

        #region Properties

        private IRepository<ICountry> CountryRepository
        {
            get
            {
                return this.currentCountryRepository;
            }
        }

        #endregion

        #region Methods

        protected override int Import(SQLiteConnection cx, SQLiteTransaction tx, params ICity[] objs)
        {
            var countries = objs.Select(c => c.Country)
                                .Distinct()
                                .ToDictionary(country => country, country => this.CountryRepository.Retrieve(new Country { Name = country }).Single().Id.Value);

            foreach (var obj in objs)
            {
                this.Log.DebugFormat(@"CityRepository.Import(""{0}"")", obj);
                try
                {
                    cx.InsertInto("City")
                        .Values("CountryId", countries[obj.Country])
                        .Values("CityName", obj.Name)
                        .Go(tx);
                }
                catch (SQLiteException sqe)
                {
                    throw new RepositoryException<ICity>(obj, sqe);
                }
            }

            return objs.Count();
        }

        public override IEnumerable<ICity> Retrieve(ICity obj = null)
        {
            this.Log.DebugFormat(@"CityRepository.Retrieve(""{0}"")", obj);

            return this.GetConnection()
                .Select<City>("Cities")
                .Column("CityId", (city, value) => city.Id = value, null == obj ? null : obj.Id)
                .Column("CountryName", (city, value) => city.Country = value, null == obj ? null : obj.Country)
                .Column("CityName", (city, value) => city.Name = value, null == obj ? null : obj.Name)
                .Column("AirportCount", (city, value) => city.AirportCount = value)
                .Go();
        }

        public override ICity Update(ICity obj)
        {
            this.Log.DebugFormat(@"CityRepository.Update(""{0}"")", obj);

            throw new System.NotImplementedException();
        }

        public override void Delete(params ICity[] objs)
        {
            foreach (var obj in objs)
            {
                this.Log.DebugFormat(@"CityRepository.Delete(""{0}"")", obj);

                this.GetConnection()
                    .DeleteFrom("City")
                    .Where("CityId", obj.Id)
                    .Where("CityName", obj.Name)
                    .CreateCommand()
                    .ExecuteNonQuery();
            }
        }

        #endregion
    }
}