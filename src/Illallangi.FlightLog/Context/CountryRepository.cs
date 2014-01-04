using System.Collections.Generic;
using Illallangi.FlightLog.Model;
using Illallangi.LiteOrm;

namespace Illallangi.FlightLog.Context
{
    public sealed class CountryRepository : SourceBase<Country>
    {
        public CountryRepository(IConnectionSource connectionSource)
            : base(connectionSource)
        {
        }

        public override Country Create(Country obj)
        {
            this.GetConnection()
                .InsertInto("Country")
                .Values("CountryName", obj.Name)
                .CreateCommand()
                .ExecuteNonQuery();

            return null;
        }

        public override IEnumerable<Country> Retrieve(Country obj)
        {
            return this.GetConnection()
                        .Select<Country>("Countries")
                        .Column("CountryId", (input, value) => input.Id = value, null == obj ? null : obj.Id)
                        .Column("CountryName", (input, value) => input.Name = value, null == obj ? null : obj.Name)
                        .Column("Cities", (input, value) => input.Cities = value)
                        .Column("Airports", (input, value) => input.Airports = value)
                        .Go();
        }

        public override void Delete(Country country)
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