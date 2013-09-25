// <copyright file="GetFlightCmdlet.cs" company="Illallangi Enterprises">Copyright Illallangi Enterprises 2013</copyright>

using System.Management.Automation;
using Illallangi.T4Database.PowerShell;
using Illallangi.FlightLog.Model;
using Illallangi.FlightLog.Repository;

namespace Illallangi.FlightLog.Powershell
{
    [Cmdlet(VerbsCommon.Get, ModelObject.Flight)]
    public sealed class GetFlightCmdlet : BaseCmdlet<Flight, IFlightRepository, FlightRepository>
    {
        protected override void BeginProcessing()
        {
            this.WriteObject(this.Repository.Retrieve(), true);
        }
    }
}