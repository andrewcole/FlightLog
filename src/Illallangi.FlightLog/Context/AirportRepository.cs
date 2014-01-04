using System.Collections.Generic;
using System.Linq;
using Illallangi.FlightLog.Model;
using Illallangi.LiteOrm;

namespace Illallangi.FlightLog.Context
{
    public sealed class AirportRepository : SourceBase, IAirportSource
    {
        private readonly ICitySource currentCitySource;

        public AirportRepository(IConnectionSource connectionSource, ICitySource citySource)
            : base(connectionSource)
        {
            this.currentCitySource = citySource;
        }

        private ICitySource CitySource
        {
            get
            {
                return this.currentCitySource;
            }
        }

        public Airport Create(Airport obj)
        {
            var city = this.CitySource.Retrieve(new City { Name = obj.CityName, CountryName = obj.CountryName }).Single();

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
                .Values("Dst", obj.Dst)
                .CreateCommand()
                .ExecuteNonQuery();

            return null;
        }

        public IEnumerable<Airport> Retrieve(Airport obj)
        {
            return this.GetConnection()
                .Select<Airport>("Airports")
                .Column("CountryId", (input, value) => input.CountryId = value)
                .Column("CountryName", (input, value) => input.CountryName = value, null == obj ? null : obj.CountryName)
                .Column("CityId", (input, value) => input.CityId = value)
                .Column("CityName", (input, value) => input.CityName = value, null == obj ? null : obj.CityName)
                .Column("AirportId", (input, value) => input.Id = value, null == obj ? null : obj.Id)
                .Column("AirportName", (input, value) => input.Name = value, null == obj ? null : obj.Name)
                .Column("Iata", (input, value) => input.Iata = value, null == obj ? null : obj.Iata)
                .Column("Icao", (input, value) => input.Icao = value, null == obj ? null : obj.Icao)
                .FloatColumn("Latitude", (input, value) => input.Latitude = value)
                .FloatColumn("Longitude", (input, value) => input.Longitude = value)
                .FloatColumn("Altitude", (input, value) => input.Altitude = value)
                .FloatColumn("Timezone", (input, value) => input.Timezone = value)
                .Column("Dst", (input, value) => input.Dst = value, null == obj ? null : obj.Dst)
                .Go();
        }

        public void Delete(Airport airport)
        {
            this.GetConnection()
                .DeleteFrom("Airport")
                .Where("AirportId", airport.Id)
                .Where("CityId", airport.CityId)
                .Where("AirportName", airport.Name)
                .Where("Iata", airport.Iata)
                .Where("Icao", airport.Icao)
                .Where("Latitude", airport.Latitude)
                .Where("Longitude", airport.Longitude)
                .Where("Altitude", airport.Altitude)
                .Where("Timezone", airport.Timezone)
                .Where("Dst", airport.Dst)
                .CreateCommand()
                .ExecuteNonQuery();
        }
    }
}