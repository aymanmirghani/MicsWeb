using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mics.Mobile.Helpers
{
    public interface IDataAccess <T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> InsertAsync(T item);
        Task<bool> UpdateAsync(T item);
        Task<bool> DeleteAsync(string id);
        Task<T> GetByIDAsync(string id);

        IEnumerable<T> GetAll();
        bool Insert(T item);
        bool Update(T item);
        bool Delete(string id);
        T GetByID(string id);



    }
}
