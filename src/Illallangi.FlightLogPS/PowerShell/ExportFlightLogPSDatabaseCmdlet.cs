// <copyright file="ExportFlightLogPSDatabaseCmdlet.cs" company="Illallangi Enterprises">Copyright Illallangi Enterprises 2013</copyright>

using System.IO;
using System.Management.Automation;
using Illallangi.FlightLogPS.Repository;

namespace Illallangi.FlightLogPS.Powershell
{
    [Cmdlet(VerbsData.Export, "FlightLogPSDatabase")]
    public sealed class ExportFlightLogPSDatabaseCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string FileName { get; set; }

        protected override void BeginProcessing()
        {
            BackupRepository.FromDatabase().ToFile(Path.GetFullPath(this.FileName));
        }
    }
}