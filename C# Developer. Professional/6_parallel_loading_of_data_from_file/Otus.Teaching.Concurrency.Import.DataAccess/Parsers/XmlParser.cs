using Otus.Teaching.Concurrency.Import.Core.AppSettings;
using Otus.Teaching.Concurrency.Import.Core.Parsers;
using Otus.Teaching.Concurrency.Import.DataGenerator.Dto;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Otus.Teaching.Concurrency.Import.DataAccess.Parsers
{
    public class XmlParser: IDataParser
    {
        ISettings _settings;

        public XmlParser(ISettings settings)
        {
            _settings = settings;
        }

        public List<Customer> Parse()
        {
            List<Customer> customers = new List<Customer>();
            using (FileStream fileStream = new FileStream(_settings.DataFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using(StreamReader reader = new StreamReader(fileStream))
                {
                    CustomersList customerList = (CustomersList)new XmlSerializer(typeof(CustomersList)).Deserialize(fileStream);
                    customers = customerList.Customers;
                }
            }
            return customers;
        }
    }
}