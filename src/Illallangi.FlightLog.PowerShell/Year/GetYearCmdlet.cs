namespace Illallangi.FlightLog.PowerShell.Year
{
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Get, Nouns.Year)]
    public sealed class GetYearCmdlet : FlightLogCmdlet<IYear>
    {
        #region Properties

        [Parameter(Position = 1)]
        public string Name { get; set; }

        #endregion

        #region Methods

        protected override void BeginProcessing()
        {
            this.WriteObject(this.Repository.Retrieve(new FlightLog.PowerShell.Year { Name = this.Name }), true);
        }

        #endregion
    }
}
