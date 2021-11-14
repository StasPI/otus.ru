using Abstraction;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Abstractions
{
   public interface ICategoriesRepository : IReadRepository<Categories, int>
   {
      Task<List<Categories>> GetPagedAsync(int page, int itemsPerPage);
   }
}