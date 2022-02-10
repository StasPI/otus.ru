using Otus.Teaching.Concurrency.Import.Handler.Data;
using XmlDataGenerator = Otus.Teaching.Concurrency.Import.DataGenerator.Generators.XmlGenerator;
using CsvDataGenerator = Otus.Teaching.Concurrency.Import.DataGenerator.Generators.CsvGenerator;
using Otus.Teaching.Concurrency.Import.Core.AppSettings;

namespace Otus.Teaching.Concurrency.Import.XmlGenerator
{
    public static class GeneratorFactory
    {
        public static IDataGenerator GetGenerator(ISettings settings)
        {
            switch (settings.DataFileFormat.ToLower())
            {
                case "csv":
                    return new CsvDataGenerator(settings);
                case "xml":
                    return new XmlDataGenerator(settings);
                default:
                    goto case "xml";
            }
        }
    }
}