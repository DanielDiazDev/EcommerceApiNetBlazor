using EcommerceNetBlazor.Data.Repositories.Contracts;
using EcommerceNetBlazor.Model;

namespace EcommerceNetBlazor.Data.Repositories.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepository<Category> CategoryRepository { get; }
        public IGenericRepository<Product> ProductRepository { get; }
        public IUserRepository UserRepository { get; }
        public ISaleRepository SaleRepository { get; }
        private readonly ApplicationDbContext _context;

        public UnitOfWork(IGenericRepository<Category> categoryRepository, IGenericRepository<Product> productRepository, IUserRepository userRepository, ISaleRepository saleRepository, ApplicationDbContext context)
        {
            CategoryRepository = categoryRepository;
            ProductRepository = productRepository;
            UserRepository = userRepository;
            SaleRepository = saleRepository;
            _context = context;
        }

        public async Task<int> Save()
            => await _context.SaveChangesAsync();

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
