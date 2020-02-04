using NLog;
using System;

namespace YourName
{
    class MainClass
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public static void Main(string[] args)
        {
            var config = new NLog.Config.LoggingConfiguration();
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "file.txt" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            NLog.LogManager.Configuration = config;

            try
            {
                Logger.Info("Hello World!");
                Console.Write("Enter some text: ");
                string entry = Console.ReadLine();
                Logger.Info(entry);
                int value = Int32.Parse(entry);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error thrown.");
            }

        }
    }
}
