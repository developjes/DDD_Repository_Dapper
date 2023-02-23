using Example.Ecommerce.Domain.Entity;

namespace Example.Ecommerce.Domain.Interface
{
    public interface IUserDomain
    {
        User Authenticate(string username, string password);
    }
}
