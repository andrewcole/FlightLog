using System.Collections.Generic;
using System.Linq;
using Illallangi.FlightLog.Model;
using Illallangi.LiteOrm;

namespace Illallangi.FlightLog.Context
{
    public sealed class CityRepository : ZumeroRepository, ICitySource
    {
        private readonly ICountrySource currentCountrySource;

        public CityRepository(IConnectionSource connectionSource, ICountrySource countrySource)
            : base(connectionSource)
        {
            this.currentCountrySource = countrySource;
        }

        private ICountrySource CountrySource
        {
            get
            {
                return this.currentCountrySource;
            }
        }

        public City Create(City obj)
        {
            var country = this.CountrySource.Retrieve(new Country { Name = obj.CountryName }).Single();

            this.GetConnection()
                .InsertInto("City")
                .Values("CityName", obj.Name)
                .Values("CountryId", country.Id)
                .CreateCommand()
                .ExecuteNonQuery();

            return null;
        }

        public IEnumerable<City> Retrieve(City obj)
        {
            return this.GetConnection()
                        .Select<City>("Cities")
                        .Column("CityId", (input, value) => input.Id = value, null == obj ? null : obj.Id)
                        .Column("CityName", (input, value) => input.Name = value, null == obj ? null : obj.Name)
                        .Column("CountryId", (input, value) => input.CountryId = value, null == obj ? null : obj.CountryId)
                        .Column("CountryName", (input, value) => input.CountryName = value, null == obj ? null : obj.CountryName)
                        .Column("Airports", (input, value) => input.Airports = value, null == obj ? null : obj.Airports)
                        .Go();
        }

        public void Delete(City obj)
        {
            this.GetConnection()
                .DeleteFrom("City")
                .Where("CityId", obj.Id)
                .Where("CityName", obj.Name)
                .Where("CountryId", obj.CountryId)
                .CreateCommand()
                .ExecuteNonQuery();
        }
    }
}