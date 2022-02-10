using Otus.Teaching.Concurrency.Import.Core.AppSettings;
using Otus.Teaching.Concurrency.Import.Core.Parsers;
using CsvDataParser = Otus.Teaching.Concurrency.Import.DataAccess.Parsers.CsvParser;
using XmlDataParser = Otus.Teaching.Concurrency.Import.DataAccess.Parsers.XmlParser;

namespace Otus.Teaching.Concurrency.Import.DataAccess
{
    public static class ParserFactory
    {
        public static IDataParser GetParser(ISettings settings)
        {
            switch (settings.DataFileFormat.ToLower())
            {
                case "csv":
                    return new CsvDataParser(settings);
                case "xml":
                    return new XmlDataParser(settings);
                default:
                    goto case "xml";
            }
        }
    }
}