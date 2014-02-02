namespace Illallangi.FlightLog.PowerShell.Country
{
    using System.Management.Automation;

    

    [Cmdlet(VerbsCommon.Remove, Nouns.Country, SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    public sealed class RemoveCountryCmdlet : FlightLogRemoveCmdlet<ICountry>
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