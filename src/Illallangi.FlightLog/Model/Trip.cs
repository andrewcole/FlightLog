namespace Illallangi.FlightLog.Model
{
    using System;

    public interface ITrip
    {
        int? Id { get; set; }

        string Year { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        int FlightCount { get; set; }

        DateTime? Departure { get; set; }

        DateTime? Arrival { get; set; }
    }

    public class Trip : ITrip
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

        public DateTime? Departure { get; set; }

        public DateTime? Arrival { get; set; }

        #endregion

        #region Calculated Properties

        #endregion
    }
}