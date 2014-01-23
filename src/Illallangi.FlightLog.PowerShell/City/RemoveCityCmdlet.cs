using System.Linq;
using System.Management.Automation;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.PowerShell
{
    [Cmdlet(VerbsCommon.Remove, Nouns.City, DefaultParameterSetName = "Id", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    public sealed class RemoveCityCmdlet : FlightLogCmdlet<ICity>
    {
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "Id")]
        public int? Id { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "Value")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "Value")]
        public string Country { get; set; }

        protected override void BeginProcessing()
        {
            foreach (var o in this.Repository.Retrieve(new City { Id = this.Id, Name = this.Name, Country = this.Country }).ToList().Where(o => this.ShouldProcess(o.ToString(), VerbsCommon.Remove)))
            {
                this.Repository.Delete(o);
            }
        }
    }
}