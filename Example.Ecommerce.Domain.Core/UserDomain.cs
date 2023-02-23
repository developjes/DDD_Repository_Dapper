using Example.Ecommerce.Domain.Entity;
using Example.Ecommerce.Domain.Interface;
using Example.Ecommerce.Infrastructure.Interface.UnitOfWork;

namespace Example.Ecommerce.Domain.Core
{
    public class UserDomain : IUserDomain
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserDomain(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public User Authenticate(string username, string password) =>
            _unitOfWork.User.Authenticate(username, password);
    }
}
