namespace Illallangi.FlightLog.PowerShell.City
{
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Get, Nouns.City)]
    public sealed class GetCityCmdlet : FlightLogGetCmdlet<ICity>, ICity
    {
        [SupportsWildcards]
        [Parameter(Mandatory = false)]
        public string Country { get; set; }

        [SupportsWildcards]
        [Parameter(Mandatory = false, Position = 1)]
        public string Name { get; set; }

        protected override ICity Target
        {
            get
            {
                return this;
            }
        }

        int? ICity.Id
        {
            get
            {
                return null;
            }
        }

        string ICity.Country
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.Country) ?
                    null :
                    new WildcardPattern(this.Country).ToWql();
            }
        }

        string ICity.Name
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.Name) ?
                    null :
                    new WildcardPattern(this.Name).ToWql();
            }
        }

        int ICity.AirportCount
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }
    }
}