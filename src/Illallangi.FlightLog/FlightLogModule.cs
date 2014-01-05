using System.Configuration;
using System.Reflection;
using Illallangi.FlightLog.Config;
using Illallangi.FlightLog.Context;
using Illallangi.FlightLog.Model;
using Illallangi.LiteOrm;
using log4net.Config;
using Ninject.Modules;

namespace Illallangi.FlightLog
{
    public sealed class FlightLogModule : NinjectModule
    {
        public override void Load()
        {
            XmlConfigurator.Configure(
                Assembly
                    .GetExecutingAssembly()
                    .GetManifestResourceStream(
                        string.Format(
                            "{0}.Log4Net.config",
                            Assembly.GetExecutingAssembly().GetName().Name)));

            this.Bind<ILiteOrmConfig>()
                .ToMethod(
                    cx =>
                        (FlightLogConfig)
                            ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location)
                                .GetSection("FlightLogConfig")).InSingletonScope();

            this.Bind<IRepository<IYear>>().To<YearRepository>().InSingletonScope();
            this.Bind<IRepository<Trip>>().To<TripRepository>().InSingletonScope();
            this.Bind<IRepository<Country>>().To<CountryRepository>().InSingletonScope();
            this.Bind<IRepository<City>>().To<CityRepository>().InSingletonScope();
            this.Bind<IRepository<Airport>>().To<AirportRepository>().InSingletonScope();
            this.Bind<IRepository<Flight>>().To<FlightRepository>().InSingletonScope();
            
            this.Bind<IConnectionSource>().To<SQLiteConnectionSource>().InSingletonScope();
        }
    }
}