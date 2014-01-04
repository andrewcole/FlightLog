using System;
using System.Collections.Generic;
using System.Linq;
using Illallangi.FlightLog.Model;
using Illallangi.LiteOrm;
using Ninject.Extensions.Logging;

namespace Illallangi.FlightLog.Context
{
    public class AirportRepository : SourceBase<Airport>
    {
        private readonly ISource<City> currentCitySource;

        public AirportRepository(ILogger logger, IConnectionSource connectionSource, ISource<City> citySource)
            : base(logger, connectionSource)
        {
            this.Logger.Debug(@"AirportSource(""{0}"",""{1}"",""{2}"")", logger, connectionSource, citySource);
            this.currentCitySource = citySource;
        }

        private ISource<City> CitySource
        {
            get { return this.currentCitySource; }
        }

        public override Airport Create(Airport obj)
        {
            this.Logger.Debug(@"AirportSource.Create(""{0}"")", obj);
            var city = this.CitySource.Retrieve(new City { Name = obj.City, Country = obj.Country }).Single();

            var id = this.GetConnection()
                .InsertInto("Airport")
                .Values("AirportName", obj.Name)
                .Values("CityId", city.Id)
                .Values("Iata", obj.Iata)
                .Values("Icao", obj.Icao)
                .Values("Latitude", obj.Latitude)
                .Values("Longitude", obj.Longitude)
                .Values("Altitude", obj.Altitude)
                .Values("Timezone", obj.Timezone)
                .Go();

            return this.Retrieve(new Airport { Id = id }).Single();
        }

        public override IEnumerable<Airport> Retrieve(Airport obj = null)
        {
            return this.GetConnection()
            .Select<Airport>("Airports")
            .Column("AirportId", (airport, value) => airport.Id = value, null == obj ? null : obj.Id)
            .Column("CountryName", (airport, value) => airport.Country = value, null == obj ? null : obj.Country)
            .Column("CityName", (airport, value) => airport.City = value, null == obj ? null : obj.City)
            .Column("Icao", (airport, value) => airport.Icao = value, null == obj ? null : obj.Icao)
            .Column("Iata", (airport, value) => airport.Iata = value, null == obj ? null : obj.Iata)
            .Column("AirportName", (airport, value) => airport.Name = value, null == obj ? null : obj.Name)
            .FloatColumn("Latitude", (airport, value) => airport.Latitude = value)
            .FloatColumn("Longitude", (airport, value) => airport.Longitude = value)
            .FloatColumn("Altitude", (airport, value) => airport.Altitude = value)
            .Column("Timezone", (airport, value) => airport.Timezone = value)
            .Go();
        }

        public override Airport Update(Airport obj)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Airport airport)
        {
            this.GetConnection()
                .DeleteFrom("Airport")
                .Where("AirportId", airport.Id)
                .Where("AirportName", airport.Name)
                .Where("Iata", airport.Iata)
                .Where("Icao", airport.Icao)
                .Where("Latitude", airport.Latitude)
                .Where("Longitude", airport.Longitude)
                .Where("Altitude", airport.Altitude)
                .Where("Timezone", airport.Timezone)
                .CreateCommand()
                .ExecuteNonQuery();
        }
    }
}