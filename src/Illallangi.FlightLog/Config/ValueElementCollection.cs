using System.Configuration;

namespace Illallangi.FlightLog.Config
{
    public sealed class ValueElementCollection : ConfigurationElementCollection
    {
        public ValueElement this[int index]
        {
            get
            {
                return base.BaseGet(index) as ValueElement;
            }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ValueElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ValueElement)element).Value;
        }
    }
}