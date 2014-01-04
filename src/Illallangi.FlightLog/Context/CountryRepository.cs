using System.Collections.Generic;
using Illallangi.FlightLog.Model;
using Illallangi.LiteOrm;
using Ninject.Extensions.Logging;

namespace Illallangi.FlightLog.Context
{
    public sealed class CountryRepository : SourceBase<Country>
    {
        public CountryRepository(ILogger logger, IConnectionSource connectionSource) : base(logger, connectionSource)
        {
            this.Logger.Debug(@"CountrySource(""{0}"",""{1}"")", logger, connectionSource);
        }

        public override Country Create(Country obj)
        {
            this.Logger.Debug(@"CountrySource.Create(""{0}"")", obj);
            
            this.GetConnection()
                .InsertInto("Country")
                .Values("Country", obj.Name)
                .CreateCommand()
                .ExecuteNonQuery();

            return null;
        }

        public override IEnumerable<Country> Retrieve(Country obj = null)
        {
            return this.GetConnection()
                        .Select<Country>("Countries")
                        .Column("CountryId", (input, value) => input.Id = value, null == obj ? null : obj.Id)
                        .Column("Country", (input, value) => input.Name = value, null == obj ? null : obj.Name)
                        .Column("Cities", (input, value) => input.CityCount = value)
                        .Go();
        }

        public override Country Update(Country obj)
        {
            throw new System.NotImplementedException();
        }

        public override void Delete(Country country)
        {
            this.GetConnection()
                .DeleteFrom("Country")
                .Where("CountryId", country.Id)
                .Where("Country", country.Name)
                .CreateCommand()
                .ExecuteNonQuery();
        }
    }
}