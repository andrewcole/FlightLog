using System.Data.SQLite;
using Illallangi.LiteOrm;

namespace Illallangi.FlightLogPS.Repository
{
    public interface IDebugHooks
    {
        event DebugEventHandler Debug;
    }

    public abstract class ZumeroRepository : IDebugHooks
    {
        private readonly IConnectionSource currentConnectionSource;

        protected ZumeroRepository(IConnectionSource connectionSource)
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

        public event DebugEventHandler Debug;


        protected virtual void OnDebug(string message, params object[] args)
        {
            this.OnDebug(new DebugEventArgs(message, args));
        }

        protected virtual void OnDebug(DebugEventArgs e)
        {
            var debug = this.Debug;
            if (null != debug)
            {
                debug(this, e);
            }
        }

    }

    public delegate void DebugEventHandler(object sender, DebugEventArgs args);

    public class DebugEventArgs
    {
        private readonly string currentMessage;

        public DebugEventArgs(string message, params object[] args)
        {
            this.currentMessage = string.Format(message, args);
        }

        public string Message
        {
            get
            {
                return this.currentMessage;
            }
        }
    }
}