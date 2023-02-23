using Example.Ecommerce.Domain.Entity;

namespace Example.Ecommerce.Infrastructure.Interface.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User Authenticate(string username, string password);
    }
}
