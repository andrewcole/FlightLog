// <copyright file="AddAirlineCmdlet.cs" company="Illallangi Enterprises">Copyright Illallangi Enterprises 2013</copyright>

using System.Management.Automation;
using Illallangi.T4Database.PowerShell;
using Illallangi.FlightLogPS.Model;
using Illallangi.FlightLogPS.Repository;

namespace Illallangi.FlightLogPS.Powershell
{
    [Cmdlet(VerbsCommon.Add, ModelObject.Airline)]
    public sealed class AddAirlineCmdlet : BaseCmdlet<Airline, IAirlineRepository, AirlineRepository>
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [AllowEmptyString]
        public string Alias { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [AllowEmptyString]
        public string Iata { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [AllowEmptyString]
        public string Icao { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [AllowEmptyString]
        public string Callsign { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [AllowEmptyString]
        public string Country { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Active { get; set; }

        protected override void ProcessRecord()
        {
            this.WriteObject(this.Repository.Create(this.Name, this.Alias, this.Iata, this.Icao, this.Callsign, this.Country, this.Active));
        }
    }
}