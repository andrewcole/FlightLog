using System.Collections.Generic;
using System.Linq;
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
            
            var id = this.GetConnection()
                         .InsertInto("Country")
                         .Values("CountryName", obj.Name)
                         .Go();

            return this.Retrieve(new Country { Id = id }).Single();
        }

        public override IEnumerable<Country> Retrieve(Country obj = null)
        {
            return this.GetConnection()
                       .Select<Country>("Countries")
                       .Column("CountryId", (country, value) => country.Id = value, null == obj ? null : obj.Id)
                       .Column("CountryName", (country, value) => country.Name = value, null == obj ? null : obj.Name)
                       .Column("CityCount", (country, value) => country.CityCount = value)
                       .Go();
        }

        public override Country Update(Country obj)
        {
            throw new System.NotImplementedException();
        }

        public override void Delete(Country obj)
        {
            this.GetConnection()
                .DeleteFrom("Country")
                .Where("CountryId", obj.Id)
                .Where("Country", obj.Name)
                .CreateCommand()
                .ExecuteNonQuery();
        }
    }
}