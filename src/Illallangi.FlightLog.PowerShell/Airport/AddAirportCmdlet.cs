namespace Illallangi.FlightLog.PowerShell.Airport
{
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Add, Nouns.Airport)]
    public class AddAirportCmdlet : FlightLogAddCmdlet<IAirport, Airport>
    {
        #region Parent Properties

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Country { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string City { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Timezone { get; set; }

        #endregion

        #region Instance Properties

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Iata { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Icao { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public float Latitude { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public float Longitude { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public float Altitude { get; set; }

        #endregion
    }

    [Cmdlet(VerbsData.Import, Nouns.Airport)]
    public class ImportAirportCmdlet : AddAirportCmdlet
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