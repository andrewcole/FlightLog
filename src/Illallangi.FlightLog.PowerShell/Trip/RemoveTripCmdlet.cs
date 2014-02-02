namespace Illallangi.FlightLog.PowerShell.Trip
{
    using System.Management.Automation;

    

    [Cmdlet(VerbsCommon.Remove, Nouns.Trip, SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    public sealed class RemoveTripCmdlet : FlightLogRemoveCmdlet<ITrip>
    {
        #region Primary Key Property

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public int? Id { get; set; }

        #endregion

        #region Parent Properties

        [SupportsWildcards]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Country { get; set; }

        #endregion

        #region Instance Properties

        [SupportsWildcards]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        #endregion
    }
}