namespace Illallangi.FlightLog
{
    public interface ICity
    {
        int? Id { get; set; }

        string Country { get; set; }

        string Name { get; set; }

        int AirportCount { get; set; }
    }
}