using System.Management.Automation;
using Illallangi.FlightLog.Context;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.PowerShell
{
    [Cmdlet(VerbsCommon.Get, Nouns.City, DefaultParameterSetName = "Id")]
    public sealed class GetCityCmdlet : FlightLogCmdlet<City>
    {
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "Id")]
        public int? Id { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "Value")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "Value")]
        public string Country { get; set; }

        protected override void BeginProcessing()
        {
            this.WriteObject(this.Repository.Retrieve(new City { Id = this.Id, Name = this.Name, Country = this.Country }), true);
        }
    }
}