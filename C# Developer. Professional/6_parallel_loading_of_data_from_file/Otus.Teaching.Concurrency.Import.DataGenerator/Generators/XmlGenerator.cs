using Otus.Teaching.Concurrency.Import.Core.AppSettings;
using Otus.Teaching.Concurrency.Import.DataGenerator.Dto;
using Otus.Teaching.Concurrency.Import.Handler.Data;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Otus.Teaching.Concurrency.Import.DataGenerator.Generators
{
    public class XmlGenerator : IDataGenerator
    {
        ISettings _setting;

        public XmlGenerator(ISettings settings)
        {
            _setting = settings;
        }
        
        public void Generate()
        {
            List<Customer> customers = RandomCustomerGenerator.Generate(_setting);
            using FileStream stream = File.Create(_setting.DataFilePath);
            new XmlSerializer(typeof(CustomersList)).Serialize(stream, new CustomersList()
            {
                Customers = customers
            });
        }
    }
}