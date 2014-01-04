﻿using System.Collections.Generic;
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
                .Values("Country", obj.Name)
                .CreateCommand()
                .ExecuteNonQuery();

            return null;
        }

        public override IEnumerable<Country> Retrieve(Country obj)
        {
            return this.GetConnection()
                        .Select<Country>("Countries")
                        .Column("CountryId", (input, value) => input.Id = value, null == obj ? null : obj.Id)
                        .Column("Country", (input, value) => input.Name = value, null == obj ? null : obj.Name)
                        .Column("Cities", (input, value) => input.CityCount = value)
                        .Go();
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