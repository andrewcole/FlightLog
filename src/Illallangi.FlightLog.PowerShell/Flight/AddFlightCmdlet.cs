namespace Illallangi.FlightLog.PowerShell.Flight
{
    using System;
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Add, Nouns.Flight)]
    public class AddFlightCmdlet : FlightLogAddCmdlet<IFlight, Flight>
    {
        #region Parent Properties

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Year { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Trip { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Origin { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Destination { get; set; }

        #endregion

        #region Instance Properties

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public DateTime Departure { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public DateTime Arrival { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Airline { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Number { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Aircraft { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Seat { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [Alias("Comment")]
        public string Note { get; set; }

        #endregion
    }

    [Cmdlet(VerbsData.Import, Nouns.Flight)]
    public class ImportFlightCmdlet : AddFlightCmdlet
    {
        protected override InsertMode Mode
        {
            get
            {
                return InsertMode.Import;
            }
        }
    }
}