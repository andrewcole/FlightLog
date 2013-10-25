using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using Illallangi.T4Database.Repository;

namespace Illallangi.FlightLog.Repository
{
    public sealed class SqlResources : ISqlResources
    {
        #region Fields

        private static ResourceManager staticResourceManager;

        private static CultureInfo staticCultureInfo;

        #endregion

        #region Properties

        private static ResourceManager ResourceManager
        {
            get
            {
                return SqlResources.staticResourceManager ?? (SqlResources.staticResourceManager = new ResourceManager("Illallangi.FlightLog.Repository.SqlResources", typeof(SqlResources).Assembly));
            }
        }

        public static CultureInfo CultureInfo
        {
            get
            {
                return SqlResources.staticCultureInfo;
            }

            set
            {
                SqlResources.staticCultureInfo = value;
            }
        }

        #endregion

        #region Methods

        public string Table(string table)
        {
            return SqlResources.GetString(table, "Table");
        }

        public string View(string table)
        {
            return SqlResources.GetString(table, "View");
        }

        public string Create<T>()
        {
            return SqlResources.GetString<T>("Create");
        }

        public string Retrieve<T>()
        {
            return SqlResources.GetString<T>("Retrieve");
        }

        public string RetrieveById<T>()
        {
            return SqlResources.GetString<T>("RetrieveById");
        }

        public string Update<T>()
        {
            return SqlResources.GetString<T>("Update");
        }

        public string Delete<T>()
        {
            return SqlResources.GetString<T>("Delete");
        }

        public string Search<T>()
        {
            return SqlResources.GetString<T>("Search");
        }

        public string DbPath
        {
            get
            {
                return SqlResources.GetString("DbPath");
            }
        }

        public string ConnectionString
        {
            get
            {
                return SqlResources.GetString("ConnectionString");
            }
        }

        public IEnumerable<string> Tables
        {
            get
            {
                yield return "Airport";
                yield return "Airline";
            }
        }

        private static string GetString<T>(string value)
        {
            return SqlResources.GetString(typeof(T).Name, value);
        }

        private static string GetString(params string[] values)
        {
            var result = SqlResources.ResourceManager.GetString(string.Concat(values), SqlResources.CultureInfo);
            if (null == result)
            {
                throw new ArgumentException(string.Format("No resources string found for {0}", string.Concat(values)));
            }
            return result;
        }

        #endregion Methods
    }
}