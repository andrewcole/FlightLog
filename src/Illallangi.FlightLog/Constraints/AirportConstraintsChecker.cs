namespace Illallangi.FlightLog.Constraints
{
    using System.Collections.Generic;
    using System.Linq;

    using Illallangi.FlightLog.Model;

    public class AirportConstraintsChecker : IConstraintsChecker<IAirport>
    {
        public IEnumerable<string> GetErrors(IAirport newObject, params IEnumerable<IAirport>[] sets)
        {
            if (sets.SelectMany(s => s).Any(a => a.Icao.Equals(newObject.Icao)))
            {
                yield return string.Format(@"ICAO {0} already exists", newObject.Icao);
            }

            if (sets.SelectMany(s => s).Any(a => a.Iata.Equals(newObject.Iata)))
            {
                yield return string.Format(@"IATA {0} already exists", newObject.Iata);
            }

            if (sets.SelectMany(s => s).Any(a => a.Latitude.Equals(newObject.Latitude) && a.Longitude.Equals(newObject.Longitude)))
            {
                yield return
                    string.Format("An airport already exists at {0}x{1}", newObject.Latitude, newObject.Longitude);
            }

            if (sets.SelectMany(s => s).Any(a => a.Country.Equals(newObject.Country) && a.City.Equals(newObject.City) && a.Name.Equals(newObject.Name)))
            {
                yield return
                    string.Format(
                        "{0}, {1} already has an airport named {2}",
                        newObject.City,
                        newObject.Country,
                        newObject.Name);
            }
        }

        public bool HasErrors(IAirport newObject, params IEnumerable<IAirport>[] sets)
        {
            return this.GetErrors(newObject, sets).Any();
        }
    }
}