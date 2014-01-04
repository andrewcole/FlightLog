using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Ninject.Extensions.Logging;

namespace Illallangi.LiteOrm
{
    public sealed class SQLiteConnectionSource : IConnectionSource
    {
        #region Fields

        private readonly ILiteOrmConfig currentLiteOrmConfig;
        private readonly ILogger currentLogger;

        #endregion

        #region Constructors

        public SQLiteConnectionSource(ILiteOrmConfig liteOrmConfig, ILogger logger)
        {
            this.currentLiteOrmConfig = liteOrmConfig;
            currentLogger = logger;
        }

        #endregion

        #region Properties

        private ILiteOrmConfig LiteOrmConfig
        {
            get
            {
                return this.currentLiteOrmConfig;
            }
        }

        private ILogger Logger
        {
            get { return this.currentLogger; }
        }

        #endregion

        #region Methods

        private string GetDbPath()
        {
            var dbPath = Path.GetFullPath(Environment.ExpandEnvironmentVariables(this.LiteOrmConfig.DbPath));
            Debug.Assert(dbPath != null, "dbPath != null");

            var dbDirectory = Path.GetDirectoryName(dbPath);
            Debug.Assert(dbDirectory != null, "dbDirectory != null");

            if (!Directory.Exists(dbDirectory))
            {
                Directory.CreateDirectory(dbDirectory);
            }

            return dbPath;
        }

        private string GetConnectionString()
        {
            return string.Format(this.LiteOrmConfig.ConnectionString, this.GetDbPath());
        }


        public SQLiteConnection GetConnection()
        {
            if (!File.Exists(this.GetDbPath()))
            {
                using (var conn = new SQLiteConnection(this.GetConnectionString())
                    .OpenAndReturn()
                    .LoadAllExtensions(this.LiteOrmConfig.Extensions)
                    .SetAllPragmas(this.LiteOrmConfig.Pragmas)
                    .WithLogger(this.Logger))
                {
                    foreach (
                        var line in 
                            this.LiteOrmConfig
                                .SqlSchema
                                .Select(f => Path.GetFullPath(Environment.ExpandEnvironmentVariables(f)))
                                .Where(File.Exists)
                                .SelectMany(file => File.ReadAllText(file).Split(';')))
                    {
                        new SQLiteCommand(line, conn).ExecuteNonQuery();
                    }
                }
            }

            return new SQLiteConnection(this.GetConnectionString())
                .OpenAndReturn()
                .LoadAllExtensions(this.LiteOrmConfig.Extensions)
                .SetAllPragmas(this.LiteOrmConfig.Pragmas)
                .WithLogger(this.Logger);
        }

        #endregion
    }
}