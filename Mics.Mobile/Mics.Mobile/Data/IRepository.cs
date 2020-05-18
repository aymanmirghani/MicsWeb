using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mics.Mobile.Data
{
    public interface IRepository<T>
    {
        Task<bool> InsertAsync(T item);
        bool InsertBulkAsync(List<T> itemList);
        Task<bool> UpdateAsync(T item);
        Task<bool> DeleteAsync(string id);
        Task<T> GetByIdAsync(string id);
        Task<bool> DeleteAsync(int id);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GeAllAsync(bool forceRefresh = false);
        Task<IEnumerable<T>> QueryAsync(Func<T,bool> predicate);
        bool IsSynchedWith(T old, T entity);
        void SynchEntity(T old, T entity);
    }
}
