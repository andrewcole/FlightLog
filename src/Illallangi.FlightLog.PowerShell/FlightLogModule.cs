namespace Illallangi.FlightLog.PowerShell
{
    using System;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Reflection;

    using AutoMapper;

    using Common.Logging;
    using Common.Logging.Log4Net;

    using Illallangi.FlightLog.Config;
    using Illallangi.FlightLog.Constraints;
    
    using Illallangi.FlightLog.PowerShell.Config;
    using Illallangi.FlightLog.Sqlite.Context;
    using Illallangi.LiteOrm;

    using log4net.Config;

    using Ninject.Modules;

    public sealed class FlightLogModule : NinjectModule
    {
        public override void Load()
        {
            LogManager.Adapter = new Log4NetLoggerFactoryAdapter(new NameValueCollection { { "configType", "EXTERNAL" } });

            XmlConfigurator.Configure(
                Assembly
                    .GetExecutingAssembly()
                    .GetManifestResourceStream(
                        string.Format(
                            "{0}.Log4Net.config",
                            Assembly.GetExecutingAssembly().GetName().Name)));

            Mapper.CreateMap<string, string>().ConvertUsing((i) => string.IsNullOrWhiteSpace(i) ? null : i);

            this.Bind<IFlightLogConfig>()
                .ToMethod(
                    cx =>
                        (FlightLogConfig)
                            ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location)
                                .GetSection("FlightLogConfig")).InSingletonScope();

            this.BindModel<IAirport, AirportRepository, AirportConstraintsChecker>();
            this.BindModel<ICity, CityRepository>();
            this.BindModel<ICountry, CountryRepository>();
            this.BindModel<IFlight, FlightRepository, FlightConstraintsChecker>();
            this.BindModel<ITimezone, TimezoneRepository>();
            this.BindModel<ITrip, TripRepository>();
            this.BindModel<IYear, YearRepository>();

            this.Bind<ILog>().ToMethod(cx => LogManager.GetLogger(cx.Request.Target.Type));
        }

        private void BindModel<TInt, TRepo>() 
            where TInt : class 
            where TRepo : IRepository<TInt>
        {
            this.BindModel<TInt, TRepo, NullConstraintsChecker<TInt>>();
        }

        private void BindModel<TInt, TRepo, TConstraints>() 
            where TInt : class 
            where TRepo : IRepository<TInt>
            where TConstraints : IConstraintsChecker<TInt>
        {
            this.Bind<Func<object, TInt>>().ToMethod(context => (obj) => Mapper.DynamicMap<TInt>(obj)).InSingletonScope();
            this.Bind<IRepository<TInt>>().To<TRepo>().InSingletonScope();
            this.Bind<IConstraintsChecker<TInt>>().To<TConstraints>().InSingletonScope();
        }
    }
}