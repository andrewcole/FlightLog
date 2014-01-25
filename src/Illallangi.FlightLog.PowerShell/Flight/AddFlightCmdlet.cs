namespace Illallangi.FlightLog.PowerShell.Flight
{
    using System;
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Add, Nouns.Flight)]
    public sealed class AddFlightCmdlet : FlightLogAddCmdlet<IFlight, Flight>
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
    }
}