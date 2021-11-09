using Abstraction;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
   public class Products : IEntity<int>
   {
      public int Id { get; set; }

      [Required]
      public string Name { get; set; }

      public string Description { get; set; }

      [Required]
      public decimal Price { get; set; }

      public virtual Categories Category { get; set; }

      [Required]
      public int CategoryId { get; set; }

      public virtual Sellers Seller { get; set; }

      [Required]
      public int SellerId { get; set; }
   }
}