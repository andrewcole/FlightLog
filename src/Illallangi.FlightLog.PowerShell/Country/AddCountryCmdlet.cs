namespace Illallangi.FlightLog.PowerShell.Country
{
    using System.Management.Automation;

    

    [Cmdlet(VerbsCommon.Add, Nouns.Country)]
    public class AddCountryCmdlet : FlightLogAddCmdlet<ICountry>
    {
        #region Instance Properties

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 1)]
        [Alias("Country")]
        public string Name { get; set; }

        #endregion
    }

    [Cmdlet(VerbsData.Import, Nouns.Country)]
    public sealed class ImportCountryCmdlet : AddCountryCmdlet
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