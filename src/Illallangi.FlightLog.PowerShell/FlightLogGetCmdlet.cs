namespace Illallangi.FlightLog.PowerShell
{
    using AutoMapper;

    using Illallangi.LiteOrm;

    public abstract class FlightLogGetCmdlet<T, Timpl> : NinjectCmdlet<FlightLogModule>
        where T : class
        where Timpl : T
    {
        #region Methods

        protected override void ProcessRecord()
        {
            this.WriteObject(this.Get<IRepository<T>>().Retrieve(Mapper.DynamicMap<Timpl>(this)), true);
        }

        #endregion
    }
}