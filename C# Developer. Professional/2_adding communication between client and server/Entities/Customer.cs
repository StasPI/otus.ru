using Abstraction;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
   public class Customer : IEntity<long>
   {
      public long Id { get; init; }

      [Required]
      public string Firstname { get; init; }

      [Required]
      public string Lastname { get; init; }
   }
}