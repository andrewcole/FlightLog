namespace Illallangi.FlightLog.PowerShell.Country
{
    using System;
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Get, Nouns.Country)]
    public sealed class GetCountryCmdlet : FlightLogCmdlet<ICountry>, ICountry
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
                return (new WildcardPattern(this.Name)).ToWql();
            }
        }

        int ICountry.CityCount
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override void BeginProcessing()
        {
            this.WriteObject(this.Repository.Retrieve(this), true);
        }
    }
}