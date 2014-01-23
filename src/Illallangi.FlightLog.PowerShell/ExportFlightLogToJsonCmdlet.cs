namespace Illallangi.FlightLog.PowerShell
{
    using System.IO;
    using System.Linq;
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;
    using Illallangi.LiteOrm;

    using Newtonsoft.Json;

    [Cmdlet(VerbsData.Export, "FlightLogToJson")]
    public sealed class ExportFlightLogToJsonCmdlet : NinjectCmdlet
    {
        [Parameter(Mandatory = true)]
        public string FileName { get; set; }

        protected override void BeginProcessing()
        {
            File.WriteAllText(
                Path.GetFullPath(this.FileName),
                JsonConvert.SerializeObject(
                    new
                    {
                        Airports = this.Get<IRepository<IAirport>>()
                            .Retrieve()
                            .Select(
                                airport => new
                                {
                                    airport.Icao,
                                    airport.Iata,
                                    airport.Name,
                                    airport.City,
                                    airport.Country,
                                    airport.Latitude,
                                    airport.Longitude,
                                    airport.Altitude,
                                    airport.Timezone,
                                }),
                        Years = this.Get<IRepository<IYear>>()
                            .Retrieve()
                            .Select(
                                year => new
                                {
                                    Title = year.Name,
                                    Trips = this.Get<IRepository<ITrip>>()
                                        .Retrieve(new Model.Trip { Year = year.Name })
                                        .Select(
                                            trip => new
                                            {
                                                Title = trip.Name,
                                                trip.Description,
                                                Flights = this.Get<IRepository<IFlight>>()
                                                    .Retrieve(new Model.Flight { Year = year.Name, Trip = trip.Name })
                                                    .OrderBy(flight => flight.Departure)
                                                    .Select(
                                                        flight => new
                                                        {
                                                            flight.Departure,
                                                            flight.Arrival,
                                                            flight.Airline,
                                                            flight.Number,
                                                            flight.Origin,
                                                            flight.Destination,
                                                            flight.Aircraft,
                                                            flight.Seat,
                                                            flight.Note,
                                                        })
                                            })
                                })
                    },
                    Formatting.Indented,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }
    }
}