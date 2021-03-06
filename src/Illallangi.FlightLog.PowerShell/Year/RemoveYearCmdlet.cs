namespace Illallangi.FlightLog.PowerShell.Year
{
    using System.Management.Automation;

    

    [Cmdlet(VerbsCommon.Remove, Nouns.Year, SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    public sealed class RemoveYearCmdlet : FlightLogRemoveCmdlet<IYear>
    {
        #region Primary Key Property

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public int? Id { get; set; }

        #endregion

        #region Instance Properties

        [SupportsWildcards]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        #endregion
    }
}