namespace Illallangi.FlightLog.PowerShell
{
    using AutoMapper;

    public abstract class FlightLogAddCmdlet<T, Timpl> : FlightLogCmdlet<T> where T: class where Timpl : T
    {
        #region Methods

        protected override void ProcessRecord()
        {
            this.WriteObject(this.Repository.Create(Mapper.DynamicMap<Timpl>(this)));
        }

        #endregion
    }
}