using System.Data.SQLite;
using Illallangi.LiteOrm;

namespace Illallangi.FlightLog.Context
{
    public abstract class SourceBase
    {
        private readonly IConnectionSource currentConnectionSource;

        protected SourceBase(IConnectionSource connectionSource)
        {
            this.currentConnectionSource = connectionSource;
        }

        private IConnectionSource ConnectionSource
        {
            get
            {
                return this.currentConnectionSource;
            }
        }

        protected SQLiteConnection GetConnection()
        {
            return this.ConnectionSource.GetConnection();
        }
    }
}