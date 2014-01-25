namespace Illallangi.FlightLog.PowerShell.Airport
{
    using System;
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Get, Nouns.Airport)]
    public sealed class GetAirportCmdlet : FlightLogGetCmdlet<IAirport>, IAirport
    {
        private string currentCountry;

        private string currentCity;

        private string currentName;

        private string currentIata;

        private string currentIcao;

        protected override IAirport Target
        {
            get
            {
                return this;
            }
        }

        public int? Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        [SupportsWildcards]
        [Parameter(Mandatory = false)]
        public string Country
        {
            get
            {
                return this.currentCountry;
            }
            set
            {
                this.currentCountry = value;
            }
        }

        [SupportsWildcards]
        [Parameter(Mandatory = false)]
        public string City
        {
            get
            {
                return this.currentCity;
            }
            set
            {
                this.currentCity = value;
            }
        }

        public string Timezone
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        [SupportsWildcards]
        [Parameter(Mandatory = false, Position = 1)]
        public string Name
        {
            get
            {
                return this.currentName;
            }
            set
            {
                this.currentName = value;
            }
        }

        [SupportsWildcards]
        [Parameter(Mandatory = false)]
        public string Icao
        {
            get
            {
                return this.currentIcao;
            }
            set
            {
                this.currentIcao = value;
            }
        }

        public float Latitude
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public float Longitude
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public float Altitude
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        [SupportsWildcards]
        [Parameter(Mandatory = false)]
        public string Iata
        {
            get
            {
                return this.currentIata;
            }
            set
            {
                this.currentIata = value;
            }
        }
    }
}