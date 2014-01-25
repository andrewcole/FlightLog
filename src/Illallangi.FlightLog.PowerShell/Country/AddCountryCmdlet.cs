namespace Illallangi.FlightLog.PowerShell.Country
{
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Add, Nouns.Country)]
    public sealed class AddCountryCmdlet : FlightLogCmdlet<ICountry>, ICountry
    {
        #region Properties

        public int? Id
        {
            get
            {
                return null;
            }
        }

        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        public int CityCount
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        #endregion
        
        #region Methods

        protected override void ProcessRecord()
        {
            this.WriteObject(this.Repository.Create(this));
        }

        #endregion
    }
}