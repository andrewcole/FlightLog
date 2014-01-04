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

            this.Bind<ISource<Year>>().To<YearRepository>().InSingletonScope();
            this.Bind<ISource<Trip>>().To<TripRepository>().InSingletonScope();
            this.Bind<ISource<Country>>().To<CountryRepository>().InSingletonScope();
            this.Bind<ISource<City>>().To<CityRepository>().InSingletonScope();
            this.Bind<ISource<Airport>>().To<AirportRepository>().InSingletonScope();
            this.Bind<ISource<Flight>>().To<FlightRepository>().InSingletonScope();
            
            this.Bind<IConnectionSource>().To<SQLiteConnectionSource>().InSingletonScope();
        }
    }
}