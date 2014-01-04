using System.Management.Automation;
using Illallangi.FlightLog.Context;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.PowerShell
{
    [Cmdlet(VerbsCommon.Add, Nouns.Country)]
    public sealed class AddCountryCmdlet : ZumeroCmdlet<ICountrySource>
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        protected override void ProcessRecord()
        {
            this.WriteObject(this.Repository.Create(new Country { Name = this.Name }));
        }
    }
}
