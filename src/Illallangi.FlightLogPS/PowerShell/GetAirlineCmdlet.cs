// <copyright file="GetAirlineCmdlet.cs" company="Illallangi Enterprises">Copyright Illallangi Enterprises 2013</copyright>

using System.Management.Automation;
using Illallangi.T4Database.PowerShell;
using Illallangi.FlightLogPS.Model;
using Illallangi.FlightLogPS.Repository;

namespace Illallangi.FlightLogPS.Powershell
{
    [Cmdlet(VerbsCommon.Get, ModelObject.Airline)]
    public sealed class GetAirlineCmdlet : BaseCmdlet<Airline, IAirlineRepository, AirlineRepository>
    {
        protected override void BeginProcessing()
        {
            this.WriteObject(this.Repository.Retrieve(), true);
        }
    }
}