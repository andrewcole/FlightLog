using System.Management.Automation;
using Illallangi.FlightLogPS.Model;

namespace Illallangi.FlightLogPS.PowerShell
{
    [Cmdlet(VerbsCommon.Add, Nouns.Country)]
    public sealed class AddCountryCmdlet : ZumeroCmdlet<ICountrySource>
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        protected override void ProcessRecord()
        {
            this.WriteObject(this.Repository.CreateCountry(this.Name));
        }
    }
}
