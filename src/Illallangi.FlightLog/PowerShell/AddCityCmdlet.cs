using System.Management.Automation;
using Illallangi.FlightLog.Context;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.PowerShell
{
    [Cmdlet(VerbsCommon.Add, Nouns.City)]
    public sealed class AddCityCmdlet : ZumeroCmdlet<ICitySource>
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string CountryName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        protected override void ProcessRecord()
        {
            this.WriteObject(this.Repository.CreateCity(this.Name, this.CountryName));
        }
    }
}