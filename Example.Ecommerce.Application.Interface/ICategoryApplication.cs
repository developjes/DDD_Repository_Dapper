using Example.Ecommerce.Application.DTO;
using Example.Ecommerce.Transversal.Common.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.Ecommerce.Application.Interface
{
    public interface ICategoryApplication
    {
        Task<Response<IEnumerable<CategoryDto>>> GetAllAsync();
    }
}
