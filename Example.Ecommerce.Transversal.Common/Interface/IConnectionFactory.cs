using System.Data;

namespace Example.Ecommerce.Transversal.Common.Interface
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}