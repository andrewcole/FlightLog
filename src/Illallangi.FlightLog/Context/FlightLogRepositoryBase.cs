namespace Illallangi.FlightLog.Context
{
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Linq;

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

        public override int Import(params T[] objs)
        {
            using (var cx = this.GetConnection())
            {
                return this.Import(cx, objs);
            }
        }

        private int Import(SQLiteConnection cx, params T[] objs)
        {
            using (var tx = cx.BeginTransaction())
            {
                var result = this.Import(cx, tx, objs);
                tx.Commit();
                return result;
            }
        }

        protected abstract int Import(SQLiteConnection cx, SQLiteTransaction tx, params T[] objs);

        public override IEnumerable<T> Create(params T[] objs)
        {
            this.Import(objs);
            return objs.Select(obj => this.Retrieve(obj).Single());
        }

        public abstract override void Delete(params T[] objs);

        public abstract override IEnumerable<T> Retrieve(T obj = null);

        public abstract override T Update(T obj);
    }
}