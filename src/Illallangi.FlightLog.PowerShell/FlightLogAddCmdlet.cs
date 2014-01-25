namespace Illallangi.FlightLog.PowerShell
{
    using AutoMapper;

    using Illallangi.LiteOrm;

    public abstract class FlightLogAddCmdlet<T, Timpl> : NinjectCmdlet<FlightLogModule>
        where T : class
        where Timpl : T
    {
        #region Methods

        protected override void ProcessRecord()
        {
            this.WriteObject(this.Get<IRepository<T>>().Create(Mapper.DynamicMap<Timpl>(this)));
        }

        #endregion
    }
}