namespace Illallangi.FlightLog
{
    using System;
    using System.Globalization;

    public class RepositoryException<T> : Exception
    {
        private readonly T currentTarget;

        private readonly string currentErrorId;

        public RepositoryException(T target, string message, int errorId, Exception innerException)
            : this(target, message, errorId.ToString(CultureInfo.InvariantCulture), innerException)
        {
        }

        public RepositoryException(T target, string message, string errorId, Exception innerException)
            : base(message, innerException)
        {
            this.currentTarget = target;
            this.currentErrorId = errorId;
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