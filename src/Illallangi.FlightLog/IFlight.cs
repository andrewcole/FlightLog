namespace Illallangi.FlightLog
{
    using System;

    using NodaTime;

    public interface IFlight
    {
        int? Id { get; set; }

        string Year { get; set; }

        string Trip { get; set; }

        string Origin { get; set; }

        string OriginTimezone { get; set; }

        string Destination { get; set; }

        string DestinationTimezone { get; set; }

        DateTime Departure { get; set; }

        DateTime Arrival { get; set; }

        string Airline { get; set; }

        string Number { get; set; }

        string Aircraft { get; set; }

        string Seat { get; set; }

        string Note { get; set; }

        ZonedDateTime DepartureZoned { get; }

        ZonedDateTime ArrivalZoned { get; }
    }
}