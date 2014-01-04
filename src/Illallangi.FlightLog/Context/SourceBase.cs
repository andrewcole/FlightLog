using System.Collections.Generic;
using System.Data.SQLite;
using Illallangi.LiteOrm;

namespace Illallangi.FlightLog.Context
{
    public abstract class SourceBase<T> : ISource<T> where T : class
    {
        private readonly IConnectionSource currentConnectionSource;

        protected SourceBase(IConnectionSource connectionSource)
        {
            this.currentConnectionSource = connectionSource;
        }

        private IConnectionSource ConnectionSource
        {
            get { return this.currentConnectionSource; }
        }

        protected SQLiteConnection GetConnection()
        {
            return this.ConnectionSource.GetConnection();
        }

        public abstract T Create(T obj);

        public abstract IEnumerable<T> Retrieve(T obj);

        public abstract void Delete(T obj);
    }
}