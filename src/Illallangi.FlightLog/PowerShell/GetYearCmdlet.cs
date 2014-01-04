using System.Management.Automation;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.PowerShell
{
    [Cmdlet(VerbsCommon.Get, Nouns.Year)]
    public sealed class GetYearCmdlet : FlightLogCmdlet<Year>
    {
        #region Properties

        [Parameter(Position = 1)]
        public string Name { get; set; }

        #endregion

        #region Methods

        protected override void BeginProcessing()
        {
            this.WriteObject(this.Repository.Retrieve(new Year { Name = this.Name }), true);
        }

        #endregion
    }
}
