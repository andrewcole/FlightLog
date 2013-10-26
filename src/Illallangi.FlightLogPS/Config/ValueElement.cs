using System;
using System.Configuration;

namespace Illallangi.FlightLogPS.Config
{
    public class ValueElement : ConfigurationElement
    {
        [ConfigurationProperty("Value", IsRequired = true)]
        public string Value
        {
            get { return (String) this["Value"]; }
            set { this["Value"] = value; }
        }
    }
}