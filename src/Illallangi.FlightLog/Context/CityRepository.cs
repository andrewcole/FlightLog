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

        public City Create(string name, string countryName)
        {
            var country = this.CountrySource.Retrieve(new Country { Name = countryName }).Single();

            this.GetConnection()
                .InsertInto("City")
                .Values("CityName", name)
                .Values("CountryId", country.Id)
                .CreateCommand()
                .ExecuteNonQuery();

            return null;
        }

        public IEnumerable<City> Retrieve(int? id = null, string name = null, string countryName = null)
        {
            return this.GetConnection()
                        .Select<City>("Cities")
                        .Column("CityId", (input, value) => input.Id = value, id)
                        .Column("CityName", (input, value) => input.Name = value, name)
                        .Column("CountryId", (input, value) => input.CountryId = value)
                        .Column("CountryName", (input, value) => input.CountryName = value, countryName)
                        .Column("Airports", (input, value) => input.Airports = value)
                        .Go();
        }

        public void Delete(City city)
        {
            this.GetConnection()
                .DeleteFrom("City")
                .Where("CityId", city.Id)
                .Where("CityName", city.Name)
                .Where("CountryId", city.CountryId)
                .CreateCommand()
                .ExecuteNonQuery();
        }
    }
}