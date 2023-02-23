using Example.Ecommerce.Infrastructure.Interface.Repository;
using Example.Ecommerce.Infrastructure.Interface.UnitOfWork;
using System;

namespace Example.Ecommerce.Infrastructure.Repository.UnitOfWork
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        #region Repositories

        public ICustomerRepository Customer { get; }
        public IUserRepository User { get; }
        public ICategoryRepository Category { get; }

        #endregion

        public UnitOfWork(ICustomerRepository customer, IUserRepository user, ICategoryRepository category) =>
            (Customer, User, Category) = (customer, user, category);

        #region Dispose

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}