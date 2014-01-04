using System.Configuration;
using System.Reflection;
using Illallangi.FlightLog.Config;
using Illallangi.FlightLog.Model;

using Illallangi.FlightLog.Repository;
using Illallangi.LiteOrm;
using Ninject.Modules;

namespace Illallangi.FlightLog
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