namespace Illallangi.FlightLog.Constraints
{
    using System.Collections.Generic;
    using System.Linq;

    public class TripConstraintsChecker : IConstraintsChecker<ITrip>
    {
        public IEnumerable<string> GetErrors(ITrip newObject, params IEnumerable<ITrip>[] sets)
        {
            if (sets.SelectMany(s => s).Any(a => a.Year.Equals(newObject.Year) && a.Name.Equals(newObject.Name)))
            {
                yield return
                    string.Format("Trip {1} ({0}) already exists", newObject.Year, newObject.Name);
            }
        }

        public bool HasErrors(ITrip newObject, params IEnumerable<ITrip>[] sets)
        {
            return this.GetErrors(newObject, sets).Any();
        }
    }
}