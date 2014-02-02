namespace Illallangi.FlightLog.Model
{
    using System;

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

        public override string ToString()
        {
            return string.Format("{0} ({1})", this.Name, this.Year);
        }

        #endregion
    }
}