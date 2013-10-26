using System.Management.Automation;
using Illallangi.FlightLogPS.Model;

namespace Illallangi.FlightLogPS.PowerShell
{
    [Cmdlet(VerbsCommon.Get, Nouns.Country, DefaultParameterSetName = "Id")]
    public sealed class GetCountryCmdlet : ZumeroCmdlet<ICountrySource>
    {
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "Id")]
        public int? Id { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "Value")]
        public string Name { get; set; }

        protected override void BeginProcessing()
        {
            this.WriteObject(this.Repository.RetrieveCountry(this.Id, this.Name), true);
        }
    }
}