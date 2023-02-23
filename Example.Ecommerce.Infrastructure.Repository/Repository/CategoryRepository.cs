using Dapper;
using Example.Ecommerce.Domain.Entity;
using Example.Ecommerce.Infrastructure.Data;
using Example.Ecommerce.Infrastructure.Interface.Repository;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Example.Ecommerce.Infrastructure.Repository.Repository
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly DapperContext _context;

        public CategoryRepository(DapperContext context) => _context = context;

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            using IDbConnection connection = _context.CreateConnection();
            const string sqlQuery = "SELECT * FROM Categories";

            return await connection.QueryAsync<Category>(sqlQuery, commandType: CommandType.StoredProcedure);
        }

        public int Count()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(string customerId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(string customerId)
        {
            throw new System.NotImplementedException();
        }

        public Category Get(string customerId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Category> GetAllWithPagination(int pageNumber, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<Category> GetAsync(string customerId)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(Category customer)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> InsertAsync(Category customer)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Category customer)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync(Category customer)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
