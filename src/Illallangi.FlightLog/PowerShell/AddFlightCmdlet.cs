using System;
using System.Management.Automation;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.PowerShell
{
    [Cmdlet(VerbsCommon.Add, Nouns.Flight)]
    public sealed class AddFlightCmdlet : FlightLogCmdlet<Flight>
    {
        #region Properties

        [Parameter(Mandatory = true)]
        public string Year { get; set; }

        [Parameter(Mandatory = true)]
        public string Trip { get; set; }

        [Parameter(Mandatory = true)]
        public string Origin { get; set; }

        [Parameter(Mandatory = true)]
        public string Destination { get; set; }

        [Parameter(Mandatory = true)]
        public DateTime Departure { get; set; }

        [Parameter(Mandatory = true)]
        public DateTime Arrival { get; set; }

        [Parameter(Mandatory = true)]
        public string Airline { get; set; }

        [Parameter(Mandatory = true)]
        public string Number { get; set; }

        [Parameter(Mandatory = false)]
        public string Aircraft { get; set; }

        [Parameter(Mandatory = false)]
        public string Seat { get; set; }
        
        [Parameter(Mandatory = false)]
        public string Note { get; set; }

        #endregion

        #region Methods

        protected override void ProcessRecord()
        {
            this.WriteObject(this.Repository.Create(new Flight
            {
                Year = this.Year,
                Trip = this.Trip,
                Origin = this.Origin,
                Destination = this.Destination,
                Departure = this.Departure,
                Arrival = this.Arrival,
                Airline = this.Airline,
                Number = this.Number,
                Aircraft = this.Aircraft,
                Seat = this.Seat,
                Note = this.Note,
            }));
        }

        #endregion
    }
}