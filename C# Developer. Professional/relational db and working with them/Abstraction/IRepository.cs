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
      // Запросить все сущности в базе
      IQueryable<T> GetAll(bool noTracking = false);

      // Запросить все сущности в базе
      Task<List<T>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking = false);

      // Запросить все сущности и связи
      IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties);
      IEnumerable<T> GetWithInclude(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties);

      // Получить сущность по ID
      T Get(TPrimaryKey id);

      // Получить сущность по ID
      Task<T> GetAsync(TPrimaryKey id);

      // Удалить сущность
      bool Delete(TPrimaryKey id);
      bool Delete(T entity);

      // Удалить сущности
      bool DeleteRange(ICollection<T> entities);

      // Для сущности проставить состояние - что она изменена
      void Update(T entity);

      // Добавить в базу одну сущность
      T Add(T entity);
      Task<T> AddAsync(T entity);

      // Добавить в базу массив сущностей
      void AddRange(List<T> entities);
      Task AddRangeAsync(ICollection<T> entities);

      // Сохранить изменения
      void SaveChanges();
      Task SaveChangesAsync(CancellationToken cancellationToken = default);
   }
}