using Example.Ecommerce.Infrastructure.Interface.Repository;
using System;

namespace Example.Ecommerce.Infrastructure.Interface.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customer { get; }
        IUserRepository User { get; }
        ICategoryRepository Category { get; }
    }
}
