namespace Illallangi.FlightLog.PowerShell.Country
{
    using System;
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Get, Nouns.Country)]
    public sealed class GetCountryCmdlet : FlightLogGetCmdlet<ICountry>, ICountry
    {
        [SupportsWildcards]
        [Parameter(Mandatory = false, Position = 1)]
        public string Name { get; set; }

        int? ICountry.Id
        {
            get
            {
                return null;
            }
        }

        string ICountry.Name
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.Name) ?
                    null :
                    new WildcardPattern(this.Name).ToWql();
            }
        }

        int ICountry.CityCount
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override ICountry Target
        {
            get
            {
                return this;
            }
        }
    }
}