using System.Collections.Generic;
using System.Data.SQLite;
using Illallangi.LiteOrm;
using Ninject.Extensions.Logging;

namespace Illallangi.FlightLog.Context
{
    public abstract class SourceBase<T> : ISource<T> where T : class
    {
        private readonly ILogger currentLogger; 
        
        private readonly IConnectionSource currentConnectionSource;

        protected SourceBase(ILogger logger, IConnectionSource connectionSource)
        {
            this.currentLogger = logger;
            this.currentConnectionSource = connectionSource;
        }

        protected ILogger Logger
        {
            get { return this.currentLogger; }
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