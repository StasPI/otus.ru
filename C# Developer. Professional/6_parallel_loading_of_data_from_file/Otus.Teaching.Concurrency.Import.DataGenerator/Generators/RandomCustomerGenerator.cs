using Bogus;
using Otus.Teaching.Concurrency.Import.Core.AppSettings;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using System.Collections.Generic;

namespace Otus.Teaching.Concurrency.Import.DataGenerator.Generators
{
    public static class RandomCustomerGenerator
    {
        public static List<Customer> Generate(ISettings settings)
        {
            List<Customer> customers = new List<Customer>();
            Faker<Customer> customersFaker = CreateFaker();

            foreach (Customer customer in customersFaker.GenerateForever())
            {
                customers.Add(customer);

                if (settings.DataCount == customer.Id)
                    return customers;
            }

            return customers;
        }

        private static Faker<Customer> CreateFaker()
        {
            int id = 1;
            Faker<Customer> customersFaker = new Faker<Customer>()
                .CustomInstantiator(f => new Customer()
                {
                    Id = id++
                })
                .RuleFor(u => u.FullName, (f, u) => f.Name.FullName())
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FullName))
                .RuleFor(u => u.Phone, (f, u) => f.Phone.PhoneNumber("1-###-###-####"));

            return customersFaker;
        }
    }
}