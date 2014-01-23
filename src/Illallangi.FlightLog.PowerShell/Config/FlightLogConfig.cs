namespace Illallangi.FlightLog.PowerShell.Config
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using Illallangi.FlightLog.Config;

    public sealed class FlightLogConfig : ConfigurationSection, IFlightLogConfig
    {
        #region Properties

        [ConfigurationProperty("DatabasePath", DefaultValue = @"FlightLog.dat")]
        public string DatabasePath
        {
            get
            {
                return Path.GetFullPath(Environment.ExpandEnvironmentVariables((string)this["DatabasePath"]));
            }
        }

        [ConfigurationProperty("ConnectionString", DefaultValue = @"data source=""{0}""")]
        public string ConnectionString
        {
            get
            {
                return string.Format((string)this["ConnectionString"], this.DatabasePath);
            }
        }

        [ConfigurationProperty("Extensions")]
        public ValueElementCollection ExtensionCollection
        {
            get
            {
                return (ValueElementCollection)this["Extensions"] ??
                       new ValueElementCollection();
            }
        }

        [ConfigurationProperty("Pragmas")]
        public ValueElementCollection PragmaCollection
        {
            get
            {
                return (ValueElementCollection)this["Pragmas"] ??
                       new ValueElementCollection();
            }
        }

        [ConfigurationProperty("SqlSchemaLines")]
        public ValueElementCollection SqlSchemaLineCollection
        {
            get
            {
                return (ValueElementCollection)this["SqlSchemaLines"] ??
                       new ValueElementCollection();
            }
        }

        [ConfigurationProperty("SqlSchemaFiles")]
        public ValueElementCollection SqlSchemaFileCollection
        {
            get
            {
                return (ValueElementCollection)this["SqlSchemaFiles"] ??
                       new ValueElementCollection();
            }
        }

        public IEnumerable<string> Extensions
        {
            get
            {
                foreach (var extension in this.ExtensionCollection.Cast<ValueElement>().Select(element => element.Value))
                {
                    if (null != Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) &&
                             File.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), extension)))
                    {
                        yield return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), extension);
                    }
                    else if (File.Exists(extension))
                    {
                        yield return extension;
                    }
                    else if (File.Exists(Path.GetFullPath(extension)))
                    {
                        yield return Path.GetFullPath(extension);
                    }
                    else
                    {
                        throw new FileNotFoundException(extension);
                    }
                }
            }
        }

        public IEnumerable<string> Pragmas
        {
            get
            {
                return this.PragmaCollection.Cast<ValueElement>().Select(element => element.Value);
            }
        }

        public IEnumerable<string> SqlSchemaLines
        {
            get
            {
                return this.SqlSchemaLineCollection.Cast<ValueElement>().Select(element => element.Value);
            }
        }

        public IEnumerable<string> SqlSchemaFiles
        {
            get
            {
                foreach (var sqlSchemaFile in this.SqlSchemaFileCollection.Cast<ValueElement>().Select(element => element.Value))
                {
                    if (null != Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) &&
                             File.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), sqlSchemaFile)))
                    {
                        yield return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), sqlSchemaFile);
                    }
                    else if (File.Exists(sqlSchemaFile))
                    {
                        yield return sqlSchemaFile;
                    }
                    else if (File.Exists(Path.GetFullPath(sqlSchemaFile)))
                    {
                        yield return Path.GetFullPath(sqlSchemaFile);
                    }
                    else
                    {
                        throw new FileNotFoundException(sqlSchemaFile);
                    }
                }
            }
        }

        #endregion
    }
}