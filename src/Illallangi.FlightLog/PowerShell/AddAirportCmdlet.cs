using System.Management.Automation;
using Illallangi.FlightLog.Context;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.PowerShell
{
    [Cmdlet(VerbsCommon.Add, Nouns.Airport)]
    public sealed class AddAirportCmdlet : ZumeroCmdlet<IAirportSource>
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string CityName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string CountryName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Dst { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public float Timezone { get; set; }

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
        
        protected override void BeginProcessing()
        {
//            this.WriteObject(this.Repository.Retrieve(this.Id, this.Name, this.CityName, 
  //              this.CountryName, this.Iata, this.Icao, this.Latitude, this.Longitude, this.Altitude, this.Timezone, this.Dst), true);
        }
        protected override void ProcessRecord()
        {
            this.WriteObject(this.Repository.Create(this.Name, this.CityName, this.CountryName, this.Iata, this.Icao,
                this.Latitude, this.Longitude, this.Altitude, this.Timezone, this.Dst));
        }

    }
}