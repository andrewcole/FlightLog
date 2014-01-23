namespace Illallangi.FlightLog.PowerShell.Airport
{
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Get, Nouns.Airport)]
    public sealed class GetAirportCmdlet : FlightLogCmdlet<IAirport>
    {
        protected override void BeginProcessing()
        {
            this.WriteObject(this.Repository.Retrieve(), true);
        }
    }
}