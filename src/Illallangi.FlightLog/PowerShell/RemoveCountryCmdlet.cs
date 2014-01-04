using System.Linq;
using System.Management.Automation;
using Illallangi.FlightLog.Context;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.PowerShell
{
    [Cmdlet(VerbsCommon.Remove, Nouns.Country, DefaultParameterSetName = "Id", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    public sealed class RemoveCountryCmdlet : ZumeroCmdlet<ICountrySource>
    {
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "Id")]
        public int? Id { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "Value")]
        public string Name { get; set; }

        protected override void BeginProcessing()
        {
            foreach (var o in this.Repository.Retrieve(this.Id, this.Name).ToList().Where(o => this.ShouldProcess(o.ToString(), VerbsCommon.Remove)))
            {
                this.Repository.Delete(o);
            }
        }
    }
}