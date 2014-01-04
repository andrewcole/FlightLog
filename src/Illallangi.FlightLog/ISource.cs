using System.Collections.Generic;

namespace Illallangi.FlightLog
{
    public interface ISource<T> where T : class 
    {
        T Create(T obj);

        IEnumerable<T> Retrieve(T obj = null);

        void Delete(T obj);
    }
}