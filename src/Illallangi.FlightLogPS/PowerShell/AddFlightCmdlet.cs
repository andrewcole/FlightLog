// <copyright file="AddFlightCmdlet.cs" company="Illallangi Enterprises">Copyright Illallangi Enterprises 2013</copyright>

using System.Management.Automation;
using Illallangi.T4Database.PowerShell;
using Illallangi.FlightLog.Model;
using Illallangi.FlightLog.Repository;

namespace Illallangi.FlightLog.Powershell
{
    [Cmdlet(VerbsCommon.Add, ModelObject.Flight)]
    public sealed class AddFlightCmdlet : BaseCmdlet<Flight, IFlightRepository, FlightRepository>
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public int AirportId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public int AirportId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Departure { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Arrival { get; set; }

        protected override void ProcessRecord()
        {
            this.WriteObject(this.Repository.Create(this.AirportId, this.AirportId, this.Departure, this.Arrival));
        }
    }
}