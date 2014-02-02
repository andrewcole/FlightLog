namespace Illallangi.FlightLog.PowerShell.Trip
{
    using System.Management.Automation;

    

    [Cmdlet(VerbsCommon.Get, Nouns.Trip)]
    public sealed class GetTripCmdlet : FlightLogGetCmdlet<ITrip>
    {
        #region Parent Properties

        [SupportsWildcards]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Year { get; set; }

        #endregion

        #region Instance Properties

        [SupportsWildcards]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        [SupportsWildcards]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Description { get; set; }

        #endregion
    }
}