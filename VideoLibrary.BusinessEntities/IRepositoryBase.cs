using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VideoLibrary.BusinessEntities
{
    public interface IRepositoryBase : IDisposable
    {
        Task<T> InsertAsync<T>(T entity, bool saveNow = true) where T : class;

        Task<T> UpdateAsync<T>(T entity, bool saveNow = true) where T : class;
        T Update<T>(T entity, bool saveNow = true) where T : class;

        Task<T> DeleteAsync<T>(T entity, bool saveNow = true) where T : class;

        Task<List<T>> DeleteRangeAsync<T>(List<T> entity, bool saveNow = true) where T : class;

        Task<int> BatchSaveAsync();
    }
}
