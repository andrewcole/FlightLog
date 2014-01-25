namespace Illallangi.FlightLog.PowerShell
{
    using System.Linq;
    using System.Management.Automation;

    using AutoMapper;

    public abstract class FlightLogRemoveCmdlet<T, Timpl> : FlightLogCmdlet<T> where T : class where Timpl : T
    {
        protected override void ProcessRecord()
        {
            foreach (var o in this.Repository.Retrieve(Mapper.DynamicMap<Timpl>(this)).Where(o => this.ShouldProcess(o.ToString(), VerbsCommon.Remove)))
            {
                this.Repository.Delete(o);
            }
        }
    }
}