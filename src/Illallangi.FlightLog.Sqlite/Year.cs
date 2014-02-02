namespace Illallangi.FlightLog.Sqlite
{
    public class Year : IYear
    {
        #region Primary Key Property

        public int? Id { get; set; }

        #endregion

        #region Parent Properties

        #endregion

        #region Instance Properties

        public string Name { get; set; }

        #endregion

        #region Child Properties

        public int TripCount { get; set; }

        #endregion

        #region Calculated Properties

        #endregion

        #region Methods

        public override string ToString()
        {
            return string.Format("Year {0}", this.Name);
        }

        #endregion
    }
}
