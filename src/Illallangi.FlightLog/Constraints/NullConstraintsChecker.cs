namespace Illallangi.FlightLog.Constraints
{
    using System.Collections.Generic;

    public class NullConstraintsChecker<T> : IConstraintsChecker<T>
    {
        public IEnumerable<string> GetErrors(T newObject, params IEnumerable<T>[] sets)
        {
            yield break;
        }

        public bool HasErrors(T newObject, params IEnumerable<T>[] sets)
        {
            return false;
        }
    }
}