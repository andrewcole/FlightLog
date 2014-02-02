namespace Illallangi.FlightLog.PowerShell.City
{
    using System.Management.Automation;

    

    [Cmdlet(VerbsCommon.Get, Nouns.City)]
    public sealed class GetCityCmdlet : FlightLogGetCmdlet<ICity>
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