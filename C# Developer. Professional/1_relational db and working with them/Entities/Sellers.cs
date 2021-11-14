using Abstraction;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
   public class Sellers : IEntity<int>
   {
      public int Id { get; set; }

      [Required]
      public string FirstName { get; set; }

      public string LastName { get; set; }

      public string MiddleName { get; set; }

      [Required]
      public string Email { get; set; }

      [Required]
      public string Phone { get; set; }

      public virtual List<Products> Product { get; set; }
   }
}