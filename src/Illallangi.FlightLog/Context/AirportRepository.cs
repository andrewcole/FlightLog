using System;
using System.Collections.Generic;
using System.Linq;

using Common.Logging;

using Illallangi.FlightLog.Config;
using Illallangi.FlightLog.Model;
using Illallangi.LiteOrm;

namespace Illallangi.FlightLog.Context
{
    public class AirportRepository : RepositoryBase<IAirport>
    {
        #region Fields

        private readonly IRepository<ICity> currentCityRepository;

        private readonly IRepository<ITimezone> currentTimezoneRepository;

        #endregion

        #region Constructor

        public AirportRepository(
            IFlightLogConfig flightLogConfig, 
            IRepository<ICity> cityRepository, 
            IRepository<ITimezone> timezoneRepository, 
            ILog log = null)
        : base(
            flightLogConfig.DatabasePath,
            flightLogConfig.ConnectionString,
            flightLogConfig.SqlSchemaLines,
            flightLogConfig.SqlSchemaFiles,
            flightLogConfig.Pragmas,
            flightLogConfig.Extensions,
            log)
        {
            this.Log.DebugFormat(
                @"AirportRepository(""{0}"", ""{1}"", ""{2}"",  ""{3}"")",
                flightLogConfig,
                cityRepository,
                timezoneRepository,
                log);
            this.currentCityRepository = cityRepository;
            this.currentTimezoneRepository = timezoneRepository;
        }

        #endregion

        #region Properties

        private IRepository<ICity> CityRepository
        {
            get { return this.currentCityRepository; }
        }

        private IRepository<ITimezone> TimezoneRepository
        {
            get { return this.currentTimezoneRepository; }
        }

        #endregion

        #region Methods

        public override IAirport Create(IAirport obj)
        {
            this.Log.DebugFormat(@"AirportRepository.Create(""{0}"")", obj);

            var city = this.CityRepository.Retrieve(new City { Name = obj.City, Country = obj.Country }).Single();
            var timezone = this.TimezoneRepository.Retrieve(new Timezone { Name = obj.Timezone }).Single();

            var id = this.GetConnection()
                .InsertInto("Airport")
                .Values("CityId", city.Id)
                .Values("TimezoneId", timezone.Id)
                .Values("AirportName", obj.Name)
                .Values("Iata", obj.Iata)
                .Values("Icao", obj.Icao)
                .Values("Latitude", obj.Latitude)
                .Values("Longitude", obj.Longitude)
                .Values("Altitude", obj.Altitude)
                .Go();

            return this.Retrieve(new Airport { Id = id }).Single();
        }

        public override IEnumerable<IAirport> Retrieve(IAirport obj = null)
        {
            this.Log.DebugFormat(@"AirportRepository.Retrieve(""{0}"")", obj);

            return this.GetConnection()
                .Select<Airport>("Airports")
                .Column("AirportId", (airport, value) => airport.Id = value, null == obj ? null : obj.Id)
                .Column("CountryName", (airport, value) => airport.Country = value, null == obj ? null : obj.Country)
                .Column("CityName", (airport, value) => airport.City = value, null == obj ? null : obj.City)
                .Column("TimezoneName", (airport, value) => airport.Timezone = value)
                .Column("AirportName", (airport, value) => airport.Name = value, null == obj ? null : obj.Name)
                .Column("Iata", (airport, value) => airport.Iata = value, null == obj ? null : obj.Iata)
                .Column("Icao", (airport, value) => airport.Icao = value, null == obj ? null : obj.Icao)
                .FloatColumn("Latitude", (airport, value) => airport.Latitude = value)
                .FloatColumn("Longitude", (airport, value) => airport.Longitude = value)
                .FloatColumn("Altitude", (airport, value) => airport.Altitude = value)
                .Go();
        }

        public override IAirport Update(IAirport obj)
        {
            this.Log.DebugFormat(@"AirportRepository.Update(""{0}"")", obj);

            throw new NotImplementedException();
        }

        public override void Delete(IAirport obj)
        {
            this.Log.DebugFormat(@"AirportRepository.Delete(""{0}"")", obj);

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