using System.Management.Automation;
using Illallangi.FlightLog.Context;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.PowerShell
{
    [Cmdlet(VerbsCommon.Add, Nouns.Airport)]
    public sealed class AddAirportCmdlet : FlightLogCmdlet<ISource<Airport>>
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string CityName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string CountryName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Timezone { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public float Altitude { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public float Longitude { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public float Latitude { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Icao { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Iata { get; set; }
        
        protected override void ProcessRecord()
        {
            this.WriteObject(
                this.Repository.Create(
                    new Airport 
                    { 
                        Name = this.Name, 
                        City = this.CityName, 
                        Country = this.CountryName, 
                        Iata = this.Iata, 
                        Icao = this.Icao, 
                        Latitude = this.Latitude, 
                        Longitude = this.Longitude, 
                        Altitude = this.Altitude, 
                        Timezone = this.Timezone,
                    }));
        }
    }
}