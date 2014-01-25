namespace Illallangi.FlightLog.PowerShell.Year
{
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Add, Nouns.Year)]
    public sealed class AddYearCmdlet : FlightLogAddCmdlet<IYear, Year>
    {
        #region Properties

        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        #endregion
    }
}