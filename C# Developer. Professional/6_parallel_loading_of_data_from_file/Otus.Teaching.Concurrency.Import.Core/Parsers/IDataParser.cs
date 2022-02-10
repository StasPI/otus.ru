using Otus.Teaching.Concurrency.Import.Handler.Entities;
using System.Collections.Generic;

namespace Otus.Teaching.Concurrency.Import.Core.Parsers
{
    public interface IDataParser
    {
        public List<Customer> Parse();
    }
}