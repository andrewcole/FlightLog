using System.Management.Automation;
using Illallangi.FlightLog.Context;
using Ninject;

namespace Illallangi.FlightLog.PowerShell
{
    [Cmdlet(VerbsCommon.Get, Nouns.Null)]
    public abstract class ZumeroCmdlet<T> : PSCmdlet where T: class, IDebugHooks
    {
        private StandardKernel currentKernel;
        private FlightLogModule currentModule;
        private T currentRepository;
        
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

        protected T Repository
        {
            get
            {
                return this.currentRepository ?? (this.currentRepository = this.GetRepository());
            }
        }

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
            repository.Debug += (sender, e) => this.WriteDebug(e.Message);
            return repository;
        }
    }
}