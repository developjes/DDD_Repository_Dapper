using Dapper;
using Example.Ecommerce.Domain.Entity;
using Example.Ecommerce.Infrastructure.Data;
using Example.Ecommerce.Infrastructure.Interface.Repository;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Example.Ecommerce.Infrastructure.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _context;

        public UserRepository(DapperContext context) => _context = context;

        public User Authenticate(string username, string password)
        {
            using var connection = _context.CreateConnection();

            const string query = "UsersGetByUserAndPassword";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("UserName", username);
            parameters.Add("Password", password);

            return connection.QuerySingle<User>(query, param: parameters, commandType: CommandType.StoredProcedure);
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

        public User Get(string customerId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetAllWithPagination(int pageNumber, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetAsync(string customerId)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(User customer)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> InsertAsync(User customer)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(User customer)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync(User customer)
        {
            throw new System.NotImplementedException();
        }
    }
}