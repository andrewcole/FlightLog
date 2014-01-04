namespace Illallangi.FlightLog.Model
{
    public class City
    {
        public int? Id { get; set; }

        public string Name { get; set; }
        
        public int? CountryId { get; set; }

        public string CountryName { get; set; }
        
        public int? Airports { get; set; }

        public override string ToString()
        {
            return string.Format(@"{0}, {1}", this.Name, this.CountryName);
        }
    }
}