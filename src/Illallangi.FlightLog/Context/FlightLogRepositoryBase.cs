namespace Illallangi.FlightLog.Context
{
    using System.Collections.Generic;

    using Common.Logging;

    using Illallangi.FlightLog.Config;
    using Illallangi.LiteOrm;

    public abstract class FlightLogRepositoryBase<T> : RepositoryBase<T> where T : class 
    {
        protected FlightLogRepositoryBase(
            IFlightLogConfig flightLogConfig, 
            ILog log = null)
        : base(
            flightLogConfig.DatabasePath,
            flightLogConfig.ConnectionString,
            flightLogConfig.SqlSchemaLines,
            flightLogConfig.SqlSchemaFiles,
            flightLogConfig.Pragmas,
            flightLogConfig.Extensions,
            log)
        {
        }

        public abstract override IEnumerable<T> Create(params T[] objs);

        public abstract override void Delete(params T[] objs);

        public abstract override IEnumerable<T> Retrieve(T obj = null);

        public abstract override T Update(T obj);
    }
}