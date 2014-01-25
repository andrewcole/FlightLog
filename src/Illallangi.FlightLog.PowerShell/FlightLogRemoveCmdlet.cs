namespace Illallangi.FlightLog.PowerShell
{
    using System.Linq;
    using System.Management.Automation;

    using AutoMapper;

    using Illallangi.LiteOrm;

    public abstract class FlightLogRemoveCmdlet<T, Timpl> : NinjectCmdlet<FlightLogModule>
        where T : class
        where Timpl : T
    {
        protected override void ProcessRecord()
        {
            foreach (var o in this.Get<IRepository<T>>().Retrieve(Mapper.DynamicMap<Timpl>(this)).Where(o => this.ShouldProcess(o.ToString(), VerbsCommon.Remove)))
            {
                this.Get<IRepository<T>>().Delete(o);
            }
        }
    }
}