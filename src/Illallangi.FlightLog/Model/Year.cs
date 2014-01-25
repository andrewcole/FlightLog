namespace Illallangi.FlightLog.Model
{
    public interface IYear
    {
        int? Id { get; }

        string Name { get; }

        int TripCount { get; }
    }

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
    }
}
