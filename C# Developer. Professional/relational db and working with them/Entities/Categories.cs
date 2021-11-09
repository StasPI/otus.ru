using Abstraction;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
   public class Categories : IEntity<int>
   {
      public int Id { get; set; }

      [Required]
      public string Name { get; set; }

      public virtual List<Products> Product { get; set; }
   }
}