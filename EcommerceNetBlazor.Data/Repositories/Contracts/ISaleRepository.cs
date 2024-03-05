using EcommerceNetBlazor.Model;
using System.Collections.Generic;

namespace EcommerceNetBlazor.Data.Repositories.Contracts
{
    public interface ISaleRepository : IGenericRepository<Sale>
    {
        Task<Sale> Register(Sale entity);
    }
}
