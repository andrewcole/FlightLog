using System.Collections.Generic;
using System.Linq;
using Illallangi.FlightLog.Model;
using Illallangi.LiteOrm;
using Ninject.Extensions.Logging;

namespace Illallangi.FlightLog.Context
{
    public sealed class CityRepository : RepositoryBase<ICity>
    {
        #region Fields

        private readonly IRepository<ICountry> currentCountryRepository;

        #endregion

        #region Constructor

        public CityRepository(ILogger logger, IConnectionSource connectionSource, IRepository<ICountry> countryRepository)
            : base(logger, connectionSource)
        {
            this.Logger.Debug(@"CityRepository(""{0}"",""{1}"",""{2}"")", logger, connectionSource, countryRepository);
            this.currentCountryRepository = countryRepository;
        }

        #endregion

        #region Properties

        private IRepository<ICountry> CountryRepository
        {
            get
            {
                return this.currentCountryRepository;
            }
        }

        #endregion

        #region Methods

        public override ICity Create(ICity obj)
        {
            this.Logger.Debug(@"CityRepository.Create(""{0}"")", obj);

            var country = this.CountryRepository.Retrieve(new Country { Name = obj.Country }).Single();

            var id = this.GetConnection()
                .InsertInto("City")
                .Values("CountryId", country.Id)
                .Values("CityName", obj.Name)
                .Go();

            return this.Retrieve(new City { Id = id }).Single();
        }

        public override IEnumerable<ICity> Retrieve(ICity obj = null)
        {
            this.Logger.Debug(@"CityRepository.Retrieve(""{0}"")", obj);

            return this.GetConnection()
                .Select<City>("Cities")
                .Column("CityId", (city, value) => city.Id = value, null == obj ? null : obj.Id)
                .Column("CountryName", (city, value) => city.Country = value, null == obj ? null : obj.Country)
                .Column("CityName", (city, value) => city.Name = value, null == obj ? null : obj.Name)
                .Column("AirportCount", (city, value) => city.AirportCount = value)
                .Go();
        }

        public override ICity Update(ICity obj)
        {
            this.Logger.Debug(@"CityRepository.Update(""{0}"")", obj);

            throw new System.NotImplementedException();
        }

        public override void Delete(ICity obj)
        {
            this.Logger.Debug(@"CityRepository.Delete(""{0}"")", obj);

            this.GetConnection()
                .DeleteFrom("City")
                .Where("CityId", obj.Id)
                .Where("City", obj.Name)
                .CreateCommand()
                .ExecuteNonQuery();
        }

        #endregion
    }
}