namespace Illallangi.FlightLog.PowerShell.Trip
{
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Add, Nouns.Trip)]
    public sealed class AddTripCmdlet : FlightLogAddCmdlet<ITrip, Trip>
    {
        #region Parent Properties

        [Parameter(Mandatory = true)]
        public string Year { get; set; }

        #endregion

        #region Instance Properties

        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        [Parameter(Mandatory = false)]
        public string Description { get; set; }

        #endregion
    }
}