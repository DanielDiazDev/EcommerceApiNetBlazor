using EcommerceNetBlazor.Model;

namespace EcommerceNetBlazor.Data.Repositories.Contracts
{
    public interface IUnitOfWork
    {
        IGenericRepository<Category> CategoryRepository { get; }
        IGenericRepository<Product> ProductRepository { get; }
        ISaleRepository SaleRepository { get; }
        IUserRepository UserRepository { get; }
        Task<int> Save();
    }
}
