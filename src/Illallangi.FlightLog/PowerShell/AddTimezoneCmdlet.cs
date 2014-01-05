using System.Management.Automation;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.PowerShell
{
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
            this.WriteObject(this.Repository.Create(new Timezone
            {
                Name = this.Name,
            }));
        }

        #endregion
    }
}