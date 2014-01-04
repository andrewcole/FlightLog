using System.Collections.Generic;
using System.Linq;
using Illallangi.FlightLog.Model;
using Illallangi.LiteOrm;
using Ninject.Extensions.Logging;

namespace Illallangi.FlightLog.Context
{
    public sealed class CityRepository : SourceBase<City>
    {
        private readonly ISource<Country> currentCountrySource;

        public CityRepository(ILogger logger, IConnectionSource connectionSource, ISource<Country> countrySource) : base(logger, connectionSource)
        {
            this.Logger.Debug(@"CityRepository(""{0}"",""{1}"",""{2}"")", logger, connectionSource, countrySource);
            this.currentCountrySource = countrySource;
        }

        private ISource<Country> CountrySource
        {
            get
            {
                return this.currentCountrySource;
            }
        }

        public override City Create(City obj)
        {
            this.Logger.Debug(@"CityRepository.Create(""{0}"")", obj);
            var country = this.CountrySource.Retrieve(new Country { Name = obj.Country }).Single();

            this.GetConnection()
                .InsertInto("City")
                .Values("City", obj.Name)
                .Values("CountryId", country.Id)
                .CreateCommand()
                .ExecuteNonQuery();

            return null;
        }

        public override IEnumerable<City> Retrieve(City obj)
        {
            return this.GetConnection()
                        .Select<City>("Cities")
                        .Column("CityId", (input, value) => input.Id = value, null == obj ? null : obj.Id)
                        .Column("City", (input, value) => input.Name = value, null == obj ? null : obj.Name)
                        .Column("Country", (input, value) => input.Country = value, null == obj ? null : obj.Country)
                        .Column("AirportCount", (input, value) => input.AirportCount = value)
                        .Go();
        }

        public override void Delete(City obj)
        {
            this.GetConnection()
                .DeleteFrom("City")
                .Where("CityId", obj.Id)
                .Where("City", obj.Name)
                .CreateCommand()
                .ExecuteNonQuery();
        }
    }
}