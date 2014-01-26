namespace Illallangi.FlightLog.PowerShell.Country
{
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Add, Nouns.Country)]
    public sealed class AddCountryCmdlet : FlightLogAddCmdlet<ICountry, Country>
    {
        #region Instance Properties

        [SupportsWildcards]
        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        #endregion
    }
}