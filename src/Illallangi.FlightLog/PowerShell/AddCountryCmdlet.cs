using System.Management.Automation;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.PowerShell
{
    [Cmdlet(VerbsCommon.Add, Nouns.Country)]
    public sealed class AddCountryCmdlet : FlightLogCmdlet<ICountry>
    {
        #region Properties

        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        #endregion
        
        #region Methods

        protected override void ProcessRecord()
        {
            this.WriteObject(this.Repository.Create(new Country
            {
                Name = this.Name,
            }));
        }

        #endregion
    }
}