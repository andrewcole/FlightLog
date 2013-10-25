using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Illallangi.FlightLogPS.Config
{
    public sealed class FlightLogConfig : ConfigurationSection, IConfig
    {
        #region Properties

        [ConfigurationProperty("DbPath", DefaultValue = @"FlightLog.dat")]
        public string DbPath
        {
            get { return (string)this["DbPath"]; }
            set { this["DbPath"] = value; }
        }

        [ConfigurationProperty("ConnectionString", DefaultValue = @"data source=""{0}""")]
        public string ConnectionString
        {
            get { return (string)this["ConnectionString"]; }
            set { this["ConnectionString"] = value; }
        }

        [ConfigurationProperty("Extension")]
        public ValueElementCollection ExtensionCollection
        {
            get
            {
                return (ValueElementCollection)this["Extension"] ??
                       new ValueElementCollection();
            }
        }

        [ConfigurationProperty("SqlSchema")]
        public ValueElementCollection SqlSchemaCollection
        {
            get
            {
                return (ValueElementCollection)this["SqlSchema"] ??
                       new ValueElementCollection();
            }
        }
        [ConfigurationProperty("Pragma")]
        public ValueElementCollection PragmaCollection
        {
            get
            {
                return (ValueElementCollection)this["Pragma"] ??
                       new ValueElementCollection();
            }
        }

        public IEnumerable<string> Extensions
        {
            get
            {
                return this.ExtensionCollection.Cast<ValueElement>().Select(element => element.Value);
            }
        }

        public IEnumerable<string> Pragmas
        {
            get
            {
                return this.PragmaCollection.Cast<ValueElement>().Select(element => element.Value);
            }
        }


        public IEnumerable<string> SqlSchema
        {
            get
            {
                return this.SqlSchemaCollection.Cast<ValueElement>().Select(element => element.Value);
            }
        }

        #endregion
    }
}