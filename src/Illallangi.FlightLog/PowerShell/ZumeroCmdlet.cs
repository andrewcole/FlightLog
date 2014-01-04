using System.Management.Automation;
using Ninject;

namespace Illallangi.FlightLog.PowerShell
{
    [Cmdlet(VerbsCommon.Get, Nouns.Null)]
    public abstract class ZumeroCmdlet<T> : PSCmdlet where T : class
    {
        #region Fields

        private StandardKernel currentKernel;
        private FlightLogModule currentModule;
        private T currentRepository;

        #endregion

        #region Properties

        #region Protected Properties

        protected T Repository
        {
            get
            {
                return this.currentRepository ?? (this.currentRepository = this.GetRepository());
            }
        }

        #endregion

        #region Private Properties

        private FlightLogModule Module
        {
            get
            {
                return this.currentModule ?? (this.currentModule = this.GetModule());
            }
        }

        private StandardKernel Kernel
        {
            get
            {
                return this.currentKernel ?? (this.currentKernel = this.GetKernel());
            }
        }

        #endregion
        
        #endregion

        #region Methods

        private FlightLogModule GetModule()
        {
            return new FlightLogModule();
        }

        private StandardKernel GetKernel()
        {
            return new StandardKernel(this.Module);
        }

        private T GetRepository()
        {
            var repository = this.Kernel.Get<T>();
            return repository;
        }

        #endregion
    }
}