using Otus.Teaching.Concurrency.Import.Core.AppSettings;
using Otus.Teaching.Concurrency.Import.Handler.Data;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using System.Collections.Generic;
using System.IO;

namespace Otus.Teaching.Concurrency.Import.DataGenerator.Generators
{
    public class CsvGenerator : IDataGenerator
    {
        ISettings _setting;

        public CsvGenerator(ISettings settings)
        {
            _setting = settings;
        }
        public void Generate()
        {
            List<Customer> customers = RandomCustomerGenerator.Generate(_setting);
            using (StreamWriter writer = new StreamWriter(new FileStream(_setting.DataFilePath, FileMode.Create, FileAccess.Write)))
            {
                foreach (Customer customer in customers)
                {
                    writer.WriteLine($"{customer.Id},{customer.FullName},{customer.Email},{customer.Phone}");
                }
            }
        }
    }
}