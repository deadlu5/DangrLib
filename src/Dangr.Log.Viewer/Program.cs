﻿// -----------------------------------------------------------------------
//  <copyright file="Program.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Log.Viewer
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using Dangr.Core.Configuration;
    using Dangr.Core.Configuration.Sources;
    using Dangr.Core.Logging;
    using Dangr.Core.Logging.Loggers;
    using Dangr.Core.Logging.Wcf;

    public class Program
    {
        private const string LogInternalCategory = "_logInternal";

        public static void Main(string[] args)
        {
            Configuration configuration = new Configuration();
            WcfLoggerConfigView configurationView = new WcfLoggerConfigView();
            configuration.RegisterConfigurationView(configurationView);
            configuration.RegisterConfigurationSource(new AppSettingsConfigurationSource());

            Binding binding = Program.ParseBinding(configurationView.Binding);
            Uri uri = new Uri(configurationView.Uri);
            string serviceName = configurationView.ServiceName;

            var endpoints = new Dictionary<string, Binding>
            {
                { serviceName, binding }
            };

            using (LogService loggerService = new LogService())
            {
                ConsoleLogger consoleLogger = new ConsoleLogger();
                loggerService.RegisterInternalEndpoint(consoleLogger);
                loggerService.RegisterInternalEndpoint(
                    new TextLogger(logFileDirectory: string.Empty, logFilePrefix: "Live Viewer Errors - "));

                loggerService.RegisterEndpoint(consoleLogger);
                loggerService.RegisterEndpoint(
                    new TextLogger(
                        logFileDirectory: configurationView.LogFileDirectory,
                        logFilePrefix: configurationView.LogFilePrefix));

                loggerService.Log(LogLevel.Status, Program.LogInternalCategory, "The logger service is ready.");

                // Run the wcf service and wait for completion.
                try
                {
                    using (
                        WcfLogService.ServiceHolder wcfServiceHolder = WcfLogService.Run(
                            loggerService,
                            new[] { uri },
                            endpoints))
                    {
                        wcfServiceHolder.Wait(TimeSpan.FromMilliseconds(-1));
                    }
                }
                catch (Exception e)
                {
                    loggerService.LogFatal(Program.LogInternalCategory, $"An error has occurred: {e}");
                }
            }

            Console.WriteLine("Service has shut down. Press enter to exit.");
            Console.ReadLine();
        }

        private static Binding ParseBinding(string binding)
        {
            switch (binding.ToLowerInvariant())
            {
                case "http":
                    return new BasicHttpBinding();
                case "tcp":
                    return new NetTcpBinding();
                case "namedpipe":
                    return new NetNamedPipeBinding();
                case "msmq":
                    return new NetMsmqBinding();
                default:
                    throw new ArgumentException("Binding Type");
            }
        }
    }
}