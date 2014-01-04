using System.Management.Automation;
using Illallangi.FlightLog.Context;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.PowerShell
{
    [Cmdlet(VerbsCommon.Get, Nouns.Airport, DefaultParameterSetName = "Id")]
    public sealed class GetAirportCmdlet : ZumeroCmdlet<ISource<Airport>>
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
            this.WriteObject(
                this.Repository.Retrieve(
                    new Airport 
                    { 
                        Id = this.Id, 
                        Name = this.Name, 
                        City = this.CityName, 
                        Country = this.CountryName, 
                        Iata = this.Iata, 
                        Icao = this.Icao 
                    }), 
                true);
        }
    }
}