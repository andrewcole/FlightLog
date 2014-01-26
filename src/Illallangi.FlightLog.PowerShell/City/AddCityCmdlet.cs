namespace Illallangi.FlightLog.PowerShell.City
{
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Add, Nouns.City)]
    public sealed class AddCityCmdlet : FlightLogAddCmdlet<ICity, City>
    {
        #region Parent Properties

        [Parameter(Mandatory = true)]
        public string Country { get; set; }

        #endregion

        #region Instance Properties

        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        #endregion
    }
}