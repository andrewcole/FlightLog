namespace Illallangi.FlightLog.PowerShell.Year
{
    using System.Management.Automation;

    

    [Cmdlet(VerbsCommon.Get, Nouns.Year)]
    public sealed class GetYearCmdlet : FlightLogGetCmdlet<IYear>
    {
        #region Instance Properties

        [SupportsWildcards]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        #endregion
    }
}
