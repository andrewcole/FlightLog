using System.Configuration;

namespace Illallangi.FlightLog.Config
{
    public class ValueElement : ConfigurationElement
    {
        [ConfigurationProperty("Value", IsRequired = true)]
        public string Value
        {
            get { return (string)this["Value"]; }
            set { this["Value"] = value; }
        }
    }
}