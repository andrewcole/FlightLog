namespace Illallangi.FlightLog.PowerShell.City
{
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Get, Nouns.City)]
    public sealed class GetCityCmdlet : FlightLogGetCmdlet<ICity, City>
    {
        [SupportsWildcards]
        [Parameter(Mandatory = false)]
        public string Country { get; set; }

        [SupportsWildcards]
        [Parameter(Mandatory = false, Position = 1)]
        public string Name { get; set; }
    }
}