using System;

namespace Abstraction
{
   public interface IEntity<TId>
   {
      TId Id { get; set; }
   }
}