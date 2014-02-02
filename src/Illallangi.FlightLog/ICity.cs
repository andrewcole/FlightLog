namespace Illallangi.FlightLog
{
    public interface ICity
    {
        int? Id { get; }

        string Country { get; }

        string Name { get; }

        int AirportCount { get; }
    }
}