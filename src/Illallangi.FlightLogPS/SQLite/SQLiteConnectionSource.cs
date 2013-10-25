﻿using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Illallangi.FlightLogPS.Config;

namespace Illallangi.FlightLogPS.SQLite
{
    public sealed class SQLiteConnectionSource : IConnectionSource
    {
        #region Fields

        private readonly IConfig currentConfig;

        #endregion

        #region Constructors

        public SQLiteConnectionSource(IConfig config)
        {
            this.currentConfig = config;
        }

        #endregion

        #region Properties

        private IConfig Config
        {
            get
            {
                return this.currentConfig;
            }
        }

        #endregion

        #region Methods

        private string GetDbPath()
        {
            var dbPath = Path.GetFullPath(Environment.ExpandEnvironmentVariables(this.Config.DbPath));
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
            return string.Format(this.Config.ConnectionString, this.GetDbPath());
        }


        public SQLiteConnection GetConnection()
        {
            if (!File.Exists(this.GetDbPath()))
            {
                using (var conn = new SQLiteConnection(this.GetConnectionString())
                    .OpenAndReturn()
                    .LoadAllExtensions(this.Config.Extensions)
                    .SetAllPragmas(this.Config.Pragmas))
                {
                    foreach (var file in 
                        this.Config.SqlSchema
                            .Select(f => Path.GetFullPath(Environment.ExpandEnvironmentVariables(f)))
                            .Where(File.Exists))
                    {
                        new SQLiteCommand(File.ReadAllText(file), conn).ExecuteNonQuery();
                    }
                }
            }

            return
                new SQLiteConnection(this.GetConnectionString())
                    .OpenAndReturn()
                    .LoadAllExtensions(this.Config.Extensions)
                    .SetAllPragmas(this.Config.Pragmas);
        }

        #endregion
    }
}