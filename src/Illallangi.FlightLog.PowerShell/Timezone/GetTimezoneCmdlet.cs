using System.Management.Automation;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.PowerShell
{
    [Cmdlet(VerbsCommon.Get, Nouns.Timezone)]
    public sealed class GetTimezoneCmdlet : FlightLogCmdlet<ITimezone>
    {
        protected override void BeginProcessing()
        {
            this.WriteObject(this.Repository.Retrieve(), true);
        }
    }
}