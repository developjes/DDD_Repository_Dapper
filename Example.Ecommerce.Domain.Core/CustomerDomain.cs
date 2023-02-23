using Example.Ecommerce.Domain.Entity;
using Example.Ecommerce.Domain.Interface;
using Example.Ecommerce.Infrastructure.Interface.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.Ecommerce.Domain.Core
{
    public class CustomerDomain : ICustomerDomain
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerDomain(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public bool Delete(string customerId)
        {
            // Realizar logica de negocio
            return _unitOfWork.Customer.Delete(customerId);
        }

        public async Task<bool> DeleteAsync(string customerId)
        {
            return await _unitOfWork.Customer.DeleteAsync(customerId);
        }

        public Customer Get(string customerId)
        {
            return _unitOfWork.Customer.Get(customerId);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _unitOfWork.Customer.GetAll();
        }

        public async Task<IEnumerable<Customer>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            return await _unitOfWork.Customer.GetAllWithPaginationAsync(pageNumber, pageSize);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _unitOfWork.Customer.GetAllAsync();
        }

        public IEnumerable<Customer> GetAllWithPagination(int pageNumber, int pageSize)
        {
            return _unitOfWork.Customer.GetAllWithPagination(pageNumber, pageSize);
        }

        public async Task<Customer> GetAsync(string customerId)
        {
            return await _unitOfWork.Customer.GetAsync(customerId);
        }

        public bool Insert(Customer customer)
        {
            return _unitOfWork.Customer.Insert(customer);
        }

        public async Task<bool> InsertAsync(Customer customer)
        {
            return await _unitOfWork.Customer.InsertAsync(customer);
        }

        public bool Update(Customer customer)
        {
            return _unitOfWork.Customer.Update(customer);
        }

        public async Task<bool> UpdateAsync(Customer customer)
        {
            return await _unitOfWork.Customer.UpdateAsync(customer);
        }

        public int Count()
        {
            return _unitOfWork.Customer.Count();
        }

        public async Task<int> CountAsync()
        {
            return await _unitOfWork.Customer.CountAsync();
        }
    }
}
