namespace Illallangi.FlightLog.PowerShell.Timezone
{
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Add, Nouns.Timezone)]
    public class AddTimezoneCmdlet : FlightLogAddCmdlet<ITimezone, Timezone>
    {
        #region Instance Properties

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 1)]
        [Alias("Timezone")]
        public string Name { get; set; }

        #endregion
    }

    [Cmdlet(VerbsData.Import, Nouns.Timezone)]
    public class ImportTimezoneCmdlet : AddTimezoneCmdlet
    {
        protected override InsertMode Mode
        {
            get
            {
                return InsertMode.Import;
            }
        }
    }
}