namespace Illallangi.FlightLog.PowerShell.Trip
{
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Get, Nouns.Trip)]
    public sealed class GetTripCmdlet : FlightLogCmdlet<ITrip>
    {
        protected override void BeginProcessing()
        {
            this.WriteObject(this.Repository.Retrieve(), true);
        }
    }
}