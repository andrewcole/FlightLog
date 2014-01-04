using System.Linq;
using System.Management.Automation;
using Illallangi.FlightLog.Context;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.PowerShell
{
    [Cmdlet(VerbsCommon.Remove, Nouns.Airport, DefaultParameterSetName = "Id", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    public sealed class RemoveAirportCmdlet : ZumeroCmdlet<ISource<Airport>>
    {
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "Id")]
        public int? Id { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "Value")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "Value")]
        public string CityName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "Value")]
        public string CountryName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "Value")]
        public string Icao { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "Value")]
        public string Iata { get; set; }

        protected override void BeginProcessing()
        {
            foreach (var o in this.Repository.Retrieve(
                new Airport 
                { 
                    Id = this.Id, 
                    Name = this.Name, 
                    City = this.CityName, 
                    Country = this.CountryName, 
                    Iata = this.Iata, 
                    Icao = this.Icao 
                }).ToList().Where(o => this.ShouldProcess(o.ToString(), VerbsCommon.Remove)))
            {
                this.Repository.Delete(o);
            }
        }
    }
}