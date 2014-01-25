namespace Illallangi.FlightLog.PowerShell.Year
{
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Get, Nouns.Year)]
    public sealed class GetYearCmdlet : FlightLogGetCmdlet<IYear>, IYear
    {
        private string currentName;

        public int? Id
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        [SupportsWildcards]
        [Parameter(Position = 1)]
        public string Name
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.currentName) ?
                    null :
                    new WildcardPattern(this.currentName).ToWql();
            }
            set
            {
                this.currentName = value;
            }
        }

        public int TripCount
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        protected override IYear Target
        {
            get
            {
                return this;
            }
        }
    }
}
