namespace Illallangi.FlightLog.PowerShell
{
    using AutoMapper;

    public abstract class FlightLogGetCmdlet<T, Timpl> : FlightLogCmdlet<T> where T : class where Timpl : T
    {
        #region Methods

        protected override void ProcessRecord()
        {
            this.WriteObject(this.Repository.Retrieve(Mapper.DynamicMap<Timpl>(this)), true);
        }

        #endregion
    }
}