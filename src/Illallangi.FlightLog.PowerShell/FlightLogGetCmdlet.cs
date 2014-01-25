namespace Illallangi.FlightLog.PowerShell
{
    public abstract class FlightLogGetCmdlet<T> : FlightLogCmdlet<T>
        where T : class
    {
        protected abstract T Target { get; }

        protected override void BeginProcessing()
        {
            this.WriteObject(this.Repository.Retrieve(this.Target), true);
        }
    }
}