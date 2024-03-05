using EcommerceNetBlazor.Data.Repositories.Contracts;
using EcommerceNetBlazor.Model;

namespace EcommerceNetBlazor.Data.Repositories.Implementation
{
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        private readonly ApplicationDbContext _context;
        public SaleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Sale> Register(Sale entity)
        {
            Sale saleGenerated = new Sale();
            using(var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var sd in entity.SalesDetails)
                    {
                        Product productfound = _context.Products.Where(p => p.Id == sd.ProductId).First(); //Comprobar luego la version modificada
                        productfound.Quantity -= sd.Quantity;
                        _context.Products.Update(productfound);
                    }
                    await _context.SaveChangesAsync();
                    await _context.Sales.AddAsync(entity);
                    await _context.SaveChangesAsync();
                    saleGenerated = entity;
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
            return saleGenerated;
        }
    }
}
