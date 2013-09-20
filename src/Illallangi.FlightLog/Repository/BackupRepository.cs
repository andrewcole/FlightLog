using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.Repository
{
    public class BackupRepository
    {
        #region Constructor

        public BackupRepository()
            : this(new List<Country>(), new List<City>(), new List<Airport>(), new List<Airline>())
        {
        }

        public BackupRepository(List<Country> Country, List<City> City, List<Airport> Airport, List<Airline> Airline)
        {
            this.Country = Country;
            this.City = City;
            this.Airport = Airport;
            this.Airline = Airline;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public void ToFile(string fileName)
        {
            File.WriteAllText(this.ToString(), fileName);
        }

        public static BackupRepository FromDatabase()
        {
            return new BackupRepository(new CountryRepository().Retrieve().ToList(), new CityRepository().Retrieve().ToList(), new AirportRepository().Retrieve().ToList(), new AirlineRepository().Retrieve().ToList());
        }

        public static BackupRepository FromString(string value)
        {
            return JsonConvert.DeserializeObject<BackupRepository>(value);
        }

        public static BackupRepository FromFile(string fileName)
        {
            return BackupRepository.FromString(File.ReadAllText(fileName));
        }

        #endregion

        #region Properties

        public List<Country> Country { get; private set; }

        public List<City> City { get; private set; }

        public List<Airport> Airport { get; private set; }

        public List<Airline> Airline { get; private set; }

        #endregion
    }
}