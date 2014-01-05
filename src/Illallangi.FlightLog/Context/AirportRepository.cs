using System;
using System.Collections.Generic;
using System.Linq;
using Illallangi.FlightLog.Model;
using Illallangi.LiteOrm;
using Ninject.Extensions.Logging;

namespace Illallangi.FlightLog.Context
{
    public class AirportRepository : RepositoryBase<IAirport>
    {
        #region Fields

        private readonly IRepository<ICity> currentCityRepository;

        #endregion

        #region Constructor

        public AirportRepository(ILogger logger, IConnectionSource connectionSource, IRepository<ICity> cityRepository)
            : base(logger, connectionSource)
        {
            this.Logger.Debug(@"AirportRepository(""{0}"",""{1}"",""{2}"")", logger, connectionSource, cityRepository);
            this.currentCityRepository = cityRepository;
        }

        #endregion

        #region Properties

        private IRepository<ICity> CityRepository
        {
            get { return this.currentCityRepository; }
        }

        #endregion

        #region Methods

        public override IAirport Create(IAirport obj)
        {
            this.Logger.Debug(@"AirportRepository.Create(""{0}"")", obj);

            var city = this.CityRepository.Retrieve(new City { Name = obj.City, Country = obj.Country }).Single();

            var id = this.GetConnection()
                .InsertInto("Airport")
                .Values("CityId", city.Id)
                .Values("AirportName", obj.Name)
                .Values("Iata", obj.Iata)
                .Values("Icao", obj.Icao)
                .Values("Latitude", obj.Latitude)
                .Values("Longitude", obj.Longitude)
                .Values("Altitude", obj.Altitude)
                .Values("Timezone", obj.Timezone)
                .Go();

            return this.Retrieve(new Airport { Id = id }).Single();
        }

        public override IEnumerable<IAirport> Retrieve(IAirport obj = null)
        {
            this.Logger.Debug(@"AirportRepository.Retrieve(""{0}"")", obj);

            return this.GetConnection()
                .Select<Airport>("Airports")
                .Column("AirportId", (airport, value) => airport.Id = value, null == obj ? null : obj.Id)
                .Column("CountryName", (airport, value) => airport.Country = value, null == obj ? null : obj.Country)
                .Column("CityName", (airport, value) => airport.City = value, null == obj ? null : obj.City)
                .Column("AirportName", (airport, value) => airport.Name = value, null == obj ? null : obj.Name)
                .Column("Iata", (airport, value) => airport.Iata = value, null == obj ? null : obj.Iata)
                .Column("Icao", (airport, value) => airport.Icao = value, null == obj ? null : obj.Icao)
                .FloatColumn("Latitude", (airport, value) => airport.Latitude = value)
                .FloatColumn("Longitude", (airport, value) => airport.Longitude = value)
                .FloatColumn("Altitude", (airport, value) => airport.Altitude = value)
                .Column("Timezone", (airport, value) => airport.Timezone = value)
                .Go();
        }

        public override IAirport Update(IAirport obj)
        {
            this.Logger.Debug(@"AirportRepository.Update(""{0}"")", obj);

            throw new NotImplementedException();
        }

        public override void Delete(IAirport obj)
        {
            this.Logger.Debug(@"AirportRepository.Delete(""{0}"")", obj);

            this.GetConnection()
                .DeleteFrom("Airport")
                .Where("AirportId", obj.Id)
                .Where("AirportName", obj.Name)
                .Where("Iata", obj.Iata)
                .Where("Icao", obj.Icao)
                .Where("Latitude", obj.Latitude)
                .Where("Longitude", obj.Longitude)
                .Where("Altitude", obj.Altitude)
                .Where("Timezone", obj.Timezone)
                .CreateCommand()
                .ExecuteNonQuery();
        }

        #endregion
    }
}