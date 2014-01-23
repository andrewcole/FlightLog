namespace Illallangi.FlightLog.PowerShell.City
{
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Get, Nouns.City)]
    public sealed class GetCityCmdlet : FlightLogCmdlet<ICity>
    {
        protected override void BeginProcessing()
        {
            this.WriteObject(this.Repository.Retrieve(), true);
        }
    }
}