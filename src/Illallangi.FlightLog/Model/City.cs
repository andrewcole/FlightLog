namespace Illallangi.FlightLog.Model
{
    public class City
    {
        #region Primary Key Property

        public int? Id { get; set; }

        #endregion

        #region Parent Properties

        public string Country { get; set; }

        #endregion

        #region Instance Properties

        public string Name { get; set; }

        #endregion

        #region Child Properties

        public int AirportCount { get; set; }

        #endregion

        #region Calculated Properties

        #endregion

        public override string ToString()
        {
            return string.Format(@"{0}, {1}", this.Name, this.Country);
        }
    }
}