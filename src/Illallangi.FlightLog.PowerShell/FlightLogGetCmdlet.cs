namespace Illallangi.FlightLog.PowerShell
{
    using System;

    using Illallangi.LiteOrm;

    public abstract class FlightLogGetCmdlet<T> : NinjectCmdlet<FlightLogModule>
        where T : class
    {
        #region Methods

        protected override void ProcessRecord()
        {
            this.WriteObject(this.Get<IRepository<T>>().Retrieve(this.Get<Func<object, T>>()(this)), true);
        }

        #endregion
    }
}