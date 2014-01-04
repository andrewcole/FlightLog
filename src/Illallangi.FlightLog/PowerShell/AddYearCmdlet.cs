using System.Management.Automation;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.PowerShell
{
    [Cmdlet(VerbsCommon.Add, Nouns.Year)]
    public sealed class AddYearCmdlet : FlightLogCmdlet<Year>
    {
        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        protected override void ProcessRecord()
        {
            this.WriteObject(this.Repository.Create(new Year { Name = this.Name }));
        }
    }
}