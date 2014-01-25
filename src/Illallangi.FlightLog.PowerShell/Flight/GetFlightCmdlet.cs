namespace Illallangi.FlightLog.PowerShell.Flight
{
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Get, Nouns.Flight)]
    public sealed class GetFlightCmdlet : FlightLogGetCmdlet<IFlight, Flight>
    {
    }
}