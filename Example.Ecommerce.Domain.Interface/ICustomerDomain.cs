using Example.Ecommerce.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.Ecommerce.Domain.Interface
{
    public interface ICustomerDomain
    {
        #region Sync methods

        bool Insert(Customer customer);
        bool Update(Customer customer);
        bool Delete(string customerId);
        Customer Get(string customerId);
        IEnumerable<Customer> GetAll();
        IEnumerable<Customer> GetAllWithPagination(int pageNumber, int pageSize);
        int Count();

        #endregion

        #region Async methods
        Task<bool> InsertAsync(Customer customer);
        Task<bool> UpdateAsync(Customer customer);
        Task<bool> DeleteAsync(string customerId);
        Task<Customer> GetAsync(string customerId);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<IEnumerable<Customer>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
        Task<int> CountAsync();

        #endregion
    }
}