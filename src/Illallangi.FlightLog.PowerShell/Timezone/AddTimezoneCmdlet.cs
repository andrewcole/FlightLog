namespace Illallangi.FlightLog.PowerShell.Timezone
{
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Add, Nouns.Timezone)]
    public sealed class AddTimezoneCmdlet : FlightLogCmdlet<ITimezone>
    {
        #region Properties

        [Parameter(Mandatory = true, Position = 1)]
        public string Name { get; set; }

        #endregion
        
        #region Methods

        protected override void ProcessRecord()
        {
            this.WriteObject(this.Repository.Create(new FlightLog.PowerShell.Timezone
            {
                Name = this.Name,
            }));
        }

        #endregion
    }
}