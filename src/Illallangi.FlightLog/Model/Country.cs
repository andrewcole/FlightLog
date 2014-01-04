
namespace Illallangi.FlightLog.Model
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Cities { get; set; }
        
        public int Airports { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}