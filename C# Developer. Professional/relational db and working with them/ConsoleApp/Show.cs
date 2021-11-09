using Entities;
using EntityFramework;
using Implementation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
   public class Show
   {
      private readonly DatabaseContext _dbContext;

      public Show(DatabaseContext dbContext)
      {
         _dbContext = dbContext;
      }

      public void ShowCategories()
      {
         Console.WriteLine($"Categories");
         Repository<Categories, int> categories = new Repository<Categories, int>(_dbContext);

         var category = categories.GetAll().ToList();
         foreach (Categories c in category)
         {
            ShowCategory(c);
         }
      }

      public void ShowSellers()
      {
         Console.WriteLine($"Sellers");
         Repository<Sellers, int> sellers = new Repository<Sellers, int>(_dbContext);

         IQueryable<Sellers> seller = sellers.GetAll();
         foreach (Sellers s in seller)
         {
            ShowSeller(s);
         }
      }

      public void ShowProducts()
      {
         Console.WriteLine($"Products");
         Repository<Products, int> products = new Repository<Products, int>(_dbContext);

         IEnumerable<Products> product = products.GetWithInclude(с => с.Category, s => s.Seller);
         foreach (Products p in product)
         {
            ShowProduct(p);
         }
      }

      public void ShowCategory(Categories c)
      {
         Console.WriteLine($"Id: {c.Id,3}| Name: {c.Name,10}");
      }

      public void ShowSeller(Sellers s)
      {
         Console.WriteLine($"Id: {s.Id,3}| FirstName: {s.FirstName,10}| LastName: {s.LastName}| MiddleName: {s.MiddleName}| Email: {s.Email}| Phone: {s.Phone}");
      }

      public void ShowProduct(Products p)
      {
         Console.WriteLine($"Id: {p.Id,3}| Name: {p.Name,15}| Description: {p.Description,13}| Price: {p.Price,10}| CategoryName: {p.Category.Name,13}| SellerName: {p.Seller.FirstName,13}");
      }

      public void ShowAll()
      {
         ShowCategories();
         ShowSellers();
         ShowProducts();
      }
   }
}