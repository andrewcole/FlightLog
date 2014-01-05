using System.Management.Automation;
using Illallangi.FlightLog.Model;

namespace Illallangi.FlightLog.PowerShell
{
    [Cmdlet(VerbsCommon.Add, Nouns.Airport)]
    public sealed class AddAirportCmdlet : FlightLogCmdlet<Airport>
    {
        #region Properties

        [Parameter(Mandatory = true)]
        public string Country { get; set; }

        [Parameter(Mandatory = true)]
        public string City { get; set; }

        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        [Parameter(Mandatory = true)]
        public string Iata { get; set; }

        [Parameter(Mandatory = true)]
        public string Icao { get; set; }

        [Parameter(Mandatory = true)]
        public float Latitude { get; set; }

        [Parameter(Mandatory = true)]
        public float Longitude { get; set; }

        [Parameter(Mandatory = true)]
        public float Altitude { get; set; }

        [Parameter(Mandatory = true)]
        public string Timezone { get; set; }

        #endregion

        #region Methods
        
        protected override void ProcessRecord()
        {
            this.WriteObject(this.Repository.Create(new Airport
                    { 
                        Country = this.Country, 
                        City = this.City,
                        Name = this.Name,
                        Iata = this.Iata, 
                        Icao = this.Icao, 
                        Latitude = this.Latitude, 
                        Longitude = this.Longitude, 
                        Altitude = this.Altitude, 
                        Timezone = this.Timezone,
                    }));
        }

        #endregion
    }
}