using System.Management.Automation;
using Illallangi.FlightLogPS.Model;

namespace Illallangi.FlightLogPS.PowerShell
{
    [Cmdlet(VerbsCommon.Get, Nouns.City, DefaultParameterSetName = "Id")]
    public sealed class GetCityCmdlet : ZumeroCmdlet<ICitySource>
    {
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "Id")]
        public int? Id { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "Value")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "Value")]
        public string CountryName { get; set; }

        protected override void BeginProcessing()
        {
            this.WriteObject(this.Repository.RetrieveCity(this.Id, this.Name, this.CountryName), true);
        }
    }
}