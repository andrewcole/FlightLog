namespace Illallangi.FlightLog.Model
{
    public class Trip
    {
        #region Primary Key Property

        public int? Id { get; set; }

        #endregion

        #region Parent Properties

        public string Year { get; set; }

        #endregion

        #region Instance Properties

        public string Name { get; set; }

        public string Description { get; set; }

        #endregion

        #region Child Properties

        public int FlightCount { get; set; }

        #endregion

        #region Calculated Properties

        #endregion
    }
}