namespace Illallangi.FlightLog.PowerShell
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Management.Automation;

    using Illallangi.LiteOrm;

    public abstract class FlightLogRemoveCmdlet<T, Timpl> : NinjectCmdlet<FlightLogModule>
        where T : class
        where Timpl : T
    {
        #region Fields

        private ICollection<T> currentCollection;

        #endregion

        #region Methods

        protected override void ProcessRecord()
        {
            foreach (var o in this.Get<IRepository<T>>()
                                  .Retrieve(this.Get<Func<object, Timpl>>()(this))
                                  .Where(o => this.ShouldProcess(o.ToString(), VerbsCommon.Remove)))
            {
                this.Collection.Add(o);
            }
        }

        protected override void EndProcessing()
        {
            this.Get<IRepository<T>>().Delete(this.Collection.ToArray());
        }

        #endregion

        #region Properties

        private ICollection<T> Collection
        {
            get
            {
                return this.currentCollection ?? (this.currentCollection = new Collection<T>());
            }
        }

        #endregion
    }
}