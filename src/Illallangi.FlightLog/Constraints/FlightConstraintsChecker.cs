namespace Illallangi.FlightLog.Constraints
{
    using System.Collections.Generic;
    using System.Linq;

    using Illallangi.FlightLog.Model;

    public class FlightConstraintsChecker : IConstraintsChecker<IFlight>
    {
        public IEnumerable<string> GetErrors(IFlight newObject, params IEnumerable<IFlight>[] sets)
        {
            if (sets.SelectMany(s => s).Any(a => a.Year.Equals(newObject.Year) && a.Trip.Equals(newObject.Trip) && a.Origin.Equals(newObject.Origin) && a.Destination.Equals(newObject.Destination)))
            {
                yield return string.Format(@"{0} ({1}) already has a flight from {2} to {3}", newObject.Year, newObject.Trip, newObject.Origin, newObject.Destination);
            }
        }

        public bool HasErrors(IFlight newObject, params IEnumerable<IFlight>[] sets)
        {
            return this.GetErrors(newObject, sets).Any();
        }
    }
}