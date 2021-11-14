using Abstraction;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Abstractions
{
   public interface ISellersRepository : IRepository<Sellers, int>
   {
      Task<List<Sellers>> GetPagedAsync(int page, int itemsPerPage);
   }
}