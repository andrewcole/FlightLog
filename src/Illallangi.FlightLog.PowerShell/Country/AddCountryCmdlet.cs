namespace Illallangi.FlightLog.PowerShell.Country
{
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Add, Nouns.Country)]
    public sealed class AddCountryCmdlet : FlightLogAddCmdlet<ICountry, Country>
    {
        #region Properties

        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        #endregion
    }
}