using System.Configuration;
using System.Reflection;
using Illallangi.FlightLog.Config;
using Illallangi.FlightLog.Context;
using Illallangi.FlightLog.Model;
using Illallangi.LiteOrm;
using Ninject.Modules;

namespace Illallangi.FlightLog
{
    public sealed class FlightLogModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ILiteOrmConfig>()
                .ToMethod(
                    cx =>
                        (FlightLogConfig)
                            ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location)
                                .GetSection("FlightLogConfig")).InSingletonScope();
            this.Bind<ISource<Country>>().To<CountryRepository>().InTransientScope();
            this.Bind<ISource<City>>().To<CityRepository>().InTransientScope();
            this.Bind<ISource<Airport>>().To<AirportRepository>().InTransientScope();
            this.Bind<IConnectionSource>().To<SQLiteConnectionSource>().InSingletonScope();
        }
    }
}