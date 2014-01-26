namespace Illallangi.FlightLog.PowerShell.City
{
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Get, Nouns.City)]
    public sealed class GetCityCmdlet : FlightLogGetCmdlet<ICity, City>
    {
        #region Parent Properties
        
        [SupportsWildcards]
        [Parameter(Mandatory = false)]
        public string Country { get; set; }

        #endregion

        #region Instance Properties

        [SupportsWildcards]
        [Parameter(Mandatory = false)]
        public string Name { get; set; }

        #endregion
    }
}