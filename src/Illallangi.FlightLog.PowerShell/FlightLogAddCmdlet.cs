namespace Illallangi.FlightLog.PowerShell
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using Illallangi.LiteOrm;

    public abstract class FlightLogAddCmdlet<T, Timpl> : NinjectCmdlet<FlightLogModule>
        where T : class
        where Timpl : T
    {
        #region Fields

        private ICollection<T> currentCollection;

        #endregion

        #region Methods

        protected override void ProcessRecord()
        {
            this.Collection.Add(this.Get<Func<object, Timpl>>()(this));
        }

        protected override void EndProcessing()
        {
            this.WriteObject(this.Get<IRepository<T>>().Create(this.Collection.ToArray()), true);
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