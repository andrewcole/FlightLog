using System.Management.Automation;
using Illallangi.FlightLog.Context;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.PowerShell
{
    [Cmdlet(VerbsCommon.Get, Nouns.City, DefaultParameterSetName = "Id")]
    public sealed class GetCityCmdlet : ZumeroCmdlet<ISource<City>>
    {
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "Id")]
        public int? Id { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "Value")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "Value")]
        public string CountryName { get; set; }

        protected override void BeginProcessing()
        {
            this.WriteObject(this.Repository.Retrieve(new City { Id = this.Id, Name = this.Name, CountryName = this.CountryName } ), true);
        }
    }
}