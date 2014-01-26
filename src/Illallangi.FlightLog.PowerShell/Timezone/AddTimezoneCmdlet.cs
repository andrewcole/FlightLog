namespace Illallangi.FlightLog.PowerShell.Timezone
{
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Add, Nouns.Timezone)]
    public sealed class AddTimezoneCmdlet : FlightLogAddCmdlet<ITimezone, Timezone>
    {
        #region Instance Properties

        [Parameter(Mandatory = true, Position = 1)]
        public string Name { get; set; }

        #endregion
    }
}