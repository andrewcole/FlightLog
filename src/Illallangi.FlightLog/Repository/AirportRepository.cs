using System.Collections.Generic;
using System.Linq;
using Illallangi.FlightLog.Model;
using Illallangi.LiteOrm;


namespace Illallangi.FlightLog.Repository
{
    public sealed class AirportRepository : ZumeroRepository, IAirportSource
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

        public Airport CreateAirport(string name, string cityName, string countryName, string iata, string icao, float latitude,
            float longitude, float altitude, float timezone, string dst)
        {
            var city = this.CitySource.RetrieveCity(name: cityName, countryName: countryName).Single();

            this.GetConnection()
                .InsertInto("Airport")
                .Values("AirportName", name)
                .Values("CityId", city.Id)
                .Values("Iata", iata)
                .Values("Icao", icao)
                .Values("Latitude", latitude)
                .Values("Longitude", longitude)
                .Values("Altitude", altitude)
                .Values("Timezone", timezone)
                .Values("Dst", dst)
                .CreateCommand()
                .ExecuteNonQuery();

            return null;
        }

        public IEnumerable<Airport> RetrieveAirport(int? id, string name = null, string cityName = null, string countryName = null,
                    string iata = null, string icao = null, float? latitude = null, float? longitude = null, float? altitude = null,
                    float? timezone = null, string dst = null)
        {
            return this.GetConnection()
                .Select<Airport>("Airports")
                .Column("CountryId", (input, value) => input.CountryId = value)
                .Column("CountryName", (input, value) => input.CountryName = value, countryName)
                .Column("CityId", (input, value) => input.CityId = value)
                .Column("CityName", (input, value) => input.CityName = value, cityName)
                .Column("AirportId", (input, value) => input.Id = value, id)
                .Column("AirportName", (input, value) => input.Name = value, name)
                .Column("Iata", (input, value) => input.Iata = value, iata)
                .Column("Icao", (input, value) => input.Icao = value, icao)
                .FloatColumn("Latitude", (input, value) => input.Latitude = value, latitude)
                .FloatColumn("Longitude", (input, value) => input.Longitude = value, longitude)
                .FloatColumn("Altitude", (input, value) => input.Altitude = value, altitude)
                .FloatColumn("Timezone", (input, value) => input.Timezone = value, timezone)
                .Column("Dst", (input, value) => input.Dst = value, dst)
                .Go();
        }

        public void DeleteAirport(Airport airport)
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