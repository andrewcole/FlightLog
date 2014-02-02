namespace Illallangi.FlightLog
{
    public interface ITimezone
    {
        int? Id { get; set; }

        string Name { get; set; }

        int AirportCount { get; set; }
    }
}