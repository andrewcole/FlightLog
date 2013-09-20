// <copyright file="ExportCmdlet.cs" company="Illallangi Enterprises">Copyright Illallangi Enterprises 2013</copyright>

using System.Management.Automation;
using Illallangi.FlightLog.Repository;

namespace Illallangi.FlightLog.Powershell
{
    [Cmdlet(VerbsData.Export, "T4Database")]
    public sealed class ExportCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string FileName { get; set; }

        protected override void BeginProcessing()
        {
            BackupRepository.FromDatabase().ToFile(this.FileName);
        }
    }
}