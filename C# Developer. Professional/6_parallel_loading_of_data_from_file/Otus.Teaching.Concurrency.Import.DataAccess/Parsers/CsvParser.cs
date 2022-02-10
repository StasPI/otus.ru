using Otus.Teaching.Concurrency.Import.Core.AppSettings;
using Otus.Teaching.Concurrency.Import.Core.Parsers;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace Otus.Teaching.Concurrency.Import.DataAccess.Parsers
{
    public class CsvParser : IDataParser
    {
        ISettings _settings;
        public CsvParser(ISettings settings)
        {
            _settings = settings;
        }

        public List<Customer> Parse()
        {
            List<Customer> customers = new List<Customer>();
            using (FileStream fileStream = new FileStream(_settings.DataFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    while (!reader.EndOfStream)
                    {
                        string[] customerData = reader.ReadLine().Split(",");
                        Customer customer = new Customer()
                        {
                            Id = Int32.Parse(customerData[0]),
                            Email = customerData[1],
                            Phone = customerData[2],
                            FullName = customerData[3]
                        };
                        customers.Add(customer);
                    }
                }
            }
            return customers;
        }
    }
}