using System.Management.Automation;

namespace Illallangi.FlightLog.PowerShell
{
    [Cmdlet(VerbsCommon.Get, Nouns.Null)]
    public abstract class FlightLogCmdlet<T> : NinjectCmdlet where T : class
    {
        #region Fields

        private ISource<T> currentRepository;

        #endregion

        #region Properties

        protected ISource<T> Repository
        {
            get
            {
                return this.currentRepository ?? (this.currentRepository = this.GetRepository());
            }
        }
        
        #endregion

        #region Methods

        private ISource<T> GetRepository()
        {
            return this.Get<ISource<T>>();
        }

        #endregion
    }
}