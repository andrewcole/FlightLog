namespace Illallangi.FlightLog.PowerShell
{
    using System;

    using Illallangi.LiteOrm;

    public abstract class FlightLogGetCmdlet<T, Timpl> : NinjectCmdlet<FlightLogModule>
        where T : class
        where Timpl : T
    {
        #region Methods

        protected override void ProcessRecord()
        {
            this.WriteObject(this.Get<IRepository<T>>().Retrieve(this.Get<Func<object, Timpl>>()(this)), true);
        }

        #endregion
    }
}