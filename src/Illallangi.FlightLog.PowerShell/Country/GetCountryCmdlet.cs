namespace Illallangi.FlightLog.PowerShell.Country
{
    using System.Management.Automation;

    

    [Cmdlet(VerbsCommon.Get, Nouns.Country)]
    public sealed class GetCountryCmdlet : FlightLogGetCmdlet<ICountry>
    {
        #region Instance Properties

        [SupportsWildcards]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        #endregion
    }
}