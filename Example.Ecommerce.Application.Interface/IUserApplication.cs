using Example.Ecommerce.Application.DTO;
using Example.Ecommerce.Transversal.Common.Generic;

namespace Example.Ecommerce.Application.Interface
{
    public interface IUserApplication
    {
        Response<UserDto> Authenticate(string username, string password);
    }
}
