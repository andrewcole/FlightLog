using System.Collections.Generic;
using System.Linq;
using Illallangi.FlightLog.Model;
using Illallangi.LiteOrm;

namespace Illallangi.FlightLog.Context
{
    public sealed class AirportRepository : SourceBase<Airport>
    {
        private readonly ISource<City> currentCitySource;

        public AirportRepository(IConnectionSource connectionSource, ISource<City> citySource)
            : base(connectionSource)
        {
            this.currentCitySource = citySource;
        }

        private ISource<City> CitySource
        {
            get
            {
                return this.currentCitySource;
            }
        }

        public override Airport Create(Airport obj)
        {
            var city = this.CitySource.Retrieve(new City { Name = obj.City, CountryName = obj.Country }).Single();

            this.GetConnection()
                .InsertInto("Airport")
                .Values("AirportName", obj.Name)
                .Values("CityId", city.Id)
                .Values("Iata", obj.Iata)
                .Values("Icao", obj.Icao)
                .Values("Latitude", obj.Latitude)
                .Values("Longitude", obj.Longitude)
                .Values("Altitude", obj.Altitude)
                .Values("Timezone", obj.Timezone)
                .CreateCommand()
                .ExecuteNonQuery();

            return null;
        }

        public override IEnumerable<Airport> Retrieve(Airport obj)
        {
            return this.GetConnection()
                .Select<Airport>("Airports")
                .Column("Country", (input, value) => input.Country = value, null == obj ? null : obj.Country)
                .Column("City", (input, value) => input.City = value, null == obj ? null : obj.City)
                .Column("AirportId", (input, value) => input.Id = value, null == obj ? null : obj.Id)
                .Column("AirportName", (input, value) => input.Name = value, null == obj ? null : obj.Name)
                .Column("Iata", (input, value) => input.Iata = value, null == obj ? null : obj.Iata)
                .Column("Icao", (input, value) => input.Icao = value, null == obj ? null : obj.Icao)
                .FloatColumn("Latitude", (input, value) => input.Latitude = value)
                .FloatColumn("Longitude", (input, value) => input.Longitude = value)
                .FloatColumn("Altitude", (input, value) => input.Altitude = value)
                .Column("Timezone", (input, value) => input.Timezone = value)
                .Go();
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