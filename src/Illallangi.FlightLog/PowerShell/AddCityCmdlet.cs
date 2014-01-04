using System.Management.Automation;
using Illallangi.FlightLog.Context;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.PowerShell
{
    [Cmdlet(VerbsCommon.Add, Nouns.City)]
    public sealed class AddCityCmdlet : ZumeroCmdlet<ISource<City>>
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Country { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        protected override void ProcessRecord()
        {
            this.WriteObject(this.Repository.Create(new City {Name = this.Name, Country = this.Country }));
        }
    }
}