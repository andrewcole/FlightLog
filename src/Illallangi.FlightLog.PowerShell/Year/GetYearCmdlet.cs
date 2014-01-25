namespace Illallangi.FlightLog.PowerShell.Year
{
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Get, Nouns.Year)]
    public sealed class GetYearCmdlet : FlightLogGetCmdlet<IYear, Year>
    {
        [SupportsWildcards]
        [Parameter(Position = 1)]
        public string Name { get; set; }
    }
}
