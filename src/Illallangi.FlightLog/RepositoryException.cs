namespace Illallangi.FlightLog
{
    using System;
    using System.Data.SQLite;

    public class RepositoryException<T> : Exception
    {
        private readonly T currentTarget;

        private readonly string currentErrorId;

        public RepositoryException(T target, SQLiteException sqe)
            : base(sqe.Message, sqe)
        {
            this.currentTarget = target;
            this.currentErrorId = sqe.ErrorCode.ToString();
        }

        public T Target
        {
            get
            {
                return this.currentTarget;
            }
        }

        public string ErrorId
        {
            get
            {
                return this.currentErrorId;
            }
        }
    }
}