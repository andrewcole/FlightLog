namespace Illallangi.FlightLog.PowerShell.Trip
{
    using System.Management.Automation;

    

    [Cmdlet(VerbsCommon.Add, Nouns.Trip)]
    public class AddTripCmdlet : FlightLogAddCmdlet<ITrip>
    {
        #region Parent Properties

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Year { get; set; }

        #endregion

        #region Instance Properties

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Alias("Trip")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Description { get; set; }

        #endregion
    }

    [Cmdlet(VerbsData.Import, Nouns.Trip)]
    public class ImportTripCmdlet : AddTripCmdlet 
    {
        protected override InsertMode Mode
        {
            get
            {
                return InsertMode.Import;
            }
        }
    }
}