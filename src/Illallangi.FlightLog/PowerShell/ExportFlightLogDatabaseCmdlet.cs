// <copyright file="ExportFlightLogDatabaseCmdlet.cs" company="Illallangi Enterprises">Copyright Illallangi Enterprises 2013</copyright>

using System.IO;
using System.Management.Automation;
using Illallangi.FlightLog.Repository;

namespace Illallangi.FlightLog.Powershell
{
    [Cmdlet(VerbsData.Export, "FlightLogDatabase")]
    public sealed class ExportFlightLogDatabaseCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string FileName { get; set; }

        protected override void BeginProcessing()
        {
            BackupRepository.FromDatabase().ToFile(Path.GetFullPath(this.FileName));
        }
    }
}