using Otus.Teaching.Concurrency.Import.Handler.Entities;
using System.Collections.Generic;
using System.Threading;

namespace Otus.Teaching.Concurrency.Import.Loader.Loaders
{
    public class CustomersPool
    {
        public List<Customer> Customers { get; set; }
        public WaitHandle WaitHandle { get; set; }

        public CustomersPool()
        {
            WaitHandle = new AutoResetEvent(false);
        }
    }
}