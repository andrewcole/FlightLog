namespace Illallangi.FlightLog
{
    using System;

    public interface ITrip
    {
        int? Id { get; set; }

        string Year { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        int FlightCount { get; set; }

        DateTime? Departure { get; set; }

        DateTime? Arrival { get; set; }
    }
}