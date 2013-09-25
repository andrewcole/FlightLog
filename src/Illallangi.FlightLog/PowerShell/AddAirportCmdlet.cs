// <copyright file="AddAirportCmdlet.cs" company="Illallangi Enterprises">Copyright Illallangi Enterprises 2013</copyright>

using System.Management.Automation;
using Illallangi.T4Database.PowerShell;
using Illallangi.FlightLog.Model;
using Illallangi.FlightLog.Repository;

namespace Illallangi.FlightLog.Powershell
{
    [Cmdlet(VerbsCommon.Add, ModelObject.Airport)]
    public sealed class AddAirportCmdlet : BaseCmdlet<Airport, IAirportRepository, AirportRepository>
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string City { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Country { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [AllowEmptyString]
        public string Iata { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [AllowEmptyString]
        public string Icao { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public float Latitude { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public float Longitude { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public float Altitude { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public float Timezone { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string DST { get; set; }

        protected override void ProcessRecord()
        {
            this.WriteObject(this.Repository.Create(this.Name, this.City, this.Country, this.Iata, this.Icao, this.Latitude, this.Longitude, this.Altitude, this.Timezone, this.DST));
        }
    }
}