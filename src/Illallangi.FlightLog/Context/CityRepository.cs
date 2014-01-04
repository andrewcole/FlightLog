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

            var id = this.GetConnection()
                .InsertInto("City")
                .Values("CountryId", country.Id)
                .Values("CityName", obj.Name)
                .Go();

            return this.Retrieve(new City { Id = id }).Single();
        }

        public override IEnumerable<City> Retrieve(City obj = null)
        {
            return this.GetConnection()
           .Select<City>("Cities")
           .Column("CityId", (city, value) => city.Id = value, null == obj ? null : obj.Id)
           .Column("CountryName", (city, value) => city.Country = value, null == obj ? null : obj.Country)
           .Column("CityName", (city, value) => city.Name = value, null == obj ? null : obj.Name)
           .Column("AirportCount", (city, value) => city.AirportCount = value)
           .Go();
        }

        public override City Update(City obj)
        {
            throw new System.NotImplementedException();
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