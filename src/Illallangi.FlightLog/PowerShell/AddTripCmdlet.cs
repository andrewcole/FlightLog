using System.Management.Automation;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.PowerShell
{
    [Cmdlet(VerbsCommon.Add, Nouns.Trip)]
    public sealed class AddTripCmdlet : FlightLogCmdlet<Trip>
    {
        #region Properties

        [Parameter(Mandatory = true)]
        public string Year { get; set; }

        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        [Parameter(Mandatory = false)]
        public string Description { get; set; }

        #endregion

        #region Methods

        protected override void ProcessRecord()
        {
            this.WriteObject(this.Repository.Create(new Trip { Name = this.Name, Year = this.Year, Description = this.Description }));
        }

        #endregion
    }
}