using Entities;
using EntityFramework;
using Implementation;
using System;
using System.Collections.Generic;

namespace BLL.Show
{
   public class ShowAll
   {
      Repository<Categories, int> phoneRepo2 = new Repository<Categories, int>(new DatabaseContextFactory().CreateDbContext(args));

      IEnumerable<Categories> phones2 = phoneRepo2.GetAll();
         foreach (Categories p2 in phones2)
         {
            Console.WriteLine($"{p2.ToString()}");
         }
}
}
