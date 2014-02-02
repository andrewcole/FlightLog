namespace Illallangi.FlightLog.PowerShell.Year
{
    using System.Management.Automation;

    

    [Cmdlet(VerbsCommon.Add, Nouns.Year)]
    public class AddYearCmdlet : FlightLogAddCmdlet<IYear>
    {
        #region Instance Properties

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 1)]
        [Alias("Year")]
        public string Name { get; set; }

        #endregion
    }

    [Cmdlet(VerbsData.Import, Nouns.Year)]
    public sealed class ImportYearCmdlet : AddYearCmdlet
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