namespace Illallangi.FlightLog.Constraints
{
    using System.Collections.Generic;

    public interface IConstraintsChecker<in T>
    {
        IEnumerable<string> GetErrors(T newObject, params IEnumerable<T>[] sets);

        bool HasErrors(T newObject, params IEnumerable<T>[] sets);
    }
}