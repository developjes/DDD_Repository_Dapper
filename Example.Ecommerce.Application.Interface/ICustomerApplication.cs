using Example.Ecommerce.Application.DTO;
using Example.Ecommerce.Transversal.Common.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.Ecommerce.Application.Interface
{
    public interface ICustomerApplication
    {
        #region Sync methods

        Response<bool> Insert(CustomerDto customerDto);
        Response<bool> Update(CustomerDto customerDto);
        Response<bool> Delete(string customerId);
        Response<CustomerDto> Get(string customerId);
        Response<IEnumerable<CustomerDto>> GetAll();
        ResponsePagination<IEnumerable<CustomerDto>> GetAllWithPagination(int pageNumber, int pageSize);

        #endregion

        #region Async methods
        Task<Response<bool>> InsertAsync(CustomerDto customerDto);
        Task<Response<bool>> UpdateAsync(CustomerDto customerDto);
        Task<Response<bool>> DeleteAsync(string customerId);
        Task<Response<CustomerDto>> GetAsync(string customerId);
        Task<Response<IEnumerable<CustomerDto>>> GetAllAsync();
        Task<ResponsePagination<IEnumerable<CustomerDto>>> GetAllWithPaginationAsync(int pageNumber, int pageSize);

        #endregion
    }
}
