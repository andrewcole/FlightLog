namespace Illallangi.FlightLog.PowerShell.Country
{
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Get, Nouns.Country)]
    public sealed class GetCountryCmdlet : FlightLogGetCmdlet<ICountry, Country>
    {
        [SupportsWildcards]
        [Parameter(Mandatory = false, Position = 1)]
        public string Name { get; set; }
    }
}