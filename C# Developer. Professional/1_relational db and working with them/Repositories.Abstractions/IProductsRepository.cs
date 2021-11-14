using Abstraction;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Abstractions
{
   public interface IProductsRepository : IReadRepository<Products, int>
   {
      Task<List<Products>> GetPagedAsync(int page, int itemsPerPage);
   }
}