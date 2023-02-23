using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.Ecommerce.Infrastructure.Interface.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        #region Sync methods

        bool Insert(T customer);
        bool Update(T customer);
        bool Delete(string customerId);
        T Get(string customerId);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllWithPagination(int pageNumber, int pageSize);
        int Count();
        #endregion

        #region Async methods

        Task<bool> InsertAsync(T customer);
        Task<bool> UpdateAsync(T customer);
        Task<bool> DeleteAsync(string customerId);
        Task<T> GetAsync(string customerId);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
        Task<int> CountAsync();
        #endregion
    }
}
