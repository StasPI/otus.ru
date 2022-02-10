using Microsoft.Extensions.Configuration;
using Otus.Teaching.Concurrency.Import.Core.AppSettings;
using Otus.Teaching.Concurrency.Import.Core.Loaders;
using Otus.Teaching.Concurrency.Import.Core.Parsers;
using Otus.Teaching.Concurrency.Import.DataAccess;
using Otus.Teaching.Concurrency.Import.Handler.Data;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using Otus.Teaching.Concurrency.Import.XmlGenerator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Otus.Teaching.Concurrency.Import.Loader
{
    class Program
    {
        private static List<Customer> _customers;

        static void Main(string[] args)
        {
            IConfigurationRoot builder = new ConfigurationBuilder()
                           .AddJsonFile("appsettings.json")
                           .Build();

            ISettings settings = builder.GetSection("Settings").Get<Settings>();

            settings.DataFileDirectory = AppDomain.CurrentDomain.BaseDirectory;
            settings.DataFilePath = Path.Combine(settings.DataFileDirectory, (settings.DataFileName + "." + settings.DataFileFormat));

            Stopwatch stopwatch = new Stopwatch();
            IDataGenerator dataGenerator;
            IDataParser dataParser;

            using var dbContext = new DatabaseContext(settings);
            dbContext.DropDatabase();

            dataGenerator = GeneratorFactory.GetGenerator(settings);
            dataParser = ParserFactory.GetParser(settings);

            switch (settings.StartType.ToLower())
            {
                case "p":
                    Console.WriteLine($"Start Process");
                    stopwatch.Start();
                    StartProcess(settings);
                    stopwatch.Stop();
                    break;
                case "m":
                    Console.WriteLine($"Start Method");
                    stopwatch.Start();
                    dataGenerator.Generate();
                    stopwatch.Stop();
                    break;
                default:
                    goto case "m";
            }

            Console.WriteLine($"Generated data time: {stopwatch.ElapsedMilliseconds}");

            stopwatch.Restart();
            _customers = dataParser.Parse();
            stopwatch.Stop();
            Console.WriteLine($"Parsing data time: {stopwatch.ElapsedMilliseconds}");

            FakeDataLoader fakeDataLoader = new FakeDataLoader(_customers, settings);

            stopwatch.Restart();
            fakeDataLoader.LoadData();
            stopwatch.Stop();
            Console.WriteLine($"Load DB data time: {stopwatch.ElapsedMilliseconds}");
        }

        private static Process StartProcess(ISettings settings)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                ArgumentList = { settings.DataFilePath, settings.DataCount.ToString(), settings.DataFileFormat },
                FileName = Path.Combine(settings.ProcessPath, settings.ProcessFileName),
            };

            Process process = Process.Start(startInfo);
            process.WaitForExit();
            return process;
        }
    }
}