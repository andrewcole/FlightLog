using System.Configuration;
using System.Reflection;
using Illallangi.FlightLogPS.Config;
using Illallangi.FlightLogPS.Model;
using Illallangi.FlightLogPS.SQLite;
using Illallangi.FlightLogPS.Repository;
using Ninject.Modules;

namespace Illallangi.FlightLogPS
{
    public sealed class ZumeroModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IConfig>()
                .ToMethod(
                    cx =>
                        (FlightLogConfig)
                            ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location)
                                .GetSection("FlightLogConfig")).InSingletonScope();


            this.Bind<IConnectionSource>().To<SQLiteConnectionSource>().InTransientScope();

            this.Bind<ICountrySource>().To<CountryRepository>().InTransientScope();
            this.Bind<ICitySource>().To<CityRepository>().InTransientScope();
            this.Bind<IAirportSource>().To<AirportRepository>().InTransientScope();
        }
    }
}