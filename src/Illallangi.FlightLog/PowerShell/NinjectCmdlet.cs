using System.Management.Automation;
using Ninject;
using Ninject.Extensions.Logging.Log4net;
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

        private INinjectModule Log4NetModule
        {
            get
            {
                return this.currentLog4NetModule ?? (this.currentLog4NetModule = this.GetLog4NetModule());
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

        private INinjectModule GetLog4NetModule()
        {
            return new Log4NetModule();
        }

        private INinjectModule GetFlightLogModule()
        {
            return new FlightLogModule();
        }

        private StandardKernel GetKernel()
        {
            return new StandardKernel(this.FlightLogModule, this.Log4NetModule);
        }

        #endregion

        #endregion
    }
}