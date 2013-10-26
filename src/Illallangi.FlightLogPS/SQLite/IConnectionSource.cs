using System.Data.SQLite;

namespace Illallangi.FlightLogPS.SQLite
{
    public interface IConnectionSource
    {
        SQLiteConnection GetConnection();
    }
}