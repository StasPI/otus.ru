using Otus.Teaching.Concurrency.Import.Core.AppSettings;
using Otus.Teaching.Concurrency.Import.Handler.Data;
using System;

namespace Otus.Teaching.Concurrency.Import.XmlGenerator
{
    class Program
    {
        private static string _dataFilePath;
        private static string _dataFileFormat = "xml";
        private static int _dataCount = 100; 
        
        static void Main(string[] args)
        {
            ISettings settings = new Settings();
            if (!TryValidateAndParseArgs(args))
                return;

            settings.DataFilePath = _dataFilePath;
            settings.DataFileFormat = _dataFileFormat;
            settings.DataCount = _dataCount;
            
            Console.WriteLine("Generating data...");
            IDataGenerator dataGenerator = GeneratorFactory.GetGenerator(settings);
            dataGenerator.Generate();
            Console.WriteLine($"Generated data in {_dataFilePath}...");
        }

        private static bool TryValidateAndParseArgs(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                _dataFilePath = args[0];
            }
            else
            {
                Console.WriteLine("Data file name without extension is required");
                return false;
            }

            if (args.Length > 1)
            {
                if (!int.TryParse(args[1], out _dataCount))
                {
                    Console.WriteLine("Data must be integer");
                    return false;
                }
            }

            if (args.Length > 2)
            {
                _dataFileFormat = args[2];
            }

            return true;
        }
    }
}