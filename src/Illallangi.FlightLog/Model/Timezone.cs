namespace Illallangi.FlightLog.Model
{
    public interface ITimezone
    {
        int? Id { get; set; }

        string Name { get; set; }

        int AirportCount { get; set; }

        string ToString();
    }

    public class Timezone : ITimezone
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

        public int AirportCount { get; set; }

        #endregion

        #region Calculated Properties

        #endregion

        public override string ToString()
        {
            return this.Name;
        }
    }
}