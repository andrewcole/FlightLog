using System.Collections.Generic;

namespace Illallangi.FlightLogPS.Config
{
    public interface IConfig
    {
        string DbPath { get; }
        string ConnectionString { get; }
        IEnumerable<string> Extensions { get; }
        IEnumerable<string> Pragmas { get; } 
        IEnumerable<string> SqlSchema { get; }
    }
}