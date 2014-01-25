namespace Illallangi.FlightLog.PowerShell
{
    using System.Management.Automation;

    using Illallangi.LiteOrm;

    [Cmdlet(VerbsCommon.Get, Nouns.Null)]
    public abstract class FlightLogCmdlet<T> : NinjectCmdlet<FlightLogModule> where T : class
    {
        #region Fields

        private IRepository<T> currentRepository;

        #endregion

        #region Properties

        protected IRepository<T> Repository
        {
            get
            {
                return this.currentRepository ?? (this.currentRepository = this.GetRepository());
            }
        }
        
        #endregion

        #region Methods

        private IRepository<T> GetRepository()
        {
            return this.Get<IRepository<T>>();
        }

        #endregion
    }
}