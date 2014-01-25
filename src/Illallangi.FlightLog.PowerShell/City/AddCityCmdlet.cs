namespace Illallangi.FlightLog.PowerShell.City
{
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Add, Nouns.City)]
    public sealed class AddCityCmdlet : FlightLogAddCmdlet<ICity, City>
    {
        #region Properties

        [Parameter(Mandatory = true)]
        public string Country { get; set; }

        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        #endregion
    }
}