using System.Collections.Generic;
using Illallangi.FlightLog.Model;
using Illallangi.LiteOrm;

namespace Illallangi.FlightLog.Context
{
    public sealed class CountryRepository : ZumeroRepository, ICountrySource
    {
        public CountryRepository(IConnectionSource connectionSource)
            : base(connectionSource)
        {
        }

        public Country Create(string name)
        {
            this.GetConnection()
                .InsertInto("Country")
                .Values("CountryName", name)
                .CreateCommand()
                .ExecuteNonQuery();

            return null;
        }

        public IEnumerable<Country> Retrieve(int? id = null, string name = null)
        {
            return this.GetConnection()
                        .Select<Country>("Countries")
                        .Column("CountryId", (input, value) => input.Id = value, id)
                        .Column("CountryName", (input, value) => input.Name = value, name)
                        .Column("Cities", (input, value) => input.Cities = value)
                        .Column("Airports", (input, value) => input.Airports = value)
                        .Go();
        }

        public void Delete(Country country)
        {
            this.GetConnection()
                .DeleteFrom("Country")
                .Where("CountryId", country.Id)
                .Where("CountryName", country.Name)
                .CreateCommand()
                .ExecuteNonQuery();
        }
    }
}