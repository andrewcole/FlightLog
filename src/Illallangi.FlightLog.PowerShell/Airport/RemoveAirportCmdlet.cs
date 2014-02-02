namespace Illallangi.FlightLog.PowerShell.Airport
{
    using System.Management.Automation;

    

    [Cmdlet(VerbsCommon.Remove, Nouns.Airport, SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    public sealed class RemoveAirportCmdlet : FlightLogRemoveCmdlet<IAirport>
    {
        #region Primary Key Property

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public int? Id { get; set; }

        #endregion

        #region Parent Properties

        [SupportsWildcards]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Country { get; set; }

        [SupportsWildcards]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string City { get; set; }

        #endregion

        #region Instance Properties

        [SupportsWildcards]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        [SupportsWildcards]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Iata { get; set; }

        [SupportsWildcards]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Icao { get; set; }

        #endregion
    }
}