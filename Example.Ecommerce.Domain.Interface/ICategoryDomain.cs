using Example.Ecommerce.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.Ecommerce.Domain.Interface
{
    public interface ICategoryDomain
    {
        Task<IEnumerable<Category>> GetAllAsync();
    }
}
