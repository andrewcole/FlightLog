namespace Illallangi.FlightLog.Model
{
    public interface ICountry
    {
        int? Id { get; set; }

        string Name { get; set; }

        int CityCount { get; set; }

        string ToString();
    }

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

        public override string ToString()
        {
            return this.Name;
        }
    }
}