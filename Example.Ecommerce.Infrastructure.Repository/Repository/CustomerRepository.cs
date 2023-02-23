using Dapper;
using Example.Ecommerce.Domain.Entity;
using Example.Ecommerce.Infrastructure.Data;
using Example.Ecommerce.Infrastructure.Interface.Repository;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Example.Ecommerce.Infrastructure.Repository.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DapperContext _context;
        public CustomerRepository(DapperContext context) => _context = context;

        public int Count()
        {
            using IDbConnection connection = _context.CreateConnection();
            const string query = "Select Count(*) from Customers";

            return connection.ExecuteScalar<int>(query, commandType: CommandType.Text);
        }

        public async Task<int> CountAsync()
        {
            using IDbConnection connection = _context.CreateConnection();
            const string query = "Select Count(*) from Customers";

            return await connection.ExecuteScalarAsync<int>(query, commandType: CommandType.Text);
        }

        public bool Delete(string customerId)
        {
            using IDbConnection connection = _context.CreateConnection();

            const string query = "CustomersDelete";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("CustomerID", customerId);

            int result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public async Task<bool> DeleteAsync(string customerId)
        {
            using IDbConnection connection = _context.CreateConnection();

            const string query = "CustomersDelete";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("CustomerID", customerId);

            int result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public Customer Get(string customerId)
        {
            using IDbConnection connection = _context.CreateConnection();
            const string query = "CustomersGetByID";

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("CustomerID", customerId);

            return connection.QuerySingle<Customer>(query, param: dynamicParameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<Customer> GetAll()
        {
            const string sqlProcedureQuery = "CustomersList";
            using IDbConnection connection = _context.CreateConnection();

            return connection.Query<Customer>(sqlProcedureQuery, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            const string sqlProcedureQuery = "CustomersList";
            using IDbConnection connection = _context.CreateConnection();

            return await connection.QueryAsync<Customer>(sqlProcedureQuery, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<Customer> GetAllWithPagination(int pageNumber, int pageSize)
        {
            using IDbConnection connection = _context.CreateConnection();
            const string query = "CustomersListWithPagination";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("PageNumber", pageNumber);
            parameters.Add("PageSize", pageSize);

            return connection.Query<Customer>(query, param: parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Customer>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            using IDbConnection connection = _context.CreateConnection();
            const string query = "CustomersListWithPagination";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("PageNumber", pageNumber);
            parameters.Add("PageSize", pageSize);

            return await connection.QueryAsync<Customer>(query, param: parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<Customer> GetAsync(string customerId)
        {
            using IDbConnection connection = _context.CreateConnection();
            const string sqlProcedureQuery = "CustomersGetByID";

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("CustomerID", customerId);

            return await connection.QuerySingleAsync<Customer>(sqlProcedureQuery, param: dynamicParameters, commandType: CommandType.StoredProcedure);
        }

        public bool Insert(Customer customer)
        {
            using IDbConnection connection = _context.CreateConnection();

            const string sqlProcedureQuery = "CustomerInsert";

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("CustomerID", customer.CustomerId);
            dynamicParameters.Add("CompanyName", customer.CompanyName);
            dynamicParameters.Add("ContactName", customer.ContactName);
            dynamicParameters.Add("ContactTitle", customer.ContactTitle);
            dynamicParameters.Add("Address", customer.Address);
            dynamicParameters.Add("City", customer.City);
            dynamicParameters.Add("Region", customer.Region);
            dynamicParameters.Add("PostalCode", customer.PostalCode);
            dynamicParameters.Add("Country", customer.Country);
            dynamicParameters.Add("Phone", customer.Phone);
            dynamicParameters.Add("Fax", customer.Fax);

            int result = connection.Execute(sqlProcedureQuery, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public async Task<bool> InsertAsync(Customer customer)
        {
            using IDbConnection connection = _context.CreateConnection();

            const string sqlProcedureQuery = "CustomerInsert";

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("CustomerID", customer.CustomerId);
            dynamicParameters.Add("CompanyName", customer.CompanyName);
            dynamicParameters.Add("ContactName", customer.ContactName);
            dynamicParameters.Add("ContactTitle", customer.ContactTitle);
            dynamicParameters.Add("Address", customer.Address);
            dynamicParameters.Add("City", customer.City);
            dynamicParameters.Add("Region", customer.Region);
            dynamicParameters.Add("PostalCode", customer.PostalCode);
            dynamicParameters.Add("Country", customer.Country);
            dynamicParameters.Add("Phone", customer.Phone);
            dynamicParameters.Add("Fax", customer.Fax);

            int result = await connection.ExecuteAsync(sqlProcedureQuery, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public bool Update(Customer customer)
        {
            using IDbConnection connection = _context.CreateConnection();

            const string sqlProcedureQuery = "CustomersUpdate";

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("CustomerID", customer.CustomerId);
            dynamicParameters.Add("CompanyName", customer.CompanyName);
            dynamicParameters.Add("ContactName", customer.ContactName);
            dynamicParameters.Add("ContactTitle", customer.ContactTitle);
            dynamicParameters.Add("Address", customer.Address);
            dynamicParameters.Add("City", customer.City);
            dynamicParameters.Add("Region", customer.Region);
            dynamicParameters.Add("PostalCode", customer.PostalCode);
            dynamicParameters.Add("Country", customer.Country);
            dynamicParameters.Add("Phone", customer.Phone);
            dynamicParameters.Add("Fax", customer.Fax);

            int result = connection.Execute(sqlProcedureQuery, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public async Task<bool> UpdateAsync(Customer customer)
        {
            using IDbConnection connection = _context.CreateConnection();

            const string sqlProcedureQuery = "CustomersUpdate";

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("CustomerID", customer.CustomerId);
            dynamicParameters.Add("CompanyName", customer.CompanyName);
            dynamicParameters.Add("ContactName", customer.ContactName);
            dynamicParameters.Add("ContactTitle", customer.ContactTitle);
            dynamicParameters.Add("Address", customer.Address);
            dynamicParameters.Add("City", customer.City);
            dynamicParameters.Add("Region", customer.Region);
            dynamicParameters.Add("PostalCode", customer.PostalCode);
            dynamicParameters.Add("Country", customer.Country);
            dynamicParameters.Add("Phone", customer.Phone);
            dynamicParameters.Add("Fax", customer.Fax);

            int result = await connection.ExecuteAsync(sqlProcedureQuery, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }
    }
}
