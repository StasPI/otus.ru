using EntityFramework;
using System;
using System.Text;

namespace ConsoleApp
{
   class Program
   {

      static void Main(string[] args)
      {
         string yn;
         string entity;
         DatabaseContext dbContext = new DatabaseContextFactory().CreateDbContext(args);
         Console.InputEncoding = Encoding.Unicode;
         Console.OutputEncoding = Encoding.Unicode;

         Show show = new Show(dbContext);
         show.ShowAll();

         while (true)
         {
            Console.WriteLine("Желаете добавить запись? [Y/N]");
            yn = Console.ReadLine().ToLower();
            if (yn == "n")
            {
               break;
            }
            else if (yn == "y")
            {
               Insert insert = new Insert(dbContext);
               Console.WriteLine("Введите название сущности для которой желаете осуществить ввод(Категория, Продавец, Товар)");
               entity = Console.ReadLine().ToLower();
               switch (entity)
               {
                  case "категория":
                     insert.InsertCategories();
                     break;
                  case "продавец":
                     insert.InsertSellers();
                     break;
                  case "товар":
                     insert.InsertProducts();
                     break;
                  default:
                     Console.WriteLine("Нет такой категории");
                     break;
               }
            }
            else
            {
               Console.WriteLine("Ввели что то не то... Давайте попробуем еще раз.");
            }
         }

         Console.ReadKey();
      }
   }
}