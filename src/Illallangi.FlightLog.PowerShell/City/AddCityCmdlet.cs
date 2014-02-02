namespace Illallangi.FlightLog.PowerShell.City
{
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Add, Nouns.City)]
    public class AddCityCmdlet : FlightLogAddCmdlet<ICity, City>
    {
        #region Parent Properties

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Country { get; set; }

        #endregion

        #region Instance Properties

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Alias("City")]
        public string Name { get; set; }

        #endregion
    }

    [Cmdlet(VerbsData.Import, Nouns.City)]
    public class ImportCityCmdlet : AddCityCmdlet
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