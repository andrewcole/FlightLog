namespace Illallangi.FlightLog
{
    public interface ICountry
    {
        int? Id { get; set; }

        string Name { get; set; }

        int CityCount { get; set; }
    }
}