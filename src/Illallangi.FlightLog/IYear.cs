namespace Illallangi.FlightLog
{
    public interface IYear
    {
        int? Id { get; }

        string Name { get; }

        int TripCount { get; }
    }
}