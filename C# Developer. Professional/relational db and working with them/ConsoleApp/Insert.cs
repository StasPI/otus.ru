using Entities;
using EntityFramework;
using Implementation;
using System;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
   public class Insert
   {
      private readonly DatabaseContext _dbContext;
      private readonly Show show;



      public Insert(DatabaseContext dbContext)
      {
         _dbContext = dbContext;
         show = new Show(dbContext);
      }

      public static string GetStringFromUser(string prompt)
      {
         Console.Write(prompt);
         return Console.ReadLine();
      }

      public void InsertCategories()
      {
         Categories userCategory = new Categories();
         userCategory.Name = GetStringFromUser("Введите название: ");

         Repository<Categories, int> categories = new Repository<Categories, int>(_dbContext);
         categories.Add(userCategory);
         categories.SaveChanges();

         show.ShowCategory(userCategory);
      }

      public void InsertSellers()
      {
         Sellers userSellers = new Sellers();
         userSellers.FirstName = GetStringFromUser("Введите имя: ");
         userSellers.LastName = GetStringFromUser("Введите фамилию: ");
         userSellers.MiddleName = GetStringFromUser("Введите отчество: ");
         userSellers.Email = GetStringFromUser("Введите электронную почту: ");
         userSellers.Phone = GetStringFromUser("Введите номер телефона: ");

         Repository<Sellers, int> sellers = new Repository<Sellers, int>(_dbContext);
         sellers.Add(userSellers);
         sellers.SaveChanges();

         show.ShowSeller(userSellers);
      }

      public void InsertProducts()
      {
         Products userProducts = new Products();
         userProducts.Name = GetStringFromUser("Введите название: ");
         userProducts.Description = GetStringFromUser("Введите описание: ");
         userProducts.Price = Convert.ToDecimal(GetStringFromUser("Введите цену товара: "));
         userProducts.SellerId = Convert.ToInt32(GetStringFromUser("Введите ID продавца: "));
         userProducts.CategoryId = Convert.ToInt32(GetStringFromUser("Введите ID категории: "));

         Repository<Products, int> products = new Repository<Products, int>(_dbContext);
         products.Add(userProducts);
         products.SaveChanges();

         show.ShowProduct(userProducts);
      }
   }
}