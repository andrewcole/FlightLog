using System.Management.Automation;
using Ninject;
using Ninject.Modules;

namespace Illallangi.FlightLog.PowerShell
{
    [Cmdlet(VerbsCommon.Get, Nouns.Null)]
    public abstract class NinjectCmdlet : PSCmdlet
    {
        #region Fields

        private INinjectModule currentFlightLogModule;

        private INinjectModule currentLog4NetModule;

        private StandardKernel currentKernel;

        #endregion

        #region Properties

        private INinjectModule FlightLogModule
        {
            get
            {
                return this.currentFlightLogModule ?? (this.currentFlightLogModule = this.GetFlightLogModule());
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

        #region Methods

        #region Protected Methods

        protected T Get<T>()
        {
            return this.Kernel.Get<T>();
        }

        #endregion

        #region Private Methods

        private INinjectModule GetFlightLogModule()
        {
            return new FlightLogModule();
        }

        private StandardKernel GetKernel()
        {
            return new StandardKernel(this.FlightLogModule);
        }

        #endregion

        #endregion
    }
}