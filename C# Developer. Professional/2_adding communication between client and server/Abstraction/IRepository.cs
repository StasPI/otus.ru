using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Abstraction
{
   public interface IRepository
   {
   }

   public interface IRepository<T, TPrimaryKey> where T : IEntity<TPrimaryKey>
   {

      /// < summary > Запросить все сущности в базе </ summary >
      IQueryable<T> GetAll(bool noTracking = false);

      /// < summary > Запросить все сущности в базе </ summary >
      Task<List<T>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking = false);

      /// < summary > Запросить все сущности и связи </ summary >
      IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties);
      IEnumerable<T> GetWithInclude(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties);

      /// < summary > Получить сущность по ID </ summary >
      T Get(TPrimaryKey id);

      /// < summary > Получить сущность по ID </ summary >
      Task<T> GetAsync(TPrimaryKey id);

      /// < summary > Удалить сущность </ summary >
      bool Delete(TPrimaryKey id);
      bool Delete(T entity);

      /// < summary > Удалить сущности </ summary >
      bool DeleteRange(ICollection<T> entities);

      /// < summary > Для сущности проставить состояние - что она изменена </ summary >
      void Update(T entity);

      /// < summary > Добавить в базу одну сущность </ summary >
      T Add(T entity);
      Task<T> AddAsync(T entity);

      /// < summary > Добавить в базу массив сущностей </ summary >
      void AddRange(List<T> entities);
      Task AddRangeAsync(ICollection<T> entities);

      /// < summary > Сохранить изменения ID </ summary >
      void SaveChanges();
      Task SaveChangesAsync(CancellationToken cancellationToken = default);
   }
}