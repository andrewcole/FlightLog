// <copyright file="GetAirportCmdlet.cs" company="Illallangi Enterprises">Copyright Illallangi Enterprises 2013</copyright>

using System.Management.Automation;
using Illallangi.T4Database.PowerShell;
using Illallangi.FlightLogPS.Model;
using Illallangi.FlightLogPS.Repository;

namespace Illallangi.FlightLogPS.Powershell
{
    [Cmdlet(VerbsCommon.Get, ModelObject.Airport)]
    public sealed class GetAirportCmdlet : BaseCmdlet<Airport, IAirportRepository, AirportRepository>
    {
        protected override void BeginProcessing()
        {
            this.WriteObject(this.Repository.Retrieve(), true);
        }
    }
}