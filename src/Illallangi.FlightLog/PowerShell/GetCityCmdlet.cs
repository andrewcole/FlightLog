using System.Management.Automation;
using Illallangi.FlightLog.Context;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.PowerShell
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
            this.WriteObject(this.Repository.Retrieve(this.Id, this.Name, this.CountryName), true);
        }
    }
}