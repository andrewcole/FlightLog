namespace Illallangi.FlightLog.Sqlite
{
    public class Country : ICountry
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

        public int CityCount { get; set; }

        #endregion

        #region Calculated Properties

        #endregion

        #region Methods

        public override string ToString()
        {
            return this.Name;
        }

        #endregion
    }
}