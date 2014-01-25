namespace Illallangi.FlightLog.PowerShell.Timezone
{
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Get, Nouns.Timezone)]
    public sealed class GetTimezoneCmdlet : FlightLogGetCmdlet<ITimezone, Timezone>
    {
    }
}