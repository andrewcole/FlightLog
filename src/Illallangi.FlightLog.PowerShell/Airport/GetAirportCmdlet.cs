namespace Illallangi.FlightLog.PowerShell.Airport
{
    using System;
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Get, Nouns.Airport)]
    public sealed class GetAirportCmdlet : FlightLogGetCmdlet<IAirport, Airport>
    {[SupportsWildcards]
        [Parameter(Mandatory = false)]
        public string Country { get; set; }
        
        [SupportsWildcards]
        [Parameter(Mandatory = false)]
        public string City { get; set; }
        
        [SupportsWildcards]
        [Parameter(Mandatory = false, Position = 1)]
        public string Name { get; set; }
        
        [SupportsWildcards]
        [Parameter(Mandatory = false)]
        public string Icao { get; set; }
        
        [SupportsWildcards]
        [Parameter(Mandatory = false)]
        public string Iata { get; set; }
    }
}