// <copyright file="AddAirlineCmdlet.cs" company="Illallangi Enterprises">Copyright Illallangi Enterprises 2013</copyright>

using System.Management.Automation;
using Illallangi.T4Database.PowerShell;
using Illallangi.FlightLog.Model;
using Illallangi.FlightLog.Repository;

namespace Illallangi.FlightLog.Powershell
{
    [Cmdlet(VerbsCommon.Add, ModelObject.Airline)]
    public sealed class AddAirlineCmdlet : BaseCmdlet<Airline, IAirlineRepository, AirlineRepository>
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public int CountryId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Alias { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Iata { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Icao { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Callsign { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public int OpenFlightsId { get; set; }

        protected override void ProcessRecord()
        {
            this.WriteObject(this.Repository.Create(this.CountryId, this.Name, this.Alias, this.Iata, this.Icao, this.Callsign, this.OpenFlightsId));
        }
    }
}