using Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Implementation
{
   // Репозиторий чтения и записи
   public class Repository<T, TPrimaryKey> : IRepository<T, TPrimaryKey> where T : class, IEntity<TPrimaryKey>
   {
      protected readonly DbContext Context;
      protected DbSet<T> EntitySet;

      public Repository(DbContext context)
      {
         Context = context;
         EntitySet = context.Set<T>();
      }

      // Запросить все сущности в базе
      public IQueryable<T> GetAll(bool asNoTracking = false)
      {
         return asNoTracking ? EntitySet.AsNoTracking() : EntitySet;
      }

      // Запросить все сущности в базе
      public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking = false)
      {
         return await GetAll(asNoTracking).ToListAsync(cancellationToken);
      }

      // Запросить все сущности и связи
      public IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties)
      {
         return Include(includeProperties).ToList();
      }

      public IEnumerable<T> GetWithInclude(Func<T, bool> predicate,
          params Expression<Func<T, object>>[] includeProperties)
      {
         var query = Include(includeProperties);
         return query.Where(predicate).ToList();
      }

      private IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties)
      {
         IQueryable<T> query = EntitySet.AsNoTracking();
         return includeProperties
             .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
      }

      // Получить сущность по ID
      public T Get(TPrimaryKey id)
      {
         return EntitySet.Find(id);
      }

      // Получить сущность по ID
      public async Task<T> GetAsync(TPrimaryKey id)
      {
         return await EntitySet.FindAsync((object)id);
      }

      // Удалить сущность
      public bool Delete(TPrimaryKey id)
      {
         var obj = EntitySet.Find(id);
         if (obj is null)
         {
            return false;
         }
         EntitySet.Remove(obj);
         return true;
      }

      // Удалить сущность
      public bool Delete(T entity)
      {
         if (entity is null)
         {
            return false;
         }
         Context.Entry(entity).State = EntityState.Deleted;
         return true;
      }

      // Удалить сущности
      public bool DeleteRange(ICollection<T> entities)
      {
         if (entities is null || !entities.Any())
         {
            return false;
         }
         EntitySet.RemoveRange(entities);
         return true;
      }

      // Для сущности проставить состояние - что она изменена
      public void Update(T entity)
      {
         Context.Entry(entity).State = EntityState.Modified;
      }

      // Добавить в базу одну сущность
      public T Add(T entity)
      {
         var objToReturn = Context.Set<T>().Add(entity);
         return objToReturn.Entity;
      }

      // Добавить в базу одну сущность
      public async Task<T> AddAsync(T entity)
      {
         return (await Context.Set<T>().AddAsync(entity)).Entity;
      }

      // Добавить в базу массив сущностей
      public void AddRange(List<T> entities)
      {
         var enumerable = entities as IList<T> ?? entities.ToList();
         Context.Set<T>().AddRange(enumerable);
      }

      // Добавить в базу массив сущностей
      public async Task AddRangeAsync(ICollection<T> entities)
      {
         if (entities is null || !entities.Any())
         {
            return;
         }
         await EntitySet.AddRangeAsync(entities);
      }

      // Сохранить изменения
      public void SaveChanges()
      {
         Context.SaveChanges();
      }

      // Сохранить изменения
      public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
      {
         await Context.SaveChangesAsync(cancellationToken);
      }
   }
}