namespace Illallangi.FlightLog.Config
{
    using System.Collections.Generic;

    public interface IFlightLogConfig
    {
        string DatabasePath { get; }
        string ConnectionString { get; }
        IEnumerable<string> SqlSchemaLines { get; }
        IEnumerable<string> SqlSchemaFiles { get; }
        IEnumerable<string> Pragmas { get; }
        IEnumerable<string> Extensions { get; }
    }
}