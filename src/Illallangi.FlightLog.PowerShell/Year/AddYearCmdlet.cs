namespace Illallangi.FlightLog.PowerShell.Year
{
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Add, Nouns.Year)]
    public sealed class AddYearCmdlet : FlightLogCmdlet<IYear>
    {
        #region Properties

        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        #endregion

        #region Methods

        protected override void ProcessRecord()
        {
            this.WriteObject(this.Repository.Create(new Year
            {
                Name = this.Name,
            }));
        }

        #endregion
    }
}