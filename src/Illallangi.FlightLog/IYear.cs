namespace Illallangi.FlightLog
{
    public interface IYear
    {
        int? Id { get; set; }

        string Name { get; set; }

        int TripCount { get; set; }
    }
}