namespace Illallangi.FlightLog
{
    public interface ICountry
    {
        int? Id { get; }

        string Name { get; }

        int CityCount { get; }
    }
}