namespace Illallangi.FlightLog.PowerShell.City
{
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Add, Nouns.City)]
    public sealed class AddCityCmdlet : FlightLogCmdlet<ICity>
    {
        #region Properties

        [Parameter(Mandatory = true)]
        public string Country { get; set; }

        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        #endregion
        
        #region Methods

        protected override void ProcessRecord()
        {
            this.WriteObject(this.Repository.Create(new City
            {
                Name = this.Name, 
                Country = this.Country,
            }));
        }

        #endregion
    }
}