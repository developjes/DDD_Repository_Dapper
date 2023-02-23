using Example.Ecommerce.Domain.Entity;
using Example.Ecommerce.Domain.Interface;
using Example.Ecommerce.Infrastructure.Interface.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.Ecommerce.Domain.Core
{
    public class CategoryDomain : ICategoryDomain
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryDomain(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _unitOfWork.Category.GetAllAsync();
        }
    }
}
