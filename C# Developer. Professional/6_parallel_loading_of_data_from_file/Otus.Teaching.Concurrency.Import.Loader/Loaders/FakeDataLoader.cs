using Otus.Teaching.Concurrency.Import.Core.AppSettings;
using Otus.Teaching.Concurrency.Import.DataAccess;
using Otus.Teaching.Concurrency.Import.DataAccess.Repositories;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using Otus.Teaching.Concurrency.Import.Loader.Loaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Otus.Teaching.Concurrency.Import.Core.Loaders
{
    public class FakeDataLoader: IDataLoader
    {
        private List<Customer> _customers;
        ISettings _settings;

        public FakeDataLoader(List<Customer> customers, ISettings settings)
        {
            _customers = customers;
            _settings = settings;
        }
        public void LoadData()
        {
            WaitHandle[] waitHandles = new WaitHandle[_settings.CountThreads];
            for (int i = 0; i < _settings.CountThreads; i++)
            {
                CustomersPool item = new CustomersPool()
                {
                    Customers = _customers.Where(x => x.Id % _settings.CountThreads == i).ToList()
                };
                waitHandles[i] = item.WaitHandle;

                ThreadPool.QueueUserWorkItem(DataLoadPool, item);
            }

            WaitHandle.WaitAll(waitHandles);
        }

        private void DataLoadPool(object item)
        {
            int tryNumber = 0;
            while (tryNumber < _settings.CountTries)
            {
                try
                {
                    using DatabaseContext dbContext = new DatabaseContext(_settings);

                    CustomersPool cp = (CustomersPool)item;

                    CustomerRepository customerRepository = new CustomerRepository(dbContext);
                    foreach (Customer customer in cp.Customers)
                    {
                        customerRepository.AddCustomer(customer);
                    }

                    dbContext.SaveChanges();

                    AutoResetEvent autoResetEvent = (AutoResetEvent)cp.WaitHandle;
                    autoResetEvent.Set();

                    tryNumber = _settings.CountTries;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Try number {tryNumber + 1} for ManagedThreadId={Thread.CurrentThread.ManagedThreadId} has fail");
                    Console.WriteLine($"{ex.Message}");
                    tryNumber++;
                }
            }
        }
    }
}