﻿using System;
using NLog;

namespace NLogExample
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // create NLog configuration
            var config = new NLog.Config.LoggingConfiguration();

            // define targets
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "log_file.txt" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            // specify minimum log level to maximum log level and target (console, file, etc.)
            config.AddRule(LogLevel.Trace, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logfile);

            // apply NLog configuration
            NLog.LogManager.Configuration = config;
        }
    }
}
