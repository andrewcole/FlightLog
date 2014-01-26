namespace Illallangi.FlightLog.PowerShell.Timezone
{
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Get, Nouns.Timezone)]
    public sealed class GetTimezoneCmdlet : FlightLogGetCmdlet<ITimezone, Timezone>
    {
        #region Instance Properties

        [SupportsWildcards]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        #endregion
    }
}