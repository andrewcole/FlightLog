namespace Illallangi.FlightLog.PowerShell
{
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Management.Automation;
    using System.Net.Configuration;
    using System.Reflection;
    using System.Text;

    
    using Illallangi.LiteOrm;

    using Newtonsoft.Json;

    [Cmdlet(VerbsData.Export, "FlightLogToHtml")]
    public sealed class ExportFlightLogToHtml : NinjectCmdlet<FlightLogModule>
    {
        private string currentPath;

        [Parameter(Mandatory = true, Position = 1)]
        [Alias("Path")]
        public string Output
        {
            get
            {
                return Path.GetFullPath(this.currentPath);
            }
            set
            {
                this.currentPath = value;
            }
        }

        protected override void BeginProcessing()
        {
            if (!Directory.Exists(this.Output))
            {
                Directory.CreateDirectory(this.Output);
            }

            using (var indexStream = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream(
                    string.Format("{0}.Web.index.html", Assembly.GetExecutingAssembly().GetName().Name)))
            using (var fileStream = File.Create(this.IndexHtmlFile))
            {
                Debug.Assert(indexStream != null, "indexStream != null");
                indexStream.CopyTo(fileStream);
            }

            this.WriteJson(new
                                 {
                                     type = "index",
                                     id = "index",
                                     years = this.Get<IRepository<IYear>>()
                                         .Retrieve()
                                         .Select(
                                             year => new
                                                         {
                                                             name = year.Name,
                                                             id = Hash(year),
                                                         }),
                                    tails =
                                        this.Get<IRepository<IFlight>>()
                                            .Retrieve()
                                            .GroupBy(flight => flight.Airline)
                                            .OrderByDescending(count => count.Count())
                                            .Select(count => count.Key)
                                            .Take(5),
                                 },
                                 this.IndexJsonFile);

            foreach (var year in this.Get<IRepository<IYear>>().Retrieve())
            {
                this.WriteJson(new
                {
                    type = "year",
                    id = Hash(year),
                    trips = this.Get<IRepository<ITrip>>()
                        .Retrieve(new { Year = year.Name })
                        .Select(
                            trip => new
                            {
                                name = trip.Name,
                                id = Hash(trip),
                            })
                });
            }

            foreach (var trip in this.Get<IRepository<ITrip>>().Retrieve())
            {
                this.WriteJson(new
                {
                    type = "trip",
                    id = Hash(trip),
                    trip.Description,
                    flights = this.Get<IRepository<IFlight>>()
                        .Retrieve(new { Year = trip.Year, Trip = trip.Name })
                        .Select(
                            flight => new
                            {
                                flight.Origin,
                                flight.Destination,
                                flight.Airline,
                                flight.Number,
                            })
                });
            }
        }

        private void WriteJson(dynamic index, string path = null)
        {
            File.WriteAllText(Path.Combine(this.Output, Path.ChangeExtension(index.id, "json")), JsonConvert.SerializeObject(index, Formatting.Indented));
        }

        private static string Hash(object obj)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                var retVal = md5.ComputeHash(Encoding.Unicode.GetBytes(obj.ToString()));
                var sb = new StringBuilder();
                foreach (var t in retVal)
                {
                    sb.Append(t.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        private string IndexHtmlFile
        {
            get
            {
                return Path.Combine(this.Output, "index.html");
            }
        }
        private string IndexJsonFile
        {
            get
            {
                return Path.Combine(this.Output, "index.json");
            }
        }
    }
}