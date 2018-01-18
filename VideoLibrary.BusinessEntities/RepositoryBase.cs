using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace VideoLibrary.BusinessEntities
{
    public abstract class RepositoryBase<TContext> : IRepositoryBase where TContext : DbContext, new()
    {
        protected RepositoryBase()
        {
            Context = new TContext();
        }

        protected TContext Context { get; private set; }

        public virtual async Task<T> InsertAsync<T>(T entity, bool saveNow = true) where T : class
        {
            return await EntityManipulationAsync(entity, saveNow, EntityState.Added);
        }

        private async Task<T> EntityManipulationAsync<T>(T entity, bool saveNow, EntityState stat) where T : class
        {
            Context.Entry(entity).State = stat;
            if (saveNow) await Context.SaveChangesAsync();
            return entity;
        }

        private T EntityManipulation<T>(T entity, bool saveNow, EntityState stat) where T : class
        {
            Context.Entry(entity).State = stat;
            if (saveNow) Context.SaveChanges();
            return entity;
        }

        public virtual async Task<T> UpdateAsync<T>(T entity, bool saveNow = true) where T : class
        {
            return await EntityManipulationAsync(entity, saveNow, EntityState.Modified);
        }

        public T Update<T>(T entity, bool saveNow = true) where T : class
        {
            return EntityManipulation(entity, saveNow, EntityState.Modified);
        }

        public virtual async Task<T> DeleteAsync<T>(T entity, bool saveNow = true) where T : class
        {
            return await EntityManipulationAsync(entity, saveNow, EntityState.Deleted);
        }

        public virtual async Task<List<T>> DeleteRangeAsync<T>(List<T> entity, bool saveNow = true) where T : class
        {
            Context.Entry(entity).State = EntityState.Deleted;
            if (saveNow) await Context.SaveChangesAsync();
            return entity;
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public virtual async Task<int> BatchSaveAsync()
        {
            return await Context.SaveChangesAsync();
        }


    }
}
