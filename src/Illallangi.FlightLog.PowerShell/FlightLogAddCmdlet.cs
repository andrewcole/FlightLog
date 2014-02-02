namespace Illallangi.FlightLog.PowerShell
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.SQLite;
    using System.Linq;
    using System.Management.Automation;

    using Illallangi.FlightLog.Constraints;
    using Illallangi.FlightLog.Context;
    using Illallangi.LiteOrm;

    public abstract class FlightLogAddCmdlet<T, Timpl> : NinjectCmdlet<FlightLogModule>
        where T : class
        where Timpl : T
    {
        #region Fields

        private ICollection<T> currentCollection;

        private IEnumerable<T> currentExisting;

        private IRepository<T> currentRepository;

        private IConstraintsChecker<T> currentConstraintsChecker;

        #endregion

        #region Methods

        protected override void ProcessRecord()
        {
            var item = this.Get<Func<object, Timpl>>()(this);
            if (this.ConstraintsChecker.HasErrors(item, this.Collection, this.Existing))
            {
                foreach (var error in this.ConstraintsChecker.GetErrors(item, this.Collection, this.Existing))
                {
                    this.WriteWarning(error);
                }
            }
            else
            {
                this.Collection.Add(item);
            }
        }

        protected override void EndProcessing()
        {
            try
            {
                switch (this.Mode)
                {
                    case InsertMode.Add:
                        this.WriteObject(this.Repository.Create(this.Collection.ToArray()), true);
                        break;
                    case InsertMode.Import:
                        this.Repository.Import(this.Collection.ToArray());
                        break;
                }
            }
            catch (RepositoryException<T> sqe)
            {
                this.ThrowTerminatingError(new ErrorRecord(sqe.InnerException, sqe.ErrorId, ErrorCategory.WriteError, sqe.Target));
            }
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

        private IEnumerable<T> Existing
        {
            get
            {
                return this.currentExisting ?? (this.currentExisting = this.Repository.Retrieve().ToList());
            }
        }

        private IRepository<T> Repository
        {
            get
            {
                return this.currentRepository ?? (this.currentRepository = this.Get<IRepository<T>>());
            }
        }
        private IConstraintsChecker<T> ConstraintsChecker
        {
            get
            {
                return this.currentConstraintsChecker ?? (this.currentConstraintsChecker = this.Get<IConstraintsChecker<T>>());
            }
        }

        protected virtual InsertMode Mode
        {
            get
            {
                return InsertMode.Add;
            }
        }

        protected enum InsertMode
        {
            Add = 0,
            Import = 1,
        }

        #endregion
    }
}