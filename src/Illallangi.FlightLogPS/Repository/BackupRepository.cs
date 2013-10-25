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
            : this(new List<Flight>(), new List<Airport>(), new List<Airline>())
        {
        }

        public BackupRepository(List<Flight> Flight, List<Airport> Airport, List<Airline> Airline)
        {
            this.Flight = Flight;
            this.Airport = Airport;
            this.Airline = Airline;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return this.ToString(true);
        }

        public string ToString(bool indent)
        {
            return JsonConvert.SerializeObject(this, indent ? Formatting.Indented : Formatting.None);
        }

        public void ToFile(string fileName, bool indent = true)
        {
            File.WriteAllText(fileName, this.ToString(indent));
        }

        public static BackupRepository FromDatabase()
        {
            return new BackupRepository(new FlightRepository().Retrieve().ToList(), new AirportRepository().Retrieve().ToList(), new AirlineRepository().Retrieve().ToList());
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

        public List<Flight> Flight { get; private set; }

        public List<Airport> Airport { get; private set; }

        public List<Airline> Airline { get; private set; }

        #endregion
    }
}